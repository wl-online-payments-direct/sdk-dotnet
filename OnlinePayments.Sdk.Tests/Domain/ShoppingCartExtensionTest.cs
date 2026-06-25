using System;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Domain;

[TestFixture]
public class ShoppingCartExtensionTest
{
    [TestFixture]
    public class WithInvalidCreator
    {
        [Test]
        public void Constructor_WithNullCreator_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension(null, "MyPlugin", "1.0"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("creator is required"));
        }

        [Test]
        public void Constructor_WithEmptyCreator_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("", "MyPlugin", "1.0"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("creator is required"));
        }

        [Test]
        public void Constructor_WithWhitespaceCreator_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("   ", "MyPlugin", "1.0"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("creator is required"));
        }
    }

    [TestFixture]
    public class WithInvalidName
    {
        [Test]
        public void Constructor_WithNullName_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", null, "1.0"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("name is required"));
        }

        [Test]
        public void Constructor_WithEmptyName_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "", "1.0"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("name is required"));
        }

        [Test]
        public void Constructor_WithWhitespaceName_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "   ", "1.0"); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("name is required"));
        }
    }

    [TestFixture]
    public class WithInvalidVersion
    {
        [Test]
        public void Constructor_WithNullVersion_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "MyPlugin", null); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("version is required"));
        }

        [Test]
        public void Constructor_WithEmptyVersion_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "MyPlugin", ""); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("version is required"));
        }

        [Test]
        public void Constructor_WithWhitespaceVersion_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "MyPlugin", "   "); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("version is required"));
        }
    }

    [TestFixture]
    public class WithValidArguments
    {
        [Test]
        public void Constructor_WithValidArguments_StoresCreator()
        {
            ShoppingCartExtension shoppingCartExtension = new("MyCompany", "MyPlugin", "1.0");

            Assert.That(shoppingCartExtension.Creator, Is.EqualTo("MyCompany"));
        }

        [Test]
        public void Constructor_WithValidArguments_StoresName()
        {
            ShoppingCartExtension shoppingCartExtension = new("MyCompany", "MyPlugin", "1.0");

            Assert.That(shoppingCartExtension.Name, Is.EqualTo("MyPlugin"));
        }

        [Test]
        public void Constructor_WithValidArguments_StoresVersion()
        {
            ShoppingCartExtension shoppingCartExtension = new("MyCompany", "MyPlugin", "1.0");

            Assert.That(shoppingCartExtension.Version, Is.EqualTo("1.0"));
        }

        [Test]
        public void Constructor_WithValidArguments_HasNullExtensionId()
        {
            ShoppingCartExtension shoppingCartExtension = new("MyCompany", "MyPlugin", "1.0");

            Assert.That(shoppingCartExtension.ExtensionId, Is.Null);
        }
    }

    [TestFixture]
    public class WithOptionalId
    {
        [Test]
        public void Constructor_WithValidExtensionId_StoresExtensionId()
        {
            ShoppingCartExtension shoppingCartExtension = new("MyCompany", "MyPlugin", "1.0", "ext-123");

            Assert.That(shoppingCartExtension.ExtensionId, Is.EqualTo("ext-123"));
        }

        [Test]
        public void Constructor_WithNullExtensionId_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "MyPlugin", "1.0", null); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("extensionId is required"));
        }

        [Test]
        public void Constructor_WithEmptyExtensionId_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "MyPlugin", "1.0", ""); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("extensionId is required"));
        }

        [Test]
        public void Constructor_WithWhitespaceExtensionId_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => { _ = new ShoppingCartExtension("MyCompany", "MyPlugin", "1.0", "   "); });

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("extensionId is required"));
        }
    }
}
