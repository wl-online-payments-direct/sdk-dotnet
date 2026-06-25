using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class ValidationExceptionTest
{
    [Test]
    public void Constructor_WithDefaultMessage_SetsDefaultMessageAndProperties()
    {
        List<APIError> errors = [];
        ValidationException exception = new(HttpStatusCode.BadRequest, "Invalid input", "ERR_400", errors);

        Assert.That(exception.Message, Is.EqualTo("the payment platform returned an incorrect request error response"));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.ResponseBody, Is.EqualTo("Invalid input"));
        Assert.That(exception.ErrorId, Is.EqualTo("ERR_400"));
        Assert.That(exception.Errors, Is.SameAs(errors));
    }

    [Test]
    public void Constructor_WithCustomMessage_SetsCustomMessageAndProperties()
    {
        List<APIError> errors = [];
        ValidationException exception = new("Custom validation error", HttpStatusCode.BadRequest, "Invalid input", "ERR_400", errors);

        Assert.That(exception.Message, Is.EqualTo("Custom validation error"));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.ResponseBody, Is.EqualTo("Invalid input"));
        Assert.That(exception.ErrorId, Is.EqualTo("ERR_400"));
        Assert.That(exception.Errors, Is.SameAs(errors));
    }
}
