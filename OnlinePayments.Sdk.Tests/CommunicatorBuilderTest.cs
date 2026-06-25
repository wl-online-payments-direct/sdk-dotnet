using System;
using Moq;
using NUnit.Framework;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk;

[TestFixture]
public class CommunicatorBuilderTest
{
    [TestCase]
    public void WithApiEndpoint_ReturnsThis()
    {
        CommunicatorBuilder builder = new();

        var result = builder.WithApiEndpoint(new Uri("https://api.example.com"));

        Assert.That(result, Is.SameAs(builder));
    }

    [TestCase]
    public void WithConnection_ReturnsThis()
    {
        CommunicatorBuilder builder = new();

        var result = builder.WithConnection(new Mock<IConnection>().Object);

        Assert.That(result, Is.SameAs(builder));
    }

    [TestCase]
    public void WithAuthenticator_ReturnsThis()
    {
        CommunicatorBuilder builder = new();

        var result = builder.WithAuthenticator(new Mock<IAuthenticator>().Object);

        Assert.That(result, Is.SameAs(builder));
    }

    [TestCase]
    public void WithMetadataProvider_ReturnsThis()
    {
        CommunicatorBuilder builder = new();

        var result = builder.WithMetadataProvider(new Mock<IMetadataProvider>().Object);

        Assert.That(result, Is.SameAs(builder));
    }

    [TestCase]
    public void WithMarshaller_ReturnsThis()
    {
        CommunicatorBuilder builder = new();

        var result = builder.WithMarshaller(new Mock<IMarshaller>().Object);

        Assert.That(result, Is.SameAs(builder));
    }

    [TestCase]
    public void Build_WithAllComponents_ReturnsCommunicator()
    {
        var result = CreateBuilderWithAllComponents().Build();

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<ICommunicator>());
    }

    [TestCase]
    public void Build_WithoutApiEndpoint_ThrowsArgumentException()
    {
        var builder = new CommunicatorBuilder()
            .WithConnection(new Mock<IConnection>().Object)
            .WithAuthenticator(new Mock<IAuthenticator>().Object)
            .WithMetadataProvider(new Mock<IMetadataProvider>().Object)
            .WithMarshaller(new Mock<IMarshaller>().Object);

        Assert.That(builder.Build, Throws.ArgumentException);
    }

    [TestCase]
    public void Build_WithoutConnection_ThrowsArgumentException()
    {
        var builder = new CommunicatorBuilder()
            .WithApiEndpoint(new Uri("https://api.example.com"))
            .WithAuthenticator(new Mock<IAuthenticator>().Object)
            .WithMetadataProvider(new Mock<IMetadataProvider>().Object)
            .WithMarshaller(new Mock<IMarshaller>().Object);

        Assert.That(builder.Build, Throws.ArgumentException);
    }

    [TestCase]
    public void Build_WithoutAuthenticator_ThrowsArgumentException()
    {
        var builder = new CommunicatorBuilder()
            .WithApiEndpoint(new Uri("https://api.example.com"))
            .WithConnection(new Mock<IConnection>().Object)
            .WithMetadataProvider(new Mock<IMetadataProvider>().Object)
            .WithMarshaller(new Mock<IMarshaller>().Object);

        Assert.That(builder.Build, Throws.ArgumentException);
    }

    [TestCase]
    public void Build_WithoutMetadataProvider_ThrowsArgumentException()
    {
        var builder = new CommunicatorBuilder()
            .WithApiEndpoint(new Uri("https://api.example.com"))
            .WithConnection(new Mock<IConnection>().Object)
            .WithAuthenticator(new Mock<IAuthenticator>().Object)
            .WithMarshaller(new Mock<IMarshaller>().Object);

        Assert.That(builder.Build, Throws.ArgumentException);
    }

    [TestCase]
    public void Build_WithoutMarshaller_ThrowsArgumentException()
    {
        CommunicatorBuilder builder = new CommunicatorBuilder()
            .WithApiEndpoint(new Uri("https://api.example.com"))
            .WithConnection(new Mock<IConnection>().Object)
            .WithAuthenticator(new Mock<IAuthenticator>().Object)
            .WithMetadataProvider(new Mock<IMetadataProvider>().Object);

        Assert.That(builder.Build, Throws.ArgumentException);
    }

    [TestCase("https://api.example.com/v2/path")]
    public void Build_WithApiEndpointContainingPath_ThrowsArgumentException(string apiEndpoint)
    {
        var builder = CreateBuilderWithAllComponents()
            .WithApiEndpoint(new Uri(apiEndpoint));

        Assert.That(builder.Build, Throws.ArgumentException);
    }

    private static CommunicatorBuilder CreateBuilderWithAllComponents()
        => new CommunicatorBuilder()
            .WithApiEndpoint(new Uri("https://api.example.com"))
            .WithConnection(new Mock<IConnection>().Object)
            .WithAuthenticator(new Mock<IAuthenticator>().Object)
            .WithMetadataProvider(new Mock<IMetadataProvider>().Object)
            .WithMarshaller(new Mock<IMarshaller>().Object);
}
