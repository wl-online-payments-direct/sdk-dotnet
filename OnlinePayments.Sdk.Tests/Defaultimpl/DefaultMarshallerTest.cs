using OnlinePayments.Sdk.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.DefaultImpl
{
    [TestFixture]
    public class DefaultMarshallerTest
    {
        [TestCase]
        public void TestUnmarshalWithExtraFields()
        {
            string iban = "barbarbarbarfoo";
            DateTime date = new DateTime(1999, 9, 29);
            ExtendedToken token = new ExtendedToken
            {
                Amount = 1337,
                Date = date,
                Iban = iban
            };

            string json = DefaultMarshaller.Instance.Marshal(token);
            JsonToken returnedToken = DefaultMarshaller.Instance.Unmarshal<JsonToken>(json);

            Assert.AreEqual(iban, returnedToken.Iban);
            Assert.AreEqual(date, returnedToken.Date);
        }

        [TestCase]
        public void TestRETURNMAC()
        {
            string retmac = "aaa";

            string json = DefaultMarshaller.Instance.Marshal(new CreateHostedCheckoutResponse { RETURNMAC = retmac });
            Assert.AreEqual(json, "{\"RETURNMAC\":\"aaa\"}");

            var anObject = DefaultMarshaller.Instance.Unmarshal<CreateHostedCheckoutResponse>(json);
            Assert.NotNull(anObject.RETURNMAC);
        }

        [TestCase]
        public void TesRedirectData()
        {
            var redirectData = new RedirectData {
                RETURNMAC = "hello",
                RedirectURL = "world"
            };

            string json = DefaultMarshaller.Instance.Marshal(redirectData);
            Assert.AreEqual("{\"RETURNMAC\":\"hello\",\"redirectURL\":\"world\"}", json);

            var unmarshalledRedirectData = DefaultMarshaller.Instance.Unmarshal<RedirectData>(json);

            Assert.AreEqual(redirectData.RETURNMAC, unmarshalledRedirectData.RETURNMAC);
            Assert.AreEqual(redirectData.RedirectURL, unmarshalledRedirectData.RedirectURL);
        }

        [TestCase]
        public void TestPaymentProducts()
        {
            var paymentProducts = new GetPaymentProductsResponse
            {
                PaymentProducts = new List<PaymentProduct>
                {
                    new PaymentProduct { Id = 1 }
                }
            };

            string json = DefaultMarshaller.Instance.Marshal(paymentProducts);
            Assert.AreEqual("{\"paymentProducts\":[{\"id\":1}]}", json);

            var unmarshalledPaymentProducts = DefaultMarshaller.Instance.Unmarshal<GetPaymentProductsResponse>(json);

            Assert.AreEqual(paymentProducts.PaymentProducts.Count, unmarshalledPaymentProducts.PaymentProducts.Count);
            Assert.AreEqual(paymentProducts.PaymentProducts[0].Id, unmarshalledPaymentProducts.PaymentProducts[0].Id);
        }
    }

    class JsonToken
    {
        public DateTime Date { get; set; } = new DateTime(1945, 4, 5);

        public string Iban { get; set; } = null;
    }

    class ExtendedToken : JsonToken
    {
        public int Amount { get; set;}
    }
}
