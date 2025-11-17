/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PendingAuthentication
    {
        /// <summary>
        /// A URL that must be polled using JavaScript; it responds with either true or false to say if transaction is still pending or not. As long as the response status is 'true', the message should be shown and polling should continue. Once the status changes to 'false', you should verify the payment outcome and redirect the customer to your status page accordingly. Remember, a pending status 'false' indicates that the CV Connect process has concluded, but it does not necessarily confirm a successful payment. And if you end the polling after a few minutes without receiving the status 'false', it means that the transaction can't be ended as accepted or refused yet. NB - If you try to call the polling endpoint with invalid data, you will receive an http 204.
        /// </summary>
        public string PollingUrl { get; set; }
    }
}
