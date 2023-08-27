using System;
using System.Linq;

namespace RecyclingApp.Tests.Common.Utilities;

public static class RandomGenerator
{
    private static readonly Random _rnd = new();
    private static readonly string _range = "qwertyuiopasdfghjklzxcvbnm";

    public static string GetText(int length = 8)
        => new(Enumerable.Range(0, length).Select(x => _range[_rnd.Next(_range.Length)]).ToArray());
}
