using System;
using NUnit.Framework;

namespace OnlinePayments.Sdk;

[TestFixture]
public class UriUtilsTest
{
    [TestCase("https://api.example.com", false, TestName = "HasPath_WithRootUri_ReturnsFalse")]
    [TestCase("https://api.example.com/", false, TestName = "HasPath_WithTrailingSlashOnly_ReturnsFalse")]
    [TestCase("https://api.example.com/v2", true, TestName = "HasPath_WithPathUri_ReturnsTrue")]
    [TestCase("https://api.example.com/v2/payments", true, TestName = "HasPath_WithDeepPath_ReturnsTrue")]
    public void HasPath_WithUri_ReturnsExpected(string uri, bool expected)
    {
        Uri apiEndpoint = new(uri);

        Assert.That(apiEndpoint.HasPath(), Is.EqualTo(expected));
    }

    [TestCase("https://api.example.com", false, TestName = "HasUserInfoOrQueryOrFragment_WithPlainUri_ReturnsFalse")]
    [TestCase("https://api.example.com?key=value", true, TestName = "HasUserInfoOrQueryOrFragment_WithQuery_ReturnsTrue")]
    [TestCase("https://api.example.com#section", true, TestName = "HasUserInfoOrQueryOrFragment_WithFragment_ReturnsTrue")]
    public void HasUserInfoOrQueryOrFragment_WithUri_ReturnsExpected(string uri, bool expected)
    {
        Uri apiEndpoint = new(uri);

        Assert.That(apiEndpoint.HasUserInfoOrQueryOrFragment(), Is.EqualTo(expected));
    }
}
