using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Common;
using OnlinePayments.Sdk.Merchant;
using OnlinePayments.Sdk.It.Builders.Mandates;
using OnlinePayments.Sdk.It.Builders.MerchantBatch;
using OnlinePayments.Sdk.It.Builders.PaymentLinks;
using OnlinePayments.Sdk.It.Builders.Payouts;

namespace OnlinePayments.Sdk.It.Helpers;

public class SdkTestHelper(IMerchantClient merchantClient)
{

    #region Payments

    private async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request)
    {
        return await merchantClient
            .Payments
            .CreatePayment(request)
            .ConfigureAwait(false);
    }

    public async Task<string> CreatePaymentAndGetId()
    {
        CreatePaymentResponse response =
            await CreatePayment(new CreatePaymentRequestBuilder().Build()).ConfigureAwait(false);

        return response.Payment.Id;
    }

    public async Task<string> CreatePaymentAndGetId(long amount, string currencyCode)
    {
        CreatePaymentResponse response = await CreatePayment(new CreatePaymentRequestBuilder()
            .WithAmount(amount)
            .WithCurrencyCode(currencyCode)
            .Build())
            .ConfigureAwait(false);

        return response.Payment.Id;
    }

    public async Task<string> CreatePayPalPaymentAndGetId()
    {
        CreatePaymentResponse response = await CreatePayment(
            new CreatePaymentRequestBuilder()
                .WithPayPalRedirectPaymentMethod()
                .Build());

        return response.Payment.Id;
    }

    #endregion

    #region Tokens

    private async Task<CreatedTokenResponse> CreateToken(CreateTokenRequest request)
    {
        return await merchantClient
            .Tokens
            .CreateToken(request)
            .ConfigureAwait(false);
    }

    public async Task<string> CreateTokenAndGetId()
    {
        CreatedTokenResponse response = await CreateToken(new CreateTokenRequestBuilder().Build());

        return response.Token;
    }

    #endregion

    #region Hosted Tokenization

    private async Task<CreateHostedTokenizationResponse> CreateHostedTokenization(
        CreateHostedTokenizationRequest request)
    {
        return await merchantClient
            .HostedTokenization
            .CreateHostedTokenization(request)
            .ConfigureAwait(false);
    }

    public async Task<string> CreateHostedTokenizationAndGetId()
    {
        CreateHostedTokenizationResponse response = await CreateHostedTokenization(
            new Builders.HostedTokenization.CreateHostedTokenizationRequestBuilder().Build());

        return response.HostedTokenizationId;
    }

    #endregion

    #region Payment Links

    private async Task<PaymentLinkResponse> CreatePaymentLink(CreatePaymentLinkRequest request)
    {
        return await merchantClient
            .PaymentLinks
            .CreatePaymentLink(request)
            .ConfigureAwait(false);
    }

    public async Task<string> CreatePaymentLinkAndGetId()
    {
        PaymentLinkResponse response = await CreatePaymentLink(new CreatePaymentLinkRequestBuilder().Build());

        return response.PaymentLinkId;
    }

    #endregion

    #region Payouts

    private async Task<PayoutResponse> CreatePayout(CreatePayoutRequest request)
    {
        return await merchantClient
            .Payouts
            .CreatePayout(request)
            .ConfigureAwait(false);
    }

    public async Task<string> CreatePayoutAndGetId()
    {
        PayoutResponse response = await CreatePayout(new CreatePayoutRequestBuilder().Build());

        return response.Id;
    }

    #endregion

    #region Mandates

    private async Task<CreateMandateResponse> CreateMandate(CreateMandateRequest request)
    {
        return await merchantClient
            .Mandates
            .CreateMandate(request)
            .ConfigureAwait(false);
    }

    public async Task<string> CreateMandateAndGetReference()
    {
        CreateMandateRequest request = new CreateMandateRequestBuilder()
            .WithUniqueMandateReference("exampleMandateReference" + DateTime.Now.ToString("HH:mm:ss.fff"))
            .Build();
        CreateMandateResponse response = await CreateMandate(request).ConfigureAwait(false);

        return response.Mandate.UniqueMandateReference;
    }

    #endregion

    #region MerchantBatch

    private async Task<SubmitBatchResponse> SubmitBatch(SubmitBatchRequestBody request)
    {
        return await merchantClient
            .MerchantBatch
            .SubmitBatch(request)
            .ConfigureAwait(false);
    }

    public async Task<string> SubmitBatchAndGetReference(
        List<CreatePaymentRequest> requests,
        string operationType,
        int itemCount)
    {
        SubmitBatchResponse response =
            await SubmitBatch(new SubmitBatchRequestBodyBuilder().WithCreatePaymentRequests(requests)
                    .WithOperationType(operationType).WithItemCount(itemCount).Build())
            .ConfigureAwait(false);

        return response.MerchantBatchReference;
    }

    #endregion
}
