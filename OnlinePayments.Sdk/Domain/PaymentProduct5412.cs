/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct5412
    {
        /// <summary>
        /// A URL intended for mobile devices that is to be linked to the QR code so that mobile users can tap it, to open the Chèque-Vacances app.
        /// </summary>
        public string AppUrl { get; set; }

        /// <summary>
        /// A URL that must be polled using JavaScript; it responds with one of the following:
        /// <list type="bullet">
        ///   <item><description>PRETRANSACTION, which indicates that the user has not yet consummed the QR code. At this step, the user can still be allowed to enter their beneficiary ID (or an e-mail known by ANCV) to initiate a CV Connect payment. As long as the response status is 'PRETRANSACTION', the input form should be shown and polling should continue.</description></item>
        ///   <item><description>TRANSACTION, which indicates that the buyer has used the QR code to open the Chèque-Vacances app, but has not yet confirmed the payment in the app. In this case, you should show a message asking the user to confirm the payment in their Chèque-Vacances app and continue polling. The user should no longer be allowed to enter their beneficiary ID. As long as the response status is not 'FINALIZED', the message should be shown and polling should continue.</description></item>
        ///   <item><description>FINALIZED, which indicates that the CV Connect process has concluded, but it does not necessarily confirm a successful payment. In this case, you should verify the payment outcome and redirect the customer to your status page accordingly.
        /// If polling ends after a few minutes without receiving the status 'FINALIZED', it means the transaction cannot yet be ended as accepted or refused. Once the status changes to 'FINALIZED', you should verify the payment outcome and redirect the customer to your status page accordingly. Remember, a 'FINALIZED' status indicates that the CV Connect process has concluded, but it does not necessarily confirm a successful payment. If you end the polling after a few minutes without receiving the status 'FINALIZED', it means the transaction cannot yet be ended as accepted or refused. NB — If you try to call the polling endpoint with invalid data, you will receive an HTTP 204.</description></item>
        /// </list>
        /// </summary>
        public string PollingUrl { get; set; }

        /// <summary>
        /// Contains a base64 encoded PNG image. By prepending data:image/png;base64, this value can be used as the source of an HTML inline image on a desktop or tablet (intended to be scanned by a device with the Chèque-Vacances app)
        /// </summary>
        public string QrCode { get; set; }
    }
}
