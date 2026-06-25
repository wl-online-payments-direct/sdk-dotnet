using NUnit.Framework;

namespace OnlinePayments.Sdk;

[TestFixture]
public class StringUtilsTest
{
    [TestCase]
    public void ToBase64String_WithValidInput_EncodesCorrectly()
    {
        const string input = "Hello, World!";
        const string expected = "SGVsbG8sIFdvcmxkIQ==";

        var actual = input.ToBase64String();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase]
    public void FromBase64String_WithValidInput_DecodesCorrectly()
    {
        const string input = "SGVsbG8sIFdvcmxkIQ==";
        const string expected = "Hello, World!";

        var actual = input.FromBase64String();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase]
    public void ToBase64String_FromBase64String_RoundTrip()
    {
        const string input = "Hello, World!";

        var actual = input.ToBase64String().FromBase64String();

        Assert.That(actual, Is.EqualTo(input));
    }

    [TestCase]
    public void NullIfEmpty_WithNull_ReturnsNull()
    {
        string input = null;

        var actual = input.NullIfEmpty();

        Assert.That(actual, Is.Null);
    }

    [TestCase]
    public void NullIfEmpty_WithEmptyString_ReturnsNull()
    {
        const string input = "";

        var actual = input.NullIfEmpty();

        Assert.That(actual, Is.Null);
    }

    [TestCase]
    public void NullIfEmpty_WithNonEmptyString_ReturnsSameString()
    {
        const string input = "hello";

        var actual = input.NullIfEmpty();

        Assert.That(actual, Is.EqualTo(input));
    }

    [TestCase]
    public void IsBlank_WithNull_ReturnsTrue()
    {
        var actual = ((string)null).IsBlank();

        Assert.That(actual, Is.True);
    }

    [TestCase]
    public void IsBlank_WithEmptyString_ReturnsTrue()
    {
        const string input = "";

        var actual = input.IsBlank();

        Assert.That(actual, Is.True);
    }

    [TestCase]
    public void IsBlank_WithWhitespaceOnly_ReturnsTrue()
    {
        const string input = "   ";

        var actual = input.IsBlank();

        Assert.That(actual, Is.True);
    }

    [TestCase]
    public void IsBlank_WithNonBlankString_ReturnsFalse()
    {
        const string input = "hello";

        var actual = input.IsBlank();

        Assert.That(actual, Is.False);
    }

    [TestCase]
    public void CompareWithoutTimingLeak_EqualStrings_ReturnsTrue()
    {
        const string input = "secret";
        const string expected = "secret";

        var actual = input.CompareWithoutTimingLeak(expected);

        Assert.That(actual, Is.True);
    }

    [TestCase]
    public void CompareWithoutTimingLeak_DifferentStrings_ReturnsFalse()
    {
        const string input = "secret";
        const string expected = "other!";

        var actual = input.CompareWithoutTimingLeak(expected);

        Assert.That(actual, Is.False);
    }

    [TestCase]
    public void CompareWithoutTimingLeak_DifferentLengths_ReturnsFalse()
    {
        const string input = "short";
        const string expected = "longer string";

        var actual = input.CompareWithoutTimingLeak(expected);

        Assert.That(actual, Is.False);
    }

    [TestCase]
    public void CompareWithoutTimingLeak_EmptyStrings_ReturnsTrue()
    {
        const string input = "";
        const string expected = "";

        var actual = input.CompareWithoutTimingLeak(expected);

        Assert.That(actual, Is.True);
    }
}
