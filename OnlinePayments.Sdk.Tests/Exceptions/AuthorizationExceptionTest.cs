using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class AuthorizationExceptionTest
{
    [TestFixture]
    public class WhenConstructingWith4Parameters
    {
        [Test]
        public void Constructor_WhenCalled_SetsDefaultMessage()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", new List<APIError>());

            Assert.That(exception.Message, Is.EqualTo("the payment platform returned an authorization error response"));
        }

        [Test]
        public void Constructor_WithValidParameters_StoresStatusCode()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", new List<APIError>());

            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        }

        [Test]
        public void Constructor_WithValidParameters_StoresResponseBody()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "Forbidden response", "ERR_403", new List<APIError>());

            Assert.That(exception.ResponseBody, Is.EqualTo("Forbidden response"));
        }

        [Test]
        public void Constructor_WithValidParameters_StoresErrorId()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", new List<APIError>());

            Assert.That(exception.ErrorId, Is.EqualTo("ERR_403"));
        }

        [Test]
        public void Constructor_WithNullErrorsList_ConvertsToEmptyList()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", null);

            Assert.That(exception.Errors, Is.Not.Null);
            Assert.That(exception.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_WithErrorsList_StoresErrors()
        {
            List<APIError> errors = [new() { Message = "Unauthorized" }];
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", errors);

            Assert.That(exception.Errors, Is.SameAs(errors));
        }
    }

    [TestFixture]
    public class WhenConstructingWith5Parameters
    {
        [Test]
        public void Constructor_WithCustomMessage_StoresCustomMessage()
        {
            AuthorizationException exception = new("Custom auth error", HttpStatusCode.Forbidden, "error", "ERR_403", new List<APIError>());

            Assert.That(exception.Message, Is.EqualTo("Custom auth error"));
        }

        [Test]
        public void Constructor_WithAllParameters_StoresAllParameters()
        {
            List<APIError> errors = [new() { Message = "Not authorized" }];
            AuthorizationException exception = new("Auth failed", HttpStatusCode.Forbidden, "Forbidden", "ERR_403", errors);

            Assert.That(exception.Message, Is.EqualTo("Auth failed"));
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
            Assert.That(exception.ResponseBody, Is.EqualTo("Forbidden"));
            Assert.That(exception.ErrorId, Is.EqualTo("ERR_403"));
            Assert.That(exception.Errors.Count, Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class WhenExtendingApiException
    {
        [Test]
        public void AuthorizationException_WhenCreated_IsInstanceOfApiException()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", new List<APIError>());

            Assert.That(exception, Is.InstanceOf<ApiException>());
        }

        [Test]
        public void AuthorizationException_WhenCreated_IsInstanceOfSystemException()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", new List<APIError>());

            Assert.That(exception, Is.InstanceOf<System.Exception>());
        }
    }

    [TestFixture]
    public class WhenConvertingToString
    {
        [Test]
        public void ToString_WithPositiveStatusCode_IncludesStatusCode()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "Forbidden", "ERR_403", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("statusCode=Forbidden"));
        }

        [Test]
        public void ToString_WithNonEmptyResponseBody_IncludesResponseBody()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "Forbidden response", "ERR_403", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("responseBody='Forbidden response'"));
        }

        [Test]
        public void ToString_WhenCalled_IncludesDefaultMessage()
        {
            AuthorizationException exception = new(HttpStatusCode.Forbidden, "error", "ERR_403", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("the payment platform returned an authorization error response"));
        }
    }
}
