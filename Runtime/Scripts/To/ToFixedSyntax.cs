// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for fixed-point number formatting with specified decimal places.
    /// Supports float, double, decimal and their nullable variants, as well as string conversion.
    /// All rounding operations use MidpointRounding.AwayFromZero strategy.
    /// </summary>
    public static class ToFixedSyntax
    {
        #region 32-bit (Float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFixed(this float value, int digits = 2) => (float)Math.Round(value, digits, MidpointRounding.AwayFromZero);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFixed(this float? value, int digits = 2) => value.HasValue ? (float)Math.Round(value.Value, digits, MidpointRounding.AwayFromZero) : 0f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFixedString(this float value, int digits = 2) => value.ToFixed(digits).ToString(FormatF.Get(digits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFixedString(this float? value, int digits = 2) => value.HasValue ? value.Value.ToFixed(digits).ToString(FormatF.Get(digits)) : string.Empty;

        #endregion

        #region 64-bit (Double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToFixed(this double value, int digits = 2) => Math.Round(value, digits, MidpointRounding.AwayFromZero);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToFixed(this double? value, int digits = 2) => value.HasValue ? Math.Round(value.Value, digits, MidpointRounding.AwayFromZero) : 0d;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFixedString(this double value, int digits = 2) => value.ToFixed(digits).ToString(FormatF.Get(digits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFixedString(this double? value, int digits = 2) => value.HasValue ? value.Value.ToFixed(digits).ToString(FormatF.Get(digits)) : string.Empty;

        #endregion

        #region 128-bit (Decimal)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToFixed(this decimal value, int digits = 2) => Math.Round(value, digits, MidpointRounding.AwayFromZero);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToFixed(this decimal? value, int digits = 2) => value.HasValue ? Math.Round(value.Value, digits, MidpointRounding.AwayFromZero) : 0m;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFixedString(this decimal value, int digits = 2) => value.ToFixed(digits).ToString(FormatF.Get(digits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFixedString(this decimal? value, int digits = 2) => value.HasValue ? value.Value.ToFixed(digits).ToString(FormatF.Get(digits)) : string.Empty;

        #endregion

        #region String

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFixed(this string value, int digits = 2) => string.IsNullOrEmpty(value) ? value : decimal.TryParse(value, out var number) ? number.ToFixedString(digits) : value;

        #endregion
    }
}