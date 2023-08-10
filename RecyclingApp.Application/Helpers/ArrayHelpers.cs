using System;

namespace RecyclingApp.Application.Helpers;

internal static class ArrayHelpers
{
    internal static bool IsNullOrEmpty(this Array? array)
        => array == null || array.Length == 0;
}
