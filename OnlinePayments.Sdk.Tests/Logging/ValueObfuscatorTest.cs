using NUnit.Framework;

namespace OnlinePayments.Sdk.Logging;

[TestFixture]
public class ValueObfuscatorTest
{
    [TestCase]
    public void All_WithValue_ReplacesAllWithAsterisks()
    {
        var result = ValueObfuscator.All.ObfuscateValue("secret123");

        Assert.That(result, Is.EqualTo("*********"));
    }

    [TestCase]
    public void All_WithNullValue_ReturnsNull()
    {
        var result = ValueObfuscator.All.ObfuscateValue(null);

        Assert.That(result, Is.Null);
    }

    [TestCase]
    public void All_WithEmptyValue_ReturnsEmpty()
    {
        var result = ValueObfuscator.All.ObfuscateValue(string.Empty);

        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [TestCase]
    public void FixedLength_WithValue_ReturnsFixedLengthMask()
    {
        var result = ValueObfuscator.FixedLength(8).ObfuscateValue("secret123");

        Assert.That(result, Is.EqualTo("********"));
    }

    [TestCase]
    public void FixedLength_WithShortValue_StillReturnsFixedLength()
    {
        var result = ValueObfuscator.FixedLength(8).ObfuscateValue("ab");

        Assert.That(result, Is.EqualTo("********"));
    }

    [TestCase]
    public void FixedLength_WithNullValue_ReturnsNull()
    {
        var result = ValueObfuscator.FixedLength(8).ObfuscateValue(null);

        Assert.That(result, Is.Null);
    }

    [TestCase]
    public void KeepingStartCount_WithValue_PreservesStartChars()
    {
        var result = ValueObfuscator.KeepingStartCount(4).ObfuscateValue("secret123");

        Assert.That(result, Is.EqualTo("secr*****"));
    }

    [TestCase]
    public void KeepingStartCount_WithShortValue_ReturnsOriginal()
    {
        var result = ValueObfuscator.KeepingStartCount(10).ObfuscateValue("short");

        Assert.That(result, Is.EqualTo("short"));
    }

    [TestCase]
    public void KeepingStartCount_WithNullValue_ReturnsNull()
    {
        var result = ValueObfuscator.KeepingStartCount(4).ObfuscateValue(null);

        Assert.That(result, Is.Null);
    }

    [TestCase]
    public void KeepingEndCount_WithValue_PreservesEndChars()
    {
        var result = ValueObfuscator.KeepingEndCount(4).ObfuscateValue("secret123");

        Assert.That(result, Is.EqualTo("*****t123"));
    }

    [TestCase]
    public void KeepingEndCount_WithShortValue_ReturnsOriginal()
    {
        var result = ValueObfuscator.KeepingEndCount(10).ObfuscateValue("short");

        Assert.That(result, Is.EqualTo("short"));
    }

    [TestCase]
    public void KeepingEndCount_WithNullValue_ReturnsNull()
    {
        var result = ValueObfuscator.KeepingEndCount(4).ObfuscateValue(null);

        Assert.That(result, Is.Null);
    }
}
