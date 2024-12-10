// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.Globalization.CultureInfo;

namespace Grow.Extensions
{
    public static class ToFloorSyntax
    {
        #region 32-bit (Float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloor(this float value) => MathF.Floor(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloor(this float? value) => value.HasValue ? MathF.Floor(value.Value) : 0f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFloorString(this float value) => value.ToFloor().ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFloorString(this float? value) => value.HasValue ? value.Value.ToFloor().ToString(CurrentCulture) : string.Empty;

        #endregion

        #region 64-bit (Double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToFloor(this double value) => Math.Floor(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToFloor(this double? value) => value.HasValue ? Math.Floor(value.Value) : 0d;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFloorString(this double value) => value.ToFloor().ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFloorString(this double? value) => value.HasValue ? value.Value.ToFloor().ToString(CurrentCulture) : string.Empty;

        #endregion

        #region 128-bit (Decimal)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToFloor(this decimal value) => Math.Floor(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToFloor(this decimal? value) => value.HasValue ? Math.Floor(value.Value) : 0m;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFloorString(this decimal value) => value.ToFloor().ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFloorString(this decimal? value) => value.HasValue ? value.Value.ToFloor().ToString(CurrentCulture) : string.Empty;

        #endregion

        #region String

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToFloor(this string value) => string.IsNullOrEmpty(value) ? string.Empty : decimal.TryParse(value, out var number) ? number.ToFloor().ToString(CurrentCulture) : value;

        #endregion
    }
}