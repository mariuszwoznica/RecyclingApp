using System;

namespace RecyclingApp.Application.Utilities;

internal static class ArrayExtensions
{
    internal static bool IsNullOrEmpty(this Array? array)
        => array == null || array.Length == 0;
}
