using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class DeclinedRefundExceptionTest
{
    [Test]
    public void Constructor_WithRefundResult_ExposesExpectedProperties()
    {
        var response = CreateResponse("refund-789", "DECLINED", "REFUND_ERR");
        DeclinedRefundException exception = new(HttpStatusCode.BadRequest, "refund response", response);

        Assert.That(exception.Message, Is.EqualTo("declined refund 'refund-789' with status 'DECLINED'"));
        Assert.That(exception.RefundResponse, Is.SameAs(response.RefundResult));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.ResponseBody, Is.EqualTo("refund response"));
        Assert.That(exception.ErrorId, Is.EqualTo("REFUND_ERR"));
    }

    private static RefundErrorResponse CreateResponse(string refundId = null, string refundStatus = null, string errorId = "ERR_400")
    {
        RefundErrorResponse response = new() { ErrorId = errorId, Errors = new List<APIError>() };
        if (refundId != null || refundStatus != null)
        {
            response.RefundResult = new RefundResponse { Id = refundId, Status = refundStatus };
        }

        return response;
    }
}
