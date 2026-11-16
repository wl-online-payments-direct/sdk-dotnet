# Webhooks

The platform sends an HTTP POST to your endpoint when a payment, refund, payment link, payout or token changes.
Webhooks are how you learn the result when the customer never returns to your site, and how you learn about changes
made later (captures, refunds, chargebacks).

## Set up

1. In the Merchant Portal, go to Developer > Webhooks. Generate the webhook key ID and secret, and enter your
   endpoint URL (HTTPS). The secret is displayed for 60 seconds only: store it at once. Generating a new pair
   revokes the existing one immediately.
2. Store the key ID and secret like the API secret: configuration or a secret store, never in code.
3. You can also send up to five endpoint URLs with each request in `feedbacks.webhooksUrls`;
   `feedbacks.webhookUrl` is deprecated.
4. Let the platform reach your endpoint: whitelist its IP range in your firewall (see the Firewall documentation on
   the documentation portal).
5. Create the SDK's webhooks helper once at startup with a secret key store that holds the key ID and secret.
6. Check the setup with the `ValidateWebhookCredentials` operation (your key and secret) and the `SendTestWebhook`
   operation (a test event, type `payment.test`; your endpoint must answer 2xx).

```csharp
// Create the helper once at startup. The key ID and secret come from the Merchant Portal
// (Developer > Webhooks) and are validated with the other settings (see OnlinePaymentsOptions).
// In production, implement ISecretKeyStore on top of your secret storage.
public static WebhooksHelper CreateHelper(OnlinePaymentsOptions options)
{
    // The in-memory store is shared by the whole process and StoreSecretKey throws when the key ID is
    // already stored, for example when the setup runs twice in tests. Remove the key first.
    InMemorySecretKeyStore.Instance.RemoveSecretKey(options.WebhookKeyId);
    InMemorySecretKeyStore.Instance.StoreSecretKey(options.WebhookKeyId, options.WebhookSecret);
    return new WebhooksHelper(DefaultMarshaller.Instance, InMemorySecretKeyStore.Instance);
}
```

## Receive

Mandatory rule 4: verify every webhook with the SDK's webhooks helper before processing the event.

1. Read the raw request body as bytes or an unchanged string. The signature is calculated over the exact body; a
   body that was parsed and serialised again fails verification.
2. Pass the body and all request headers to the helper. It checks the `X-GCS-Signature` and `X-GCS-KeyId` headers
   and returns the parsed event. A repeated `X-GCS-Signature` or `X-GCS-KeyId` must fail verification, so never pass
   only the first value of a header. How to pass a repeated header depends on the helper: see `dotnet.md`.
3. If verification fails, answer with an error status and do not process the event. Do not add a way to skip
   verification, such as a configuration flag or a check for the development environment. For local testing, use a
   test webhook key ID and secret from the Merchant Portal, or send a test event with SendTestWebhook; both go
   through normal verification.
4. Save the verified event before you answer: a database row or a persistent queue, ignoring duplicates (the
   webhooks guide identifies a duplicate by identical `payment.id` and `type`). Then answer with HTTP 2xx right away,
   as the guide recommends, and do the work in the background. Do nothing else before the answer.
5. If the event passed verification but the SDK cannot read it (API version mismatch, malformed body), the sender
   is the platform, so do not answer with an error status. Save the raw body, log it with an alert, and answer 2xx.
   A retry would send the same body and fail the same way; the saved body can be replayed after you upgrade the
   SDK. Only a failed verification gets an error status.

When the platform gets no 2xx answer in time, it sends the event again: after 10 minutes, 1 hour, 2 hours, 8 hours
and 24 hours. Each delivery has a `retry-count` header: 0 for the first attempt, higher for a retry. Log it; it
tells a new event from a retry. A 2xx tells the platform the event arrived, so do not count on another delivery after
you answered 2xx. An event that is only in memory when the process dies can be lost, and retrying failed background
work does not make the platform send it again. Keep your own retry for saved events that failed. The guide also
recommends a back-up mechanism, so run a reconciliation job: for every order that stays pending longer than a
customer normally needs to pay, read the status with `GetPaymentDetails` (see "Payment status" in `flows.md`) and
update the order.

```csharp
[HttpPost]
public async Task<IActionResult> Receive()
{
    // Use the raw body: the signature is calculated over the exact bytes that were sent.
    byte[] body;
    using (var buffer = new MemoryStream())
    {
        await Request.Body.CopyToAsync(buffer);
        body = buffer.ToArray();
    }

    // One header object per received value. Joining repeated values into one string would hide a
    // duplicate X-GCS-Signature or X-GCS-KeyId, which the helper rejects.
    List<IRequestHeader> headers = Request.Headers
        .SelectMany(header => header.Value.Select(value => (IRequestHeader)new RequestHeader(header.Key, value)))
        .ToList();

    WebhooksEvent webhooksEvent;
    try
    {
        // Checks the X-GCS-Signature and X-GCS-KeyId headers before parsing the event.
        webhooksEvent = _webhooksHelper.Unmarshal(body, headers);
    }
    catch (SignatureValidationException)
    {
        // Not sent by the platform, or the wrong secret is configured. Do not process it.
        return Unauthorized();
    }
    catch (Exception e) when (e is ApiVersionMismatchException || e is MarshallerSyntaxException)
    {
        // The signature is valid, so the platform sent this, but the SDK cannot read it. An error status
        // would only make the platform send the same body again. Keep the body, raise an alert, and
        // replay it after you upgrade the SDK.
        _inbox.SaveUnreadable(body);
        _logger.LogError(e, "A verified webhook could not be read; the raw body was saved");
        return Ok();
    }

    // Save first, then answer. Do not count on the platform sending the event again after a 2xx, so an
    // event that only lives in memory can be lost when the process dies.
    _inbox.SaveEvent(webhooksEvent);
    return Ok();
}
```

## Process

- **Duplicates are normal.** The same event can arrive more than once. Processing must be idempotent.
- **Order is not guaranteed.** A `payment.created` event can arrive after `payment.captured`.
- **Read the current status.** Treat the event as a signal: call `GetPaymentDetails` and update the order from its
  `statusOutput` (see "Payment status" in `flows.md`). This also makes duplicates and old events harmless. The
  `payment.id` of a payment changes when a maintenance operation (capture, refund, ...) is performed, and a hosted
  checkout session numbers its authorization attempts (`<id>_0`, `<id>_1`, ...). The platform strongly recommends not
  building your business operations around the ID. `GetPaymentDetails` with the ID of an earlier authorization
  attempt returns the payment's current state, with all operations in `operations` and the latest one as `id`, so
  reading the status by ID gives the current state even for an event about an older operation. Status changes made
  by the platform send webhooks too, without changing the `payment.id`.
- **Do not log the event or the request body.** The event's `payment` contains card details and customer data (see
  the logging rules in `errors.md`). Log the event `id`, `type` and the payment ID.
- **Find your order** with `payment.paymentOutput.references.merchantReference`, which holds the order reference you
  sent. The payment ID changes when you perform a maintenance operation such as a capture or refund, so do not use it as
  your only key.
- **Do not use webhooks for decisions during checkout.** While the customer waits, use `GetHostedCheckout` or
  `GetPaymentDetails`.

```csharp
// Runs in the background for every saved event. Events can arrive twice and out of order, so read the
// current status instead of trusting the event; repeating this is harmless. If it fails, retry it from
// your inbox: do not count on the platform sending the event again.
public async Task Process(WebhooksEvent webhooksEvent)
{
    if (webhooksEvent.Payment == null)
    {
        // Refund, payment link, payout and token events carry other objects, e.g. webhooksEvent.Refund.
        return;
    }

    string orderId = webhooksEvent.Payment.PaymentOutput?.References?.MerchantReference;
    if (orderId == null)
    {
        return;
    }

    PaymentDetailsResponse details = await _merchantClient.Payments.GetPaymentDetails(webhooksEvent.Payment.Id);
    _orders.SavePaymentId(orderId, details.Id);
    _orders.SaveState(orderId, PaymentStatusExample.ToOrderState(details.Status, details.StatusOutput));
}
```

## Event types

| Object | Types |
|---|---|
| Payment | `payment.created`, `payment.redirected`, `payment.authorization_requested`, `payment.pending_approval`, `payment.pending_completion`, `payment.pending_capture`, `payment.capture_requested`, `payment.captured`, `payment.rejected`, `payment.rejected_capture`, `payment.cancelled`, `payment.refunded` |
| Refund | `refund.refund_requested` |
| Payment link | `paymentlink.created`, `paymentlink.clicked`, `paymentlink.paid`, `paymentlink.cancelled`, `paymentlink.expired`, `paymentlink.payment.rejected`, `paymentlink.payment.cancelled` |
| Test | `payment.test` (sent by the SendTestWebhook operation) |

The event's `type` field holds the type. The object that changed is in the matching field of the event (`payment`,
`refund`, `paymentLink`, `payout`, `token`).

Webhooks guide: https://docs.direct.worldline-solutions.com/en/integration/api-developer-guide/webhooks
