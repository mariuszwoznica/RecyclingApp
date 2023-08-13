using System;

namespace RecyclingApp.Application.Helpers;

internal static class StringHelpers
{
    internal static bool IsNullOrWhiteSpace(this String? text)
        => String.IsNullOrWhiteSpace(text);
}
