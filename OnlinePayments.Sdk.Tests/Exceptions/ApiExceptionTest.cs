using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class ApiExceptionTest
{
    private static APIError CreateError(string message)
    {
        APIError error = new()        {
            Message = message
        };

        return error;
    }

    [TestFixture]
    public class WhenConstructingWith4Parameters
    {
        [Test]
        public void Constructor_WithNegativeStatusCode_StoresStatusCode()
        {
            ApiException exception = new((HttpStatusCode)(-1), "error", "ERR_001", new List<APIError>());

            Assert.That((int)exception.StatusCode, Is.EqualTo(-1));
        }

        [Test]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            List<APIError> errors = [CreateError("Invalid input")];
            ApiException exception = new(HttpStatusCode.BadRequest, "Bad Request", "ERR_400", errors);

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(exception.ResponseBody, Is.EqualTo("Bad Request"));
            Assert.That(exception.ErrorId, Is.EqualTo("ERR_400"));
            Assert.That(exception.Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public void Constructor_WithNullErrorsList_ConvertsToEmptyList()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "ERR_001", null);

            Assert.That(exception.Errors, Is.Not.Null);
            Assert.That(exception.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_WithNullResponseBody_StoresNull()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, null, "ERR_001", new List<APIError>());

            Assert.That(exception.ResponseBody, Is.Null);
        }

        [Test]
        public void Constructor_WithNullErrorId_StoresNull()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", null, new List<APIError>());

            Assert.That(exception.ErrorId, Is.Null);
        }

        [Test]
        public void Constructor_WhenCalled_SetsDefaultMessage()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "ERR_001", new List<APIError>());

            Assert.That(exception.Message, Is.EqualTo("the payment platform returned an error response"));
        }

        [Test]
        public void Constructor_WithZeroStatusCode_StoresStatusCode()
        {
            ApiException exception = new(0, "error", "ERR_001", new List<APIError>());

            Assert.That((int)exception.StatusCode, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_WithEmptyStringResponseBody_StoresEmptyString()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "", "ERR_001", new List<APIError>());

            Assert.That(exception.ResponseBody, Is.EqualTo(""));
        }

        [Test]
        public void Constructor_WithEmptyStringErrorId_StoresEmptyString()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "", new List<APIError>());

            Assert.That(exception.ErrorId, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenConstructingWith5Parameters
    {
        [Test]
        public void Constructor_WithCustomMessage_StoresCustomMessage()
        {
            ApiException exception = new("Custom error message", HttpStatusCode.InternalServerError, "Internal Server Error", "ERR_500", new List<APIError>());

            Assert.That(exception.Message, Is.EqualTo("Custom error message"));
        }

        [Test]
        public void Constructor_WithAllParameters_StoresAllParameters()
        {
            List<APIError> errors = [CreateError("Resource not found")];
            ApiException exception = new("Error occurred", HttpStatusCode.NotFound, "Not Found", "ERR_404", errors);

            Assert.That(exception.Message, Is.EqualTo("Error occurred"));
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.ResponseBody, Is.EqualTo("Not Found"));
            Assert.That(exception.ErrorId, Is.EqualTo("ERR_404"));
            Assert.That(exception.Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public void Constructor_WithNullErrorsList_ConvertsToEmptyList()
        {
            ApiException exception = new("Error", HttpStatusCode.BadRequest, "error", "ERR_001", null);

            Assert.That(exception.Errors, Is.Not.Null);
            Assert.That(exception.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_WithNullResponseBody_StoresNull()
        {
            ApiException exception = new("Error", HttpStatusCode.BadRequest, null, "ERR_001", new List<APIError>());

            Assert.That(exception.ResponseBody, Is.Null);
        }

        [Test]
        public void Constructor_WithNullErrorId_StoresNull()
        {
            ApiException exception = new("Error", HttpStatusCode.BadRequest, "error", null, new List<APIError>());

            Assert.That(exception.ErrorId, Is.Null);
        }

        [Test]
        public void Constructor_WithZeroStatusCode_StoresStatusCode()
        {
            ApiException exception = new("Error", 0, "error", "ERR_001", new List<APIError>());

            Assert.That((int)exception.StatusCode, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_WithNullMessage_UsesDefaultExceptionMessage()
        {
            ApiException exception = new(null, HttpStatusCode.BadRequest, "error", "ERR_001", new List<APIError>());

            Assert.That(exception.Message, Is.EqualTo("Exception of type 'OnlinePayments.Sdk.ApiException' was thrown."));
        }

        [Test]
        public void Constructor_WithEmptyStringMessage_StoresEmptyString()
        {
            ApiException exception = new("", HttpStatusCode.BadRequest, "error", "ERR_001", new List<APIError>());

            Assert.That(exception.Message, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenGettingStatusCode
    {
        [Test]
        public void StatusCode_WhenPositive_ReturnsStatusCode()
        {
            ApiException exception = new(HttpStatusCode.Created, "Created", "ERR_201", new List<APIError>());

            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void StatusCode_WhenZero_ReturnsZero()
        {
            ApiException exception = new(0, "error", "ERR_001", new List<APIError>());

            Assert.That((int)exception.StatusCode, Is.EqualTo(0));
        }

        [Test]
        public void StatusCode_WhenNegative_ReturnsNegative()
        {
            ApiException exception = new((HttpStatusCode)(-1), "error", "ERR_001", new List<APIError>());

            Assert.That((int)exception.StatusCode, Is.EqualTo(-1));
        }

        [Test]
        public void StatusCode_WhenSetViaSecondConstructor_ReturnsStatusCode()
        {
            ApiException exception = new("Message", HttpStatusCode.ServiceUnavailable, "Service Unavailable", "ERR_503", new List<APIError>());

            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.ServiceUnavailable));
        }
    }

    [TestFixture]
    public class WhenGettingResponseBody
    {
        [Test]
        public void ResponseBody_WithNonEmptyValue_ReturnsResponseBody()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "Invalid request format", "ERR_400", new List<APIError>());

            Assert.That(exception.ResponseBody, Is.EqualTo("Invalid request format"));
        }

        [Test]
        public void ResponseBody_WhenNull_ReturnsNull()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, null, "ERR_400", new List<APIError>());

            Assert.That(exception.ResponseBody, Is.Null);
        }

        [Test]
        public void ResponseBody_WhenEmpty_ReturnsEmpty()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "", "ERR_400", new List<APIError>());

            Assert.That(exception.ResponseBody, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenGettingErrorId
    {
        [Test]
        public void ErrorId_WithNonNullValue_ReturnsErrorId()
        {
            ApiException exception = new(HttpStatusCode.PaymentRequired, "Payment required", "ERR_PAYMENT_FAILED", new List<APIError>());

            Assert.That(exception.ErrorId, Is.EqualTo("ERR_PAYMENT_FAILED"));
        }

        [Test]
        public void ErrorId_WhenNull_ReturnsNull()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", null, new List<APIError>());

            Assert.That(exception.ErrorId, Is.Null);
        }

        [Test]
        public void ErrorId_WhenEmpty_ReturnsEmpty()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "", new List<APIError>());

            Assert.That(exception.ErrorId, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenGettingErrors
    {
        [Test]
        public void Errors_WithMultipleErrors_ReturnsAllErrors()
        {
            List<APIError> errors = [CreateError("Error 1"), CreateError("Error 2")];
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", errors);

            Assert.That(exception.Errors.Count, Is.EqualTo(2));
            Assert.That(exception.Errors[0].Message, Is.EqualTo("Error 1"));
            Assert.That(exception.Errors[1].Message, Is.EqualTo("Error 2"));
        }

        [Test]
        public void Errors_WhenNullList_ReturnsEmptyList()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", null);

            Assert.That(exception.Errors, Is.Not.Null);
            Assert.That(exception.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void Errors_WhenEmptyList_ReturnsEmptyList()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", new List<APIError>());

            Assert.That(exception.Errors, Is.Not.Null);
            Assert.That(exception.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void Errors_WithSingleError_ReturnsSingleError()
        {
            List<APIError> errors = [CreateError("Single error")];
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", errors);

            Assert.That(exception.Errors.Count, Is.EqualTo(1));
            Assert.That(exception.Errors[0].Message, Is.EqualTo("Single error"));
        }
    }

    [TestFixture]
    public class WhenConvertingToString
    {
        [Test]
        public void ToString_WithPositiveStatusCode_IncludesStatusCode()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "Bad Request", "ERR_400", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("statusCode=BadRequest"));
        }

        [Test]
        public void ToString_WithZeroStatusCode_ExcludesStatusCode()
        {
            ApiException exception = new(0, "response", "ERR_001", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Not.Contain("statusCode="));
        }

        [Test]
        public void ToString_WithNegativeStatusCode_ExcludesStatusCode()
        {
            ApiException exception = new((HttpStatusCode)(-1), "response", "ERR_001", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Not.Contain("statusCode="));
        }

        [Test]
        public void ToString_WithNonEmptyResponseBody_IncludesResponseBody()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "Invalid input data", "ERR_400", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("responseBody='Invalid input data'"));
        }

        [Test]
        public void ToString_WithNullResponseBody_ExcludesResponseBody()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, null, "ERR_400", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Not.Contain("responseBody="));
        }

        [Test]
        public void ToString_WithEmptyResponseBody_ExcludesResponseBody()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "", "ERR_400", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Not.Contain("responseBody="));
        }

        [Test]
        public void ToString_WithCustomMessage_IncludesCustomMessage()
        {
            ApiException exception = new("Custom error message", HttpStatusCode.InternalServerError, "Internal Error", "ERR_500", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("Custom error message"));
        }

        [Test]
        public void ToString_WithDefaultMessage_IncludesDefaultMessage()
        {
            ApiException exception = new(HttpStatusCode.BadRequest, "error", "ERR_400", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("the payment platform returned an error response"));
        }

        [Test]
        public void ToString_WithStatusCodeAndResponseBody_FormatsCorrectly()
        {
            ApiException exception = new(HttpStatusCode.Unauthorized, "Unauthorized", "ERR_401", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("statusCode=Unauthorized"));
            Assert.That(result, Does.Contain("responseBody='Unauthorized'"));
        }

        [Test]
        public void ToString_WithStatusCodeAndEmptyResponseBody_IncludesOnlyStatusCode()
        {
            ApiException exception = new(HttpStatusCode.Forbidden, "", "ERR_403", new List<APIError>());
            var result = exception.ToString();

            Assert.That(result, Does.Contain("statusCode=Forbidden"));
            Assert.That(result, Does.Not.Contain("responseBody="));
        }
    }

    [TestFixture]
    public class WhenExtendingException
    {
        [Test]
        public void ApiException_WhenCreated_IsInstanceOfSystemException()
        {
            ApiException exception = new(HttpStatusCode.InternalServerError, "error", "ERR_500", new List<APIError>());

            Assert.That(exception, Is.InstanceOf<System.Exception>());
        }

        [Test]
        public void ApiException_WhenThrown_CanBeCaughtAsSystemException()
        {
            ApiException exception = new(HttpStatusCode.InternalServerError, "error", "ERR_500", new List<APIError>());

            try
            {
                throw exception;
            }
            catch (System.Exception e)
            {
                Assert.That(e.Message, Is.EqualTo("the payment platform returned an error response"));
            }
        }
    }
}
