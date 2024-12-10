// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.Globalization.CultureInfo;
using static System.MidpointRounding;

namespace Grow.Extensions
{
    public static class ToRoundSyntax
    {
        #region 32-bit (Float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRound(this float value, int digits = 2, MidpointRounding model = AwayFromZero) => MathF.Round(value, digits, model);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRound(this float? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? MathF.Round(value.Value, digits, model) : 0f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRoundString(this float value, int digits = 2, MidpointRounding model = AwayFromZero) => value.ToRound(digits, model).ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRoundString(this float? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? value.Value.ToRound(digits, model).ToString(CurrentCulture) : string.Empty;

        #endregion

        #region 64-bit (Double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRound(this double value, int digits = 2, MidpointRounding model = AwayFromZero) => Math.Round(value, digits, model);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRound(this double? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? Math.Round(value.Value, digits, model) : 0d;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRoundString(this double value, int digits = 2, MidpointRounding model = AwayFromZero) => value.ToRound(digits, model).ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRoundString(this double? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? value.Value.ToRound(digits, model).ToString(CurrentCulture) : string.Empty;

        #endregion

        #region 128-bit (Decimal)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToRound(this decimal value, int digits = 2, MidpointRounding model = AwayFromZero) => Math.Round(value, digits, model);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToRound(this decimal? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? Math.Round(value.Value, digits, model) : 0m;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRoundString(this decimal value, int digits = 2, MidpointRounding model = AwayFromZero) => value.ToRound(digits, model).ToString(CurrentCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRoundString(this decimal? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? value.Value.ToRound(digits, model).ToString(CurrentCulture) : string.Empty;

        #endregion

        #region String

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToRound(this string value, int digits = 2, MidpointRounding model = AwayFromZero) => string.IsNullOrEmpty(value) ? string.Empty : decimal.TryParse(value, out var number) ? number.ToRound(digits, model).ToString(CurrentCulture) : value;

        #endregion
    }
}