using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OnlinePayments.Sdk.DefaultImpl;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Provides meta info about the server. Thread-safe.
    /// </summary>
    public class MetaDataProvider
    {
        public static readonly IEnumerable<string> ProhibitedHeaders = new ReadOnlyCollection<string>(new List<string>
        {
            SERVER_META_INFO_HEADER,
            "X-GCS-Idempotence-Key",
            "Date",
            "Content-Type",
            "Authorization"
        });

        private const string SERVER_META_INFO_HEADER = "X-GCS-ServerMetaInfo";
        private const string SDK_VERSION = "3.27.1";
        internal string SdkIdentifier => "OnlinePaymentsDotnetServerSDK/v" + SDK_VERSION;

        private static readonly string _platformIdentifier = Environment.OSVersion.Platform + "/" + Environment.OSVersion.Version + " .NET/" + Environment.Version;
        internal String PlatformIdentifier => _platformIdentifier;

        public MetaDataProvider(MetaDataProviderBuilder builder)
            : this(builder.Integrator, builder.ShoppingCartExtension, builder.AdditionalRequestHeaders)
        {

        }

        public MetaDataProvider(string integrator) : this(integrator, null, null)
        {

        }

        MetaDataProvider(string integrator, ShoppingCartExtension shoppingCartExtension, IEnumerable<RequestHeader> additionalRequestHeaders)
        {
            ValidateAdditionalRequestHeaders(additionalRequestHeaders);

            ServerMetaInfo serverMetaInfo = new ServerMetaInfo()
            {
                PlatformIdentifier = _platformIdentifier,
                SdkIdentifier = SdkIdentifier,
                SdkCreator = "OnlinePayments",
                Integrator = integrator,
                ShoppingCartExtension = shoppingCartExtension
            };

            string serverMetaInfoString = DefaultMarshaller.Instance.Marshal(serverMetaInfo);
            RequestHeader serverMetaInfoHeader = new RequestHeader(SERVER_META_INFO_HEADER, serverMetaInfoString.ToBase64String());

            ServerMetaDataHeaders = new List<RequestHeader> { serverMetaInfoHeader }
                .Concat(additionalRequestHeaders ?? Enumerable.Empty<RequestHeader>()); ;
        }

        // Only for unit testing, will result in an invalid object
        protected MetaDataProvider()
        {

        }

        /// <summary>
        /// Gets the server related headers containing the metadata to be associated with the request (if any).
        /// This will always contain at least an automatically generated header <c>X-GCS-ServerMetaInfo</c>.
        /// </summary>
        public IEnumerable<RequestHeader> ServerMetaDataHeaders { get; }

        internal static void ValidateAdditionalRequestHeaders(IEnumerable<RequestHeader> additionalRequestHeaders)
        {
            if (additionalRequestHeaders != null)
            {
                foreach (RequestHeader additionalRequestHeader in additionalRequestHeaders)
                {
                    ValidateAdditionalRequestHeader(additionalRequestHeader);
                }
            }
        }

        public static void ValidateAdditionalRequestHeader(RequestHeader additionalRequestHeader)
        {
            if (ProhibitedHeaders.Contains(additionalRequestHeader.Name))
            {
                throw new ArgumentException("request header not allowed: " + additionalRequestHeader);
            }
        }

        internal class ServerMetaInfo
        {
            public string PlatformIdentifier { get; set; }

            public string SdkIdentifier { get; set; }

            public string SdkCreator { get; set; }

            public string Integrator { get; set; }

            public ShoppingCartExtension ShoppingCartExtension { get; set; }
        }
    }
}
