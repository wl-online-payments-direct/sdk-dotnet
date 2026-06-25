using System;
using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk;

[TestFixture]
public class ExceptionFactoryTest
{
    private static APIError CreateIdempotenceError() => new() { ErrorCode = "1409" };

    private static CallContext CreateIdempotenceContext(string key = "idempotence-key")
        => new CallContext().WithIdempotenceKey(key);

    [TestFixture]
    public class WhenCreatingExceptionForPaymentErrorResponse
    {
        [Test]
        public void CreateException_WithPaymentResultPresent_ReturnsDeclinedPaymentException()
        {
            CreatePaymentResponse createPaymentResponse = new();
            PaymentErrorResponse response = new() {
                ErrorId = "payment-error-id",
                Errors = new List<APIError>(),
                PaymentResult = createPaymentResponse
            };

            var exception = ExceptionFactory.CreateException((HttpStatusCode)402, "{\"error\":\"declined\"}", response, null);

            Assert.That(exception, Is.InstanceOf<DeclinedPaymentException>());
            var declinedEx = (DeclinedPaymentException)exception;
            Assert.That(declinedEx.StatusCode, Is.EqualTo((HttpStatusCode)402));
            Assert.That(declinedEx.ResponseBody, Is.EqualTo("{\"error\":\"declined\"}"));
            Assert.That(declinedEx.CreatePaymentResponse, Is.SameAs(createPaymentResponse));
        }

        [Test]
        public void CreateException_WithPaymentResultAbsent_ReturnsValidationException()
        {
            List<APIError> errors = new();
            PaymentErrorResponse response = new() {
                ErrorId = "payment-error-id",
                Errors = errors,
                PaymentResult = null
            };

            var exception = ExceptionFactory.CreateException(HttpStatusCode.BadRequest, "{\"error\":\"bad request\"}", response, null);

            Assert.That(exception, Is.InstanceOf<ValidationException>());
            var validationEx = (ValidationException)exception;
            Assert.That(validationEx.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(validationEx.ResponseBody, Is.EqualTo("{\"error\":\"bad request\"}"));
            Assert.That(validationEx.ErrorId, Is.EqualTo("payment-error-id"));
            Assert.That(validationEx.Errors, Is.SameAs(errors));
        }

    }

    [TestFixture]
    public class WhenCreatingExceptionForPayoutErrorResponse
    {
        [Test]
        public void CreateException_WithPayoutResultPresent_ReturnsDeclinedPayoutException()
        {
            PayoutResult payoutResult = new(){ Id = "payout-id", Status = "REJECTED" };
            PayoutErrorResponse response = new() {
                ErrorId = "payout-error-id",
                Errors = new List<APIError>(),
                PayoutResult = payoutResult
            };

            var exception = ExceptionFactory.CreateException((HttpStatusCode)402, "{\"error\":\"declined\"}", response, null);

            Assert.That(exception, Is.InstanceOf<DeclinedPayoutException>());
            var declinedEx = (DeclinedPayoutException)exception;
            Assert.That(declinedEx.StatusCode, Is.EqualTo((HttpStatusCode)402));
            Assert.That(declinedEx.ResponseBody, Is.EqualTo("{\"error\":\"declined\"}"));
            Assert.That(declinedEx.PayoutResult, Is.SameAs(payoutResult));
        }

        [Test]
        public void CreateException_WithPayoutResultAbsent_ReturnsValidationException()
        {
            List<APIError> errors = [];
            PayoutErrorResponse response = new() { ErrorId = "payout-error-id", Errors = errors };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.BadRequest, "error", response, null);

            Assert.That(exception, Is.InstanceOf<ValidationException>());
            var validationEx = (ValidationException)exception;
            Assert.That(validationEx.ErrorId, Is.EqualTo("payout-error-id"));
            Assert.That(validationEx.Errors, Is.SameAs(errors));
        }
    }

    [TestFixture]
    public class WhenCreatingExceptionForRefundErrorResponse
    {
        [Test]
        public void CreateException_WithRefundResultPresent_ReturnsDeclinedRefundException()
        {
            RefundResponse refundResult = new() { Id = "refund-1", Status = "REJECTED" };
            RefundErrorResponse response = new() {
                ErrorId = "refund-error-id",
                Errors = new List<APIError>(),
                RefundResult = refundResult
            };

            var exception = ExceptionFactory.CreateException((HttpStatusCode)402, "{\"error\":\"declined\"}", response, null);

            Assert.That(exception, Is.InstanceOf<DeclinedRefundException>());
            var declinedEx = (DeclinedRefundException)exception;
            Assert.That(declinedEx.StatusCode, Is.EqualTo((HttpStatusCode)402));
            Assert.That(declinedEx.ResponseBody, Is.EqualTo("{\"error\":\"declined\"}"));
            Assert.That(declinedEx.RefundResponse, Is.SameAs(refundResult));
        }

        [Test]
        public void CreateException_WithRefundResultAbsent_ReturnsValidationException()
        {
            List<APIError> errors = [];
            RefundErrorResponse response = new() { ErrorId = "ERR_400", Errors = errors };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.BadRequest, "error", response, null);

            Assert.That(exception, Is.InstanceOf<ValidationException>());
            var validationEx = (ValidationException)exception;
            Assert.That(validationEx.ErrorId, Is.EqualTo("ERR_400"));
            Assert.That(validationEx.Errors, Is.SameAs(errors));
        }
    }

    [TestFixture]
    public class WhenCreatingExceptionForErrorResponse
    {
        [Test]
        public void CreateException_WithStatus400_ReturnsValidationException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_400", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.BadRequest, "error", response, null);

            Assert.That(exception, Is.InstanceOf<ValidationException>());
        }

        [Test]
        public void CreateException_WithStatus403_ReturnsAuthorizationException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_403", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.Forbidden, "error", response, null);

            Assert.That(exception, Is.InstanceOf<AuthorizationException>());
        }

        [Test]
        public void CreateException_WithStatus404_ReturnsReferenceException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_404", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.NotFound, "error", response, null);

            Assert.That(exception, Is.InstanceOf<ReferenceException>());
        }

        [Test]
        public void CreateException_WithStatus409AndIdempotenceConditionsNotMet_ReturnsReferenceException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_409", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.Conflict, "error", response, null);

            Assert.That(exception, Is.InstanceOf<ReferenceException>());
        }

        [Test]
        public void CreateException_WithStatus409AndIdempotenceConditionsMet_ReturnsIdempotenceException()
        {
            ErrorResponse response = new() {
                ErrorId = "ERR_409",
                Errors = new List<APIError> { CreateIdempotenceError() }
            };

            var context = CreateIdempotenceContext("my-idempotence-key");
            var exception = ExceptionFactory.CreateException(HttpStatusCode.Conflict, "error", response, context);
            Assert.That(exception, Is.InstanceOf<IdempotenceException>());

            var idempotenceEx = (IdempotenceException)exception;
            Assert.That(idempotenceEx.IdempotenceKey, Is.EqualTo("my-idempotence-key"));
        }

        [Test]
        public void CreateException_WithStatus410_ReturnsReferenceException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_410", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.Gone, "error", response, null);

            Assert.That(exception, Is.InstanceOf<ReferenceException>());
        }

        [Test]
        public void CreateException_WithStatus500_ReturnsPlatformException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_500", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.InternalServerError, "error", response, null);

            Assert.That(exception, Is.InstanceOf<PlatformException>());
        }

        [Test]
        public void CreateException_WithStatus502_ReturnsPlatformException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_502", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.BadGateway, "error", response, null);

            Assert.That(exception, Is.InstanceOf<PlatformException>());
        }

        [Test]
        public void CreateException_WithStatus503_ReturnsPlatformException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_503", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException(HttpStatusCode.ServiceUnavailable, "error", response, null);

            Assert.That(exception, Is.InstanceOf<PlatformException>());
        }

        [Test]
        public void CreateException_WithUnexpectedStatusCode_ReturnsApiException()
        {
            ErrorResponse response = new() { ErrorId = "ERR_418", Errors = new List<APIError>() };
            var exception = ExceptionFactory.CreateException((HttpStatusCode)418, "error", response, null);

            Assert.That(exception, Is.InstanceOf<ApiException>());
            Assert.That(exception, Is.Not.InstanceOf<ValidationException>());
            Assert.That(exception, Is.Not.InstanceOf<PlatformException>());
            Assert.That(exception, Is.Not.InstanceOf<ReferenceException>());
        }
    }

    [TestFixture]
    public class WhenCreatingExceptionForNullErrorObject
    {
        [Test]
        public void CreateException_WithNullErrorObjectAndUnexpectedStatusCode_ReturnsApiException()
        {
            var exception = ExceptionFactory.CreateException((HttpStatusCode)418, "error", null, null);

            Assert.That(exception, Is.InstanceOf<ApiException>());
        }
    }

    [TestFixture]
    public class WhenCreatingExceptionForUnsupportedErrorType
    {
        [Test]
        public void CreateException_WithUnsupportedErrorType_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => ExceptionFactory.CreateException(
                    HttpStatusCode.BadRequest,
                    "error",
                    new object(),
                    null));

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("unsupported error object type"));
        }
    }
}
