using System;
using System.Net;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Exceptions;

[TestFixture]
public class ProblemDetailsExceptionTest
{
    [TestCase(HttpStatusCode.UnprocessableEntity)]
    public void Test_Construction_WithStatusCode_StoreStatusCode(HttpStatusCode statusCode)
    {
        ProblemDetailsException exception = Build(statusCode: statusCode);

        Assert.That(exception.StatusCode, Is.EqualTo(statusCode));
    }

    [TestCase("{\"type\":\"problem\"}")]
    public void Test_Construction_WithResponseBody_StoreResponseBody(string responseBody)
    {
        ProblemDetailsException exception = Build(responseBody: responseBody);

        Assert.That(exception.ResponseBody, Is.EqualTo(responseBody));
    }

    [Test]
    public void Test_Construction_WithResponseObject_StoreResponseObject()
    {
        ProblemDetailsResponse response = new ProblemDetailsResponse();
        ProblemDetailsException exception = new ProblemDetailsException(HttpStatusCode.BadRequest, "body", response);

        Assert.That(exception.Response, Is.SameAs(response));
    }

    [TestCase(null)]
    public void Test_Construction_WithNullResponseBody_StoreNullResponseBody(string responseBody)
    {
        ProblemDetailsException exception = Build(responseBody: responseBody);

        Assert.That(exception.ResponseBody, Is.Null);
    }

    [Test]
    public void Test_Construction_WithNullResponseObject_StoreNullResponseObject()
    {
        ProblemDetailsException exception = new ProblemDetailsException(HttpStatusCode.BadRequest, "body", null);

        Assert.That(exception.Response, Is.Null);
    }

    [Test]
    public void Test_GettingResponse_DefaultScenario_ReturnResponsePassedAtConstruction()
    {
        ProblemDetailsResponse response = new ProblemDetailsResponse();
        ProblemDetailsException exception = new ProblemDetailsException(HttpStatusCode.BadRequest, "body", response);

        Assert.That(exception.Response, Is.SameAs(response));
    }

    [Test]
    public void Test_ConvertingToString_DefaultScenario_IncludeProblemDetailsInMessage()
    {
        ProblemDetailsException exception = Build();

        Assert.That(exception.Message, Does.Contain("problem details"));
    }

    [Test]
    public void Test_Inheritance_DefaultScenario_IsInstanceOfProblemDetailsException()
    {
        ProblemDetailsException exception = Build();

        Assert.That(exception, Is.InstanceOf<ProblemDetailsException>());
    }

    [Test]
    public void Test_Inheritance_DefaultScenario_IsInstanceOfApiException()
    {
        ProblemDetailsException exception = Build();

        Assert.That(exception, Is.InstanceOf<ApiException>());
    }

    [Test]
    public void Test_Inheritance_DefaultScenario_IsInstanceOfException()
    {
        ProblemDetailsException exception = Build();

        Assert.That(exception, Is.InstanceOf<Exception>());
    }

    [TestCase(HttpStatusCode.InternalServerError, "error")]
    public void Test_Inheritance_DefaultScenario_IsCatchableAsApiException(HttpStatusCode statusCode, string responseBody)
    {
        ProblemDetailsException exception = Build(statusCode: statusCode, responseBody: responseBody);

        Assert.That(() => throw exception, Throws.InstanceOf<ApiException>());
    }

    private static ProblemDetailsException Build(
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        string responseBody = "body",
        ProblemDetailsResponse response = null)
    {
        response ??= new ProblemDetailsResponse();

        return new ProblemDetailsException(statusCode, responseBody, response);
    }
}
