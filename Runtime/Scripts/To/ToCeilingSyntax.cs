// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.Globalization.CultureInfo;

namespace Grow.Extensions
{
    public static class ToCeilingSyntax
    {
        #region 32-bit (Float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToCeiling(this float value) => MathF.Ceiling(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToCeiling(this float? value) => value.HasValue ? MathF.Ceiling(value.Value) : 0f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCeilingString(this float value) => value.ToCeiling().ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCeilingString(this float? value) => value.HasValue ? value.Value.ToCeiling().ToString(CurrentCulture) : string.Empty;

        #endregion

        #region 64-bit (Double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToCeiling(this double value) => Math.Ceiling(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToCeiling(this double? value) => value.HasValue ? Math.Ceiling(value.Value) : 0d;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCeilingString(this double value) => value.ToCeiling().ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCeilingString(this double? value) => value.HasValue ? value.Value.ToCeiling().ToString(CurrentCulture) : string.Empty;

        #endregion

        #region 128-bit (Decimal)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToCeiling(this decimal value) => Math.Ceiling(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToCeiling(this decimal? value) => value.HasValue ? Math.Ceiling(value.Value) : 0m;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCeilingString(this decimal value) => value.ToCeiling().ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCeilingString(this decimal? value) => value.HasValue ? value.Value.ToCeiling().ToString(CurrentCulture) : string.Empty;

        #endregion

        #region String

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCeiling(this string value) => string.IsNullOrEmpty(value) ? value : decimal.TryParse(value, out var number) ? number.ToCeiling().ToString(CurrentCulture) : value;

        #endregion
    }
}