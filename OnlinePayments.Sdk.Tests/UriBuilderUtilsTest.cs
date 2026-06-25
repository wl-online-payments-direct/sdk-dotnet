using System;
using System.Text;
using NUnit.Framework;

namespace OnlinePayments.Sdk;

[TestFixture]
public class UriBuilderUtilsTest
{
    [TestCase]
    public void AddParameter_ToEmptyQuery_AddsFirstParameter()
    {
        UriBuilder builder = new("https://api.example.com");

        builder.AddParameter("key", "value");

        Assert.That(builder.Query, Does.Contain("key=value"));
    }

    [TestCase]
    public void AddParameter_ToExistingQuery_AppendsWithAmpersand()
    {
        UriBuilder builder = new("https://api.example.com");

        builder.AddParameter("first", "1");
        builder.AddParameter("second", "2");

        Assert.That(builder.Query, Is.EqualTo("?first=1&second=2"));
    }

    [TestCase]
    public void AddParameter_WithSpecialChars_UrlEncodesNameAndValue()
    {
        UriBuilder builder = new("https://api.example.com");

        builder.AddParameter("my param", "hello world&more");

        Assert.That(builder.Query, Does.Contain("my%20param=hello%20world%26more"));
    }

    [TestCase]
    public void AddParameter_MultipleCalls_BuildsCorrectQueryString()
    {
        UriBuilder builder = new("https://api.example.com");

        builder.AddParameter("first", "1");
        builder.AddParameter("second", "2");
        builder.AddParameter("third", "3");

        var expectedQuery = new StringBuilder()
            .Append("?first=1")
            .Append("&second=2")
            .Append("&third=3")
            .ToString();

        Assert.That(builder.Query, Is.EqualTo(expectedQuery));
    }
}
