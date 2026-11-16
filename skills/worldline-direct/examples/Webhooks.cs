using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Json;
using OnlinePayments.Sdk.Merchant;
using OnlinePayments.Sdk.Webhooks;

namespace Examples
{
    /// <summary>
    /// Stand-in for your durable inbox: a database table or a persistent queue. A background job reads the
    /// saved events and calls <see cref="WebhookEventProcessor.Process"/>.
    /// </summary>
    public interface IWebhookInbox
    {
        /// <summary>Saves a verified event and returns when it is durable. Ignores a duplicate: the platform can send the same event more than once, and the webhooks guide identifies a duplicate by identical payment.id and type.</summary>
        void SaveEvent(WebhooksEvent webhooksEvent);

        /// <summary>Saves the raw body of a verified event that the SDK could not read.</summary>
        void SaveUnreadable(byte[] body);
    }

    public static class WebhooksSetup
    {
        // [START webhooks-setup]
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
        // [END webhooks-setup]
    }

    [ApiController]
    [Route("webhooks/payments")]
    public class WebhooksController : ControllerBase
    {
        private readonly WebhooksHelper _webhooksHelper;
        private readonly IWebhookInbox _inbox;
        private readonly ILogger<WebhooksController> _logger;

        public WebhooksController(WebhooksHelper webhooksHelper, IWebhookInbox inbox, ILogger<WebhooksController> logger)
        {
            _webhooksHelper = webhooksHelper;
            _inbox = inbox;
            _logger = logger;
        }

        // [START webhooks-receive]
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
        // [END webhooks-receive]
    }

    public class WebhookEventProcessor
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;

        public WebhookEventProcessor(IMerchantClient merchantClient, IOrderStore orders)
        {
            _merchantClient = merchantClient;
            _orders = orders;
        }

        // [START webhooks-process]
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
        // [END webhooks-process]
    }
}
