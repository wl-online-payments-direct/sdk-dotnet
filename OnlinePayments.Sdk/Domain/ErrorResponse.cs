/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class ErrorResponse
    {
        /// <summary>
        /// Unique reference, for debugging purposes, of this error response
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        /// List of one or more errors
        /// </summary>
        public IList<APIError> Errors { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ErrorResponse WithErrorId(string value)
        {
            ErrorId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ErrorResponse WithErrors(IList<APIError> value)
        {
            Errors = value;
            return this;
        }
    }
}
