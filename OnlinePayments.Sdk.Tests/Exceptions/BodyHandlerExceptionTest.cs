using System;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class BodyHandlerExceptionTest
{
    [Test]
    public void Constructor_WithMessage_StoresMessage()
    {
        BodyHandlerException exception = new("handler error");

        Assert.That(exception.Message, Is.EqualTo("handler error"));
    }

    [Test]
    public void Constructor_WithMessage_HasNullInnerException()
    {
        BodyHandlerException exception = new("handler error");

        Assert.That(exception.InnerException, Is.Null);
    }

    [Test]
    public void Constructor_WithEmptyMessage_StoresEmptyMessage()
    {
        BodyHandlerException exception = new("");

        Assert.That(exception.Message, Is.EqualTo(""));
    }

    [Test]
    public void Constructor_WithNullMessage_DoesNotThrow()
    {
        Assert.DoesNotThrow(() => { _ = new BodyHandlerException(null); });
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_StoresMessage()
    {
        Exception innerException = new("inner");
        BodyHandlerException exception = new("handler error", innerException);

        Assert.That(exception.Message, Is.EqualTo("handler error"));
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_StoresInnerException()
    {
        Exception innerException = new("inner cause");
        BodyHandlerException exception = new("handler error", innerException);

        Assert.That(exception.InnerException, Is.SameAs(innerException));
    }

    [Test]
    public void Constructor_WithMessageAndNullInnerException_HasNullInnerException()
    {
        BodyHandlerException exception = new("handler error", null);

        Assert.That(exception.InnerException, Is.Null);
    }

    [Test]
    public void Constructor_WithMessage_ReturnsInstanceOfException()
    {
        BodyHandlerException exception = new("error");

        Assert.That(exception, Is.InstanceOf<Exception>());
    }

    [Test]
    public void Constructor_WithMessage_CanBeCaughtAsException()
    {
        BodyHandlerException exception = new("handler error");

        try
        {
            throw exception;
        }
        catch (Exception e)
        {
            Assert.That(e.Message, Is.EqualTo("handler error"));
        }
    }
}
