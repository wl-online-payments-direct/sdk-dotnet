using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Authentication
{
    /// <summary>
    /// HMAC <see cref="IAuthenticator"/> implementation.
    /// </summary>
    public class V1HmacAuthenticator : IAuthenticator
    {
        private const String HeaderValuePattern = "\r?\n[\\s-[\r\n]]*";

        private readonly string _apiKeyId;
        private readonly string _secretApiKey;
        private readonly AuthorizationType _authorizationType;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        /// <summary>
        /// Constructs a new V1Hmac authenticator.
        /// </summary>
        /// <param name="communicatorConfiguration">The configuration object containing the V1Hmac client id, client secret and token URI,
        ///                                         connect timeout, and socket timeout. None of these can be <c>null</c> or empty, and
        ///                                         the timeout values must be positive.</param>
        public V1HmacAuthenticator(CommunicatorConfiguration communicatorConfiguration)
            : this(AuthorizationType.V1HMAC, communicatorConfiguration.ApiKeyId, communicatorConfiguration.SecretApiKey)
        {
        }

        /// <param name="authType">Based on this value both the payment platform and the merchant know which security implementation is used.
        ///        A version number is used for backward compatibility in the future.</param>
        /// <param name="apiKeyId">An identifier for the secret API key. The apiKeyId can be retrieved from the Configuration Center.
        ///        This identifier is visible in the HTTP request and is also used to identify the correct account.</param>
        /// <param name="secretApiKey">A shared secret. The shared secret can be retrieved from the Configuration Center.
        ///        An apiKeyId and secretApiKey always go hand-in-hand, the difference is that secretApiKey is never visible in the HTTP request.
        ///        This secret is used as input for the HMAC algorithm.</param>
        public V1HmacAuthenticator(AuthorizationType authType, string apiKeyId, string secretApiKey)
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

        /// <inheritdoc cref="IAuthenticator"/>
        public async Task<string> GetAuthorization(HttpMethod httpMethod, Uri resourceUri, IEnumerable<IRequestHeader> requestHeaders)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
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
                return "GCS " + _authorizationType + ":" + _apiKeyId + ":" + SignData(dataToSign);
            }
            finally
            {
                _semaphore.Release();
            }
        }

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

            return sb.AppendLLine(CanonicalizedResource(resourceUri)).ToString();
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
