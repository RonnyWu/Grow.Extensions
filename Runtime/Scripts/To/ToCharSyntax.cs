// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for converting various data types to <see cref="char"/>.
    /// </summary>
    /// <remarks>
    /// This class contains a comprehensive set of extension methods that enable type-safe conversion
    /// from different numeric types and strings to characters. All methods are optimized for performance
    /// with aggressive inlining and proper boundary checks.
    /// <para>
    /// For numeric types, values are checked to ensure they fall within the valid char range (0-65535).
    /// For floating-point types, additional checks ensure the values are integers.
    /// </para>
    /// </remarks>
    public static class ToCharSyntax
    {
        #region Constants

        /// <summary>
        /// Represents the character '1', used as the default representation for boolean true value.
        /// </summary>
        private const char TrueChar = '1';

        /// <summary>
        /// Represents the character '0', used as the default representation for boolean false value
        /// and as the default character for invalid conversions.
        /// </summary>
        private const char FalseChar = '0';

        #endregion

        #region ToChar - 1 Bits (bool)

        /// <summary>
        /// Converts a boolean value to its character representation.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>'1' for true, '0' for false.</returns>
        /// <example>
        /// <code>
        /// bool value = true;
        /// char result = value.ToChar(); // Returns '1'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this bool value) => value ? TrueChar : FalseChar;

        /// <summary>
        /// Converts a nullable boolean value to its character representation.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="default">The default character to return if the value is null.</param>
        /// <returns>
        /// '1' for true, '0' for false, or the specified default value for null.
        /// </returns>
        /// <example>
        /// <code>
        /// bool? value = null;
        /// char result = value.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this bool? value, char @default = FalseChar) => value?.ToChar() ?? @default;

        #endregion

        #region ToChar - 8 Bits (sbyte, byte)

        /// <summary>
        /// Converts a signed byte to its character representation.
        /// </summary>
        /// <param name="value">The signed byte value to convert.</param>
        /// <param name="default">The default character to return if the value is negative.</param>
        /// <returns>
        /// The character representation of the value if non-negative, otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method only converts non-negative values. Negative values will return the default character.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this sbyte value, char @default = FalseChar) => value >= 0 ? (char)value : @default;

        /// <summary>
        /// Converts a nullable signed byte to its character representation.
        /// </summary>
        /// <param name="value">The nullable signed byte value to convert.</param>
        /// <param name="default">The default character to return if the value is null or negative.</param>
        /// <returns>
        /// The character representation of the value if non-null and non-negative,
        /// otherwise the default character.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this sbyte? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        /// <summary>
        /// Converts an unsigned byte to its character representation.
        /// </summary>
        /// <param name="value">The unsigned byte value to convert.</param>
        /// <returns>The character representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as byte values (0-255) are always valid char values.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this byte value) => (char)value;

        /// <summary>
        /// Converts a nullable unsigned byte to its character representation.
        /// </summary>
        /// <param name="value">The nullable unsigned byte value to convert.</param>
        /// <param name="default">The default character to return if the value is null.</param>
        /// <returns>
        /// The character representation of the value if non-null, otherwise the default character.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this byte? value, char @default = FalseChar) => value?.ToChar() ?? @default;

        #endregion

        #region ToChar - 16 Bits (short, ushort, char)

        /// <summary>
        /// Converts a signed 16-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The signed 16-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is negative.</param>
        /// <returns>
        /// The character representation of the value if non-negative, otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method only converts non-negative values. Negative values will return the default character.
        /// The conversion is safe for all non-negative short values as they fall within the valid char range (0-65535).
        /// </remarks>
        /// <example>
        /// <code>
        /// short value1 = 65;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// short value2 = -1;
        /// char result2 = value2.ToChar(); // Returns '0' (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this short value, char @default = FalseChar) => value >= 0 ? (char)value : @default;

        /// <summary>
        /// Converts a nullable signed 16-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The nullable signed 16-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is null or negative.</param>
        /// <returns>
        /// The character representation of the value if non-null and non-negative,
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// short? value1 = 65;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// short? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this short? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        /// <summary>
        /// Converts an unsigned 16-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The unsigned 16-bit integer to convert.</param>
        /// <returns>The character representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as ushort and char share the same range (0-65535).
        /// No validation is required as all ushort values are valid char values.
        /// </remarks>
        /// <example>
        /// <code>
        /// ushort value = 65;
        /// char result = value.ToChar(); // Returns 'A'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this ushort value) => (char)value;

        /// <summary>
        /// Converts a nullable unsigned 16-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The nullable unsigned 16-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is null.</param>
        /// <returns>
        /// The character representation of the value if non-null, otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// ushort? value1 = 65;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// ushort? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this ushort? value, char @default = FalseChar) => value?.ToChar() ?? @default;

        /// <summary>
        /// Converts a nullable character to its non-nullable representation.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <param name="default">The default character to return if the value is null.</param>
        /// <returns>
        /// The character value if non-null, otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method provides a consistent way to handle nullable characters within the conversion framework.
        /// No actual type conversion is performed, only null handling.
        /// </remarks>
        /// <example>
        /// <code>
        /// char? value1 = 'A';
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// char? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this char? value, char @default = FalseChar) => value ?? @default;

        #endregion

        #region ToChar - 32 Bits (int, uint, float)

        /// <summary>
        /// Converts a 32-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The 32-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is out of range.</param>
        /// <returns>
        /// The character representation of the value if within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method uses an optimized approach by casting to uint first, which handles both
        /// negative values and values above 65535 in a single comparison. This is more efficient
        /// than checking for negative values separately.
        /// </remarks>
        /// <example>
        /// <code>
        /// int value1 = 65;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// int value2 = -1;
        /// char result2 = value2.ToChar(); // Returns '0' (default)
        ///   
        /// int value3 = 65536;
        /// char result3 = value3.ToChar(); // Returns '0' (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoLogicalPattern")]
        public static char ToChar(this int value, char @default = FalseChar) => (uint)value <= ushort.MaxValue ? (char)value : @default;

        /// <summary>
        /// Converts a nullable 32-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The nullable 32-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is null or out of range.</param>
        /// <returns>
        /// The character representation of the value if non-null and within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// int? value1 = 65;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// int? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this int? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        /// <summary>
        /// Converts an unsigned 32-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The unsigned 32-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is out of range.</param>
        /// <returns>
        /// The character representation of the value if within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method only needs to check the upper bound since uint values are always non-negative.
        /// </remarks>
        /// <example>
        /// <code>
        /// uint value1 = 65;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// uint value2 = 65536;
        /// char result2 = value2.ToChar(); // Returns '0' (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this uint value, char @default = FalseChar) => value <= ushort.MaxValue ? (char)value : @default;

        /// <summary>
        /// Converts a nullable unsigned 32-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The nullable unsigned 32-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is null or out of range.</param>
        /// <returns>
        /// The character representation of the value if non-null and within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// uint? value1 = 65;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// uint? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this uint? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        /// <summary>
        /// Converts a single-precision floating-point number to its character representation.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert.</param>
        /// <param name="default">The default character to return if the value is invalid.</param>
        /// <returns>
        /// The character representation of the value if it is a non-negative integer within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method performs three validations:
        /// <list type="bullet">
        /// <item><description>Checks if the value is non-negative</description></item>
        /// <item><description>Ensures the value is within the valid char range (0-65535)</description></item>
        /// <item><description>Verifies the value is an integer by comparing it with its integer portion</description></item>
        /// </list>
        /// The implementation uses a single integer conversion to optimize performance.
        /// </remarks>
        /// <example>
        /// <code>
        /// float value1 = 65.0f;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// float value2 = 65.5f;
        /// char result2 = value2.ToChar(); // Returns '0' (default, not an integer)
        ///   
        /// float value3 = -1.0f;
        /// char result3 = value3.ToChar(); // Returns '0' (default, negative)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")]
        public static char ToChar(this float value, char @default = FalseChar)
        {
            var intValue = (int)value;
            return value >= 0 && value <= ushort.MaxValue && value - intValue == 0 ? (char)intValue : @default;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point number to its character representation.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <param name="default">The default character to return if the value is null or invalid.</param>
        /// <returns>
        /// The character representation of the value if it is non-null and a valid integer within range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// float? value1 = 65.0f;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// float? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this float? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        #endregion

        #region ToChar - 64 Bits (long, ulong, double)

        /// <summary>
        /// Converts a 64-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The 64-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is out of range.</param>
        /// <returns>
        /// The character representation of the value if within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method uses an optimized approach by casting to ulong first, which handles both
        /// negative values and values above 65535 in a single comparison. This is more efficient
        /// than checking for negative values separately.
        /// </remarks>
        /// <example>
        /// <code>
        /// long value1 = 65L;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// long value2 = -1L;
        /// char result2 = value2.ToChar(); // Returns '0' (default)
        ///   
        /// long value3 = 65536L;
        /// char result3 = value3.ToChar(); // Returns '0' (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this long value, char @default = FalseChar) => (ulong)value <= ushort.MaxValue ? (char)value : @default;

        /// <summary>
        /// Converts a nullable 64-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The nullable 64-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is null or out of range.</param>
        /// <returns>
        /// The character representation of the value if non-null and within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// long? value1 = 65L;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// long? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this long? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        /// <summary>
        /// Converts an unsigned 64-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The unsigned 64-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is out of range.</param>
        /// <returns>
        /// The character representation of the value if within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method only needs to check the upper bound since ulong values are always non-negative.
        /// The comparison is straightforward as we only need to ensure the value fits within 16 bits.
        /// </remarks>
        /// <example>
        /// <code>
        /// ulong value1 = 65UL;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// ulong value2 = 65536UL;
        /// char result2 = value2.ToChar(); // Returns '0' (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this ulong value, char @default = FalseChar) => value <= ushort.MaxValue ? (char)value : @default;

        /// <summary>
        /// Converts a nullable unsigned 64-bit integer to its character representation.
        /// </summary>
        /// <param name="value">The nullable unsigned 64-bit integer to convert.</param>
        /// <param name="default">The default character to return if the value is null or out of range.</param>
        /// <returns>
        /// The character representation of the value if non-null and within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// ulong? value1 = 65UL;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// ulong? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this ulong? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        /// <summary>
        /// Converts a double-precision floating-point number to its character representation.
        /// </summary>
        /// <param name="value">The double-precision floating-point number to convert.</param>
        /// <param name="default">The default character to return if the value is invalid.</param>
        /// <returns>
        /// The character representation of the value if it is a non-negative integer within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method performs three essential validations:
        /// <list type="bullet">
        /// <item><description>Checks if the value is non-negative</description></item>
        /// <item><description>Ensures the value is within the valid char range (0-65535)</description></item>
        /// <item><description>Verifies the value is an integer by comparing it with its integer portion</description></item>
        /// </list>
        /// The implementation uses a single long conversion to optimize performance while maintaining precision
        /// for values within the char range. This approach is particularly important for double-precision values
        /// to avoid floating-point rounding issues.
        /// </remarks>
        /// <example>
        /// <code>
        /// double value1 = 65.0;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// double value2 = 65.5;
        /// char result2 = value2.ToChar(); // Returns '0' (default, not an integer)
        ///   
        /// double value3 = -1.0;
        /// char result3 = value3.ToChar(); // Returns '0' (default, negative)
        ///   
        /// double value4 = 65536.0;
        /// char result4 = value4.ToChar(); // Returns '0' (default, out of range)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")]
        public static char ToChar(this double value, char @default = FalseChar)
        {
            var longValue = (long)value;
            return value >= 0 && value <= ushort.MaxValue && value - longValue == 0 ? (char)longValue : @default;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to its character representation.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <param name="default">The default character to return if the value is null or invalid.</param>
        /// <returns>
        /// The character representation of the value if it is non-null and a valid integer within range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// double? value1 = 65.0;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// double? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this double? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        #endregion

        #region ToChar - 128+ Bits (decimal, string)

        /// <summary>
        /// Converts a decimal number to its character representation.
        /// </summary>
        /// <param name="value">The decimal number to convert.</param>
        /// <param name="default">The default character to return if the value is invalid.</param>
        /// <returns>
        /// The character representation of the value if it is a non-negative integer within valid range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method performs three essential validations:
        /// <list type="bullet">
        /// <item><description>Checks if the value is non-negative</description></item>
        /// <item><description>Ensures the value is within the valid char range (0-65535)</description></item>
        /// <item><description>Verifies the value is an integer by comparing it with its integer portion</description></item>
        /// </list>
        /// The implementation uses a single int conversion to optimize performance while maintaining
        /// exact decimal precision. This is particularly important for decimal values as they are
        /// often used in financial calculations where precision is critical.
        /// <para>
        /// Unlike floating-point types (float/double), decimal maintains exact decimal precision
        /// which makes the integer comparison reliable without floating-point rounding concerns.
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal value1 = 65m;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// decimal value2 = 65.5m;
        /// char result2 = value2.ToChar(); // Returns '0' (default, not an integer)
        ///   
        /// decimal value3 = -1m;
        /// char result3 = value3.ToChar(); // Returns '0' (default, negative)
        ///   
        /// decimal value4 = 65536m;
        /// char result4 = value4.ToChar(); // Returns '0' (default, out of range)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")]
        public static char ToChar(this decimal value, char @default = FalseChar)
        {
            var intValue = (int)value;
            return value >= 0 && value <= ushort.MaxValue && value == intValue ? (char)intValue : @default;
        }

        /// <summary>
        /// Converts a nullable decimal number to its character representation.
        /// </summary>
        /// <param name="value">The nullable decimal number to convert.</param>
        /// <param name="default">The default character to return if the value is null or invalid.</param>
        /// <returns>
        /// The character representation of the value if it is non-null and a valid integer within range (0-65535),
        /// otherwise the default character.
        /// </returns>
        /// <example>
        /// <code>
        /// decimal? value1 = 65m;
        /// char result1 = value1.ToChar(); // Returns 'A'
        ///   
        /// decimal? value2 = null;
        /// char result2 = value2.ToChar('?'); // Returns '?'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar(this decimal? value, char @default = FalseChar) => value?.ToChar(@default) ?? @default;

        /// <summary>
        /// Converts a string to its first character representation.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="default">The default character to return if the string is null or empty.</param>
        /// <returns>
        /// The first character of the string if the string is not null or empty,
        /// otherwise the default character.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to extract the first character from a string:
        /// <list type="bullet">
        /// <item><description>Returns the first character if the string has at least one character</description></item>
        /// <item><description>Returns the default character if the string is null</description></item>
        /// <item><description>Returns the default character if the string is empty</description></item>
        /// </list>
        /// The implementation uses pattern matching for optimal performance and clarity.
        /// Unlike string.IsNullOrEmpty, this approach requires only a single check.
        /// </remarks>
        /// <example>
        /// <code>
        /// string value1 = "Hello";
        /// char result1 = value1.ToChar(); // Returns 'H'
        ///   
        /// string value2 = "";
        /// char result2 = value2.ToChar(); // Returns '0' (default)
        ///   
        /// string value3 = null;
        /// char result3 = value3.ToChar(); // Returns '0' (default)
        ///   
        /// string value4 = "A";
        /// char result4 = value4.ToChar('?'); // Returns 'A'
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToChar([CanBeNull] this string value, char @default = FalseChar) => value is { Length: > 0 } ? value[0] : @default;

        #endregion
    }
}