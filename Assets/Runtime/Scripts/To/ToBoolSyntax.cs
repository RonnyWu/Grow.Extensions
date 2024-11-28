using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for converting various types to boolean values.
    /// </summary>
    /// <remarks>
    /// This class contains a comprehensive set of extension methods for converting different data types to boolean values.
    /// All methods are optimized for performance using aggressive inlining.
    /// The conversion logic follows these general rules:
    /// - Numeric types: true if non-zero, false if zero
    /// - Nullable types: uses the provided default value (false by default) when null
    /// - String: uses bool.TryParse with fallback to default value
    /// - Generic types: uses Convert.ToBoolean as fallback
    /// </remarks>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ToBoolSyntax
    {
        #region ToBool - 8 Bits (sbyte, byte)

        /// <summary>
        /// Converts an 8-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        /// <example>
        /// <code>
        /// sbyte value1 = 1;
        /// sbyte value2 = 0;
        /// bool result1 = value1.ToBool(); // Returns true
        /// bool result2 = value2.ToBool(); // Returns false
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this sbyte value) => value != 0;

        /// <summary>
        /// Converts a nullable 8-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this sbyte? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts an 8-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this byte value) => value != 0;

        /// <summary>
        /// Converts a nullable 8-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this byte? value, bool @default = false) => value?.ToBool() ?? @default;

        #endregion

        #region ToBool - 16 Bits (short, ushort, char)

        /// <summary>
        /// Converts a 16-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this short value) => value != 0;

        /// <summary>
        /// Converts a nullable 16-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this short? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts a 16-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this ushort value) => value != 0;

        /// <summary>
        /// Converts a nullable 16-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this ushort? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts a character to boolean.
        /// </summary>
        /// <param name="value">The character to convert.</param>
        /// <returns>true if the character is not null character ('\0'); otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this char value) => value != '\0';

        /// <summary>
        /// Converts a nullable character to boolean.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this char? value, bool @default = false) => value?.ToBool() ?? @default;

        #endregion

        #region ToBool - 32 Bits (int, uint, float)

        /// <summary>
        /// Converts a 32-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this int value) => value != 0;

        /// <summary>
        /// Converts a nullable 32-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this int? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts a 32-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this uint value) => value != 0;

        /// <summary>
        /// Converts a nullable 32-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this uint? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts a single-precision floating-point number to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this float value) => value != 0f;

        /// <summary>
        /// Converts a nullable single-precision floating-point number to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this float? value, bool @default = false) => value?.ToBool() ?? @default;

        #endregion

        #region ToBool - 64 Bits (long, ulong, double)

        /// <summary>
        /// Converts a 64-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this long value) => value != 0;

        /// <summary>
        /// Converts a nullable 64-bit signed integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this long? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts a 64-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this ulong value) => value != 0;

        /// <summary>
        /// Converts a nullable 64-bit unsigned integer to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this ulong? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts a double-precision floating-point number to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this double value) => value != 0d;

        /// <summary>
        /// Converts a nullable double-precision floating-point number to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this double? value, bool @default = false) => value?.ToBool() ?? @default;

        #endregion

        #region ToBool - 128+ Bits (decimal, string)

        /// <summary>
        /// Converts a decimal number to boolean.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>true if the value is non-zero; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this decimal value) => value != 0m;

        /// <summary>
        /// Converts a nullable decimal number to boolean.
        /// </summary>
        /// <param name="value">The nullable value to convert.</param>
        /// <param name="default">The default value to return if the input is null.</param>
        /// <returns>The boolean equivalent of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this decimal? value, bool @default = false) => value?.ToBool() ?? @default;

        /// <summary>
        /// Converts a string to boolean.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="default">The default value to return if the input is null, empty, or cannot be parsed.</param>
        /// <returns>The boolean equivalent of the string value, or the default value if conversion fails.</returns>
        /// <remarks>
        /// This method attempts to parse the string using bool.TryParse.
        /// Valid string values are (case-insensitive):
        /// - "true" or "false"
        /// - "1" or "0" are not considered valid boolean strings
        /// </remarks>
        /// <example>
        /// <code>
        /// string value1 = "true";
        /// string value2 = "false";
        /// string value3 = null;
        /// string value4 = "invalid";
        ///   
        /// bool result1 = value1.ToBool();     // Returns true
        /// bool result2 = value2.ToBool();     // Returns false
        /// bool result3 = value3.ToBool();     // Returns false (default)
        /// bool result4 = value4.ToBool(true); // Returns true (specified default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool([CanBeNull] this string value, bool @default = false) => string.IsNullOrEmpty(value) ? @default : bool.TryParse(value, out var result) ? result : @default;

        #endregion

        #region ToBool - FallBack

        /// <summary>
        /// Generic conversion method for IConvertible types to boolean.
        /// </summary>
        /// <typeparam name="T">The type to convert from, must implement IConvertible.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>The boolean equivalent of the value.</returns>
        /// <remarks>
        /// This is a fallback method for types that implement IConvertible but don't have a specific conversion method.
        /// It uses Convert.ToBoolean internally, which may throw InvalidCastException for unsupported conversions.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool<T>(this T value) where T : struct, IConvertible => Convert.ToBoolean(value);

        #endregion
    }
}