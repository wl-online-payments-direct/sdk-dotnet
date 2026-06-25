using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class DeclinedTransactionExceptionTest
{
    [Test]
    public void Constructor_WithoutMessage_SetsDefaultMessage()
    {
        TestDeclinedTransactionException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", new List<APIError>());

        Assert.That(exception.Message, Is.EqualTo("the payment platform returned an error response"));
    }

    [Test]
    public void Constructor_WithoutMessage_StoresStatusCode()
    {
        TestDeclinedTransactionException exception = new(HttpStatusCode.PaymentRequired, "error", "ERR_402", new List<APIError>());

        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.PaymentRequired));
    }

    [Test]
    public void Constructor_WithoutMessage_StoresResponseBody()
    {
        TestDeclinedTransactionException exception = new(HttpStatusCode.BadRequest, "Declined response", "ERR_400", new List<APIError>());

        Assert.That(exception.ResponseBody, Is.EqualTo("Declined response"));
    }

    [Test]
    public void Constructor_WithoutMessage_StoresErrorId()
    {
        TestDeclinedTransactionException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", new List<APIError>());

        Assert.That(exception.ErrorId, Is.EqualTo("ERR_400"));
    }

    [Test]
    public void Constructor_WithoutMessageAndNullErrors_ReturnsEmptyErrors()
    {
        TestDeclinedTransactionException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", null);

        Assert.That(exception.Errors, Is.Not.Null);
        Assert.That(exception.Errors.Count, Is.EqualTo(0));
    }

    [Test]
    public void Constructor_WithoutMessage_ReturnsInstanceOfApiException()
    {
        TestDeclinedTransactionException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", new List<APIError>());

        Assert.That(exception, Is.InstanceOf<ApiException>());
    }

    [Test]
    public void Constructor_WithoutMessage_ReturnsInstanceOfException()
    {
        TestDeclinedTransactionException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", new List<APIError>());

        Assert.That(exception, Is.InstanceOf<System.Exception>());
    }

    [Test]
    public void Constructor_WithMessage_StoresCustomMessage()
    {
        TestDeclinedTransactionException exception = new("Declined", HttpStatusCode.BadRequest, "error", "ERR_400", new List<APIError>());

        Assert.That(exception.Message, Is.EqualTo("Declined"));
    }

    [Test]
    public void Constructor_WithMessage_StoresAllParameters()
    {
        List<APIError> errors = [new() { Message = "Transaction declined" }];
        TestDeclinedTransactionException exception = new("Custom message", HttpStatusCode.BadRequest, "Declined", "ERR_400", errors);

        Assert.That(exception.Message, Is.EqualTo("Custom message"));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.ResponseBody, Is.EqualTo("Declined"));
        Assert.That(exception.ErrorId, Is.EqualTo("ERR_400"));
        Assert.That(exception.Errors.Count, Is.EqualTo(1));
    }

    private class TestDeclinedTransactionException : DeclinedTransactionException
    {
        public TestDeclinedTransactionException(HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(statusCode, responseBody, errorId, errors)
        {
        }

        public TestDeclinedTransactionException(string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message, statusCode, responseBody, errorId, errors)
        {
        }
    }
}
