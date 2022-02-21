using System.Configuration;

namespace OnlinePayments.Sdk
{
    class ShoppingCartExtensionConfiguration : ConfigurationElement
    {
        ShoppingCartExtension _shoppingCartExtension;
        string _creator;
        string _name;
        string _version;
        string _extensionId;

        public ShoppingCartExtension ShoppingCartExtension
        {
            get
            {
                if (_shoppingCartExtension != null)
                {
                    return _shoppingCartExtension;
                }
                if (string.IsNullOrEmpty(Creator)
                    && string.IsNullOrEmpty(Name)
                    && string.IsNullOrEmpty(Version)
                    && string.IsNullOrEmpty(ExtensionId))
                {
                    return null;
                }
                if (string.IsNullOrEmpty(ExtensionId))
                {
                    return new ShoppingCartExtension(Creator, Name, Version);
                }
                return new ShoppingCartExtension(Creator, Name, Version, ExtensionId);
            }
            set
            {
                _shoppingCartExtension = value;
                Creator = value.Creator;
                Name = value.Name;
                Version = value.Version;
            }
        }

        [ConfigurationProperty("creator", IsRequired = true)]
        public string Creator
        {
            get
            {
                return _creator ?? (string)this["creator"];
            }
            set
            {
                if (IsReadOnly())
                {
                    _creator = value;
                    return;
                }
                this["creator"] = value;
            }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return _name ?? (string)this["name"];
            }
            set
            {
                if (IsReadOnly())
                {
                    _name = value;
                    return;
                }
                this["name"] = value;
            }
        }

        [ConfigurationProperty("version", IsRequired = true)]
        public string Version
        {
            get
            {
                return _version ?? (string)this["version"];
            }
            set
            {
                if (IsReadOnly())
                {
                    _version = value;
                    return;
                }
                this["version"] = value;
            }
        }

        [ConfigurationProperty("extensionId", IsRequired = false)]
        public string ExtensionId
        {
            get
            {
                return _extensionId ?? (string)this["extensionId"];
            }
            set
            {
                if (IsReadOnly())
                {
                    _extensionId = value;
                    return;
                }
                this["extensionId"] = value;
            }
        }
    }
}
