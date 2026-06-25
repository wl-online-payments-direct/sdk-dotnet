using System;
using NUnit.Framework;
using OnlinePayments.Sdk.Webhooks;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class SignatureValidationExceptionTest
{
    [Test]
    public void Constructor_WithMessage_StoresMessage()
    {
        SignatureValidationException exception = new("Signature validation failed");

        Assert.That(exception.Message, Is.EqualTo("Signature validation failed"));
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_StoresMessageAndInnerException()
    {
        Exception innerException = new("hmac error");
        SignatureValidationException exception = new("Invalid signature", innerException);

        Assert.That(exception.Message, Is.EqualTo("Invalid signature"));
        Assert.That(exception.InnerException, Is.SameAs(innerException));
    }
}
