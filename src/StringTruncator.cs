namespace Philiprehberger.SmartTruncate;

/// <summary>Provides word-boundary-aware string truncation.</summary>
public static class StringTruncator
{
    /// <summary>Truncates <paramref name="text"/> to <paramref name="maxLength"/> characters, breaking at the last word boundary when possible.</summary>
    /// <param name="text">The string to truncate.</param>
    /// <param name="maxLength">Maximum allowed length including the suffix.</param>
    /// <param name="suffix">The suffix appended to truncated text (default <c>"..."</c>).</param>
    /// <returns>The original string if it fits, otherwise a truncated version with the suffix appended.</returns>
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
