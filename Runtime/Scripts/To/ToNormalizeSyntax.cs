// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.Globalization.CultureInfo;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for normalizing values to a range between 0 and 1.
    /// For a value in range [min, max], returns its normalized form: (value - min) / (max - min)
    /// </summary>
    public static class ToNormalizeSyntax
    {
        #region ToNormalize - 8 Bits (sbyte, byte)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this sbyte value, sbyte min, sbyte max) => Math.Abs((float)(max - min)) < float.Epsilon ? 0f : (float)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this sbyte? value, sbyte min, sbyte max) => !value.HasValue ? 0f : ToNormalize(value.Value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this byte value, byte min, byte max) => Math.Abs((float)(max - min)) < float.Epsilon ? 0f : (float)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this byte? value, byte min, byte max) => !value.HasValue ? 0f : ToNormalize(value.Value, min, max);

        #endregion

        #region ToNormalize - 16 Bits (short, ushort)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this short value, short min, short max) => Math.Abs((float)(max - min)) < float.Epsilon ? 0f : (float)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this short? value, short min, short max) => !value.HasValue ? 0f : ToNormalize(value.Value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this ushort value, ushort min, ushort max) => Math.Abs((float)(max - min)) < float.Epsilon ? 0f : (float)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this ushort? value, ushort min, ushort max) => !value.HasValue ? 0f : ToNormalize(value.Value, min, max);

        #endregion

        #region ToNormalize - 32 Bits (int, uint, float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this int value, int min, int max) => Math.Abs((float)(max - min)) < float.Epsilon ? 0f : (float)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this int? value, int min, int max) => !value.HasValue ? 0f : ToNormalize(value.Value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this uint value, uint min, uint max) => Math.Abs((float)(max - min)) < float.Epsilon ? 0f : (float)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this uint? value, uint min, uint max) => !value.HasValue ? 0f : ToNormalize(value.Value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this float value, float min, float max) => Math.Abs(max - min) < float.Epsilon ? 0f : (value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToNormalize(this float? value, float min, float max) => !value.HasValue ? 0f : ToNormalize(value.Value, min, max);

        #endregion

        #region ToNormalize - 64 Bits (long, ulong, double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToNormalize(this long value, long min, long max) => Math.Abs((double)(max - min)) < double.Epsilon ? 0d : (double)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToNormalize(this long? value, long min, long max) => !value.HasValue ? 0d : ToNormalize(value.Value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToNormalize(this ulong value, ulong min, ulong max) => Math.Abs((double)(max - min)) < double.Epsilon ? 0d : (double)(value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToNormalize(this ulong? value, ulong min, ulong max) => !value.HasValue ? 0d : ToNormalize(value.Value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToNormalize(this double value, double min, double max) => Math.Abs(max - min) < double.Epsilon ? 0d : (value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToNormalize(this double? value, double min, double max) => !value.HasValue ? 0d : ToNormalize(value.Value, min, max);

        #endregion

        #region ToNormalize - 128+ Bits (decimal, string)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToNormalize(this decimal value, decimal min, decimal max) => max - min == 0m ? 0m : (value - min) / (max - min);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToNormalize(this decimal? value, decimal min, decimal max) => !value.HasValue ? 0m : ToNormalize(value.Value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToNormalize(this string value, decimal min, decimal max)
        {
            if (string.IsNullOrEmpty(value)) return value;
            if (!decimal.TryParse(value, out var number)) return value;
            return max - min == 0m ? "0" : ((number - min) / (max - min)).ToString(CurrentCulture);
        }

        #endregion
    }
}