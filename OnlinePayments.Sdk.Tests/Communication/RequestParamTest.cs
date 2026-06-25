using System;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class RequestParamTest
{
    [TestFixture]
    public class WhenConstructing
    {
        [Test]
        public void Constructor_WithNullName_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new RequestParam(null, "value"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("Name is required"));
        }

        [Test]
        public void Constructor_WithEmptyName_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new RequestParam("", "value"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("Name is required"));
        }

        [Test]
        public void Constructor_WithWhitespaceOnlyName_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => { _ = new RequestParam("   ", "value"); });
        }

        [Test]
        public void Constructor_WithValidName_StoresName()
        {
            var param = new RequestParam("page", "1");

            Assert.That(param.Name, Is.EqualTo("page"));
        }

        [Test]
        public void Constructor_WithValidValue_StoresValue()
        {
            var param = new RequestParam("page", "42");

            Assert.That(param.Value, Is.EqualTo("42"));
        }

        [Test]
        public void Constructor_WithNullValue_StoresNullValue()
        {
            var param = new RequestParam("filter", null);

            Assert.That(param.Value, Is.Null);
        }

        [Test]
        public void Constructor_WithEmptyValue_StoresEmptyValue()
        {
            var param = new RequestParam("filter", "");

            Assert.That(param.Value, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class WhenConvertingToString
    {
        [Test]
        public void ToString_WithNameAndValue_ReturnsNameColonValue()
        {
            var param = new RequestParam("page", "1");

            Assert.That(param.ToString(), Is.EqualTo("page:1"));
        }

        [Test]
        public void ToString_WithNullValue_ReturnsNameColonEmpty()
        {
            var param = new RequestParam("filter", null);

            Assert.That(param.ToString(), Is.EqualTo("filter:"));
        }

        [Test]
        public void ToString_WithEmptyValue_ReturnsNameColonEmpty()
        {
            var param = new RequestParam("q", "");

            Assert.That(param.ToString(), Is.EqualTo("q:"));
        }
    }

    [TestFixture]
    public class WhenCheckingEquality
    {
        [Test]
        public void Equals_WithSameNameAndValue_ReturnsTrue()
        {
            var firstRequestParam = new RequestParam("page", "1");
            var secondRequestParam = new RequestParam("page", "1");

            Assert.That(firstRequestParam, Is.EqualTo(secondRequestParam));
        }

        [Test]
        public void Equals_WithDifferentName_ReturnsFalse()
        {
            var firstRequestParam = new RequestParam("page", "1");
            var secondRequestParam = new RequestParam("limit", "1");

            Assert.That(firstRequestParam, Is.Not.EqualTo(secondRequestParam));
        }

        [Test]
        public void Equals_WithDifferentValue_ReturnsFalse()
        {
            var firstRequestParam = new RequestParam("page", "1");
            var secondRequestParam = new RequestParam("page", "2");

            Assert.That(firstRequestParam, Is.Not.EqualTo(secondRequestParam));
        }
    }
}
