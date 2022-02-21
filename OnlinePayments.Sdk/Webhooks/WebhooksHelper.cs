using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace OnlinePayments.Sdk.Webhooks
{
    /// <summary>
    /// Payment platform webhooks helper. Thread-safe.
    /// </summary>
    public class WebhooksHelper
    {
        private readonly IMarshaller _marshaller;
        private readonly ISecretKeyStore _secretKeyStore;

        static bool SignaturePredicate(IRequestHeader h) => h.Name.Equals("X-GCS-Signature", StringComparison.InvariantCultureIgnoreCase);
        static bool KeyIdPredicate(IRequestHeader h) => h.Name.Equals("X-GCS-KeyId", StringComparison.InvariantCultureIgnoreCase);

        public WebhooksHelper(IMarshaller marshaller, ISecretKeyStore secretKeyStore)
        {
            _marshaller = marshaller ?? throw new ArgumentNullException("marshaller is required");
            _secretKeyStore = secretKeyStore ?? throw new ArgumentNullException("secretKeyStore is required");
        }

        /// <summary>
        /// Unmarshals the given body, while also validating it using the given request headers.
        /// </summary>
        /// <exception cref="SignatureValidationException">If the body could not be validated successfully.</exception>
        /// <exception cref="ApiVersionMismatchException"> If the resulting event has an API version that this version of the SDK does not support.</exception>
        public WebhooksEvent Unmarshal(string body, IEnumerable<IRequestHeader> requestHeaders)
        {
            Validate(body, requestHeaders);
            WebhooksEvent unmarshalledEvent = _marshaller.Unmarshal<WebhooksEvent>(body);
            ValidateApiVersion(unmarshalledEvent);
            return unmarshalledEvent;
        }

        /// <summary>
        /// Validates the given body using the given request headers.
        /// </summary>
        /// <exception cref="SignatureValidationException"> If the body could not be validated sucessfully</exception>
        /// <exception cref="ApiVersionMismatchException"> If the resulting event has an API version that this version of the SDK does not support.</exception>
        protected void Validate(string body, IEnumerable<IRequestHeader> requestHeaders)
        {
            Validate(StringUtils.Encoding.GetBytes(body), requestHeaders);
        }

        /// <summary>
        /// Unmarshals the given body, while also validating it using the given request headers.
        /// </summary>
        /// <exception cref="SignatureValidationException">If the body could not be validated successfully.</exception>
        /// <exception cref="ApiVersionMismatchException"> If the resulting event has an API version that this version of the SDK does not support.</exception>
        public WebhooksEvent Unmarshal(byte[] body, IEnumerable<IRequestHeader> requestHeaders)
        {
            Validate(body, requestHeaders);
            WebhooksEvent unmarshalledEvent = _marshaller.Unmarshal<WebhooksEvent>(StringUtils.Encoding.GetString(body));
            ValidateApiVersion(unmarshalledEvent);
            return unmarshalledEvent;
        }

        /// <summary>
        /// Validates the given body using the given request headers.
        /// </summary>
        /// <exception cref="SignatureValidationException"> If the body could not be validated sucessfully</exception>
        /// <exception cref="ApiVersionMismatchException"> If the resulting event has an API version that this version of the SDK does not support.</exception>
        protected void Validate(byte[] body, IEnumerable<IRequestHeader> requestHeaders)
        {
            ValidateBody(body, requestHeaders);
        }

        private void ValidateBody(byte[] body, IEnumerable<IRequestHeader> requestHeaders)
        {
            string signature = ExtractHeaderValue(requestHeaders, "X-GCS-Signature");
            string keyId = ExtractHeaderValue(requestHeaders, "X-GCS-KeyId");

            using (var mac = new HMACSHA256(StringUtils.Encoding.GetBytes(_secretKeyStore.GetSecretKey(keyId))))
            {
                mac.Initialize();
                byte[] unencodedResult = mac.ComputeHash(body);
                var expectedSignature = Convert.ToBase64String(unencodedResult);
                bool isValid = signature.CompareWithoutTimingLeak(expectedSignature);
                if (!isValid)
                {
                    throw new SignatureValidationException("failed to validate signature '" + signature + "'");
                }
            }
        }

        private static string ExtractHeaderValue(IEnumerable<IRequestHeader> requestHeaders, string headerName)
        {
            bool headerPredicate(IRequestHeader h) => h.Name.Equals(headerName, StringComparison.InvariantCultureIgnoreCase);
            var headerCount = requestHeaders.Count(headerPredicate);
            if (headerCount == 0)
            {
                throw new SignatureValidationException($"Missing ${headerName} header");
            }
            if (headerCount != 1)
            {
                throw new SignatureValidationException($"Duplicate ${headerName} header");
            }
            return requestHeaders.SingleOrDefault(headerPredicate)?.Value;
        }

        private void ValidateApiVersion(WebhooksEvent unmarshalledEvent)
        {
            if (!"v1".Equals(unmarshalledEvent.ApiVersion))
            {
                throw new ApiVersionMismatchException(unmarshalledEvent.ApiVersion, "v1");
            }
        }
    }
}
