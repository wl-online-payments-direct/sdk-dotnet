using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Json;

[TestFixture]
public class DefaultMarshallerTest
{
    [TestCase]
    public void Marshal_WithNullDateFields_ExcludesNullFields()
    {
        ObjectWithDates objectWithDates = new() {
            Date = null,
            DateTime = null
        };

        var json = DefaultMarshaller.Instance.Marshal(objectWithDates);

        Assert.That(json, Is.EqualTo("{}"));
    }

    [TestCase]
    public void Marshal_WithListField_RoundTripsCorrectly()
    {
        ObjectWithListField original = new() {
            Values = ["first", "second", "third"]
        };

        var json = DefaultMarshaller.Instance.Marshal(original);
        var unmarshalled = DefaultMarshaller.Instance.Unmarshal<ObjectWithListField>(json);

        Assert.That(unmarshalled.Values, Is.EqualTo(original.Values));
    }

    [TestCase]
    public void Marshal_WithNullObject_ReturnsJsonNull()
    {
        var json = DefaultMarshaller.Instance.Marshal(null);

        Assert.That(json, Is.EqualTo("null"));
    }

    [TestCase]
    public void Unmarshal_WithNullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => DefaultMarshaller.Instance.Unmarshal<JsonToken>((string)null)
        );
    }

    [TestCase]
    public void Marshal_WithDateAndDateTime_ReturnsExpectedJsonValues()
    {
        ObjectWithDates objectWithDates = new() {
            Date = new DateTime(2023,
                12,
                31),
            DateTime = new DateTimeOffset(2023,
                12,
                31,
                13,
                24,
                59,
                123,
                TimeSpan.FromHours(2))
        };

        var json = DefaultMarshaller.Instance.Marshal(objectWithDates);

        Assert.That(json,
            Does.Contain("\"2023-12-31\""));
        Assert.That(json,
            Does.Contain("\"2023-12-31T13:24:59.123+02:00\""));
    }

    [TestCase]
    public void Unmarshal_WithExtraFields_IgnoresUnknownFields()
    {
        const string iban = "barbarbarbarfoo";
        DateTime date = new(1999, 9, 29);
        ExtendedToken token = new() {
            Date = date,
            Iban = iban
        };

        var json = DefaultMarshaller.Instance.Marshal(token);
        var returnedToken = DefaultMarshaller.Instance.Unmarshal<JsonToken>(json);

        Assert.That(returnedToken.Iban, Is.EqualTo(iban));
        Assert.That(returnedToken.Date, Is.EqualTo(date));
    }

    [TestCase]
    public void Unmarshal_WithDateAndDateTimeJson_ReturnsExpectedObject()
    {
        const string json = "{\"date\": \"2023-12-31\", \"dateTime\": \"2023-12-31T13:24:59.123+02:00\"}";

        var objectWithDates = DefaultMarshaller.Instance.Unmarshal<ObjectWithDates>(json);

        Assert.That(objectWithDates.Date,
            Is.EqualTo(new DateTime(2023,
                12,
                31)));
        Assert.That(objectWithDates.DateTime,
            Is.EqualTo(new DateTimeOffset(2023,
                12,
                31,
                13,
                24,
                59,
                123,
                TimeSpan.FromHours(2))));
    }

    [TestCase]
    public void Unmarshal_WithZuluDateTime_ReturnsUtcDateTimeOffset()
    {
        const string json = "{\"dateTime\": \"2023-12-31T13:24:59.123Z\"}";

        var objectWithDates = DefaultMarshaller.Instance.Unmarshal<ObjectWithDates>(json);

        Assert.That(objectWithDates.Date,
            Is.Null);
        Assert.That(objectWithDates.DateTime,
            Is.Not.Null);

        Assert.That(
            objectWithDates.DateTime,
            Is.EqualTo(new DateTimeOffset(2023,
                12,
                31,
                13,
                24,
                59,
                123,
                TimeSpan.Zero)));

        Assert.That(objectWithDates.DateTime.Value.Offset,
            Is.EqualTo(TimeSpan.Zero));
    }

    [TestCase]
    public void Unmarshal_WithFullTimezoneOffset_ParsesAndMarshalsCorrectly()
    {
        const string fullTimezone = "\"2026-03-26T12:34:56+01:00\"";
        var expected = DateTimeOffset.Parse("2026-03-26T12:34:56+01:00");

        var parsed = DefaultMarshaller.Instance.Unmarshal<DateTimeOffset>(fullTimezone);

        Assert.That(parsed.ToUniversalTime(), Is.EqualTo(expected.ToUniversalTime()));
        Assert.That(parsed.Offset, Is.EqualTo(expected.Offset));
        Assert.That(DefaultMarshaller.Instance.Marshal(parsed), Is.EqualTo(fullTimezone));
    }

    [TestCase]
    public void Unmarshal_WithShortTimezoneOffset_NormalizesToFullOffset()
    {
        const string shortTimezone = "\"2026-03-26T12:34:56+01\"";
        var expected = DateTimeOffset.Parse("2026-03-26T12:34:56+01:00");

        var parsed = DefaultMarshaller.Instance.Unmarshal<DateTimeOffset>(shortTimezone);

        Assert.That(parsed.ToUniversalTime(), Is.EqualTo(expected.ToUniversalTime()));
        Assert.That(parsed.Offset, Is.EqualTo(expected.Offset));
        Assert.That(DefaultMarshaller.Instance.Marshal(parsed), Is.EqualTo("\"2026-03-26T12:34:56+01:00\""));
    }

    [TestCase]
    public void Unmarshal_WithDateTimeWithoutOffset_ParsesDateTime()
    {
        const string withoutOffset = "\"2026-03-10T11:14:15\"";

        var result = DefaultMarshaller.Instance.Unmarshal<DateTimeOffset>(withoutOffset);

        Assert.That(result.DateTime,
            Is.EqualTo(new DateTime(2026,
                3,
                10,
                11,
                14,
                15)));
    }

    [TestCase]
    public void Unmarshal_WithJustDate_ParsesDate()
    {
        const string justDate = "\"2026-03-10\"";

        var result = DefaultMarshaller.Instance.Unmarshal<DateTimeOffset>(justDate);

        Assert.That(result.Date, Is.EqualTo(new DateTime(2026, 3, 10)));
    }

    [TestCase]
    public void Unmarshal_WithStream_ReturnsExpectedObject()
    {
        const string json = "{\"date\": \"2023-12-31\", \"dateTime\": \"2023-12-31T13:24:59.123+02:00\"}";

        using MemoryStream stream = new(Encoding.UTF8.GetBytes(json));
        var objectWithDates = DefaultMarshaller.Instance.Unmarshal<ObjectWithDates>(stream);

        Assert.That(objectWithDates.Date,
            Is.EqualTo(new DateTime(2023,
                12,
                31)));
        Assert.That(objectWithDates.DateTime,
            Is.EqualTo(new DateTimeOffset(2023,
                12,
                31,
                13,
                24,
                59,
                123,
                TimeSpan.FromHours(2))));
    }

    [TestCase]
    public void Unmarshal_WithInvalidDateTimeJsonFormat_ThrowsMarshallerSyntaxException()
    {
        const string json = "{\"dateTime\": \"not-a-valid-datetime\"}";

        Assert.Throws<MarshallerSyntaxException>(
            () => DefaultMarshaller.Instance.Unmarshal<ObjectWithDates>(json)
        );
    }

    [TestCase]
    public void Unmarshal_WithInvalidJsonFormat_ThrowsMarshallerSyntaxException()
    {
        const string json = "{ this is : not valid json }";

        Assert.Throws<MarshallerSyntaxException>(
            () => DefaultMarshaller.Instance.Unmarshal<ObjectWithDates>(json)
        );
    }
}

internal class JsonToken
{
    public DateTime Date { get; init; } = new(1945, 4, 5);

    public string Iban { get; init; }
}

internal class ExtendedToken : JsonToken;

internal class ObjectWithDates
{
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateTime? Date { get; init; }

    public DateTimeOffset? DateTime { get; init; }
}

internal class ObjectWithListField
{
    public List<string> Values { get; init; }
}
