using System.Text;
using NUnit.Framework;

namespace OnlinePayments.Sdk;

[TestFixture]
public class StringBuilderUtilsTest
{
    [TestCase("hello", "hello\n")]
    public void AppendLLine_AppendsStringAndNewline(string value, string expected)
    {
        StringBuilder sb = new();

        sb.AppendLLine(value);

        Assert.That(sb.ToString(), Is.EqualTo(expected));
    }

    [TestCase("", "\n")]
    public void AppendLLine_WithEmptyString_AppendsOnlyNewline(string value, string expected)
    {
        StringBuilder sb = new();

        sb.AppendLLine(value);

        Assert.That(sb.ToString(), Is.EqualTo(expected));
    }

    [TestCase("line1", "line2", "line1\nline2\n")]
    public void AppendLLine_MultipleCalls_AppendsAll(string firstValue, string secondValue, string expected)
    {
        StringBuilder sb = new();

        sb.AppendLLine(firstValue)
            .AppendLLine(secondValue);

        Assert.That(sb.ToString(), Is.EqualTo(expected));
    }
}
