using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class ReferenceExceptionTest
{
    [Test]
    public void Constructor_WithDefaultMessage_SetsDefaultMessageAndProperties()
    {
        List<APIError> errors = [];
        ReferenceException exception = new(HttpStatusCode.NotFound, "Not found", "ERR_404", errors);

        Assert.That(exception.Message, Is.EqualTo("the payment platform returned a reference error response"));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(exception.ResponseBody, Is.EqualTo("Not found"));
        Assert.That(exception.ErrorId, Is.EqualTo("ERR_404"));
        Assert.That(exception.Errors, Is.SameAs(errors));
    }

    [Test]
    public void Constructor_WithCustomMessage_SetsCustomMessageAndProperties()
    {
        List<APIError> errors = [];
        ReferenceException exception = new("Custom reference error", HttpStatusCode.NotFound, "Not found", "ERR_404", errors);

        Assert.That(exception.Message, Is.EqualTo("Custom reference error"));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(exception.ResponseBody, Is.EqualTo("Not found"));
        Assert.That(exception.ErrorId, Is.EqualTo("ERR_404"));
        Assert.That(exception.Errors, Is.SameAs(errors));
    }
}
