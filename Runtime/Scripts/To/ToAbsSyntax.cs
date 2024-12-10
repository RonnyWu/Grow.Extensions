// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.Globalization.CultureInfo;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for computing absolute values of numeric types.
    /// Returns the absolute value of a number, preserving the original type.
    /// </summary>
    public static class ToAbsSyntax
    {
        #region ToAbs - 8 Bits (sbyte)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ToAbs(this sbyte value) => Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ToAbs(this sbyte? value) => value.HasValue ? Math.Abs(value.Value) : (sbyte)0;

        #endregion

        #region ToAbs - 16 Bits (short)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToAbs(this short value) => Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToAbs(this short? value) => value.HasValue ? Math.Abs(value.Value) : (short)0;

        #endregion

        #region ToAbs - 32 Bits (int, float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToAbs(this int value) => Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToAbs(this int? value) => value.HasValue ? Math.Abs(value.Value) : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToAbs(this float value) => MathF.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToAbs(this float? value) => value.HasValue ? MathF.Abs(value.Value) : 0f;

        #endregion

        #region ToAbs - 64 Bits (long, double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToAbs(this long value) => Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToAbs(this long? value) => value.HasValue ? Math.Abs(value.Value) : 0L;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToAbs(this double value) => Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToAbs(this double? value) => value.HasValue ? Math.Abs(value.Value) : 0d;

        #endregion

        #region ToAbs - 128+ Bits (decimal, string)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToAbs(this decimal value) => Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToAbs(this decimal? value) => value.HasValue ? Math.Abs(value.Value) : 0m;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToAbs(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return decimal.TryParse(value, out var decimalValue) ? Math.Abs(decimalValue).ToString(CurrentCulture) : value;
        }

        #endregion
    }
}