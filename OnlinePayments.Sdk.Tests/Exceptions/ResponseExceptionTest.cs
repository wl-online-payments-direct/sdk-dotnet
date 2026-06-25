using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class ResponseExceptionTest
{
    [Test]
    public void Constructor_WithoutHeaders_ReturnsEmptyHeadersAndNullHeaderValues()
    {
        ResponseException exception = new(HttpStatusCode.BadRequest, null, null);

        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.Body, Is.Null);
        Assert.That(exception.Headers, Is.Not.Null);
        Assert.That(exception.Headers, Is.Empty);
        Assert.That(exception.GetHeader("Content-Type"), Is.Null);
        Assert.That(exception.GetHeaderValue("Content-Type"), Is.Null);
    }

    [Test]
    public void Constructor_WithHeaders_ReturnsExpectedHeadersAndHeaderValues()
    {
        List<IResponseHeader> headers =
        [
            new ResponseHeader("Content-Type", "application/json"),
            new ResponseHeader("X-Request-Id", "request-id")
        ];

        ResponseException exception = new(HttpStatusCode.BadRequest, "{\"error\":\"bad request\"}", headers);

        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.Body, Is.EqualTo("{\"error\":\"bad request\"}"));
        Assert.That(exception.Headers, Is.EqualTo(headers));
        Assert.That(exception.GetHeader("Content-Type"), Is.Not.Null);
        Assert.That(exception.GetHeaderValue("Content-Type"), Is.EqualTo("application/json"));
        Assert.That(exception.GetHeader("X-Request-Id"), Is.Not.Null);
        Assert.That(exception.GetHeaderValue("X-Request-Id"), Is.EqualTo("request-id"));
    }

    [Test]
    public void ToString_WithStatusCodeAndBody_ContainsStatusCodeAndResponseBody()
    {
        List<IResponseHeader> headers = [new ResponseHeader("Content-Type", "application/json")];
        ResponseException exception = new(HttpStatusCode.NotFound, "{\"error\":\"not found\"}", headers);
        var result = exception.ToString();

        Assert.That(result, Does.Contain("statusCode=NotFound"));
        Assert.That(result, Does.Contain("responseBody='{\"error\":\"not found\"}'"));
    }
}
