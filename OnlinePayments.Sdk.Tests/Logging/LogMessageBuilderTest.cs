using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Logging;

[TestFixture]
public class LogMessageBuilderTest
{
    private static BodyObfuscator DefaultBodyObfuscator => BodyObfuscator.DefaultObfuscator;
    private static HeaderObfuscator DefaultHeaderObfuscator => HeaderObfuscator.DefaultObfuscator;

    private static RequestLogMessageBuilder CreateBuilder(
        string requestId = "test-request-id",
        string method = "GET",
        string uri = "https://example.com/api")
        => new(requestId, method, uri, DefaultBodyObfuscator, DefaultHeaderObfuscator);

    [Test]
    public void Constructor_WithNullRequestId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestLogMessageBuilder(null, "GET", "https://example.com", DefaultBodyObfuscator,
                DefaultHeaderObfuscator);
        });
    }

    [Test]
    public void Constructor_WithEmptyRequestId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestLogMessageBuilder("", "GET", "https://example.com", DefaultBodyObfuscator,
                DefaultHeaderObfuscator);
        });
    }

    [Test]
    public void Constructor_WithNullBodyObfuscator_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestLogMessageBuilder("req-1", "GET", "https://example.com", null,
                DefaultHeaderObfuscator);
        });
    }

    [Test]
    public void Constructor_WithNullHeaderObfuscator_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new RequestLogMessageBuilder("req-1", "GET", "https://example.com", DefaultBodyObfuscator,
                null);
        });
    }

    [Test]
    public void Constructor_WithValidParameters_CreatesInstance()
    {
        Assert.DoesNotThrow(() => CreateBuilder());
    }

    [Test]
    public void AddHeader_WithNameAndValue_IncludesHeaderInMessage()
    {
        var builder = CreateBuilder();
        builder.AddHeader("Content-Type", "application/json");

        Assert.That(builder.Message, Does.Contain("Content-Type"));
    }

    [Test]
    public void AddHeader_WithNameAndValue_IncludesValueInMessage()
    {
        var builder = CreateBuilder();
        builder.AddHeader("Content-Type", "application/json");

        Assert.That(builder.Message, Does.Contain("application/json"));
    }

    [Test]
    public void AddHeader_WithMultipleHeaders_SeparatesWithCommaAndSpace()
    {
        var builder = CreateBuilder();
        builder.AddHeader("Content-Type", "application/json");
        builder.AddHeader("Accept", "text/plain");

        Assert.That(builder.Message, Does.Contain("Content-Type=\"application/json\", Accept=\"text/plain\""));
    }

    [Test]
    public void AddHeader_WithNullValue_IncludesHeaderNameInMessage()
    {
        var builder = CreateBuilder();

        Assert.DoesNotThrow(() => builder.AddHeader("X-Header", null));
        Assert.That(builder.Message, Does.Contain("X-Header"));
    }

    [Test]
    public void SetBody_WithStringAndContentType_IncludesBodyInMessage()
    {
        var builder = CreateBuilder();
        builder.SetBody("{\"key\":\"value\"}", "application/json");

        Assert.That(builder.Message, Does.Contain("{\"key\":\"value\"}"));
    }

    [Test]
    public void SetBody_WithStringAndContentType_IncludesContentTypeInMessage()
    {
        var builder = CreateBuilder();
        builder.SetBody("{}", "application/json");

        Assert.That(builder.Message, Does.Contain("application/json"));
    }

    [Test]
    public void SetBody_WithOctetStreamContentType_ShowsBinaryPlaceholder()
    {
        var builder = CreateBuilder();
        builder.SetBody(null, "application/octet-stream");

        Assert.That(builder.Message, Does.Contain("<binary content>"));
    }

    [Test]
    public void SetBody_WithImageContentType_ShowsBinaryPlaceholder()
    {
        var builder = CreateBuilder();
        builder.SetBody(null, "image/png");

        Assert.That(builder.Message, Does.Contain("<binary content>"));
    }

    [Test]
    public void SetBody_WithTextContentType_ShowsActualBody()
    {
        var builder = CreateBuilder();
        builder.SetBody("plain text body", "text/plain");

        Assert.That(builder.Message, Does.Contain("plain text body"));
    }

    [Test]
    public void SetBody_WithJsonContentType_ShowsActualBody()
    {
        var builder = CreateBuilder();
        builder.SetBody("{\"id\":1}", "application/json");

        Assert.That(builder.Message, Does.Contain("{\"id\":1}"));
    }

    [Test]
    public void SetBody_WithXmlContentType_ShowsActualBody()
    {
        var builder = CreateBuilder();
        builder.SetBody("<root/>", "application/xml");

        Assert.That(builder.Message, Does.Contain("<root/>"));
    }

    [Test]
    public void SetBody_FromInputStream_IncludesBodyInMessage()
    {
        var builder = CreateBuilder();
        const string content = "test input stream body";
        using MemoryStream stream = new(Encoding.UTF8.GetBytes(content));
        builder.SetBody(new StreamReader(stream, Encoding.UTF8).ReadToEnd(), "text/plain");

        Assert.That(builder.Message, Does.Contain("test input stream body"));
    }

    [Test]
    public void SetBody_FromInputStreamWithBinaryContentType_ShowsBinaryPlaceholder()
    {
        var builder = CreateBuilder();
        builder.SetBody(null, "application/octet-stream");

        Assert.That(builder.Message, Does.Contain("<binary content>"));
    }

    [Test]
    public void SetBody_FromReader_IncludesBodyInMessage()
    {
        var builder = CreateBuilder();
        using StringReader reader = new("test reader body");
        builder.SetBody(reader.ReadToEnd(), "text/plain");

        Assert.That(builder.Message, Does.Contain("test reader body"));
    }

    [Test]
    public void SetBinaryContentBody_WithOctetStreamContentType_StoresBinaryPlaceholderAndContentType()
    {
        var builder = CreateBuilder();
        builder.SetBinaryContentBody("application/octet-stream");

        Assert.That(builder.Message, Does.Contain("<binary content>"));
        Assert.That(builder.Message, Does.Contain("application/octet-stream"));
    }

    [Test]
    public void SetBinaryContentBody_WithImageContentType_StoresBinaryPlaceholderAndContentType()
    {
        var builder = CreateBuilder();
        builder.SetBinaryContentBody("image/png");

        Assert.That(builder.Message, Does.Contain("<binary content>"));
        Assert.That(builder.Message, Does.Contain("image/png"));
    }

    [Test]
    public void SetBinaryContentBody_WithTextPlainContentType_ThrowsArgumentException()
    {
        var builder = CreateBuilder();

        Assert.Throws<ArgumentException>(() => builder.SetBinaryContentBody("text/plain"));
    }

    [Test]
    public void SetBinaryContentBody_WithApplicationJsonContentType_ThrowsArgumentException()
    {
        var builder = CreateBuilder();

        Assert.Throws<ArgumentException>(() => builder.SetBinaryContentBody("application/json"));
    }

    [Test]
    public void SetBinaryContentBody_WithApplicationXmlContentType_ThrowsArgumentException()
    {
        var builder = CreateBuilder();

        Assert.Throws<ArgumentException>(() => builder.SetBinaryContentBody("application/xml"));
    }
}
