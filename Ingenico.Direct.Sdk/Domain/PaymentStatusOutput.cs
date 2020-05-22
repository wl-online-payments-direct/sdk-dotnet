/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentStatusOutput
    {
        public IList<APIError> Errors { get; set; } = null;

        public bool? IsAuthorized { get; set; } = null;

        public bool? IsCancellable { get; set; } = null;

        public bool? IsRefundable { get; set; } = null;

        public string StatusCategory { get; set; } = null;

        public int? StatusCode { get; set; } = null;

        public string StatusCodeChangeDateTime { get; set; } = null;
    }
}
