using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Json;
using static System.Linq.Enumerable;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class MetadataProviderTest
{
    [TestCase]
    public void ServerMetadataHeaders_WithNoAdditionalHeaders_ReturnsOnlyServerMetaInfoHeader()
    {
        var metadataProvider = new MetadataProvider("OnlinePayments");

        var requestHeaders = metadataProvider.ServerMetadataHeaders.ToList();

        Assert.That(requestHeaders.Count, Is.EqualTo(1));

        var requestHeader = requestHeaders[0];

        AssertServerMetaInfo(metadataProvider, requestHeader);
    }

    [TestCase]
    public void ServerMetadataHeaders_WithAdditionalHeaders_ReturnsServerMetaInfoAndAdditionalHeaders()
    {
        var additionalHeaders = new List<RequestHeader>
        {
            new("Header1", "Value1"),
            new("Header2", "Value2"),
            new("Header3", "Value3")
        };

        var metadataProvider =
            new MetadataProviderBuilder("OnlinePayments")
                {
                    AdditionalRequestHeaders = additionalHeaders
                }
                .Build();

        var requestHeaders = metadataProvider.ServerMetadataHeaders.ToList();

        Assert.That(requestHeaders.Count, Is.EqualTo(4));

        var requestHeader = requestHeaders[0];
        AssertServerMetaInfo(metadataProvider, requestHeader);

        for (var i = 0; i < additionalHeaders.Count; i++)
        {
            requestHeader = requestHeaders[i + 1];

            Assert.That(additionalHeaders[i], Is.EqualTo(requestHeader));
        }
    }

    [TestCase]
    public void Constructor_WithProhibitedAdditionalHeaders_ThrowsArgumentException()
    {
        foreach (var name in MetadataProvider.ProhibitedHeaders)
        {
            var headers = new List<RequestHeader>
            {
                new("Header1", "Value1"),
                new(name, "whatever"),
                new("Header2", "Value2")
            };

            Assert.That(() => new MetadataProviderBuilder("OnlinePayments") { AdditionalRequestHeaders = headers }.Build(), Throws.ArgumentException.With.Message.Contain(name));
        }
    }

    [TestCase]
    public void ServerMetadataHeaders_WithShoppingCartExtensionIncludingId_ReturnsServerMetaInfoWithExtension()
    {
        var shoppingCartExtension = new ShoppingCartExtension("OnlinePayments.Creator", "Extension", "1.0", "ExtensionId");

        var metadataProvider = new MetadataProviderBuilder("OnlinePayments.Integrator")
            .WithShoppingCartExtension(shoppingCartExtension)
            .Build();

        var requestHeaders = metadataProvider.ServerMetadataHeaders.ToList();

        Assert.That(requestHeaders.Count, Is.EqualTo(1));

        var requestHeader = requestHeaders[0];
        Assert.That(requestHeader.Name, Is.EqualTo("X-GCS-ServerMetaInfo"));
        Assert.That(requestHeader.Value, Is.Not.Null);

        var data = Convert.FromBase64String(requestHeader.Value);
        var serverMetaInfoJson = Encoding.UTF8.GetString(data);
        var serverMetaInfo = DefaultMarshaller.Instance.Unmarshal<MetadataProvider.ServerMetaInfo>(serverMetaInfoJson);

        Assert.That(serverMetaInfo.PlatformIdentifier, Is.EqualTo(metadataProvider.PlatformIdentifier));
        Assert.That(serverMetaInfo.SdkIdentifier, Is.EqualTo(metadataProvider.SdkIdentifier));
        Assert.That(serverMetaInfo.SdkCreator, Is.EqualTo("OnlinePayments"));
        Assert.That(serverMetaInfo.Integrator, Is.EqualTo("OnlinePayments.Integrator"));
        Assert.That(serverMetaInfo.ShoppingCartExtension, Is.Not.Null);
    }

    [TestCase]
    public void ServerMetadataHeaders_WithShoppingCartExtensionWithoutId_ReturnsServerMetaInfoWithExtension()
    {
        var shoppingCartExtension = new ShoppingCartExtension("OnlinePayments.Creator", "Extension", "1.0");

        var metadataProvider = new MetadataProviderBuilder("OnlinePayments.Integrator")
            .WithShoppingCartExtension(shoppingCartExtension)
            .Build();

        var requestHeaders = metadataProvider.ServerMetadataHeaders.ToList();

        Assert.That(requestHeaders.Count, Is.EqualTo(1));

        var requestHeader = requestHeaders[0];
        Assert.That(requestHeader.Name, Is.EqualTo("X-GCS-ServerMetaInfo"));
        Assert.That(requestHeader.Value, Is.Not.Null);

        var data = Convert.FromBase64String(requestHeader.Value);
        var serverMetaInfoJson = Encoding.UTF8.GetString(data);
        var serverMetaInfo = DefaultMarshaller.Instance.Unmarshal<MetadataProvider.ServerMetaInfo>(serverMetaInfoJson);

        Assert.That(serverMetaInfo.PlatformIdentifier, Is.EqualTo(metadataProvider.PlatformIdentifier));
        Assert.That(serverMetaInfo.SdkIdentifier, Is.EqualTo(metadataProvider.SdkIdentifier));
        Assert.That(serverMetaInfo.SdkCreator, Is.EqualTo("OnlinePayments"));
        Assert.That(serverMetaInfo.Integrator, Is.EqualTo("OnlinePayments.Integrator"));
        Assert.That(serverMetaInfo.ShoppingCartExtension, Is.Not.Null);
    }

    private static void AssertServerMetaInfo(MetadataProvider metadataProvider, IRequestHeader requestHeader)
    {
        Assert.That(requestHeader.Name, Is.EqualTo("X-GCS-ServerMetaInfo"));
        Assert.That(requestHeader.Value, Is.Not.Null);

        var data = Convert.FromBase64String(requestHeader.Value);
        var serverMetaInfoJson = Encoding.UTF8.GetString(data);

        var serverMetaInfo = DefaultMarshaller.Instance.Unmarshal<MetadataProvider.ServerMetaInfo>(serverMetaInfoJson);
        Assert.That(serverMetaInfo.SdkIdentifier, Is.EqualTo(metadataProvider.SdkIdentifier));
        Assert.That(serverMetaInfo.SdkCreator, Is.EqualTo("OnlinePayments"));
        Assert.That(serverMetaInfo.PlatformIdentifier, Is.EqualTo(metadataProvider.PlatformIdentifier));
    }
}
