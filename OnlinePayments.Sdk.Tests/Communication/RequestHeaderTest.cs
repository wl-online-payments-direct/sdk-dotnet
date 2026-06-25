using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class RequestHeaderTest
{
    [TestFixture]
    public class WhenConstructing
    {
        [Test]
        public void Constructor_WithNullName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { _ = new RequestHeader(null, "value"); });
        }

        [Test]
        public void Constructor_WithEmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { _ = new RequestHeader("", "value"); });
        }

        [Test]
        public void Constructor_WithWhitespaceOnlyName_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => { _ = new RequestHeader("   ", "value"); });
        }

        [Test]
        public void Constructor_WithValidName_StoresName()
        {
            var header = new RequestHeader("Content-Type", "application/json");

            Assert.That(header.Name, Is.EqualTo("Content-Type"));
        }

        [Test]
        public void Constructor_WithValidValue_StoresValue()
        {
            var header = new RequestHeader("Accept", "application/json");

            Assert.That(header.Value, Is.EqualTo("application/json"));
        }

        [Test]
        public void Constructor_WithNullValue_StoresNullValue()
        {
            var header = new RequestHeader("X-Header", null);

            Assert.That(header.Value, Is.Null);
        }

        [Test]
        public void Constructor_WithEmptyValue_StoresEmptyValue()
        {
            var header = new RequestHeader("X-Header", "");

            Assert.That(header.Value, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenNormalizingValue
    {
        [Test]
        public void Constructor_WithValueContainingLineFeed_NormalizesValue()
        {
            var header = new RequestHeader("Authorization", "Bearer\n  token");

            Assert.That(header.Value, Is.EqualTo("Bearer token"));
        }

        [Test]
        public void Constructor_WithValueContainingCarriageReturnLineFeed_NormalizesValue()
        {
            var header = new RequestHeader("Authorization", "Bearer\r\n  token");

            Assert.That(header.Value, Is.EqualTo("Bearer token"));
        }

        [Test]
        public void Constructor_WithValueHavingLeadingAndTrailingWhitespace_TrimsWhitespace()
        {
            var header = new RequestHeader("X-Header", "  value  ");

            Assert.That(header.Value, Is.EqualTo("value"));
        }

        [Test]
        public void Constructor_WithNormalValue_DoesNotModifyValue()
        {
            var header = new RequestHeader("Content-Type", "application/json");

            Assert.That(header.Value, Is.EqualTo("application/json"));
        }

        [Test]
        public void Constructor_WithContentTypeValue_NormalizesValue()
        {
            var header = new RequestHeader("Content-Type", " application/json;\r\n  charset=UTF-8");

            Assert.That(header.Value, Is.EqualTo("application/json; charset=UTF-8"));
        }

        [Test]
        public void Constructor_WithCookieValue_NormalizesValue()
        {
            var header = new RequestHeader("Cookie", " sessionId=abc123  \r\n \n path=/;\r\n  Secure ");

            Assert.That(header.Value, Is.EqualTo("sessionId=abc123    path=/; Secure"));
        }

        [Test]
        public void Constructor_WithNullValue_NormalizesToNull()
        {
            var header = new RequestHeader("X-Header", null);

            Assert.That(header.Value, Is.Null);
        }

        [Test]
        public void Constructor_WithEmptyValue_NormalizesToEmptyString()
        {
            var header = new RequestHeader("X-Header", "");

            Assert.That(header.Value, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenConvertingToString
    {
        [Test]
        public void ToString_WithNameAndValue_ReturnsNameColonValue()
        {
            var header = new RequestHeader("Content-Type", "application/json");

            Assert.That(header.ToString(), Is.EqualTo("Content-Type:application/json"));
        }

        [Test]
        public void ToString_WithNullValue_ReturnsNameColonEmpty()
        {
            var header = new RequestHeader("X-Header", null);

            Assert.That(header.ToString(), Is.EqualTo("X-Header:"));
        }

        [Test]
        public void ToString_WithEmptyValue_ReturnsNameColonEmpty()
        {
            var header = new RequestHeader("X-Header", "");

            Assert.That(header.ToString(), Is.EqualTo("X-Header:"));
        }
    }

    [TestFixture]
    public class WhenUsingExtensionMethods
    {
        [Test]
        public void GetHeader_WithMatchingName_ReturnsHeader()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("Content-Type", "application/json"),
                new RequestHeader("Accept", "text/plain")
            };

            var header = headers.GetHeader("Content-Type");

            Assert.That(header, Is.Not.Null);
            Assert.That(header.Name, Is.EqualTo("Content-Type"));
        }

        [Test]
        public void GetHeader_WithDifferentCaseName_ReturnsHeader()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("Content-Type", "application/json")
            };

            var resultLower = headers.GetHeader("content-type");
            var resultUpper = headers.GetHeader("CONTENT-TYPE");
            var resultMixed = headers.GetHeader("CoNtEnT-tYpE");

            Assert.That(resultLower?.Name, Is.EqualTo("Content-Type"));
            Assert.That(resultUpper?.Name, Is.EqualTo("Content-Type"));
            Assert.That(resultMixed?.Name, Is.EqualTo("Content-Type"));
        }

        [Test]
        public void GetHeader_WithMissingName_ReturnsNull()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("Content-Type", "application/json")
            };

            Assert.That(headers.GetHeader("X-Missing"), Is.Null);
        }

        [Test]
        public void GetHeader_WithDuplicateHeaderName_ReturnsFirstHeader()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("Set-Cookie", "cookie1=value1"),
                new RequestHeader("Set-Cookie", "cookie2=value2")
            };

            var header = headers.GetHeader("Set-Cookie");

            Assert.That(header?.Name, Is.EqualTo("Set-Cookie"));
            Assert.That(header.Value, Is.EqualTo("cookie1=value1"));
        }

        [Test]
        public void GetHeaderValue_WithMatchingName_ReturnsValue()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("X-Request-Id", "abc-123")
            };

            Assert.That(headers.GetHeaderValue("X-Request-Id"), Is.EqualTo("abc-123"));
        }

        [Test]
        public void GetHeaderValue_WithDifferentCaseName_ReturnsValue()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("Authorization", "Bearer token")
            };

            Assert.That(headers.GetHeaderValue("authorization"), Is.EqualTo("Bearer token"));
            Assert.That(headers.GetHeaderValue("AUTHORIZATION"), Is.EqualTo("Bearer token"));
        }

        [Test]
        public void GetHeaderValue_WithMissingName_ReturnsNull()
        {
            Assert.That(new List<IRequestHeader>().GetHeaderValue("X-Missing"), Is.Null);
        }

        [Test]
        public void GetHeaderValue_WithNullHeaderValue_ReturnsNull()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("Content-Type", null)
            };

            Assert.That(headers.GetHeaderValue("Content-Type"), Is.Null);
        }

        [Test]
        public void GetHeaderValue_WithEmptyHeaderValue_ReturnsEmptyString()
        {
            var headers = new List<IRequestHeader>
            {
                new RequestHeader("Content-Type", "")
            };

            Assert.That(headers.GetHeaderValue("Content-Type"), Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenCheckingEquality
    {
        [Test]
        public void Equals_WithSameNameAndValue_ReturnsTrue()
        {
            var firstHeader = new RequestHeader("Content-Type", "application/json");
            var secondHeader = new RequestHeader("Content-Type", "application/json");

            Assert.That(firstHeader, Is.EqualTo(secondHeader));
        }

        [Test]
        public void Equals_WithDifferentName_ReturnsFalse()
        {
            var firstHeader = new RequestHeader("Content-Type", "application/json");
            var secondHeader = new RequestHeader("Accept", "application/json");

            Assert.That(firstHeader, Is.Not.EqualTo(secondHeader));
        }

        [Test]
        public void Equals_WithDifferentValue_ReturnsFalse()
        {
            var firstHeader = new RequestHeader("Content-Type", "application/json");
            var secondHeader = new RequestHeader("Content-Type", "text/plain");

            Assert.That(firstHeader, Is.Not.EqualTo(secondHeader));
        }
    }
}
