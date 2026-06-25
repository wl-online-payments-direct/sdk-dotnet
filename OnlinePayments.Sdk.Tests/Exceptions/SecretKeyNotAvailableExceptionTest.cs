using System;
using NUnit.Framework;
using OnlinePayments.Sdk.Webhooks;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class SecretKeyNotAvailableExceptionTest
{
    [Test]
    public void Constructor_WithMessageAndKeyId_StoresMessage()
    {
        SecretKeyNotAvailableException exception = new("No secret key for 'test-key'", "test-key");

        Assert.That(exception.Message, Is.EqualTo("No secret key for 'test-key'"));
    }

    [Test]
    public void Constructor_WithMessageAndKeyId_StoresKeyId()
    {
        SecretKeyNotAvailableException exception = new("No secret key for 'test-key'", "test-key");

        Assert.That(exception.KeyId, Is.EqualTo("test-key"));
    }

    [Test]
    public void Constructor_WithAllParameters_StoresMessageKeyIdAndInnerException()
    {
        Exception innerException = new("store error");
        SecretKeyNotAvailableException exception = new("No secret key", "my-key", innerException);

        Assert.That(exception.Message, Is.EqualTo("No secret key"));
        Assert.That(exception.KeyId, Is.EqualTo("my-key"));
        Assert.That(exception.InnerException, Is.SameAs(innerException));
    }

    [Test]
    public void Throw_WhenThrown_IsCatchableAsSignatureValidationException()
    {
        var thrown = Assert.Catch<SignatureValidationException>(
            () => throw new SecretKeyNotAvailableException("Key not found", "test-key"));

        Assert.That(thrown, Is.InstanceOf<SecretKeyNotAvailableException>());
    }
}