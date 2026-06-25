using System;
using System.Net;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Logging;

[TestFixture]
public class ResponseLogMessageBuilderTest
{
    private static BodyObfuscator DefaultBodyObfuscator => BodyObfuscator.DefaultObfuscator;
    private static HeaderObfuscator DefaultHeaderObfuscator => HeaderObfuscator.DefaultObfuscator;

    [Test]
    public void Constructor_WithZeroDuration_CreatesInstance()
    {
        var builder = new ResponseLogMessageBuilder("req-1", HttpStatusCode.OK, TimeSpan.Zero, DefaultBodyObfuscator, DefaultHeaderObfuscator);

        Assert.That(builder, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithPositiveDuration_CreatesInstance()
    {
        var builder = new ResponseLogMessageBuilder("req-1", HttpStatusCode.OK, TimeSpan.FromMilliseconds(150), DefaultBodyObfuscator, DefaultHeaderObfuscator);

        Assert.That(builder, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithLargeDuration_CreatesInstance()
    {
        var builder = new ResponseLogMessageBuilder("req-1", HttpStatusCode.OK, TimeSpan.FromMilliseconds(5000), DefaultBodyObfuscator, DefaultHeaderObfuscator);

        Assert.That(builder, Is.Not.Null);
    }

    [Test]
    public void Message_WithPositiveDuration_ContainsDurationInMilliseconds()
    {
        var builder = CreateBuilder(duration: TimeSpan.FromMilliseconds(350));

        Assert.That(builder.Message, Does.Contain("350"));
    }

    [Test]
    public void Message_WithZeroDuration_ContainsDuration()
    {
        var builder = CreateBuilder(duration: TimeSpan.FromMilliseconds(0));

        Assert.That(builder.Message, Does.Contain("0"));
    }

    [Test]
    public void Message_With200StatusCode_ContainsStatusCode()
    {
        var builder = CreateBuilder(statusCode: HttpStatusCode.OK);

        Assert.That(builder.Message, Does.Contain("200"));
    }

    [Test]
    public void Message_With301StatusCode_ContainsStatusCode()
    {
        var builder = CreateBuilder(statusCode: HttpStatusCode.Moved);

        Assert.That(builder.Message, Does.Contain("301"));
    }

    [Test]
    public void Message_With400StatusCode_ContainsStatusCode()
    {
        var builder = CreateBuilder(statusCode: HttpStatusCode.BadRequest);

        Assert.That(builder.Message, Does.Contain("400"));
    }

    [Test]
    public void Message_With500StatusCode_ContainsStatusCode()
    {
        var builder = CreateBuilder(statusCode: HttpStatusCode.InternalServerError);

        Assert.That(builder.Message, Does.Contain("500"));
    }

    [Test]
    public void SetBody_WithStringBody_IncludesBodyInMessage()
    {
        var builder = CreateBuilder();
        builder.SetBody("{\"status\":\"ok\"}", "application/json");

        Assert.That(builder.Message, Does.Contain("{\"status\":\"ok\"}"));
    }

    [Test]
    public void SetBody_WithContentType_IncludesContentTypeInMessage()
    {
        var builder = CreateBuilder();
        builder.SetBody("{}", "application/json");

        Assert.That(builder.Message, Does.Contain("application/json"));
    }

    private static ResponseLogMessageBuilder CreateBuilder(
        string requestId = "test-request-id",
        HttpStatusCode statusCode = HttpStatusCode.OK,
        TimeSpan? duration = null)
        => new(requestId, statusCode, duration ?? TimeSpan.FromMilliseconds(100), DefaultBodyObfuscator, DefaultHeaderObfuscator);
}
