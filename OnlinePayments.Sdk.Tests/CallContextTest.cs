using System;
using NUnit.Framework;

namespace OnlinePayments.Sdk;

[TestFixture]
public class CallContextTest
{
    [TestCase]
    public void WithIdempotenceKey_SetsKeyAndReturnsThis()
    {
        CallContext callContext = new();

        var result = callContext.WithIdempotenceKey("my-key");

        Assert.That(result, Is.SameAs(callContext));
        Assert.That(callContext.IdempotenceKey, Is.EqualTo("my-key"));
    }

    [TestCase]
    public void IdempotenceKey_DefaultsToNull()
    {
        CallContext callContext = new();

        Assert.That(callContext.IdempotenceKey, Is.Null);
    }

    [TestCase]
    public void IdempotenceRequestTimestamp_DefaultsToNull()
    {
        CallContext callContext = new();

        Assert.That(callContext.IdempotenceRequestTimestamp, Is.Null);
    }

    [TestCase]
    public void IdempotenceResponseDateTime_DefaultsToNull()
    {
        CallContext callContext = new();

        Assert.That(callContext.IdempotenceResponseDateTime, Is.Null);
    }

    [TestCase]
    public void GZip_DefaultsToFalse()
    {
        CallContext callContext = new();

        Assert.That(callContext.GZip, Is.False);
    }

    [TestCase]
    public void GZip_WhenSetToTrue_ReturnsTrue()
    {
        CallContext callContext = new()        {
            GZip = true
        };

        Assert.That(callContext.GZip, Is.True);
    }
}
