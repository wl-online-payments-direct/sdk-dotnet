using System.Collections.Generic;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// Represents a set of request parameters.
    /// </summary>
    public abstract class AbstractParamRequest
    {
        public abstract IEnumerable<RequestParam> ToRequestParameters();
    }
}
