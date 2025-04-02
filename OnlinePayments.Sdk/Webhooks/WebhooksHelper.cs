using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Webhooks
{
    /// <summary>
    /// Online Payments platform webhooks helper. Thread-safe.
    /// </summary>
    public class WebhooksHelper
    {
        private readonly IMarshaller _marshaller;
        private readonly SignatureValidator _signatureValidator;

        public WebhooksHelper(IMarshaller marshaller, ISecretKeyStore secretKeyStore)
        {
            _marshaller = marshaller ?? throw new ArgumentException("marshaller is required");
            _signatureValidator = new SignatureValidator(secretKeyStore);
        }

        /// <summary>
        /// Unmarshals the given body, while also validating it using the given request headers.
        /// </summary>
        /// <exception cref="SignatureValidationException">If the body could not be validated successfully.</exception>
        /// <exception cref="ApiVersionMismatchException"> If the resulting event has an API version that this version of the SDK does not support.</exception>
        public WebhooksEvent Unmarshal(string body, IEnumerable<IRequestHeader> requestHeaders)
        {
            _signatureValidator.Validate(body, requestHeaders);

            var unmarshalledEvent = _marshaller.Unmarshal<WebhooksEvent>(body);
            ValidateApiVersion(unmarshalledEvent);
            return unmarshalledEvent;
        }

        /// <summary>
        /// Unmarshals the given body, while also validating it using the given request headers.
        /// </summary>
        /// <exception cref="SignatureValidationException">If the body could not be validated successfully.</exception>
        /// <exception cref="ApiVersionMismatchException"> If the resulting event has an API version that this version of the SDK does not support.</exception>
        public WebhooksEvent Unmarshal(byte[] body, IEnumerable<IRequestHeader> requestHeaders)
        {
            _signatureValidator.Validate(body, requestHeaders);

            var unmarshalledEvent = _marshaller.Unmarshal<WebhooksEvent>(StringUtils.Encoding.GetString(body));
            ValidateApiVersion(unmarshalledEvent);
            return unmarshalledEvent;
        }

        private static void ValidateApiVersion(WebhooksEvent unmarshalledEvent)
        {
            if (!"v1".Equals(unmarshalledEvent.ApiVersion))
            {
                throw new ApiVersionMismatchException(unmarshalledEvent.ApiVersion, "v1");
            }
        }
    }
}
