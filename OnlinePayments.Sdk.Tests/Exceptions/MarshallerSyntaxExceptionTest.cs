using System;
using NUnit.Framework;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class MarshallerSyntaxExceptionTest
{
    [Test]
    public void Constructor_WithCause_StoreCause()
    {
        Exception cause = new("json parse error");
        MarshallerSyntaxException exception = new(cause);

        Assert.That(exception, Is.InstanceOf<Exception>());
        Assert.That(exception.InnerException, Is.SameAs(cause));
    }
}