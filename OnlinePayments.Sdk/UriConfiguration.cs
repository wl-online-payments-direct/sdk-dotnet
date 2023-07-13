using System;
using System.Configuration;

namespace OnlinePayments.Sdk
{
    class UriConfiguration : ConfigurationElement
    {
        private Uri _uri;
        private string _scheme;
        private string _host;
        private int _port;

        public Uri Uri
        {
            get
            {
                if (_uri != null)
                {
                    return _uri;
                }
                if (string.IsNullOrEmpty(Host))
                {
                    // Element not set
                    return null;
                }
                var ub = new UriBuilder
                {
                    Host = Host
                };
                if (string.IsNullOrEmpty(Scheme))
                {
                    ub.Scheme = "https";
                }
                else
                {
                    ub.Scheme = Scheme;
                }
                if (Port > 0)
                {
                    ub.Port = Port;
                }
                return ub.Uri;
            }
            set
            {
                if (value != null && value.HasPath())
                {
                    throw new ArgumentException("apiEndpoint should not contain a path");
                }
                if (value != null && value.HasUserInfoOrQueryOrFragment())
                {
                    throw new ArgumentException("apiEndpoint should not contain user info, query or fragment");
                }
                _uri = value;
                if (value != null)
                {
                    Scheme = value.Scheme;
                    Port = value.Port;
                    Host = value.Host;
                }
            }
        }

        [ConfigurationProperty("scheme", IsRequired = false)]
        public string Scheme
        {
            get
            {
                return _scheme ?? (string)this["scheme"];
            }
            set
            {
                if (IsReadOnly())
                {
                    _scheme = value;
                    return;
                }
                this["scheme"] = value;
            }
        }

        [ConfigurationProperty("host", IsRequired = true)]
        public string Host
        {
            get
            {
                return _host ?? (string)this["host"];
            }
            set
            {
                if (IsReadOnly())
                {
                    _host = value;
                    return;
                }
                this["host"] = value;
            }
        }

        [ConfigurationProperty("port", IsRequired = false)]
        public int Port
        {
            get
            {
                return _port == 0
                    ? (int)this["port"]
                    : _port;
            }
            set
            {
                if (IsReadOnly())
                {
                    _port = value;
                    return;
                }
                this["port"] = value;
            }
        }

        public UriConfiguration WithScheme(string scheme)
        {
            Scheme = scheme;
            return this;
        }

        public UriConfiguration WithHost(string host)
        {
            Host = host;
            return this;
        }

        public UriConfiguration WithPort(int port)
        {
            Port = port;
            return this;
        }
    }
}
