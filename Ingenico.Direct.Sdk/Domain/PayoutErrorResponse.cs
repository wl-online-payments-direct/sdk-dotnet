/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class PayoutErrorResponse
    {
        public string ErrorId { get; set; } = null;

        /// <summary>
        /// Contains the set of errors<para />
        /// </summary>
        public IList<APIError> Errors { get; set; } = null;

        public PayoutResult PayoutResult { get; set; } = null;
    }
}
