using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class DeclinedPaymentExceptionTest
{
    [Test]
    public void Constructor_WithPaymentResult_ExposesExpectedProperties()
    {
        var response = CreateResponse("pay-123", "DECLINED", "MY_ERR");
        DeclinedPaymentException exception = new(HttpStatusCode.BadRequest, "response body", response);

        Assert.That(exception.Message, Is.EqualTo("declined payment 'pay-123' with status 'DECLINED'"));
        Assert.That(exception.CreatePaymentResponse, Is.SameAs(response.PaymentResult));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.ResponseBody, Is.EqualTo("response body"));
        Assert.That(exception.ErrorId, Is.EqualTo("MY_ERR"));
    }

    private static PaymentErrorResponse CreateResponse(string paymentId = null, string paymentStatus = null, string errorId = "ERR_400")
    {
        PaymentErrorResponse response = new() { ErrorId = errorId, Errors = new List<APIError>() };
        if (paymentId != null || paymentStatus != null)
        {
            response.PaymentResult = new CreatePaymentResponse
            {
                Payment = new PaymentResponse { Id = paymentId, Status = paymentStatus }
            };
        }

        return response;
    }
}
