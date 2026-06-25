using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class IdempotenceExceptionTest
{
    [Test]
    public void Constructor_WithoutMessage_SetsDefaultMessageAndProperties()
    {
        List<APIError> errors = [];
        IdempotenceException exception = new("idempotence-key", 123456789L, HttpStatusCode.Conflict, "{\"error\":\"duplicate request\"}", "error-id", errors);

        Assert.That(exception, Is.InstanceOf<ApiException>());
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        Assert.That(exception.ResponseBody, Is.EqualTo("{\"error\":\"duplicate request\"}"));
        Assert.That(exception.ErrorId, Is.EqualTo("error-id"));
        Assert.That(exception.Errors, Is.SameAs(errors));
        Assert.That(exception.IdempotenceKey, Is.EqualTo("idempotence-key"));
        Assert.That(exception.IdempotenceRequestTimestamp, Is.EqualTo(123456789L));
        Assert.That(exception.Message, Is.EqualTo("the payment platform returned a duplicate request error response"));
    }

    [Test]
    public void Constructor_WithMessage_SetsCustomMessageAndProperties()
    {
        List<APIError> errors = [];
        IdempotenceException exception = new("idempotence-key", 123456789L, "custom message", HttpStatusCode.Conflict, "{\"error\":\"duplicate request\"}", "error-id", errors);

        Assert.That(exception, Is.InstanceOf<ApiException>());
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        Assert.That(exception.ResponseBody, Is.EqualTo("{\"error\":\"duplicate request\"}"));
        Assert.That(exception.ErrorId, Is.EqualTo("error-id"));
        Assert.That(exception.Errors, Is.SameAs(errors));
        Assert.That(exception.IdempotenceKey, Is.EqualTo("idempotence-key"));
        Assert.That(exception.IdempotenceRequestTimestamp, Is.EqualTo(123456789L));
        Assert.That(exception.Message, Is.EqualTo("custom message"));
    }
}
