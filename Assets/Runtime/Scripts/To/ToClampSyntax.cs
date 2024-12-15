// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.Globalization.CultureInfo;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for clamping values within a specified range.
    /// Returns a value clamped to the inclusive range of min and max.
    /// </summary>
    public static class ToClampSyntax
    {
        #region ToClamp - 8 Bits (sbyte, byte)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ToClamp(this sbyte value, sbyte min, sbyte max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ToClamp(this sbyte? value, sbyte min, sbyte max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToClamp(this byte value, byte min, byte max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToClamp(this byte? value, byte min, byte max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        #endregion

        #region ToClamp - 16 Bits (short, ushort)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToClamp(this short value, short min, short max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToClamp(this short? value, short min, short max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ToClamp(this ushort value, ushort min, ushort max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ToClamp(this ushort? value, ushort min, ushort max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        #endregion

        #region ToClamp - 32 Bits (int, uint, float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToClamp(this int value, int min, int max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToClamp(this int? value, int min, int max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToClamp(this uint value, uint min, uint max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToClamp(this uint? value, uint min, uint max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToClamp(this float value, float min, float max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToClamp(this float? value, float min, float max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        #endregion

        #region ToClamp - 64 Bits (long, ulong, double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToClamp(this long value, long min, long max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToClamp(this long? value, long min, long max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToClamp(this ulong value, ulong min, ulong max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToClamp(this ulong? value, ulong min, ulong max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToClamp(this double value, double min, double max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToClamp(this double? value, double min, double max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        #endregion

        #region ToClamp - 128+ Bits (decimal, string)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToClamp(this decimal value, decimal min, decimal max) => Math.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToClamp(this decimal? value, decimal min, decimal max) => value.HasValue ? Math.Clamp(value.Value, min, max) : min;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToClamp(this string value, decimal min, decimal max)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return decimal.TryParse(value, out var number) ? Math.Clamp(number, min, max).ToString(CurrentCulture) : value;
        }

        #endregion
    }
}