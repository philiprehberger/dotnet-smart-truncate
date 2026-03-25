using Xunit;
namespace Philiprehberger.SmartTruncate.Tests;

public class StringTruncatorTests
{
    [Fact]
    public void Truncate_ShortText_ReturnsOriginal()
    {
        var result = StringTruncator.Truncate("hello", 10);

        Assert.Equal("hello", result);
    }

    [Fact]
    public void Truncate_ExactLength_ReturnsOriginal()
    {
        var result = StringTruncator.Truncate("hello", 5);

        Assert.Equal("hello", result);
    }

    [Fact]
    public void Truncate_LongText_TruncatesAtWordBoundary()
    {
        var result = StringTruncator.Truncate("the quick brown fox jumps", 15);

        Assert.Equal("the quick...", result);
    }

    [Fact]
    public void Truncate_NoWordBoundary_HardTruncates()
    {
        var result = StringTruncator.Truncate("abcdefghijklmnop", 10);

        Assert.Equal("abcdefg...", result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Truncate_NullOrEmpty_ReturnsSameValue(string? input)
    {
        var result = StringTruncator.Truncate(input!, 10);

        Assert.Equal(input, result);
    }

    [Fact]
    public void Truncate_MaxLengthZero_ReturnsEmpty()
    {
        var result = StringTruncator.Truncate("hello world", 0);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Truncate_CustomSuffix_UsesSuffix()
    {
        var result = StringTruncator.Truncate("the quick brown fox", 14, "…");

        Assert.EndsWith("…", result);
        Assert.True(result.Length <= 14);
    }

    [Fact]
    public void Truncate_MaxLengthShorterThanSuffix_TruncatesSuffix()
    {
        var result = StringTruncator.Truncate("hello world", 2);

        Assert.Equal("..", result);
    }

    [Theory]
    [InlineData("hello world", 8, "...", "hello...")]
    [InlineData("one two three four", 12, "...", "one two...")]
    public void Truncate_VariousInputs_ReturnsExpected(string text, int maxLength, string suffix, string expected)
    {
        var result = StringTruncator.Truncate(text, maxLength, suffix);

        Assert.Equal(expected, result);
    }
}
