using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class PlatformExceptionTest
{
    [Test]
    public void Constructor_WithDefaultMessage_SetsDefaultMessageAndProperties()
    {
        List<APIError> errors = [];
        PlatformException exception = new(HttpStatusCode.InternalServerError, "Platform error", "ERR_500", errors);

        Assert.That(exception.Message, Is.EqualTo("the payment platform returned an error response"));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        Assert.That(exception.ResponseBody, Is.EqualTo("Platform error"));
        Assert.That(exception.ErrorId, Is.EqualTo("ERR_500"));
        Assert.That(exception.Errors, Is.SameAs(errors));
    }

    [Test]
    public void Constructor_WithCustomMessage_StoresCustomMessage()
    {
        PlatformException exception = new("Custom platform error", HttpStatusCode.InternalServerError, "error", "ERR_500", new List<APIError>());

        Assert.That(exception.Message, Is.EqualTo("Custom platform error"));
    }

    [Test]
    public void Constructor_WithCustomMessageAndProperties_StoresAllParameters()
    {
        List<APIError> errors = [new() { Message = "Downstream failure" }];
        PlatformException exception = new("Platform down", HttpStatusCode.BadGateway, "Gateway error", "ERR_502", errors);

        Assert.That(exception.Message, Is.EqualTo("Platform down"));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadGateway));
        Assert.That(exception.ResponseBody, Is.EqualTo("Gateway error"));
        Assert.That(exception.ErrorId, Is.EqualTo("ERR_502"));
        Assert.That(exception.Errors.Count, Is.EqualTo(1));
    }
}
