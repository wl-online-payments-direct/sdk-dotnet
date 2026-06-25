using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Logging;

[TestFixture]
public class HeaderObfuscatorTest
{
    [TestCase]
    public void DefaultObfuscator_WhenAccessed_IsNotNull()
    {
        var obfuscator = HeaderObfuscator.DefaultObfuscator;

        Assert.That(obfuscator, Is.Not.Null);
    }

    [TestCase]
    public void DefaultObfuscator_WhenAccessedMultipleTimes_ReturnsSameInstance()
    {
        var obfuscatorFirst = HeaderObfuscator.DefaultObfuscator;
        var obfuscatorSecond = HeaderObfuscator.DefaultObfuscator;

        Assert.That(obfuscatorFirst, Is.SameAs(obfuscatorSecond));
    }

    [TestCase]
    public void DefaultObfuscator_WithAuthorizationHeader_ReturnsAsterisks()
    {
        var obfuscator = HeaderObfuscator.DefaultObfuscator;
        var result = obfuscator.ObfuscateHeader("Authorization", "Bearer secret-token");

        Assert.That(result, Is.EqualTo("********"));
    }

    [TestCase]
    public void Custom_WhenCalled_ReturnsNonNullBuilder()
    {
        var builder = HeaderObfuscator.Custom();

        Assert.That(builder, Is.Not.Null);
    }

    [TestCase]
    public void Custom_WhenBuilt_ReturnsNonNullObfuscator()
    {
        var obfuscator = HeaderObfuscator.Custom().Build();

        Assert.That(obfuscator, Is.Not.Null);
    }

    [TestCase]
    public void Custom_WithDefaultRules_ObfuscatesAuthorizationHeader()
    {
        var obfuscator = HeaderObfuscator.Custom().Build();
        var result = obfuscator.ObfuscateHeader("Authorization", "Bearer token");

        Assert.That(result, Is.EqualTo("********"));
    }

    [TestCase]
    public void ObfuscateAll_WithHeaderValue_ReplacesAllWithAsterisks()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAll("Content-Type")
            .Build();

        var result = obfuscator.ObfuscateHeader("Content-Type", "application/json");

        Assert.That(result, Is.EqualTo("****************"));
    }

    [TestCase]
    public void ObfuscateAll_WithNullValue_ReturnsNull()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAll("X-Custom-Header")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Custom-Header", null);

        Assert.That(result, Is.Null);
    }

    [TestCase]
    public void ObfuscateAll_WithEmptyValue_ReturnsEmpty()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAll("X-Custom-Header")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Custom-Header", "");

        Assert.That(result, Is.EqualTo(""));
    }

    [TestCase]
    public void ObfuscateAll_WithDifferentCases_MatchesCaseInsensitively()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAll("Content-Type")
            .Build();

        var resultLower = obfuscator.ObfuscateHeader("content-type", "application/json");
        var resultUpper = obfuscator.ObfuscateHeader("CONTENT-TYPE", "application/json");

        Assert.That(resultLower, Is.EqualTo("****************"));
        Assert.That(resultUpper, Is.EqualTo("****************"));
    }

    [TestCase]
    public void ObfuscateWithFixedLength_WithHeaderValue_CreatesFixedLengthMask()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateWithFixedLength(4, "X-Custom-Header")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Custom-Header", "very-long-value");

        Assert.That(result, Is.EqualTo("****"));
    }

    [TestCase]
    public void ObfuscateWithFixedLength_WithDifferentLengths_CreatesMasksOfCorrectLength()
    {
        var obfuscatorFour = HeaderObfuscator.Custom()
            .ObfuscateWithFixedLength(4, "HeaderFirst")
            .Build();

        var obfuscatorEight = HeaderObfuscator.Custom()
            .ObfuscateWithFixedLength(8, "HeaderSecond")
            .Build();

        var obfuscatorSixteen = HeaderObfuscator.Custom()
            .ObfuscateWithFixedLength(16, "HeaderThird")
            .Build();

        Assert.That(obfuscatorFour.ObfuscateHeader("HeaderFirst", "value"), Is.EqualTo("****"));
        Assert.That(obfuscatorEight.ObfuscateHeader("HeaderSecond", "value"), Is.EqualTo("********"));
        Assert.That(obfuscatorSixteen.ObfuscateHeader("HeaderThird", "value"), Is.EqualTo("****************"));
    }

    [TestCase]
    public void ObfuscateWithFixedLength_WithNullValue_ReturnsNull()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateWithFixedLength(8, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", null);

        Assert.That(result, Is.Null);
    }

    [TestCase]
    public void ObfuscateWithFixedLength_WithEmptyValue_ReturnsEmpty()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateWithFixedLength(8, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", "");

        Assert.That(result, Is.EqualTo(""));
    }

    [TestCase]
    public void ObfuscateAllButFirst_KeepingOneChar_PreservesFirstCharAndObfuscatesRest()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAllButFirst(1, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", "secret123");

        Assert.That(result, Is.EqualTo("s********"));
    }

    [TestCase]
    public void ObfuscateAllButFirst_WithDifferentCounts_PreservesSpecifiedNumberOfChars()
    {
        var obfuscatorOne = HeaderObfuscator.Custom()
            .ObfuscateAllButFirst(1, "HeaderFirst")
            .Build();

        var obfuscatorThree = HeaderObfuscator.Custom()
            .ObfuscateAllButFirst(3, "HeaderSecond")
            .Build();

        var obfuscatorFive = HeaderObfuscator.Custom()
            .ObfuscateAllButFirst(5, "HeaderThird")
            .Build();

        Assert.That(obfuscatorOne.ObfuscateHeader("HeaderFirst", "secret123"), Is.EqualTo("s********"));
        Assert.That(obfuscatorThree.ObfuscateHeader("HeaderSecond", "secret123"), Is.EqualTo("sec******"));
        Assert.That(obfuscatorFive.ObfuscateHeader("HeaderThird", "secret123"), Is.EqualTo("secre****"));
    }

    [TestCase]
    public void ObfuscateAllButFirst_WithNullValue_ReturnsNull()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAllButFirst(3, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", null);

        Assert.That(result, Is.Null);
    }

    [TestCase]
    public void ObfuscateAllButFirst_WithEmptyValue_ReturnsEmpty()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAllButFirst(3, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", "");

        Assert.That(result, Is.EqualTo(""));
    }

    [TestCase]
    public void ObfuscateAllButLast_KeepingOneChar_PreservesLastCharAndObfuscatesRest()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAllButLast(1, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", "secret123");

        Assert.That(result, Is.EqualTo("********3"));
    }

    [TestCase]
    public void ObfuscateAllButLast_WithDifferentCounts_PreservesSpecifiedNumberOfChars()
    {
        var obfuscatorOne = HeaderObfuscator.Custom()
            .ObfuscateAllButLast(1, "HeaderFirst")
            .Build();

        var obfuscatorThree = HeaderObfuscator.Custom()
            .ObfuscateAllButLast(3, "HeaderSecond")
            .Build();

        var obfuscatorFive = HeaderObfuscator.Custom()
            .ObfuscateAllButLast(5, "HeaderThird")
            .Build();

        Assert.That(obfuscatorOne.ObfuscateHeader("HeaderFirst", "secret123"), Is.EqualTo("********3"));
        Assert.That(obfuscatorThree.ObfuscateHeader("HeaderSecond", "secret123"), Is.EqualTo("******123"));
        Assert.That(obfuscatorFive.ObfuscateHeader("HeaderThird", "secret123"), Is.EqualTo("****et123"));
    }

    [TestCase]
    public void ObfuscateAllButLast_WithNullValue_ReturnsNull()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAllButLast(3, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", null);

        Assert.That(result, Is.Null);
    }

    [TestCase]
    public void ObfuscateAllButLast_WithEmptyValue_ReturnsEmpty()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateAllButLast(3, "X-Token")
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Token", "");

        Assert.That(result, Is.EqualTo(""));
    }

    [TestCase]
    public void ObfuscateCustom_WithNullRule_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => HeaderObfuscator.Custom()
                .ObfuscateCustom("X-Custom", null)
                .Build()
        );

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("obfuscationRule is required"));
    }

    [TestCase]
    public void ObfuscateCustom_WithCustomRule_AppliesRuleToHeaderValue()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateCustom("X-Custom", CustomRule)
            .Build();

        var result = obfuscator.ObfuscateHeader("X-Custom", "test-value");

        Assert.That(result, Is.EqualTo("CUSTOM_10"));

        return;

        string CustomRule(string value) => value != null ? "CUSTOM_" + value.Length : null;
    }

    [TestCase]
    public void ObfuscateCustom_WithMultipleRules_AppliesEachRuleToMatchingHeader()
    {
        var obfuscator = HeaderObfuscator.Custom()
            .ObfuscateCustom("X-FirstHeader", FirstCustomRule)
            .ObfuscateCustom("X-SecondHeader", SecondCustomRule)
            .Build();

        Assert.That(obfuscator.ObfuscateHeader("X-FirstHeader", "firstTest"), Is.EqualTo("FIRSTRULE_firstTest"));
        Assert.That(obfuscator.ObfuscateHeader("X-SecondHeader", "secondTest"), Is.EqualTo("SECONDRULE_secondTest"));

        return;

        string SecondCustomRule(string value) => value != null ? "SECONDRULE_" + value : null;

        string FirstCustomRule(string value) => value != null ? "FIRSTRULE_" + value : null;
    }

    private static IEnumerable<TestCaseData> ObfuscateHeaderArgs()
    {
        yield return new TestCaseData("Authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
        yield return new TestCaseData("authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
        yield return new TestCaseData("AUTHORIZATION", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");

        yield return new TestCaseData("Authorization", null, null);
        yield return new TestCaseData("Authorization", "", "");

        yield return new TestCaseData("Content-Type", "application/json", "application/json");
        yield return new TestCaseData("content-type", "application/json", "application/json");
        yield return new TestCaseData("CONTENT-TYPE", "application/json", "application/json");
    }

    [TestCaseSource(nameof(ObfuscateHeaderArgs))]
    public void ObfuscateHeader_WithDefaultObfuscator_ReturnsExpectedValue(
        string headerName,
        string originalValue,
        string expectedObfuscatedValue)
    {
        var obfuscatedValue = HeaderObfuscator.DefaultObfuscator.ObfuscateHeader(headerName, originalValue);

        Assert.That(obfuscatedValue, Is.EqualTo(expectedObfuscatedValue));
    }

    private static IEnumerable<TestCaseData> ObfuscateCustomHeaderArgs()
    {
        var headerObfuscator = HeaderObfuscator.Custom()
            .ObfuscateAll("content-type")
            .Build();

        yield return new TestCaseData(headerObfuscator, "Authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
        yield return new TestCaseData(headerObfuscator, "authorization", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");
        yield return new TestCaseData(headerObfuscator, "AUTHORIZATION", "Basic QWxhZGRpbjpPcGVuU2VzYW1l", "********");

        yield return new TestCaseData(headerObfuscator, "Content-Type", "application/json", "****************");
        yield return new TestCaseData(headerObfuscator, "content-type", "application/json", "****************");
        yield return new TestCaseData(headerObfuscator, "CONTENT-TYPE", "application/json", "****************");
    }

    [TestCaseSource(nameof(ObfuscateCustomHeaderArgs))]
    public void ObfuscateHeader_WithCustomObfuscator_ReturnsExpectedValue(
        HeaderObfuscator headerObfuscator,
        string headerName,
        string originalValue,
        string expectedObfuscatedValue)
    {
        var obfuscatedValue = headerObfuscator.ObfuscateHeader(headerName, originalValue);

        Assert.That(obfuscatedValue, Is.EqualTo(expectedObfuscatedValue));
    }
}
