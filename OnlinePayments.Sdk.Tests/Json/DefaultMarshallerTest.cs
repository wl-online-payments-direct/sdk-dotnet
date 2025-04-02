using NUnit.Framework;
using System;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Json
{
    [TestFixture]
    public class DefaultMarshallerTest
    {
        [TestCase]
        public void TestUnmarshalWithExtraFields()
        {
            const string iban = "barbarbarbarfoo";
            var date = new DateTime(1999, 9, 29);
            var token = new ExtendedToken
            {
                Amount = 1337,
                Date = date,
                Iban = iban
            };

            var json = DefaultMarshaller.Instance.Marshal(token);
            var returnedToken = DefaultMarshaller.Instance.Unmarshal<JsonToken>(json);

            Assert.AreEqual(iban, returnedToken.Iban);
            Assert.AreEqual(date, returnedToken.Date);
        }

        [TestCase]
        public void TestMarshalDateAndDateTime()
        {
            var o = new ObjectWithDates
            {
                Date = new DateTime(2023, 12, 31),
                DateTime = new DateTimeOffset(2023, 12, 31, 13, 24, 59, 123, 456, TimeSpan.FromHours(2))
            };

            var json = DefaultMarshaller.Instance.Marshal(o);

            StringAssert.Contains("\"2023-12-31\"", json);
            StringAssert.Contains("\"2023-12-31T13:24:59.123+02:00\"", json);
        }

        [TestCase]
        public void TestUnmarshalDateAndDateTime()
        {
            const string json = "{\"date\": \"2023-12-31\", \"dateTime\": \"2023-12-31T13:24:59.123+02:00\"}";

            var o = DefaultMarshaller.Instance.Unmarshal<ObjectWithDates>(json);

            Assert.AreEqual(new DateTime(2023, 12, 31), o.Date);
            Assert.AreEqual(new DateTimeOffset(2023, 12, 31, 13, 24, 59, 123, TimeSpan.FromHours(2)), o.DateTime);
        }

        [TestCase]
        public void TestUnmarshalDateTimeZ()
        {
            const string json = "{\"dateTime\": \"2023-12-31T13:24:59.123Z\"}";

            var o = DefaultMarshaller.Instance.Unmarshal<ObjectWithDates>(json);

            Assert.IsNull(o.Date);
            Assert.AreEqual(new DateTimeOffset(2023, 12, 31, 13, 24, 59, 123, TimeSpan.Zero), o.DateTime);
        }
    }

    internal class JsonToken
    {
        public DateTime Date { get; set; } = new DateTime(1945, 4, 5);

        public string Iban { get; set; }
    }

    internal class ExtendedToken : JsonToken
    {
        public int Amount { get; set;}
    }

    internal class ObjectWithDates
    {
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime? Date { get; set; }

        public DateTimeOffset? DateTime { get; set; }
    }
}
