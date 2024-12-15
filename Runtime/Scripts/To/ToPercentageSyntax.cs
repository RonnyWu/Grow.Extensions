// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using static System.MidpointRounding;

namespace Grow.Extensions
{
    public static class ToPercentageSyntax
    {
        #region 32-bit (Float)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPercentage(this float value, int digits = 2, MidpointRounding model = AwayFromZero) => MathF.Round(value, digits, model).ToString(FormatP.Get(digits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPercentage(this float? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? MathF.Round(value.Value, digits, model).ToString(FormatP.Get(digits)) : string.Empty;

        #endregion

        #region 64-bit (Double)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPercentage(this double value, int digits = 2, MidpointRounding model = AwayFromZero) => Math.Round(value, digits, model).ToString(FormatP.Get(digits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPercentage(this double? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? Math.Round(value.Value, digits, model).ToString(FormatP.Get(digits)) : string.Empty;

        #endregion

        #region 128-bit (Decimal)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPercentage(this decimal value, int digits = 2, MidpointRounding model = AwayFromZero) => Math.Round(value, digits, model).ToString(FormatP.Get(digits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPercentage(this decimal? value, int digits = 2, MidpointRounding model = AwayFromZero) => value.HasValue ? Math.Round(value.Value, digits, model).ToString(FormatP.Get(digits)) : string.Empty;

        #endregion

        #region String

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToPercentage(this string value, int digits = 2, MidpointRounding model = AwayFromZero) => string.IsNullOrEmpty(value) ? value : decimal.TryParse(value, out var number) ? number.ToPercentage(digits, model) : value;

        #endregion
    }
}