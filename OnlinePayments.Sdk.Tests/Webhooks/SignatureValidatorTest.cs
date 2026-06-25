using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Webhooks;

[TestFixture]
public class SignatureValidatorTest
{
    private const string SignatureHeader = "X-GCS-Signature";
    private const string Signature = "6sFZob2yfSpd25MiutFRgBdx8dfbgxs+ZFp5kza1QR8=";
    private const string KeyIdHeader = "X-GCS-KeyId";
    private const string KeyId = "dummy-key-id";
    private const string SecretKey = "hello+world";

    private static readonly SignatureValidator SignatureValidator = new(InMemorySecretKeyStore.Instance);

    [SetUp]
    public void SetUp()
    {
        InMemorySecretKeyStore.Instance.Clear();
    }

    [TearDown]
    public void TearDown()
    {
        InMemorySecretKeyStore.Instance.Clear();
    }

    #region WhenValidatingSignature

    [TestFixture]
    public class WhenValidatingSignature
    {
        [SetUp]
        public void SetUp() => InMemorySecretKeyStore.Instance.Clear();

        [TearDown]
        public void TearDown() => InMemorySecretKeyStore.Instance.Clear();

        [TestFixture]
        public class FromByteArray
        {
            [SetUp]
            public void SetUp() => InMemorySecretKeyStore.Instance.Clear();

            [TearDown]
            public void TearDown() => InMemorySecretKeyStore.Instance.Clear();

            [Test]
            public void Validate_WithValidRequest_DoesNotThrow()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResource("valid-body");
                var headers = CreateValidRequestHeaders();

                Assert.DoesNotThrow(() => SignatureValidator.Validate(body, headers));
            }

            [Test]
            public void Validate_WhenSecretKeyIsMissing_ThrowsSecretKeyNotAvailableException()
            {
                var body = LoadResource("valid-body");
                var headers = CreateValidRequestHeaders();

                var exception = Assert.Throws<SecretKeyNotAvailableException>(
                    () => SignatureValidator.Validate(body, headers)
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.KeyId, Is.EqualTo(KeyId));
            }

            [Test]
            public void Validate_WhenHeadersAreMissing_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResource("valid-body");

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, new List<IRequestHeader>())
                );
            }

            [Test]
            public void Validate_WhenHeadersAreDuplicated_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResource("valid-body");
                List<IRequestHeader> headers =
                [
                    new RequestHeader(SignatureHeader, Signature),
                    new RequestHeader(KeyIdHeader, KeyId),
                    new RequestHeader(SignatureHeader, Signature + "1")
                ];

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }

            [Test]
            public void Validate_WhenBodyIsInvalid_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResource("invalid-body");
                var headers = CreateValidRequestHeaders();

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }

            [Test]
            public void Validate_WhenSecretKeyIsInvalid_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, "1" + SecretKey);

                var body = LoadResource("valid-body");
                var headers = CreateValidRequestHeaders();

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }

            [Test]
            public void Validate_WhenSignatureIsInvalid_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResource("valid-body");
                List<IRequestHeader> headers =
                [
                    new RequestHeader(SignatureHeader, "1" + Signature),
                    new RequestHeader(KeyIdHeader, KeyId)
                ];

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }
        }

        [TestFixture]
        public class FromString
        {
            [SetUp]
            public void SetUp() => InMemorySecretKeyStore.Instance.Clear();

            [TearDown]
            public void TearDown() => InMemorySecretKeyStore.Instance.Clear();

            [Test]
            public void Validate_WithValidRequest_DoesNotThrow()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResourceAsString("valid-body");
                var headers = CreateValidRequestHeaders();

                Assert.DoesNotThrow(() => SignatureValidator.Validate(body, headers));
            }

            [Test]
            public void Validate_WhenSecretKeyIsMissing_ThrowsSecretKeyNotAvailableException()
            {
                var body = LoadResourceAsString("valid-body");
                var headers = CreateValidRequestHeaders();

                var exception = Assert.Throws<SecretKeyNotAvailableException>(
                    () => SignatureValidator.Validate(body, headers)
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.KeyId, Is.EqualTo(KeyId));
            }

            [Test]
            public void Validate_WhenHeadersAreMissing_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResourceAsString("valid-body");

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, new List<IRequestHeader>())
                );
            }

            [Test]
            public void Validate_WhenHeadersAreDuplicated_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResourceAsString("valid-body");
                List<IRequestHeader> headers =
                [
                    new RequestHeader(SignatureHeader, Signature),
                    new RequestHeader(KeyIdHeader, KeyId),
                    new RequestHeader(SignatureHeader, Signature + "1")
                ];

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }

            [Test]
            public void Validate_WhenBodyIsInvalid_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResourceAsString("invalid-body");
                var headers = CreateValidRequestHeaders();

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }

            [Test]
            public void Validate_WhenSecretKeyIsInvalid_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, "1" + SecretKey);

                var body = LoadResourceAsString("valid-body");
                var headers = CreateValidRequestHeaders();

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }

            [Test]
            public void Validate_WhenSignatureIsInvalid_ThrowsSignatureValidationException()
            {
                InMemorySecretKeyStore.Instance.StoreSecretKey(KeyId, SecretKey);

                var body = LoadResourceAsString("valid-body");
                List<IRequestHeader> headers =
                [
                    new RequestHeader(SignatureHeader, "1" + Signature),
                    new RequestHeader(KeyIdHeader, KeyId)
                ];

                Assert.Throws<SignatureValidationException>(
                    () => SignatureValidator.Validate(body, headers)
                );
            }
        }
    }

    #endregion

    #region Helpers

    private static List<IRequestHeader> CreateValidRequestHeaders()
    {
        return
        [
            new RequestHeader(SignatureHeader, Signature),
            new RequestHeader(KeyIdHeader, KeyId)
        ];
    }

    private static byte[] LoadResource(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var fullName = $"OnlinePayments.Sdk.Webhooks.{resourceName}";
        using var stream = assembly.GetManifestResourceStream(fullName);

        if (stream == null)
        {
            throw new FileNotFoundException($"Embedded resource '{fullName}' not found.");
        }

        using MemoryStream memoryStream = new();
        int byteValue;

        while ((byteValue = stream.ReadByte()) != -1)
        {
            if (byteValue != '\r')
            {
                memoryStream.WriteByte((byte)byteValue);
            }
        }

        return memoryStream.ToArray();
    }

    private static string LoadResourceAsString(string resourceName)
        => Encoding.UTF8.GetString(LoadResource(resourceName));

    #endregion
}
