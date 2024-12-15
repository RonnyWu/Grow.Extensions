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
    public static class ToLongSyntax
    {
        private const decimal DecimalLongMax = long.MaxValue;
        private const decimal DecimalLongMin = long.MinValue;

        #region ToLong - 1 Bits ( bool: true/false → 1/0 )

        /// <summary>
        /// Converts a boolean value to a 64-bit signed integer (1 for true, 0 for false).
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>1L if the value is true; 0L if the value is false.</returns>
        /// <remarks>
        /// This is a high-performance conversion method commonly used in bitwise operations and flags.
        /// The conversion is guaranteed to be safe and consistent across all platforms.
        /// Example:
        /// <code>
        /// bool flag = true;
        /// long bits = flag.ToLong(); // Returns 1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this bool value) => value ? 1L : 0L;

        /// <summary>
        /// Converts a nullable boolean value to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// 1L if the value is true;
        /// 0L if the value is false;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method provides a null-safe way to convert boolean values to long integers.
        /// Example:
        /// <code>
        /// bool? flag = true;
        /// long bits1 = flag.ToLong(); // Returns 1
        ///   
        /// bool? nullFlag = null;
        /// long bits2 = nullFlag.ToLong(); // Returns 0 (default)
        /// long bits3 = nullFlag.ToLong(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this bool? value, long @default = 0) => value?.ToLong() ?? @default;

        #endregion

        #region ToLong - 8 Bits ( sbyte: -128 to 127, byte: 0 to 255 )

        /// <summary>
        /// Converts an 8-bit signed integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The 8-bit signed integer to convert (range: -128 to 127).</param>
        /// <returns>The value converted to a 64-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion that preserves the sign and value.
        /// Example:
        /// <code>
        /// sbyte small = -42;
        /// long converted = small.ToLong(); // Returns -42L
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this sbyte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit signed integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 8-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to long if not null; the default value if null.</returns>
        /// <remarks>
        /// Provides null-safe conversion with customizable default value.
        /// Example:
        /// <code>
        /// sbyte? value = 127;
        /// long converted1 = value.ToLong(); // Returns 127L
        ///   
        /// sbyte? nullValue = null;
        /// long converted2 = nullValue.ToLong(); // Returns 0L
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this sbyte? value, long @default = 0) => value ?? @default;

        /// <summary>
        /// Converts an 8-bit unsigned integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The 8-bit unsigned integer to convert (range: 0 to 255).</param>
        /// <returns>The value converted to a 64-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion that preserves the value.
        /// Example:
        /// <code>
        /// byte value = 255;
        /// long converted = value.ToLong(); // Returns 255L
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this byte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit unsigned integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 8-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to long if not null; the default value if null.</returns>
        /// <remarks>
        /// Provides null-safe conversion with customizable default value.
        /// Example:
        /// <code>
        /// byte? value = 200;
        /// long converted1 = value.ToLong(); // Returns 200L
        ///   
        /// byte? nullValue = null;
        /// long converted2 = nullValue.ToLong(); // Returns 0L
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this byte? value, long @default = 0) => value ?? @default;

        #endregion

        #region ToLong - 16 Bits ( short: -32,768 to 32,767, ushort: 0 to 65,535, char: U+0000 to U+FFFF )

        /// <summary>
        /// Converts a 16-bit signed integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The 16-bit signed integer to convert (range: -32,768 to 32,767).</param>
        /// <returns>The value converted to a 64-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion that preserves the sign and value.
        /// Example: short value = -12345; long result = value.ToLong(); // Returns -12345L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this short value) => value;

        /// <summary>
        /// Converts a nullable 16-bit signed integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 16-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to long if not null; the default value if null.</returns>
        /// <remarks>
        /// Provides null-safe conversion with customizable default value.
        /// Example: short? value = null; long result = value.ToLong(-1); // Returns -1L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this short? value, long @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a 16-bit unsigned integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer to convert (range: 0 to 65,535).</param>
        /// <returns>The value converted to a 64-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion that preserves the value.
        /// Example: ushort value = 65000; long result = value.ToLong(); // Returns 65000L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this ushort value) => value;

        /// <summary>
        /// Converts a nullable 16-bit unsigned integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 16-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to long if not null; the default value if null.</returns>
        /// <remarks>
        /// Provides null-safe conversion with customizable default value.
        /// Example: ushort? value = null; long result = value.ToLong(); // Returns 0L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this ushort? value, long @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a Unicode character to a 64-bit signed integer using its UTF-16 code unit value.
        /// </summary>
        /// <param name="value">The Unicode character to convert (range: U+0000 to U+FFFF).</param>
        /// <returns>The UTF-16 code unit value as a 64-bit signed integer.</returns>
        /// <remarks>
        /// This conversion uses the character's UTF-16 code unit value.
        /// Example: char value = 'A'; long result = value.ToLong(); // Returns 65L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this char value) => value;

        /// <summary>
        /// Converts a nullable Unicode character to a 64-bit signed integer using its UTF-16 code unit value.
        /// </summary>
        /// <param name="value">The nullable Unicode character to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The UTF-16 code unit value as long if not null; the default value if null.</returns>
        /// <remarks>
        /// Provides null-safe conversion with customizable default value.
        /// Example: char? value = '世'; long result = value.ToLong(); // Returns 19990L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this char? value, long @default = 0) => value ?? @default;

        #endregion

        #region ToLong - 32 Bits ( int: -2,147,483,648 to 2,147,483,647, uint: 0 to 4,294,967,295, float: ±3.4E+38 )

        /// <summary>
        /// Converts a 32-bit signed integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The 32-bit signed integer to convert (range: -2,147,483,648 to 2,147,483,647).</param>
        /// <returns>The value converted to a 64-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion that preserves the sign and value.
        /// Example: int value = -2147483648; long result = value.ToLong(); // Returns -2147483648L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this int value) => value;

        /// <summary>
        /// Converts a nullable 32-bit signed integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 32-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to long if not null; the default value if null.</returns>
        /// <remarks>
        /// Provides null-safe conversion with customizable default value.
        /// Example: int? value = null; long result = value.ToLong(-1); // Returns -1L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this int? value, long @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a 32-bit unsigned integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The 32-bit unsigned integer to convert (range: 0 to 4,294,967,295).</param>
        /// <returns>The value converted to a 64-bit signed integer.</returns>
        /// <remarks>
        /// This is a safe widening conversion that preserves the value.
        /// Example: uint value = 4294967295; long result = value.ToLong(); // Returns 4294967295L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this uint value) => value;

        /// <summary>
        /// Converts a nullable 32-bit unsigned integer to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 32-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>The value converted to long if not null; the default value if null.</returns>
        /// <remarks>
        /// Provides null-safe conversion with customizable default value.
        /// Example: uint? value = null; long result = value.ToLong(); // Returns 0L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this uint? value, long @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a single-precision floating-point number to a 64-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the conversion would overflow or the input is not finite. Defaults to 0.</param>
        /// <returns>
        /// The value converted to a 64-bit signed integer if within valid range and finite;
        /// The default value if the input is NaN, infinite, or outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method performs safe conversion with range validation and handles special floating-point values.
        /// Examples:
        /// <code>
        /// float normal = 123.45f;
        /// long result1 = normal.ToLong(); // Returns 123L
        ///   
        /// float infinity = float.PositiveInfinity;
        /// long result2 = infinity.ToLong(); // Returns 0L (default)
        ///   
        /// float outOfRange = 1E20f;
        /// long result3 = outOfRange.ToLong(); // Returns 0L (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")] // For simple judgments, it performs better than Into Pattern
        public static long ToLong(this float value, long @default = 0) => float.IsFinite(value) && value >= long.MinValue && value <= long.MaxValue ? unchecked((long)value) : @default;

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null, not finite, or outside valid range. Defaults to 0.</param>
        /// <returns>
        /// The value converted to long if not null and within valid range;
        /// The default value if the input is null, NaN, infinite, or outside the valid range.
        /// </returns>
        /// <remarks>
        /// Combines null handling with safe float-to-long conversion.
        /// Example: float? value = null; long result = value.ToLong(-1); // Returns -1L
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this float? value, long @default = 0) => value?.ToLong(@default) ?? @default;

        #endregion

        #region ToLong - 128+ Bits ( decimal: ±7.9E+28, string: parse long )

        /// <summary>
        /// Converts a decimal value to a 64-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The decimal value to convert (valid range: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807).</param>
        /// <param name="default">The default value to return if the input is outside the valid range. Defaults to 0.</param>
        /// <returns>The converted value if within valid range; otherwise, the default value.</returns>
        /// <remarks>
        /// Performance optimized:
        /// - Uses cached decimal constants for range checks
        /// - Avoids pattern matching for better performance
        /// - Performs range validation before conversion
        ///   
        /// Example:
        /// <code>
        /// decimal valid = 123456.789m;
        /// long result1 = valid.ToLong(); // Returns 123456
        ///   
        /// decimal outOfRange = decimal.MaxValue;
        /// long result2 = outOfRange.ToLong(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")] // For simple judgments, it performs better than Into Pattern
        public static long ToLong(this decimal value, long @default = 0) => value >= DecimalLongMin && value <= DecimalLongMax ? decimal.ToInt64(value) : @default;

        /// <summary>
        /// Converts a nullable decimal value to a 64-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <param name="default">The default value to return if the input is null or outside the valid range. Defaults to 0.</param>
        /// <returns>The converted value if not null and within valid range; otherwise, the default value.</returns>
        /// <remarks>
        /// Combines null checking with range validation.
        /// Example:
        /// <code>
        /// decimal? nullValue = null;
        /// long result = nullValue.ToLong(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this decimal? value, long @default = 0) => value?.ToLong(@default) ?? @default;

        /// <summary>
        /// Converts a string representation of a number to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The string to convert. Must represent a valid long integer.</param>
        /// <param name="default">The default value to return if parsing fails. Defaults to 0.</param>
        /// <returns>
        /// The parsed long value if successful; otherwise, the default value.
        /// </returns>
        /// <remarks>
        /// Performance optimized:
        /// - Uses Span-based parsing to avoid allocations
        /// - Handles null/empty strings efficiently
        /// - Supports standard numeric formats
        ///   
        /// Examples:
        /// <code>
        /// string valid = "123456789";
        /// long result1 = valid.ToLong(); // Returns 123456789
        ///   
        /// string invalid = "not a number";
        /// long result2 = invalid.ToLong(); // Returns 0 (default)
        ///   
        /// string empty = "";
        /// long result3 = empty.ToLong(-1); // Returns -1 (default)
        ///   
        /// string withSpaces = " 123 ";
        /// long result4 = withSpaces.ToLong(); // Returns 0 (default, as spaces are not trimmed)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong([CanBeNull] this string value, long @default = 0) => string.IsNullOrEmpty(value) ? @default : long.TryParse(value.AsSpan(), out var result) ? result : @default;

        #endregion
    }
}