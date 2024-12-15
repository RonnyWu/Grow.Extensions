// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ToShortSyntax
    {
        #region ToShort - 1 Bits ( bool )

        /// <summary>
        /// Converts a boolean value to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>1 if true; 0 if false.</returns>
        /// <remarks>
        /// This conversion is lossless and deterministic:
        /// - true → 1
        /// - false → 0
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this bool value) => value ? (short)1 : (short)0;

        /// <summary>
        /// Converts a nullable boolean value to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>1 if true; 0 if false; default if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this bool? value, short @default = 0) => value?.ToShort() ?? @default;

        #endregion

        #region ToShort - 8 Bits ( sbyte: -128 to 127, byte: 0 to 255 )

        /// <summary>
        /// Converts an 8-bit signed integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The 8-bit signed integer to convert (range: -128 to 127).</param>
        /// <returns>The value converted to a 16-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion that preserves the sign and value.
        /// Example: sbyte value = -128; short result = value.ToShort(); // Returns -128
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this sbyte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit signed integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 8-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to short if not null; the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this sbyte? value, short @default = 0) => value ?? @default;

        /// <summary>
        /// Converts an 8-bit unsigned integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The 8-bit unsigned integer to convert (range: 0 to 255).</param>
        /// <returns>The value converted to a 16-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion as byte range (0 to 255) fits within short range.
        /// Example: byte value = 255; short result = value.ToShort(); // Returns 255
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this byte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit unsigned integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 8-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to short if not null; the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this byte? value, short @default = 0) => value ?? @default;

        #endregion

        #region ToShort - 16 Bits ( short: -32,768 to 32,767, ushort: 0 to 65,535, char: U+0000 to U+FFFF )

        /// <summary>
        /// Returns the input 16-bit signed integer value unchanged.
        /// </summary>
        /// <param name="value">The 16-bit signed integer (range: -32,768 to 32,767).</param>
        /// <returns>The input value unchanged.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this short value) => value;

        /// <summary>
        /// Converts a nullable 16-bit signed integer to a non-nullable value.
        /// </summary>
        /// <param name="value">The nullable 16-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The input value if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this short? value, short @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a 16-bit unsigned integer to a 16-bit signed integer with overflow checking.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer to convert (range: 0 to 65,535).</param>
        /// <param name="default">The default value to return if the input exceeds short.MaxValue. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        /// <remarks>
        /// Values larger than 32,767 will return the default value to prevent overflow.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this ushort value, short @default = 0) => value <= short.MaxValue ? (short)value : @default;

        /// <summary>
        /// Converts a nullable 16-bit unsigned integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 16-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this ushort? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        /// <summary>
        /// Converts a Unicode character to a 16-bit signed integer with overflow checking.
        /// </summary>
        /// <param name="value">The Unicode character to convert (range: U+0000 to U+FFFF).</param>
        /// <param name="default">The default value to return if the character value exceeds short.MaxValue. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        /// <remarks>
        /// Characters with code points larger than 32,767 will return the default value.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this char value, short @default = 0) => value <= short.MaxValue ? (short)value : @default;

        /// <summary>
        /// Converts a nullable Unicode character to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable Unicode character to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this char? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        #endregion

        #region ToShort - 32 Bits ( int: ±2.1B, uint: 0~4.2B, float: ±3.4E+38 )

        /// <summary>
        /// Converts a 32-bit signed integer to a 16-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The 32-bit signed integer to convert (valid range: -32,768 to 32,767).</param>
        /// <param name="default">The default value to return if the input is outside the valid range. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this int value, short @default = 0) => value is >= short.MinValue and <= short.MaxValue ? (short)value : @default;

        /// <summary>
        /// Converts a nullable 32-bit signed integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 32-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this int? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        /// <summary>
        /// Converts a 32-bit unsigned integer to a 16-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The 32-bit unsigned integer to convert (valid range: 0 to 32,767).</param>
        /// <param name="default">The default value to return if the input exceeds the valid range. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this uint value, short @default = 0) => value <= short.MaxValue ? (short)value : @default;

        /// <summary>
        /// Converts a nullable 32-bit unsigned integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 32-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this uint? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        /// <summary>
        /// Converts a single-precision floating-point number to a 16-bit signed integer with range and validity checks.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert (valid range: -32,768 to 32,767).</param>
        /// <param name="default">The default value to return if the input is invalid or outside the range. Defaults to 0.</param>
        /// <returns>The converted value if finite and within valid range; otherwise, the default value.</returns>
        /// <remarks>
        /// Returns default value for:
        /// - Non-finite values (NaN, ±Infinity)
        /// - Values outside short range
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this float value, short @default = 0) => float.IsFinite(value) ? value is >= short.MinValue and <= short.MaxValue ? (short)value : @default : @default;

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null, finite, and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this float? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        #endregion

        #region ToShort - 64 Bits ( long: ±9.2E+18, ulong: 0~18.4E+18, double: ±1.7E+308, DateTime: 1901~2038 UTC )

        /// <summary>
        /// Converts a 64-bit signed integer to a 16-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The 64-bit signed integer to convert (valid range: -32,768 to 32,767).</param>
        /// <param name="default">The default value to return if the input is outside the valid range. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this long value, short @default = 0) => value is >= short.MinValue and <= short.MaxValue ? (short)value : @default;

        /// <summary>
        /// Converts a nullable 64-bit signed integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 64-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this long? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        /// <summary>
        /// Converts a 64-bit unsigned integer to a 16-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The 64-bit unsigned integer to convert (valid range: 0 to 32,767).</param>
        /// <param name="default">The default value to return if the input exceeds the valid range. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this ulong value, short @default = 0) => value <= (ulong)short.MaxValue ? (short)value : @default;

        /// <summary>
        /// Converts a nullable 64-bit unsigned integer to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 64-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this ulong? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        /// <summary>
        /// Converts a double-precision floating-point number to a 16-bit signed integer with range and validity checks.
        /// </summary>
        /// <param name="value">The double-precision floating-point number to convert (valid range: -32,768 to 32,767).</param>
        /// <param name="default">The default value to return if the input is invalid or outside the range. Defaults to 0.</param>
        /// <returns>The converted value if finite and within valid range; otherwise, the default value.</returns>
        /// <remarks>
        /// Returns default value for:
        /// - Non-finite values (NaN, ±Infinity)
        /// - Values outside short range
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this double value, short @default = 0) => double.IsFinite(value) ? value is >= short.MinValue and <= short.MaxValue ? (short)value : @default : @default;

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null, finite, and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this double? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        #endregion

        #region ToShort - 128+ Bits ( decimal: ±7.9E+28, string: parse short )

        /// <summary>
        /// Converts a decimal value to a 16-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The decimal value to convert (valid range: -32,768 to 32,767).</param>
        /// <param name="default">The default value to return if the input is outside the valid range. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        /// <remarks>
        /// Decimal values are truncated to integer before conversion.
        /// Values outside the short range will return the default value.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort(this decimal value, short @default = 0) => value is >= short.MinValue and <= short.MaxValue ? (short)value : @default;

        /// <summary>
        /// Converts a nullable decimal value to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <param name="default">The default value to return if the input is null or invalid. Defaults to 0.</param>
        /// <returns>The converted value if not null and valid; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this decimal? value, short @default = 0) => value?.ToShort(@default) ?? @default;

        /// <summary>
        /// Converts a string representation of a number to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The string to convert. Must represent a valid short integer.</param>
        /// <param name="default">The default value to return if parsing fails. Defaults to 0.</param>
        /// <returns>
        /// The parsed short value if successful; otherwise, the default value.
        /// </returns>
        /// <remarks>
        /// Returns default value for:
        /// - Null or empty strings
        /// - Non-numeric strings
        /// - Numbers outside short range
        /// Uses Span-based parsing for better performance.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort([CanBeNull] this string value, short @default = 0) => string.IsNullOrEmpty(value) ? @default : short.TryParse(value.AsSpan(), out var result) ? result : @default;

        #endregion
    }
}