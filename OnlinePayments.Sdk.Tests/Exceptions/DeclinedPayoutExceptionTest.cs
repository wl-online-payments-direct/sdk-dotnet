using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class DeclinedPayoutExceptionTest
{
    [Test]
    public void Constructor_WithPayoutResult_ExposesExpectedProperties()
    {
        var response = CreateResponse("payout-456", "DECLINED", "PAYOUT_ERR");
        DeclinedPayoutException exception = new(HttpStatusCode.BadRequest, "payout response", response);

        Assert.That(exception.Message, Is.EqualTo("declined payout 'payout-456' with status 'DECLINED'"));
        Assert.That(exception.PayoutResult, Is.SameAs(response.PayoutResult));
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(exception.ResponseBody, Is.EqualTo("payout response"));
        Assert.That(exception.ErrorId, Is.EqualTo("PAYOUT_ERR"));
    }

    private static PayoutErrorResponse CreateResponse(string payoutId = null, string payoutStatus = null, string errorId = "ERR_400")
    {
        PayoutErrorResponse response = new() { ErrorId = errorId, Errors = new List<APIError>() };
        if (payoutId != null || payoutStatus != null)
        {
            response.PayoutResult = new PayoutResult { Id = payoutId, Status = payoutStatus };
        }

        return response;
    }
}
