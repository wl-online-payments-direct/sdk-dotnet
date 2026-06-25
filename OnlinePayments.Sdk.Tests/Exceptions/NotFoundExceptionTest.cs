using System;
using NUnit.Framework;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class NotFoundExceptionTest
{
    [Test]
    public void Constructor_WithMessageAndException_StoresMessage()
    {
        NotFoundException exception = new("Resource not found", new Exception("inner"));

        Assert.That(exception.Message, Is.EqualTo("Resource not found"));
    }

    [Test]
    public void Constructor_WithMessageAndException_StoresInnerException()
    {
        Exception innerException = new("path resolution failed");
        NotFoundException exception = new("Not found", innerException);

        Assert.That(exception.InnerException, Is.SameAs(innerException));
    }
}