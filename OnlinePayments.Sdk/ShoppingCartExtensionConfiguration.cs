using System.Configuration;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    internal class ShoppingCartExtensionConfiguration : ConfigurationElement
    {
        public ShoppingCartExtension ShoppingCartExtension
        {
            get
            {
                if (string.IsNullOrEmpty(Creator)
                    && string.IsNullOrEmpty(Name)
                    && string.IsNullOrEmpty(Version)
                    && string.IsNullOrEmpty(ExtensionId))
                {
                    return null;
                }
                return string.IsNullOrEmpty(ExtensionId) ? new ShoppingCartExtension(Creator, Name, Version) : new ShoppingCartExtension(Creator, Name, Version, ExtensionId);
            }
        }

        [ConfigurationProperty("creator", IsRequired = true)]
        public string Creator => (string)this["creator"];

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string)this["name"];

        [ConfigurationProperty("version", IsRequired = true)]
        public string Version => (string)this["version"];

        [ConfigurationProperty("extensionId", IsRequired = false)]
        public string ExtensionId => (string)this["extensionId"];
    }
}
