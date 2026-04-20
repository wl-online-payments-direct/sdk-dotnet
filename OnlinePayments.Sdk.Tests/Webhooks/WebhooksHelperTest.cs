using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Webhooks
{
    public class WebhooksHelperTest
    {
        private const string BadVersionJson = @"{
  ""apiVersion"": ""v0"",
  ""id"": ""8ee793f6-4553-4749-85dc-f2ef095c5ab0"",
  ""created"": ""2017-02-02T11:24:14.040+0100"",
  ""merchantId"": ""20000"",
  ""type"": ""payment.paid"",
  ""payment"": {
    ""id"": ""00000200000143570012"",
    ""paymentOutput"": {
      ""amountOfMoney"": {
        ""amount"": 1000,
        ""currencyCode"": ""EUR""
      },
      ""references"": {
        ""paymentReference"": ""200001681810""
      },
      ""paymentMethod"": ""bankTransfer"",
      ""bankTransferPaymentMethodSpecificOutput"": {
        ""paymentProductId"": 11
      }
    },
    ""status"": ""PAID"",
    ""statusOutput"": {
      ""isCancellable"": false,
      ""statusCategory"": ""COMPLETED"",
      ""statusCode"": 1000,
      ""statusCodeChangeDateTime"": ""20170202112414"",
      ""isAuthorized"": true
    }
  }
}";
        private const string GoodVersionJson = @"{
  ""apiVersion"": ""v1"",
  ""id"": ""8ee793f6-4553-4749-85dc-f2ef095c5ab0"",
  ""created"": ""2017-02-02T11:24:14.040+0100"",
  ""merchantId"": ""20000"",
  ""type"": ""payment.paid"",
  ""payment"": {
    ""id"": ""00000200000143570012"",
    ""paymentOutput"": {
      ""amountOfMoney"": {
        ""amount"": 1000,
        ""currencyCode"": ""EUR""
      },
      ""references"": {
        ""paymentReference"": ""200001681810""
      },
      ""paymentMethod"": ""bankTransfer"",
      ""bankTransferPaymentMethodSpecificOutput"": {
        ""paymentProductId"": 11
      }
    },
    ""status"": ""PAID"",
    ""statusOutput"": {
      ""isCancellable"": false,
      ""statusCategory"": ""COMPLETED"",
      ""statusCode"": 1000,
      ""statusCodeChangeDateTime"": ""20170202112414"",
      ""isAuthorized"": true
    }
  }
}";

        private const string KeyId = "dummy-key-id";
        private const string SecretKey = "hello+world";

        private const string KeyIdHeader = "X-GCS-KeyId";
        private const string SignatureGood = "2S7doBj/GnJnacIjSJzr5fxGM5xmfQyFAwxv1I53ZEk=";
        private const string SignatureWrongApi = "O5FDUZyrDO+9fuQ1hD187HRbJLkUlBEht2eAL9jV/kU=";
        private const string SignatureHeader = "X-GCS-Signature";

        [TestCase]
        public void TestUnmarshalApiVersionMismatch()
        {
            var store = InMemorySecretKeyStore.Instance;
            store.StoreSecretKey(KeyId, SecretKey);
            var marshaller = DefaultMarshaller.Instance;
            var helper = new WebhooksHelper(marshaller, store);

            // the signature is created with Unix line breaks, so replace any Windows line break
            var bodyStream = BadVersionJson.Replace("\r\n", "\n");

            Assert.Throws(typeof(ApiVersionMismatchException), () => helper.Unmarshal(bodyStream, new List<RequestHeader> { new RequestHeader(KeyIdHeader, KeyId), new RequestHeader(SignatureHeader, SignatureWrongApi) }));
        }

        [TestCase]
        public void TestUnmarshalNoSecretKeyAvailable()
        {
            var store = InMemorySecretKeyStore.Instance;
            var marshaller = DefaultMarshaller.Instance;
            var helper = new WebhooksHelper(marshaller, store);
            Assert.Throws(typeof(SecretKeyNotAvailableException), () => helper.Unmarshal(GoodVersionJson, new List<RequestHeader> { new RequestHeader(KeyIdHeader, KeyId), new RequestHeader(SignatureHeader, SignatureGood) }));
        }

        [TearDown]
        public void TearDown()
        {
            InMemorySecretKeyStore.Instance.Clear();
        }

        [TestCase]
        public void TestUnmarshalMissingHeaders()
        {
            var store = InMemorySecretKeyStore.Instance;
            var marshaller = DefaultMarshaller.Instance;
            var helper = new WebhooksHelper(marshaller, store);
            store.StoreSecretKey(KeyId, SecretKey);
            Assert.Throws(typeof(SignatureValidationException), () => helper.Unmarshal(GoodVersionJson, new List<RequestHeader>()));
        }

        [TestCase]
        public void TestUnmarshalDuplicateHeaders()
        {
            var store = InMemorySecretKeyStore.Instance;
            var marshaller = DefaultMarshaller.Instance;
            var helper = new WebhooksHelper(marshaller, store);
            store.StoreSecretKey(KeyId, SecretKey);
            Assert.Throws(typeof(SignatureValidationException), () => helper.Unmarshal(GoodVersionJson, new List<RequestHeader> { new RequestHeader(KeyIdHeader, KeyId), new RequestHeader(SignatureHeader, SignatureGood), new RequestHeader(SignatureHeader, SignatureGood + 1) }));
        }

        [TestCase]
        public void TestUnmarshalSuccess()
        {
            var store = InMemorySecretKeyStore.Instance;

            var marshaller = DefaultMarshaller.Instance;

            var helper = new WebhooksHelper(marshaller, store);

            store.StoreSecretKey(KeyId, SecretKey);

            // the signature is created with Unix line breaks, so replace any Windows line break
            var bodyStream = GoodVersionJson.Replace("\r\n", "\n");
            var requestHeaders = new List<RequestHeader>{
                new RequestHeader(SignatureHeader, SignatureGood),
                new RequestHeader(KeyIdHeader, KeyId)
            };

            var anEvent = helper.Unmarshal(bodyStream, requestHeaders);

            Assert.That(anEvent.ApiVersion, Is.EqualTo("v1"));
            Assert.That(anEvent.Id, Is.EqualTo("8ee793f6-4553-4749-85dc-f2ef095c5ab0"));
            Assert.That(anEvent.Created, Is.EqualTo("2017-02-02T11:24:14.040+0100"));
            Assert.That(anEvent.MerchantId, Is.EqualTo("20000"));
            Assert.That(anEvent.Type, Is.EqualTo("payment.paid"));

            Assert.That(anEvent.Payment, Is.Not.Null);
            Assert.That(anEvent.Payment.Id, Is.EqualTo("00000200000143570012"));
            Assert.That(anEvent.Payment.PaymentOutput.AmountOfMoney.Amount, Is.EqualTo(1000));
            Assert.That(anEvent.Payment.StatusOutput.StatusCategory, Is.EqualTo("COMPLETED"));
        }

        private static string Repeat(string s, int times)
        {
            var sb = new StringBuilder(times * s.Length);
            for (var i = 0; i < times; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        [TestCase]
        public void TestCompareWithoutTimingLeak()
        {
            var signature = Guid.NewGuid().ToString();
            var large = Repeat(signature, 100);

            Assert.That("abc".CompareWithoutTimingLeak(signature), Is.False);
            Assert.That(signature.CompareWithoutTimingLeak(signature + "1"), Is.False);
            Assert.That((signature + "1").CompareWithoutTimingLeak(signature), Is.False);
            Assert.That(signature.ToUpper().CompareWithoutTimingLeak(signature.ToLower()), Is.False);
            Assert.That(signature.ToLower().CompareWithoutTimingLeak(signature.ToUpper()), Is.False);

            Assert.That("abc".CompareWithoutTimingLeak(large), Is.False);
            Assert.That(large.CompareWithoutTimingLeak(large + "1"), Is.False);
            Assert.That((large + "1").CompareWithoutTimingLeak(large), Is.False);
            Assert.That(large.ToUpper().CompareWithoutTimingLeak(large.ToLower()), Is.False);
            Assert.That(large.ToLower().CompareWithoutTimingLeak(large.ToUpper()), Is.False);

            Assert.That(large.CompareWithoutTimingLeak(signature), Is.False);
            Assert.That(signature.CompareWithoutTimingLeak(large), Is.False);
        }
    }
}
