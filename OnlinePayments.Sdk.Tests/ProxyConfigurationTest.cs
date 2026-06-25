using NUnit.Framework;
using System;

namespace OnlinePayments.Sdk;

[TestFixture]
public class ProxyConfigurationTest
{
    [TestFixture]
    public class WhenCreatingProxy
    {
        [Test]
        public void ShouldHaveNullUriByDefault()
        {
            Proxy proxy = new();

            Assert.That(proxy.Uri, Is.Null);
        }

        [Test]
        public void ShouldHaveNullUsernameByDefault()
        {
            Proxy proxy = new();

            Assert.That(proxy.Username, Is.Null);
        }

        [Test]
        public void ShouldHaveNullPasswordByDefault()
        {
            Proxy proxy = new();

            Assert.That(proxy.Password, Is.Null);
        }

        [Test]
        public void ShouldAllowSettingAllPropertiesIndependently()
        {
            Proxy proxy = new() {
                Uri = new Uri("http://proxy.example.com:3128"),
                Username = "user",
                Password = "pass"
            };

            Assert.That(proxy.Uri, Is.Not.Null);
            Assert.That(proxy.Username, Is.EqualTo("user"));
            Assert.That(proxy.Password, Is.EqualTo("pass"));
        }
    }

    [TestFixture]
    public class WhenSettingUri
    {
        [Test]
        public void ShouldReturnSchemeFromUri()
        {
            Proxy proxy = new() { Uri = new Uri("http://proxy.example.com:3128") };

            Assert.That(proxy.Uri.Scheme, Is.EqualTo("http"));
        }

        [Test]
        public void ShouldReturnHostFromUri()
        {
            Proxy proxy = new() { Uri = new Uri("http://proxy.example.com:3128") };

            Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.com"));
        }

        [Test]
        public void ShouldReturnPortFromUri()
        {
            Proxy proxy = new() { Uri = new Uri("http://proxy.example.com:3128") };

            Assert.That(proxy.Uri.Port, Is.EqualTo(3128));
        }

        [Test]
        public void ShouldAllowNullUri()
        {
            Proxy proxy = new() { Uri = new Uri("http://proxy.example.com:3128") };
            proxy.Uri = null;

            Assert.That(proxy.Uri, Is.Null);
        }
    }

    [TestFixture]
    public class WhenSettingCredentials
    {
        [Test]
        public void ShouldSetAndGetUsername()
        {
            Proxy proxy = new() { Username = "proxyuser" };

            Assert.That(proxy.Username, Is.EqualTo("proxyuser"));
        }

        [Test]
        public void ShouldSetAndGetPassword()
        {
            Proxy proxy = new() { Password = "proxypass" };

            Assert.That(proxy.Password, Is.EqualTo("proxypass"));
        }

        [Test]
        public void ShouldAllowNullCredentials()
        {
            Proxy proxy = new() { Username = "user", Password = "pass" };
            proxy.Username = null;
            proxy.Password = null;

            Assert.That(proxy.Username, Is.Null);
            Assert.That(proxy.Password, Is.Null);
        }

        [Test]
        public void ShouldSetBothCredentials()
        {
            Proxy proxy = new() { Username = "proxyuser", Password = "proxypass" };

            Assert.That(proxy.Username, Is.EqualTo("proxyuser"));
            Assert.That(proxy.Password, Is.EqualTo("proxypass"));
        }
    }

    [TestFixture]
    public class WhenConfiguredWithHttpProxy
    {
        [Test]
        public void ShouldHaveNullCredentialsWhenNotProvided()
        {
            Proxy proxy = new() { Uri = new Uri("http://proxy.example.com:3128") };

            Assert.That(proxy.Uri.Scheme, Is.EqualTo("http"));
            Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.com"));
            Assert.That(proxy.Uri.Port, Is.EqualTo(3128));
            Assert.That(proxy.Username, Is.Null);
            Assert.That(proxy.Password, Is.Null);
        }

        [Test]
        public void ShouldStoreAllFieldsCorrectlyWithCredentials()
        {
            Proxy proxy = new() {
                Uri = new Uri("http://proxy.example.com:3128"),
                Username = "proxyuser",
                Password = "proxypass"
            };

            Assert.That(proxy.Uri.Scheme, Is.EqualTo("http"));
            Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.com"));
            Assert.That(proxy.Uri.Port, Is.EqualTo(3128));
            Assert.That(proxy.Username, Is.EqualTo("proxyuser"));
            Assert.That(proxy.Password, Is.EqualTo("proxypass"));
        }

        [Test]
        public void ShouldReflectNewUriWhenReplaced()
        {
            Proxy proxy = new() { Uri = new Uri("http://proxy.example.com:3128") };
            proxy.Uri = new Uri("http://newproxy.example.com:8080");

            Assert.That(proxy.Uri.Host, Is.EqualTo("newproxy.example.com"));
            Assert.That(proxy.Uri.Port, Is.EqualTo(8080));
        }
    }

    [TestFixture]
    public class WhenConfiguredWithHttpsProxy
    {
        [Test]
        public void ShouldSupportHttpsSchemeWithStandardPort()
        {
            Proxy proxy = new() { Uri = new Uri("https://proxy.example.com:443") };

            Assert.That(proxy.Uri.Scheme, Is.EqualTo("https"));
            Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.com"));
            Assert.That(proxy.Uri.Port, Is.EqualTo(443));
        }

        [Test]
        public void ShouldSupportHttpsSchemeWithNonStandardPort()
        {
            Proxy proxy = new() { Uri = new Uri("https://proxy.example.com:8443") };

            Assert.That(proxy.Uri.Scheme, Is.EqualTo("https"));
            Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.com"));
            Assert.That(proxy.Uri.Port, Is.EqualTo(8443));
        }
    }
}
