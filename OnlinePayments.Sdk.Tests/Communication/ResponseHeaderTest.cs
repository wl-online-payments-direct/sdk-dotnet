using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class ResponseHeaderTest
{
    [TestFixture]
    public class WhenConstructing
    {
        [Test]
        public void Constructor_WithNullName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { _ = new ResponseHeader(null, "value"); });
        }

        [Test]
        public void Constructor_WithEmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { _ = new ResponseHeader("", "value"); });
        }

        [Test]
        public void Constructor_WithValidName_StoresName()
        {
            var header = new ResponseHeader("Content-Type", "application/json");

            Assert.That(header.Name, Is.EqualTo("Content-Type"));
        }

        [Test]
        public void Constructor_WithValidValue_StoresValue()
        {
            var header = new ResponseHeader("Content-Type", "application/json");

            Assert.That(header.Value, Is.EqualTo("application/json"));
        }

        [Test]
        public void Constructor_WithNullValue_StoresNullValue()
        {
            var header = new ResponseHeader("X-Header", null);

            Assert.That(header.Value, Is.Null);
        }

        [Test]
        public void Constructor_WithEmptyValue_StoresEmptyValue()
        {
            var header = new ResponseHeader("X-Header", "");

            Assert.That(header.Value, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenConvertingToString
    {
        [Test]
        public void ToString_WithNameAndValue_ReturnsNameSemicolonValue()
        {
            var header = new ResponseHeader("Content-Type", "application/json");

            Assert.That(header.ToString(), Is.EqualTo("Content-Type;application/json"));
        }

        [Test]
        public void ToString_WithNullValue_ReturnsNameSemicolonEmpty()
        {
            var header = new ResponseHeader("X-Header", null);

            Assert.That(header.ToString(), Is.EqualTo("X-Header;"));
        }

        [Test]
        public void ToString_WithEmptyValue_ReturnsNameSemicolonEmpty()
        {
            var header = new ResponseHeader("X-Header", "");

            Assert.That(header.ToString(), Is.EqualTo("X-Header;"));
        }
    }

    [TestFixture]
    public class WhenUsingExtensionMethods
    {
        [Test]
        public void GetHeader_WithMatchingName_ReturnsHeader()
        {
            var headers = new List<IResponseHeader>
            {
                new ResponseHeader("Content-Type", "application/json"),
                new ResponseHeader("X-Request-Id", "abc-123")
            };

            var header = headers.GetHeader("Content-Type");

            Assert.That(header, Is.Not.Null);
            Assert.That(header.Name, Is.EqualTo("Content-Type"));
        }

        [Test]
        public void GetHeader_WithDifferentCaseName_ReturnsHeader()
        {
            var headers = new List<IResponseHeader>
            {
                new ResponseHeader("Content-Type", "application/json")
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
            var headers = new List<IResponseHeader>
            {
                new ResponseHeader("Content-Type", "application/json")
            };

            Assert.That(headers.GetHeader("X-Missing"), Is.Null);
        }

        [Test]
        public void GetHeader_WithDuplicateHeaderName_ReturnsFirstHeader()
        {
            var headers = new List<IResponseHeader>
            {
                new ResponseHeader("Set-Cookie", "cookie1=value1"),
                new ResponseHeader("Set-Cookie", "cookie2=value2")
            };

            var header = headers.GetHeader("Set-Cookie");

            Assert.That(header?.Name, Is.EqualTo("Set-Cookie"));
            Assert.That(header.Value, Is.EqualTo("cookie1=value1"));
        }

        [Test]
        public void GetHeaderValue_WithMatchingName_ReturnsValue()
        {
            var headers = new List<IResponseHeader>
            {
                new ResponseHeader("X-Request-Id", "xyz-789")
            };

            Assert.That(headers.GetHeaderValue("X-Request-Id"), Is.EqualTo("xyz-789"));
        }

        [Test]
        public void GetHeaderValue_WithDifferentCaseName_ReturnsValue()
        {
            var headers = new List<IResponseHeader>
            {
                new ResponseHeader("Authorization", "Bearer token")
            };

            Assert.That(headers.GetHeaderValue("authorization"), Is.EqualTo("Bearer token"));
            Assert.That(headers.GetHeaderValue("AUTHORIZATION"), Is.EqualTo("Bearer token"));
        }

        [Test]
        public void GetHeaderValue_WithMissingName_ReturnsNull()
        {
            IEnumerable<IResponseHeader> headers = [];

            Assert.That(headers.GetHeaderValue("X-Missing"), Is.Null);
        }

        [Test]
        public void GetHeaderValue_WithNullHeaderValue_ReturnsNull()
        {
            var headers = new List<IResponseHeader>
            {
                new ResponseHeader("Content-Type", null)
            };

            Assert.That(headers.GetHeaderValue("Content-Type"), Is.Null);
        }
    }

    [TestFixture]
    public class WhenGettingDispositionFilename
    {
        [Test]
        public void GetDispositionFilename_WithNoContentDispositionHeader_ReturnsNull()
        {
            var headers = new List<ResponseHeader>
            {
                new("Content-Type", "application/octet-stream")
            };

            Assert.That(headers.GetDispositionFilename(), Is.Null);
        }

        [TestCase("attachment; filename=testfile", "testfile")]
        [TestCase("attachment; filename=\"testfile\"", "testfile\"")]
        [TestCase("attachment; filename=\"testfile", "\"testfile")]
        [TestCase("attachment; filename=testfile\"", "testfile\"")]
        [TestCase("attachment; filename='testfile'", "testfile'")]
        [TestCase("attachment; filename='testfile", "'testfile")]
        [TestCase("attachment; filename=testfile'", "testfile'")]
        [TestCase("filename=testfile", "testfile")]
        [TestCase("filename=\"testfile\"", "testfile\"")]
        [TestCase("filename=\"testfile", "\"testfile")]
        [TestCase("filename=testfile\"", "testfile\"")]
        [TestCase("filename='testfile'", "testfile'")]
        [TestCase("filename='testfile", "'testfile")]
        [TestCase("filename=testfile'", "testfile'")]
        [TestCase("attachment; filename=testfile; x=y", "testfile")]
        [TestCase("attachment; filename=\"testfile\"; x=y", "testfile\"")]
        [TestCase("attachment; filename=\"testfile; x=y", "\"testfile")]
        [TestCase("attachment; filename=testfile\"; x=y", "testfile\"")]
        [TestCase("attachment; filename='testfile'; x=y", "testfile'")]
        [TestCase("attachment; filename='testfile; x=y", "'testfile")]
        [TestCase("attachment; filename=testfile'; x=y", "testfile'")]
        [TestCase("attachment", null)]
        [TestCase("filename=\"", "\"")]
        [TestCase("filename='", "'")]
        public void GetDispositionFilename_WithContentDispositionHeader_ReturnsExpectedFilename(
            string headerValue, string expectedFilename)
        {
            var headers = new List<ResponseHeader>
            {
                new("Content-Disposition", headerValue)
            };

            Assert.That(headers.GetDispositionFilename(), Is.EqualTo(expectedFilename));
        }
    }

    [TestFixture]
    public class WhenCheckingEquality
    {
        [Test]
        public void Equals_WithSameNameAndValue_ReturnsTrue()
        {
            var firstHeader = new ResponseHeader("Content-Type", "application/json");
            var secondHeader = new ResponseHeader("Content-Type", "application/json");

            Assert.That(firstHeader, Is.EqualTo(secondHeader));
        }

        [Test]
        public void Equals_WithDifferentName_ReturnsFalse()
        {
            var firstHeader = new ResponseHeader("Content-Type", "application/json");
            var secondHeader = new ResponseHeader("Accept", "application/json");

            Assert.That(firstHeader, Is.Not.EqualTo(secondHeader));
        }
    }
}
