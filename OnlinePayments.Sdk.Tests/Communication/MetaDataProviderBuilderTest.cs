using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class MetadataProviderBuilderTest
{
    [TestCase]
    public void WithAdditionalRequestHeader_ProhibitedHeader_ThrowsArgumentException()
    {
        foreach (var a in Parameters.Where(p => !p.Item2))
        {
            CheckWithAdditionalRequestHeader(a.Item1, a.Item2);
        }
    }

    [TestCase]
    public void WithAdditionalRequestHeader_AllowedHeader_AddsToServerMetadataHeaders()
    {
        foreach (var a in Parameters.Where(p => p.Item2))
        {
            CheckWithAdditionalRequestHeader(a.Item1, a.Item2);
        }
    }

    [TestCase]
    public void WithAdditionalRequestHeader_MultipleAllowedHeaders_AddsAll()
    {
        var firstHeader = new RequestHeader("Dummy", Guid.NewGuid().ToString());
        var secondHeader = new RequestHeader("Accept", Guid.NewGuid().ToString());

        var builder = new MetadataProviderBuilder("OnlinePayments");

        var metadataProvider = builder
            .WithAdditionalRequestHeader(firstHeader)
            .WithAdditionalRequestHeader(secondHeader)
            .Build();

        var requestHeaders = metadataProvider.ServerMetadataHeaders.ToList();

        Assert.That(requestHeaders.Count, Is.EqualTo(3));
        Assert.That(requestHeaders[0].Name, Is.EqualTo("X-GCS-ServerMetaInfo"));
        Assert.That(requestHeaders[1], Is.EqualTo(firstHeader));
        Assert.That(requestHeaders[2], Is.EqualTo(secondHeader));
    }

    [TestCase]
    public void WithAdditionalRequestHeader_NullHeader_ThrowsException()
    {
        var builder = new MetadataProviderBuilder("OnlinePayments");

        Assert.That(
            () => builder.WithAdditionalRequestHeader(null),
            Throws.InstanceOf<Exception>());
    }

    private static void CheckWithAdditionalRequestHeader(string additionalHeaderName, bool isAllowed)
    {
        var additionalRequestHeader = new RequestHeader(additionalHeaderName, Guid.NewGuid().ToString());
        var builder = new MetadataProviderBuilder("OnlinePayments");

        if (isAllowed)
        {
            var metadataProvider = builder.WithAdditionalRequestHeader(additionalRequestHeader).Build();
            var requestHeaders = metadataProvider.ServerMetadataHeaders.ToList();

            Assert.That(requestHeaders.Count, Is.EqualTo(2));

            var requestHeader = requestHeaders[0];
            Assert.That(requestHeader.Name, Is.EqualTo("X-GCS-ServerMetaInfo"));

            requestHeader = requestHeaders[1];
            Assert.That(requestHeader, Is.EqualTo(additionalRequestHeader));
        }
        else
        {
            Assert.That(
                () => builder.WithAdditionalRequestHeader(additionalRequestHeader),
                Throws.ArgumentException.With.Message.Contains(additionalHeaderName));
        }
    }

    private static IEnumerable<Tuple<string, bool>> Parameters
    {
        get
        {
            foreach (var prohibitedHeaders in MetadataProvider.ProhibitedHeaders)
            {
                yield return Tuple.Create(prohibitedHeaders, false);
            }

            yield return Tuple.Create("Dummy", true);
            yield return Tuple.Create("Accept", true);
            yield return Tuple.Create("If-None-Match", true);
            yield return Tuple.Create("If-Modified-Since", true);
        }
    }
}
