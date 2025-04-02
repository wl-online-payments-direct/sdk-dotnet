using System;
using System.Configuration;

namespace OnlinePayments.Sdk
{
    internal class UriConfiguration : ConfigurationElement
    {
        public Uri Uri
        {
            get
            {
                if (string.IsNullOrEmpty(Host))
                {
                    return null;
                }
                var ub = new UriBuilder
                {
                    Host = Host,
                    Scheme = Scheme
                };
                if (Port > 0)
                {
                    ub.Port = Port;
                }
                return ub.Uri;
            }
        }

        [ConfigurationProperty("scheme", IsRequired = false, DefaultValue = "https")]
        public string Scheme => (string)this["scheme"];

        [ConfigurationProperty("host", IsRequired = true)]
        public string Host => (string)this["host"];

        [ConfigurationProperty("port", IsRequired = false)]
        public int Port => (int)this["port"];
    }
}
