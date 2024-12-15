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
    public static class ToFloatSyntax
    {
        #region ToFloat - 1 Bits ( bool )

        /// <summary>
        /// Converts a boolean value to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>1.0f if true; 0.0f if false.</returns>
        /// <remarks>
        /// This conversion follows the standard convention:
        /// - true  → 1.0f
        /// - false → 0.0f
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this bool value) => value ? 1.0f : 0.0f;

        /// <summary>
        /// Converts a nullable boolean value to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>1.0f if true; 0.0f if false; default if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this bool? value, float @default = 0.0f) => value?.ToFloat() ?? @default;

        #endregion

        #region ToFloat - 8 Bits ( sbyte: -128 to 127, byte: 0 to 255 )

        /// <summary>
        /// Converts an 8-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 8-bit signed integer to convert (range: -128 to 127).</param>
        /// <returns>The value as a float (exact conversion, no precision loss).</returns>
        /// <remarks>
        /// This conversion is always safe as the sbyte range (-128 to 127)
        /// is well within float's precise integer range (±16,777,216).
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this sbyte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 8-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this sbyte? value, float @default = 0.0f) => value ?? @default;

        /// <summary>
        /// Converts an 8-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 8-bit unsigned integer to convert (range: 0 to 255).</param>
        /// <returns>The value as a float (exact conversion, no precision loss).</returns>
        /// <remarks>
        /// This conversion is always safe as the byte range (0 to 255)
        /// is well within float's precise integer range (±16,777,216).
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this byte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 8-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this byte? value, float @default = 0.0f) => value ?? @default;

        #endregion

        #region ToFloat - 16 Bits ( short: -32,768 to 32,767, ushort: 0 to 65,535, char: U+0000 to U+FFFF )

        /// <summary>
        /// Converts a 16-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 16-bit signed integer to convert (range: -32,768 to 32,767).</param>
        /// <returns>The value as a float (exact conversion, no precision loss).</returns>
        /// <remarks>
        /// This conversion is always safe as the short range (-32,768 to 32,767)
        /// is well within float's precise integer range (±16,777,216).
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this short value) => value;

        /// <summary>
        /// Converts a nullable 16-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 16-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this short? value, float @default = 0.0f) => value ?? @default;

        /// <summary>
        /// Converts a 16-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer to convert (range: 0 to 65,535).</param>
        /// <returns>The value as a float (exact conversion, no precision loss).</returns>
        /// <remarks>
        /// This conversion is always safe as the ushort range (0 to 65,535)
        /// is well within float's precise integer range (±16,777,216).
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this ushort value) => value;

        /// <summary>
        /// Converts a nullable 16-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 16-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this ushort? value, float @default = 0.0f) => value ?? @default;

        /// <summary>
        /// Converts a Unicode character to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The Unicode character to convert (range: U+0000 to U+FFFF).</param>
        /// <returns>The character's Unicode code point as a float (exact conversion, no precision loss).</returns>
        /// <remarks>
        /// This conversion is always safe as the char range (0 to 65,535)
        /// is well within float's precise integer range (±16,777,216).
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this char value) => value;

        /// <summary>
        /// Converts a nullable Unicode character to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable Unicode character to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The character's Unicode code point as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this char? value, float @default = 0.0f) => value ?? @default;

        #endregion

        #region ToFloat - 32 Bits ( int: ±2.1B, uint: 0~4.2B, float: ±3.4E+38 )

        /// <summary>
        /// Converts a 32-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 32-bit signed integer to convert (range: -2,147,483,648 to 2,147,483,647).</param>
        /// <returns>The value as a float.</returns>
        /// <remarks>
        /// Precision may be lost for values outside ±16,777,216 (2^24):
        /// - Exact conversion for values in range: -16,777,216 to +16,777,216
        /// - Possible precision loss for values outside this range
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this int value) => value;

        /// <summary>
        /// Converts a nullable 32-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 32-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this int? value, float @default = 0.0f) => value ?? @default;

        /// <summary>
        /// Converts a 32-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 32-bit unsigned integer to convert (range: 0 to 4,294,967,295).</param>
        /// <returns>The value as a float.</returns>
        /// <remarks>
        /// Precision may be lost for values above 16,777,216 (2^24):
        /// - Exact conversion for values in range: 0 to 16,777,216
        /// - Possible precision loss for larger values
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this uint value) => value;

        /// <summary>
        /// Converts a nullable 32-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 32-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this uint? value, float @default = 0.0f) => value ?? @default;

        /// <summary>
        /// Returns the input single-precision floating-point number unchanged.
        /// </summary>
        /// <param name="value">The single-precision floating-point number (range: ±3.4E+38).</param>
        /// <returns>The input value unchanged.</returns>
        /// <remarks>
        /// This is an identity operation with no value conversion:
        /// - Maintains all float characteristics (precision, special values)
        /// - Preserves NaN, ±Infinity, and subnormal values
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this float value) => value;

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a non-nullable float.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this float? value, float @default = 0.0f) => value ?? @default;

        #endregion

        #region ToFloat - 64 Bits ( long: ±9.2E+18, ulong: 0~18.4E+18, double: ±1.7E+308, DateTime: 1901~2038 UTC )

        /// <summary>
        /// Converts a 64-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 64-bit signed integer to convert (range: ±9.2E+18).</param>
        /// <returns>The value as a float.</returns>
        /// <remarks>
        /// Significant precision loss occurs for large values:
        /// - Exact conversion only for values in range: ±16,777,216 (2^24)
        /// - Gradually increasing precision loss beyond this range
        /// - Maximum relative error increases with magnitude of input
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this long value) => value;

        /// <summary>
        /// Converts a nullable 64-bit signed integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 64-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this long? value, float @default = 0.0f) => value ?? @default;

        /// <summary>
        /// Converts a 64-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The 64-bit unsigned integer to convert (range: 0 to 18.4E+18).</param>
        /// <returns>The value as a float.</returns>
        /// <remarks>
        /// Significant precision loss occurs for large values:
        /// - Exact conversion only for values up to 16,777,216 (2^24)
        /// - Gradually increasing precision loss beyond this range
        /// - Maximum relative error increases with magnitude of input
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this ulong value) => value;

        /// <summary>
        /// Converts a nullable 64-bit unsigned integer to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable 64-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this ulong? value, float @default = 0.0f) => value ?? @default;

        /// <summary>
        /// Converts a double-precision floating-point number to single-precision.
        /// </summary>
        /// <param name="value">The double-precision value to convert (range: ±1.7E+308).</param>
        /// <returns>The value as a float.</returns>
        /// <remarks>
        /// Precision loss characteristics:
        /// - Maintains approximate magnitude but loses precision
        /// - May overflow to ±Infinity if |value| > 3.4E+38
        /// - Preserves special values (NaN → NaN, ±Infinity → ±Infinity)
        /// - Subnormal doubles may become zero
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this double value) => (float)value;

        /// <summary>
        /// Converts a nullable double-precision floating-point number to single-precision.
        /// </summary>
        /// <param name="value">The nullable double-precision value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this double? value, float @default = 0.0f) => value?.ToFloat() ?? @default;

        #endregion

        #region ToFloat - 128+ Bits ( decimal: ±7.9E+28, string: parse float )

        /// <summary>
        /// Converts a decimal value to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The decimal value to convert (range: ±7.9E+28).</param>
        /// <returns>The value as a float.</returns>
        /// <remarks>
        /// Precision loss characteristics:
        /// - Decimal has 28-29 significant digits vs float's 6-7
        /// - Maintains approximate magnitude but loses precision
        /// - May overflow to ±Infinity if |value| > 3.4E+38
        /// - Exact decimal fractions may become inexact binary fractions
        /// - Preserves sign and approximate scale
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this decimal value) => (float)value;

        /// <summary>
        /// Converts a nullable decimal value to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0f.</param>
        /// <returns>The value as a float if not null; otherwise, the default value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this decimal? value, float @default = 0.0f) => value?.ToFloat() ?? @default;

        /// <summary>
        /// Parses a string to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The string to parse. Can contain decimal point, scientific notation (e.g., "1.23E-4").</param>
        /// <param name="default">The default value to return if parsing fails. Defaults to 0.0f.</param>
        /// <returns>
        /// - The parsed float value if successful
        /// - The default value if:
        ///   - Input is null or empty
        ///   - Input format is invalid
        ///   - Input represents a value outside float range
        /// </returns>
        /// <remarks>
        /// Parsing behavior:
        /// - Culture-invariant parsing
        /// - Accepts standard numeric formats
        /// - Handles scientific notation
        /// - Returns default for invalid inputs
        /// - Uses span-based parsing for performance
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat([CanBeNull] this string value, float @default = 0.0f) => string.IsNullOrEmpty(value) ? @default : float.TryParse(value.AsSpan(), out var result) ? result : @default;

        #endregion
    }
}