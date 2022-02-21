using OnlinePayments.Sdk.DefaultImpl;
using System;

namespace OnlinePayments.Sdk.Webhooks
{
    /// <summary>
    /// Payment platform factory for several webhooks components.
    /// </summary>
    public static class Webhooks
    {
        /// <summary>
        /// Creates a <see cref="WebhooksHelperBuilder"/> that will use the given <see cref="ISecretKeyStore"/>.
        /// </summary>
        public static WebhooksHelperBuilder CreateHelperBuilder(ISecretKeyStore secretKeyStore)
        {
            return new WebhooksHelperBuilder().WithMarshaller(DefaultMarshaller.Instance).WithSecretKeyStore(secretKeyStore);
        }

        /// <summary>
        /// Creates a <see cref="WebhooksHelper"/> that will use the given <see cref="ISecretKeyStore"/>.
        /// </summary>
        public static WebhooksHelper CreateHelper(ISecretKeyStore secretKeyStore)
        {
            WebhooksHelperBuilder webhooksHelperBuilder = CreateHelperBuilder(secretKeyStore);
            return webhooksHelperBuilder.Build();
        }
    }
}
