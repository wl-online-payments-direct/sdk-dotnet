using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// Provides meta info about the server. Thread-safe.
    /// </summary>
    public class MetadataProvider : IMetadataProvider
    {
        public MetadataProvider(MetadataProviderBuilder builder)
            : this(builder.Integrator, builder.ShoppingCartExtension, builder.AdditionalRequestHeaders)
        {

        }

        public MetadataProvider(string integrator) : this(integrator, null, null)
        {

        }

        public static void ValidateAdditionalRequestHeader(RequestHeader additionalRequestHeader)
        {
            if (ProhibitedHeaders.Contains(additionalRequestHeader.Name))
            {
                throw new ArgumentException("request header not allowed: " + additionalRequestHeader);
            }
        }

        /// <inheritdoc cref="IMetadataProvider" />
        public IEnumerable<IRequestHeader> ServerMetadataHeaders { get; }

        public static readonly IEnumerable<string> ProhibitedHeaders
            = new ReadOnlyCollection<string>(new List<string>
        {
            ServerMetaInfoHeader,
            "X-GCS-Idempotence-Key",
            "Date",
            "Content-Type",
            "Authorization"
        });

        private MetadataProvider(string integrator, ShoppingCartExtension shoppingCartExtension, IEnumerable<RequestHeader> additionalRequestHeaders)
        {
            if (integrator.IsBlank())
            {
                throw new ArgumentException("integrator is required");
            }
            ValidateAdditionalRequestHeaders(additionalRequestHeaders);

            var serverMetaInfo = new ServerMetaInfo
            {
                PlatformIdentifier = PlatformIdentifier,
                SdkIdentifier = SdkIdentifier,
                SdkCreator = "OnlinePayments",
                Integrator = integrator,
                ShoppingCartExtension = shoppingCartExtension
            };

            var serverMetaInfoString = DefaultMarshaller.Instance.Marshal(serverMetaInfo);
            var serverMetaInfoHeader = new RequestHeader(ServerMetaInfoHeader, serverMetaInfoString.ToBase64String());

            ServerMetadataHeaders = new List<RequestHeader> { serverMetaInfoHeader }
                .Concat(additionalRequestHeaders ?? Enumerable.Empty<RequestHeader>());
        }

        internal class ServerMetaInfo
        {
            public string PlatformIdentifier { get; set; }

            public string SdkIdentifier { get; set; }

            public string SdkCreator { get; set; }

            public string Integrator { get; set; }

            public ShoppingCartExtension ShoppingCartExtension { get; set; }
        }

        internal string SdkIdentifier => "DotnetServerSDK/v" + SdkVersion;

        internal string PlatformIdentifier => new StringBuilder()
            .Append(Environment.OSVersion.Platform)
            .Append("/")
            .Append(Environment.OSVersion.Version)
            .Append(" .NET/")
            .Append(Environment.Version)
            .ToString();

        private const string SdkVersion = "4.0.0";

        private const string ServerMetaInfoHeader = "X-GCS-ServerMetaInfo";

        internal static void ValidateAdditionalRequestHeaders(IEnumerable<RequestHeader> additionalRequestHeaders)
        {
            if (additionalRequestHeaders != null)
            {
                foreach (var additionalRequestHeader in additionalRequestHeaders)
                {
                    ValidateAdditionalRequestHeader(additionalRequestHeader);
                }
            }
        }
    }
}
