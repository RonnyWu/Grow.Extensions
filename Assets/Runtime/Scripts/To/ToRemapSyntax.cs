// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.Globalization.CultureInfo;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for remapping values from one range to another.
    /// For a value in range [inMin, inMax], returns its remapped value in range [outMin, outMax]
    /// </summary>
    public static class ToRemapSyntax
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float RemapToFloat(float value, float inMin, float inMax, float outMin, float outMax) => Math.Abs(inMax - inMin) < float.Epsilon ? outMin : outMin + (outMax - outMin) * ((value - inMin) / (inMax - inMin));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double RemapToDouble(double value, double inMin, double inMax, double outMin, double outMax) => Math.Abs(inMax - inMin) < double.Epsilon ? outMin : outMin + (outMax - outMin) * ((value - inMin) / (inMax - inMin));

        #region ToRemap - 8 Bits (sbyte, byte)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this sbyte value, sbyte inMin, sbyte inMax, float outMin, float outMax) => RemapToFloat(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this sbyte? value, sbyte inMin, sbyte inMax, float outMin, float outMax) => !value.HasValue ? outMin : RemapToFloat(value.Value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this byte value, byte inMin, byte inMax, float outMin, float outMax) => RemapToFloat(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this byte? value, byte inMin, byte inMax, float outMin, float outMax) => !value.HasValue ? outMin : RemapToFloat(value.Value, inMin, inMax, outMin, outMax);

        #endregion

        #region ToRemap - 16 Bits (short, ushort)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this short value, short inMin, short inMax, float outMin, float outMax) => RemapToFloat(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this short? value, short inMin, short inMax, float outMin, float outMax) => !value.HasValue ? outMin : RemapToFloat(value.Value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this ushort value, ushort inMin, ushort inMax, float outMin, float outMax) => RemapToFloat(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this ushort? value, ushort inMin, ushort inMax, float outMin, float outMax) => !value.HasValue ? outMin : RemapToFloat(value.Value, inMin, inMax, outMin, outMax);

        #endregion

        #region ToRemap - 32 Bits (int, uint, float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this int value, int inMin, int inMax, float outMin, float outMax) => RemapToFloat(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this int? value, int inMin, int inMax, float outMin, float outMax) => !value.HasValue ? outMin : RemapToFloat(value.Value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this uint value, uint inMin, uint inMax, float outMin, float outMax) => RemapToFloat(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this uint? value, uint inMin, uint inMax, float outMin, float outMax) => !value.HasValue ? outMin : RemapToFloat(value.Value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this float value, float inMin, float inMax, float outMin, float outMax) => RemapToFloat(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRemap(this float? value, float inMin, float inMax, float outMin, float outMax) => !value.HasValue ? outMin : RemapToFloat(value.Value, inMin, inMax, outMin, outMax);

        #endregion

        #region ToRemap - 64 Bits (long, ulong, double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRemap(this long value, long inMin, long inMax, double outMin, double outMax) => RemapToDouble(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRemap(this long? value, long inMin, long inMax, double outMin, double outMax) => !value.HasValue ? outMin : RemapToDouble(value.Value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRemap(this ulong value, ulong inMin, ulong inMax, double outMin, double outMax) => RemapToDouble(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRemap(this ulong? value, ulong inMin, ulong inMax, double outMin, double outMax) => !value.HasValue ? outMin : RemapToDouble(value.Value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRemap(this double value, double inMin, double inMax, double outMin, double outMax) => RemapToDouble(value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRemap(this double? value, double inMin, double inMax, double outMin, double outMax) => !value.HasValue ? outMin : RemapToDouble(value.Value, inMin, inMax, outMin, outMax);

        #endregion

        #region ToRemap - 128+ Bits (decimal, string)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToRemap(this decimal value, decimal inMin, decimal inMax, decimal outMin, decimal outMax) => inMax - inMin == 0m ? outMin : outMin + (outMax - outMin) * ((value - inMin) / (inMax - inMin));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToRemap(this decimal? value, decimal inMin, decimal inMax, decimal outMin, decimal outMax) => !value.HasValue ? outMin : ToRemap(value.Value, inMin, inMax, outMin, outMax);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRemap(this string value, decimal inMin, decimal inMax, decimal outMin, decimal outMax)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return !decimal.TryParse(value, out var number) ? value : ToRemap(number, inMin, inMax, outMin, outMax).ToString(CurrentCulture);
        }

        #endregion
    }
}