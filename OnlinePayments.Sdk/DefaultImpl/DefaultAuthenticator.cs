using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlinePayments.Sdk.DefaultImpl
{
    /// <summary>
    /// Default <see cref="IAuthenticator"/> implementation.
    /// </summary>
    public class DefaultAuthenticator : IAuthenticator
    {
        private const String HeaderValuePattern = "\r?\n[\\s-[\r\n]]*";

        private readonly string _apiKeyId;
        private readonly string _secretApiKey;
        private readonly AuthorizationType _authorizationType;

        /// <param name="apiKeyId">An identifier for the secret API key. The apiKeyId can be retrieved from the Back Office.
        ///        This identifier is visible in the HTTP request and is also used to identify the correct account.</param>
        /// <param name="secretApiKey">A shared secret. The shared secret can be retrieved from the Back Office.
        ///        An apiKeyId and secretApiKey always go hand-in-hand, the difference is that secretApiKey is never visible in the HTTP request.
        ///        This secret is used as input for the HMAC algorithm.</param>
        public DefaultAuthenticator(string apiKeyId, string secretApiKey)
            : this(AuthorizationType.V1HMAC, apiKeyId, secretApiKey)
        {
        }

        /// <param name="authType">Based on this value both the payment platform and the merchant know which security implementation is used.
        ///        A version number is used for backward compatibility in the future.</param>
        /// <param name="apiKeyId">An identifier for the secret API key. The apiKeyId can be retrieved from the Configuration Center.
        ///        This identifier is visible in the HTTP request and is also used to identify the correct account.</param>
        /// <param name="secretApiKey">A shared secret. The shared secret can be retrieved from the Configuration Center.
        ///        An apiKeyId and secretApiKey always go hand-in-hand, the difference is that secretApiKey is never visible in the HTTP request.
        ///        This secret is used as input for the HMAC algorithm.</param>
        public DefaultAuthenticator(AuthorizationType authType, string apiKeyId, string secretApiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKeyId))
            {
                throw new ArgumentException("apiKeyId is required");
            }
            if (string.IsNullOrWhiteSpace(secretApiKey))
            {
                throw new ArgumentException("secretApiKey is required");
            }
            _authorizationType = authType ?? throw new ArgumentException("authorizationType is required");
            _apiKeyId = apiKeyId;
            _secretApiKey = secretApiKey;
        }

        #region IAuthenticator Implementation
        public string CreateSimpleAuthenticationSignature(HttpMethod httpMethod, Uri resourceUri, IEnumerable<IRequestHeader> requestHeaders)
        {
            if (httpMethod == null)
            {
                throw new ArgumentException("httpMethod is required");
            }
            if (resourceUri == null)
            {
                throw new ArgumentException("resourceUri is required");
            }
            var dataToSign = ToDataToSign(httpMethod, resourceUri, requestHeaders);
            return "GCS " + _authorizationType.SignatureString + ":" + _apiKeyId + ":" + SignData(dataToSign);
        }
        #endregion

        internal string ToDataToSign(HttpMethod httpMethod, Uri resourceUri, IEnumerable<IRequestHeader> requestHeaders)
        {
            var xgcsHttpHeaders = new List<IRequestHeader>();
            string contentType = "";
            string date = "";
            if (requestHeaders != null)
            {
                foreach (IRequestHeader header in requestHeaders)
                {
                    if ("content-type".Equals(header.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        contentType = header.Value;
                    }
                    else if ("date".Equals(header.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        date = header.Value;
                    }
                    else if (header.Name.StartsWith("x-gcs", StringComparison.OrdinalIgnoreCase))
                    {
                        xgcsHttpHeaders.Add(new RequestHeader(header.Name.ToLower(), ToCanonicalizeHeaderValue(header.Value)));
                    }
                }
            }
            xgcsHttpHeaders.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
            var sb = new StringBuilder()
                .AppendLLine(httpMethod.Method.ToUpperInvariant())
                .AppendLLine(contentType ?? "")
                .AppendLLine(date);
            foreach (var a in xgcsHttpHeaders.Select((arg) => arg.Name + ":" + arg.Value))
            {
                sb.AppendLLine(a);
            }
            return sb.AppendLLine(CanonicalizedResource(resourceUri))
                .ToString();
        }

        internal string SignData(string theString)
        {
            var mac = new HMACSHA256(StringUtils.Encoding.GetBytes(_secretApiKey));
            mac.Initialize();
            byte[] unencodedResult = mac.ComputeHash(StringUtils.Encoding.GetBytes(theString));
            return Convert.ToBase64String(unencodedResult);
        }

        internal string ToCanonicalizeHeaderValue(string originalValue)
        {
            return new Regex(HeaderValuePattern, RegexOptions.Multiline | RegexOptions.CultureInvariant).Replace(originalValue, " ").Trim();
        }

        string CanonicalizedResource(Uri uri)
        {
            var sb = new StringBuilder()
                .Append(Uri.EscapeUriString(uri.LocalPath));
            if (!string.IsNullOrEmpty(uri.Query))
            {
                sb.Append(Uri.UnescapeDataString(uri.Query));
            }
            return sb.ToString();
        }
    }
}
