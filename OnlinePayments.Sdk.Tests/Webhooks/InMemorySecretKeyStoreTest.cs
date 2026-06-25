using System;
using System.Text;
using NUnit.Framework;

namespace OnlinePayments.Sdk.Webhooks;

[TestFixture]
public class InMemorySecretKeyStoreTest
{
    [TearDown]
    public void TearDown()
    {
        InMemorySecretKeyStore.Instance.Clear();
    }

    #region WhenAccessingSingleton

    [TestFixture]
    public class WhenAccessingSingleton
    {
        [Test]
        public void Instance_WhenAccessed_IsNotNull()
        {
            Assert.That(InMemorySecretKeyStore.Instance, Is.Not.Null);
        }

        [Test]
        public void Instance_WhenAccessedMultipleTimes_ReturnsSameInstance()
        {
            var instanceFirst = InMemorySecretKeyStore.Instance;
            var instanceSecond = InMemorySecretKeyStore.Instance;

            Assert.That(instanceFirst, Is.SameAs(instanceSecond));
        }
    }

    #endregion

    #region WhenStoringSecretKey

    [TestFixture]
    public class WhenStoringSecretKey
    {
        [Test]
        public void StoreSecretKey_WithValidKeyAndValue_KeyIsRetrievable()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("key-id-1", "secret-value-1");

            Assert.That(secretKeyStore.GetSecretKey("key-id-1"), Is.EqualTo("secret-value-1"));
        }

        [Test]
        public void StoreSecretKey_WithNullKeyId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => InMemorySecretKeyStore.Instance.StoreSecretKey(null, "secret-value")
            );
        }

        [Test]
        public void StoreSecretKey_WithEmptyKeyId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => InMemorySecretKeyStore.Instance.StoreSecretKey("", "secret-value")
            );
        }

        [Test]
        public void StoreSecretKey_WithWhitespaceKeyId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => InMemorySecretKeyStore.Instance.StoreSecretKey("   ", "secret-value")
            );
        }

        [Test]
        public void StoreSecretKey_WithNullSecretKey_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => InMemorySecretKeyStore.Instance.StoreSecretKey("key-id", null)
            );
        }

        [Test]
        public void StoreSecretKey_WithEmptySecretKey_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => InMemorySecretKeyStore.Instance.StoreSecretKey("key-id", "")
            );
        }

        [Test]
        public void StoreSecretKey_WithWhitespaceSecretKey_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => InMemorySecretKeyStore.Instance.StoreSecretKey("key-id", "   ")
            );
        }

        [Test]
        public void StoreSecretKey_WhenKeyAlreadyExists_ThrowsArgumentException()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("keyId", "oldSecret");

            Assert.Throws<ArgumentException>(
                () => secretKeyStore.StoreSecretKey("keyId", "newSecret")
            );
        }
    }

    #endregion

    #region WhenGettingSecretKey

    [TestFixture]
    public class WhenGettingSecretKey
    {
        [Test]
        public void GetSecretKey_WhenKeyExists_ReturnsStoredValue()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("test-key", "test-secret");

            var secretKey = secretKeyStore.GetSecretKey("test-key");

            Assert.That(secretKey, Is.EqualTo("test-secret"));
        }

        [Test]
        public void GetSecretKey_WhenKeyDoesNotExist_ThrowsSecretKeyNotAvailableException()
        {
            Assert.Throws<SecretKeyNotAvailableException>(
                () => InMemorySecretKeyStore.Instance.GetSecretKey("non-existent-key")
            );
        }

        [Test]
        public void GetSecretKey_WhenKeyDoesNotExist_ExceptionContainsCorrectKeyId()
        {
            const string missingKeyId = "missing-key";

            var exception = Assert.Throws<SecretKeyNotAvailableException>(
                () => InMemorySecretKeyStore.Instance.GetSecretKey(missingKeyId)
            );

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.KeyId, Is.EqualTo(missingKeyId));
        }

        [Test]
        public void GetSecretKey_WhenKeyDoesNotExist_ExceptionMessageContainsKeyId()
        {
            const string missingKeyId = "missing-key";

            var exception = Assert.Throws<SecretKeyNotAvailableException>(
                () => InMemorySecretKeyStore.Instance.GetSecretKey(missingKeyId)
            );

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain(missingKeyId));
        }
    }

    #endregion

    #region WhenRemovingSecretKey

    [TestFixture]
    public class WhenRemovingSecretKey
    {
        [Test]
        public void RemoveSecretKey_WhenKeyExists_KeyIsNoLongerRetrievable()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("key-to-remove", "secret");

            secretKeyStore.RemoveSecretKey("key-to-remove");

            Assert.Throws<SecretKeyNotAvailableException>(
                () => secretKeyStore.GetSecretKey("key-to-remove")
            );
        }

        [Test]
        public void RemoveSecretKey_WhenKeyDoesNotExist_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => InMemorySecretKeyStore.Instance.RemoveSecretKey("non-existent-key"));
        }

        [Test]
        public void RemoveSecretKey_WhenKeyExists_DoesNotAffectOtherKeys()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("key-1", "secret-1");
            secretKeyStore.StoreSecretKey("key-2", "secret-2");

            secretKeyStore.RemoveSecretKey("key-1");

            var remaining = secretKeyStore.GetSecretKey("key-2");
            Assert.That(remaining, Is.Not.Empty);
            Assert.That(remaining, Is.EqualTo("secret-2"));
        }
    }

    #endregion

    #region WhenClearingStore

    [TestFixture]
    public class WhenClearingStore
    {
        [Test]
        public void Clear_WhenCalled_RemovesAllStoredKeys()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("key-1", "secret-1");
            secretKeyStore.StoreSecretKey("key-2", "secret-2");
            secretKeyStore.StoreSecretKey("key-3", "secret-3");

            secretKeyStore.Clear();

            Assert.Throws<SecretKeyNotAvailableException>(() => secretKeyStore.GetSecretKey("key-1"));
            Assert.Throws<SecretKeyNotAvailableException>(() => secretKeyStore.GetSecretKey("key-2"));
            Assert.Throws<SecretKeyNotAvailableException>(() => secretKeyStore.GetSecretKey("key-3"));
        }

        [Test]
        public void Clear_WhenCalled_AllowsStoringNewKeys()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("old-key", "old-secret");

            secretKeyStore.Clear();
            secretKeyStore.StoreSecretKey("new-key", "new-secret");

            Assert.That(secretKeyStore.GetSecretKey("new-key"), Is.EqualTo("new-secret"));
        }
    }

    #endregion

    #region WhenWorkingWithMultipleKeys

    [TestFixture]
    public class WhenWorkingWithMultipleKeys
    {
        [Test]
        public void StoreSecretKey_WithMultipleKeys_AllKeysAreRetrievable()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            var firstKey = Guid.NewGuid().ToString("N");
            var secondKey = Guid.NewGuid().ToString("N");
            var thirdKey = Guid.NewGuid().ToString("N");

            secretKeyStore.StoreSecretKey(firstKey, "secret-1");
            secretKeyStore.StoreSecretKey(secondKey, "secret-2");
            secretKeyStore.StoreSecretKey(thirdKey, "secret-3");

            Assert.That(secretKeyStore.GetSecretKey(firstKey), Is.EqualTo("secret-1"));
            Assert.That(secretKeyStore.GetSecretKey(secondKey), Is.EqualTo("secret-2"));
            Assert.That(secretKeyStore.GetSecretKey(thirdKey), Is.EqualTo("secret-3"));
        }

        [Test]
        public void RemoveSecretKey_WhenOneKeyRemoved_OtherKeysRemainIntact()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;

            secretKeyStore.StoreSecretKey("api-key-1", "api-secret-1");
            secretKeyStore.StoreSecretKey("api-key-2", "api-secret-2");

            secretKeyStore.RemoveSecretKey("api-key-1");

            Assert.That(secretKeyStore.GetSecretKey("api-key-2"), Is.EqualTo("api-secret-2"));
            Assert.Throws<SecretKeyNotAvailableException>(
                () => secretKeyStore.GetSecretKey("api-key-1")
            );
        }

        [Test]
        public void StoreSecretKey_WithSpecialCharactersInValue_StoresAndRetrievesCorrectly()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;
            const string specialSecret = "secret!@#$%^&*()_+-=[]{}|;':\",./<>?";

            secretKeyStore.StoreSecretKey("special-key", specialSecret);

            Assert.That(secretKeyStore.GetSecretKey("special-key"), Is.EqualTo(specialSecret));
        }

        [Test]
        public void StoreSecretKey_WithLongSecretValue_StoresAndRetrievesCorrectly()
        {
            var secretKeyStore = InMemorySecretKeyStore.Instance;
            StringBuilder longSecret = new();
            for (int i = 0; i < 10000; i++)
            {
                longSecret.Append('a');
            }

            secretKeyStore.StoreSecretKey("long-key", longSecret.ToString());

            Assert.That(secretKeyStore.GetSecretKey("long-key"), Is.EqualTo(longSecret.ToString()));
        }
    }

    #endregion
}
