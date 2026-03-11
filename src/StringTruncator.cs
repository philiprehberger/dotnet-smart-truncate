namespace Philiprehberger.SmartTruncate;

public static class StringTruncator
{
    public static string Truncate(string text, int maxLength, string suffix = "...")
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;

        if (maxLength <= 0)
            return string.Empty;

        var suffixLength = suffix.Length;
        var trimLength = maxLength - suffixLength;

        if (trimLength <= 0)
            return suffix[..Math.Min(suffix.Length, maxLength)];

        var slice = text[..trimLength];
        var lastSpace = slice.LastIndexOf(' ');

        if (lastSpace > 0)
            return text[..lastSpace] + suffix;

        return text[..trimLength] + suffix;
    }
}
