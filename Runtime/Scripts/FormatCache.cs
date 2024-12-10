// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Grow.Extensions
{
    /// <summary>
    /// Cache implementation for number format strings using a hybrid strategy:
    /// - Common precisions (0-5): Uses string.Intern for zero-allocation retrieval
    /// - Uncommon precisions (6-28): Uses LRU cache with capacity of 8
    /// - Invalid precisions: Negative numbers return "{Format}0", numbers > 28 are capped to 28
    /// </summary>
    public class FormatCache
    {
        private const int CommonDigits = 5;
        private const int CacheCapacity = 8;
        private const int MaxDigits = 28;
        private readonly Dictionary<int, string> _uncommonFormats = new(CacheCapacity);
        private readonly LinkedList<int> _lruList = new();
        private readonly object _syncRoot = new();
        private readonly string _formatSpecifier;

        public FormatCache(string formatSpecifier) => _formatSpecifier = formatSpecifier;

        public string Get(int digits)
        {
            if (digits < 0) return string.Intern($"{_formatSpecifier}0");
            if (digits > MaxDigits) digits = MaxDigits;
            if (digits <= CommonDigits) return string.Intern($"{_formatSpecifier}{digits}");

            lock (_syncRoot)
            {
                if (_uncommonFormats.TryGetValue(digits, out var format))
                {
                    _lruList.Remove(digits);
                    _lruList.AddFirst(digits);
                    return format;
                }

                if (_uncommonFormats.Count >= CacheCapacity)
                {
                    var lastKey = _lruList.Last.Value;
                    _lruList.RemoveLast();
                    _uncommonFormats.Remove(lastKey);
                }

                format = $"{_formatSpecifier}{digits}";
                _uncommonFormats.Add(digits, format);
                _lruList.AddFirst(digits);
                return format;
            }
        }
    }

    /// <summary>
    /// Cache for F-format strings using a hybrid strategy
    /// </summary>
    public static class FormatF
    {
        private static readonly FormatCache Cache = new("F");
        public static string Get(int digits) => Cache.Get(digits);
    }

    /// <summary>
    /// Cache for P-format strings using a hybrid strategy
    /// </summary>
    public static class FormatP
    {
        private static readonly FormatCache Cache = new("P");
        public static string Get(int digits) => Cache.Get(digits);
    }
}