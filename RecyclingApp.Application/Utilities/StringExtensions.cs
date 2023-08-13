namespace RecyclingApp.Application.Utilities;

internal static class StringExtensions
{
    internal static bool IsNullOrWhiteSpace(this string? text)
        => string.IsNullOrWhiteSpace(text);
}
