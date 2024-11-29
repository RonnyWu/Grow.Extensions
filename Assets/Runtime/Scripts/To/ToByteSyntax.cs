// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for converting various types to byte values with predictable behavior and performance.
    /// </summary>
    /// <remarks>
    /// This class implements a comprehensive set of type conversion methods to byte with the following features:
    /// - Consistent handling of edge cases (negative values, overflows, special values)
    /// - Default value support for conversion failures
    /// - Optimized performance with aggressive inlining
    /// - Nullable type support with customizable default values
    ///   
    /// Conversion rules:
    /// - Boolean: false => 0, true => 1
    /// - Numeric types: returns default value for negative numbers or values > 255
    /// - Floating points: handles special values (NaN, Infinity) by returning default
    /// - String: uses byte.TryParse with fallback to default value
    /// - Nullable types: returns default value when null
    ///   
    /// Note: This implementation is considered complete and stable.
    /// Potential future enhancements could include:
    /// - Culture-aware string parsing if internationalization becomes necessary
    /// - Additional numeric format support for string parsing
    /// - Specialized handling for custom numeric types
    /// - Span-based operations for high-performance scenarios
    ///   
    /// These optimizations should only be considered based on specific requirements,
    /// as the current implementation provides robust and efficient conversion for most use cases.
    /// </remarks>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ToByteSyntax
    {
        #region ToByte - 1 Bits (bool)

        /// <summary>
        /// Converts a boolean value to a byte, where false becomes 0 and true becomes 1.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>
        /// A byte value:
        /// - 1 for true
        /// - 0 for false
        /// </returns>
        /// <example>
        /// <code>
        /// bool t = true;
        /// bool f = false;
        /// byte b1 = t.ToByte(); // returns 1
        /// byte b2 = f.ToByte(); // returns 0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this bool value) => (byte)(value ? 1 : 0);

        /// <summary>
        /// Converts a nullable boolean value to a byte, with a specified default value for null input.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - 1 for true
        /// - 0 for false
        /// - <paramref name="default"/> for null
        /// </returns>
        /// <example>
        /// <code>
        /// bool? t = true;
        /// bool? f = false;
        /// bool? n = null;
        /// byte b1 = t.ToByte();    // returns 1
        /// byte b2 = f.ToByte();    // returns 0
        /// byte b3 = n.ToByte();    // returns 0 (default)
        /// byte b4 = n.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        /// <remarks>
        /// This method provides a safe way to handle nullable boolean values while allowing
        /// customization of the null-case behavior through the default parameter.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this bool? value, byte @default = 0) => value?.ToByte() ?? @default;

        #endregion

        #region ToByte - 8 Bits (sbyte, byte)

        /// <summary>
        /// Converts a signed byte to an unsigned byte, with a specified default value for negative numbers.
        /// </summary>
        /// <param name="value">The signed byte value to convert.</param>
        /// <param name="default">The default value to return if the input is negative. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if non-negative
        /// - <paramref name="default"/> if negative
        /// </returns>
        /// <example>
        /// <code>
        /// sbyte s1 = 100;
        /// sbyte s2 = -1;
        /// byte b1 = s1.ToByte();    // returns 100
        /// byte b2 = s2.ToByte();    // returns 0 (default)
        /// byte b3 = s2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        /// <remarks>
        /// This method uses unchecked context for the conversion to prevent overflow exceptions
        /// while ensuring predictable behavior for negative values.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this sbyte value, byte @default = 0) => unchecked(value < 0 ? @default : (byte)value);

        /// <summary>
        /// Converts a nullable signed byte to an unsigned byte, with a specified default value for null or negative input.
        /// </summary>
        /// <param name="value">The nullable signed byte value to convert.</param>
        /// <param name="default">The default value to return if the input is null or negative. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if non-negative
        /// - <paramref name="default"/> if negative or null
        /// </returns>
        /// <example>
        /// <code>
        /// sbyte? s1 = 100;
        /// sbyte? s2 = -1;
        /// sbyte? s3 = null;
        /// byte b1 = s1.ToByte();    // returns 100
        /// byte b2 = s2.ToByte();    // returns 0 (default)
        /// byte b3 = s3.ToByte();    // returns 0 (default)
        /// byte b4 = s3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this sbyte? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a nullable byte to a non-nullable byte, with a specified default value for null input.
        /// </summary>
        /// <param name="value">The nullable byte value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if non-null
        /// - <paramref name="default"/> if null
        /// </returns>
        /// <example>
        /// <code>
        /// byte? b1 = 100;
        /// byte? b2 = null;
        /// byte r1 = b1.ToByte();    // returns 100
        /// byte r2 = b2.ToByte();    // returns 0 (default)
        /// byte r3 = b2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this byte? value, byte @default = 0) => value ?? @default;

        #endregion

        #region ToByte - 16 Bits (short, ushort, char)

        /// <summary>
        /// Converts a 16-bit signed integer to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The 16-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if negative or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// short s1 = 100;
        /// short s2 = -1;
        /// short s3 = 256;
        /// byte b1 = s1.ToByte();    // returns 100
        /// byte b2 = s2.ToByte();    // returns 0 (default)
        /// byte b3 = s3.ToByte();    // returns 0 (default)
        /// byte b4 = s2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        /// <remarks>
        /// This method uses unchecked context for the conversion to prevent overflow exceptions
        /// while ensuring predictable behavior for out-of-range values.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this short value, byte @default = 0) => unchecked(value < 0 ? @default : value > byte.MaxValue ? @default : (byte)value);

        /// <summary>
        /// Converts a nullable 16-bit signed integer to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable 16-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if null, negative, or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// short? s1 = 100;
        /// short? s2 = -1;
        /// short? s3 = null;
        /// byte b1 = s1.ToByte();    // returns 100
        /// byte b2 = s2.ToByte();    // returns 0 (default)
        /// byte b3 = s3.ToByte();    // returns 0 (default)
        /// byte b4 = s3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this short? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a 16-bit unsigned integer to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// ushort us1 = 100;
        /// ushort us2 = 256;
        /// byte b1 = us1.ToByte();    // returns 100
        /// byte b2 = us2.ToByte();    // returns 0 (default)
        /// byte b3 = us2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this ushort value, byte @default = 0) => value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable 16-bit unsigned integer to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable 16-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if null or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// ushort? us1 = 100;
        /// ushort? us2 = 256;
        /// ushort? us3 = null;
        /// byte b1 = us1.ToByte();    // returns 100
        /// byte b2 = us2.ToByte();    // returns 0 (default)
        /// byte b3 = us3.ToByte();    // returns 0 (default)
        /// byte b4 = us3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this ushort? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a Unicode character to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The Unicode character to convert.</param>
        /// <param name="default">The default value to return if the character value is greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The character's numeric value if between 0 and 255
        /// - <paramref name="default"/> if greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// char c1 = 'A';        // ASCII 65
        /// char c2 = 'Ā';        // Unicode 256
        /// byte b1 = c1.ToByte(); // returns 65
        /// byte b2 = c2.ToByte(); // returns 0 (default)
        /// byte b3 = c2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this char value, byte @default = 0) => value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable Unicode character to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable Unicode character to convert.</param>
        /// <param name="default">The default value to return if the input is null or the character value is greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The character's numeric value if between 0 and 255
        /// - <paramref name="default"/> if null or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// char? c1 = 'A';        // ASCII 65
        /// char? c2 = 'Ā';        // Unicode 256
        /// char? c3 = null;
        /// byte b1 = c1.ToByte(); // returns 65
        /// byte b2 = c2.ToByte(); // returns 0 (default)
        /// byte b3 = c3.ToByte(); // returns 0 (default)
        /// byte b4 = c3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this char? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        #endregion

        #region ToByte - 32 Bits (int, uint, float)

        /// <summary>
        /// Converts a 32-bit signed integer to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The 32-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if negative or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// int i1 = 100;
        /// int i2 = -1;
        /// int i3 = 256;
        /// byte b1 = i1.ToByte();    // returns 100
        /// byte b2 = i2.ToByte();    // returns 0 (default)
        /// byte b3 = i3.ToByte();    // returns 0 (default)
        /// byte b4 = i2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this int value, byte @default = 0) => value < 0 ? @default : value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable 32-bit signed integer to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable 32-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if null, negative, or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// int? i1 = 100;
        /// int? i2 = -1;
        /// int? i3 = null;
        /// byte b1 = i1.ToByte();    // returns 100
        /// byte b2 = i2.ToByte();    // returns 0 (default)
        /// byte b3 = i3.ToByte();    // returns 0 (default)
        /// byte b4 = i3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this int? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a 32-bit unsigned integer to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The 32-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// uint ui1 = 100;
        /// uint ui2 = 256;
        /// byte b1 = ui1.ToByte();    // returns 100
        /// byte b2 = ui2.ToByte();    // returns 0 (default)
        /// byte b3 = ui2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this uint value, byte @default = 0) => value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable 32-bit unsigned integer to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable 32-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if null or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// uint? ui1 = 100;
        /// uint? ui2 = 256;
        /// uint? ui3 = null;
        /// byte b1 = ui1.ToByte();    // returns 100
        /// byte b2 = ui2.ToByte();    // returns 0 (default)
        /// byte b3 = ui3.ToByte();    // returns 0 (default)
        /// byte b4 = ui3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this uint? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a single-precision floating-point number to a byte, with a specified default value for out-of-range or special values.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is out of range or not a finite number. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The truncated value if between 0 and 255
        /// - <paramref name="default"/> if negative, greater than 255, NaN, or infinity
        /// </returns>
        /// <example>
        /// <code>
        /// float f1 = 100.6f;
        /// float f2 = -1.5f;
        /// float f3 = 256.0f;
        /// float f4 = float.NaN;
        /// float f5 = float.PositiveInfinity;
        /// byte b1 = f1.ToByte();    // returns 100 (truncated)
        /// byte b2 = f2.ToByte();    // returns 0 (default)
        /// byte b3 = f3.ToByte();    // returns 0 (default)
        /// byte b4 = f4.ToByte();    // returns 0 (default)
        /// byte b5 = f5.ToByte();    // returns 0 (default)
        /// byte b6 = f2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        /// <remarks>
        /// This method handles special floating-point values (NaN and Infinity) by returning the default value.
        /// Note that the conversion truncates decimal places rather than rounding.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this float value, byte @default = 0) => !float.IsFinite(value) || value < 0 || value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a byte, with a specified default value for null, out-of-range, or special values.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null, out of range, or not a finite number. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The truncated value if between 0 and 255
        /// - <paramref name="default"/> if null, negative, greater than 255, NaN, or infinity
        /// </returns>
        /// <example>
        /// <code>
        /// float? f1 = 100.6f;
        /// float? f2 = -1.5f;
        /// float? f3 = float.NaN;
        /// float? f4 = null;
        /// byte b1 = f1.ToByte();    // returns 100 (truncated)
        /// byte b2 = f2.ToByte();    // returns 0 (default)
        /// byte b3 = f3.ToByte();    // returns 0 (default)
        /// byte b4 = f4.ToByte();    // returns 0 (default)
        /// byte b5 = f4.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this float? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        #endregion

        #region ToByte - 64 Bits (long, ulong, double)

        /// <summary>
        /// Converts a 64-bit signed integer to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The 64-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if negative or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// long l1 = 100L;
        /// long l2 = -1L;
        /// long l3 = 256L;
        /// byte b1 = l1.ToByte();    // returns 100
        /// byte b2 = l2.ToByte();    // returns 0 (default)
        /// byte b3 = l3.ToByte();    // returns 0 (default)
        /// byte b4 = l2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this long value, byte @default = 0) => value < 0 ? @default : value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable 64-bit signed integer to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable 64-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if null, negative, or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// long? l1 = 100L;
        /// long? l2 = -1L;
        /// long? l3 = null;
        /// byte b1 = l1.ToByte();    // returns 100
        /// byte b2 = l2.ToByte();    // returns 0 (default)
        /// byte b3 = l3.ToByte();    // returns 0 (default)
        /// byte b4 = l3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this long? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a 64-bit unsigned integer to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The 64-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// ulong ul1 = 100UL;
        /// ulong ul2 = 256UL;
        /// byte b1 = ul1.ToByte();    // returns 100
        /// byte b2 = ul2.ToByte();    // returns 0 (default)
        /// byte b3 = ul2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this ulong value, byte @default = 0) => value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable 64-bit unsigned integer to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable 64-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or greater than 255. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The original value if between 0 and 255
        /// - <paramref name="default"/> if null or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// ulong? ul1 = 100UL;
        /// ulong? ul2 = 256UL;
        /// ulong? ul3 = null;
        /// byte b1 = ul1.ToByte();    // returns 100
        /// byte b2 = ul2.ToByte();    // returns 0 (default)
        /// byte b3 = ul3.ToByte();    // returns 0 (default)
        /// byte b4 = ul3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this ulong? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a double-precision floating-point number to a byte, with a specified default value for out-of-range or special values.
        /// </summary>
        /// <param name="value">The double-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is out of range or not a finite number. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The truncated value if between 0 and 255
        /// - <paramref name="default"/> if negative, greater than 255, NaN, or infinity
        /// </returns>
        /// <example>
        /// <code>
        /// double d1 = 100.6;
        /// double d2 = -1.5;
        /// double d3 = 256.0;
        /// double d4 = double.NaN;
        /// double d5 = double.PositiveInfinity;
        /// byte b1 = d1.ToByte();    // returns 100 (truncated)
        /// byte b2 = d2.ToByte();    // returns 0 (default)
        /// byte b3 = d3.ToByte();    // returns 0 (default)
        /// byte b4 = d4.ToByte();    // returns 0 (default)
        /// byte b5 = d5.ToByte();    // returns 0 (default)
        /// byte b6 = d2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        /// <remarks>
        /// This method handles special floating-point values (NaN and Infinity) by returning the default value.
        /// Note that the conversion truncates decimal places rather than rounding.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this double value, byte @default = 0) => !double.IsFinite(value) || value < 0 || value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a byte, with a specified default value for null, out-of-range, or special values.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null, out of range, or not a finite number. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The truncated value if between 0 and 255
        /// - <paramref name="default"/> if null, negative, greater than 255, NaN, or infinity
        /// </returns>
        /// <example>
        /// <code>
        /// double? d1 = 100.6;
        /// double? d2 = -1.5;
        /// double? d3 = double.NaN;
        /// double? d4 = null;
        /// byte b1 = d1.ToByte();    // returns 100 (truncated)
        /// byte b2 = d2.ToByte();    // returns 0 (default)
        /// byte b3 = d3.ToByte();    // returns 0 (default)
        /// byte b4 = d4.ToByte();    // returns 0 (default)
        /// byte b5 = d4.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this double? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        #endregion

        #region ToByte - 128+ Bits (decimal, string)

        /// <summary>
        /// Converts a decimal number to a byte, with a specified default value for out-of-range input.
        /// </summary>
        /// <param name="value">The decimal number to convert.</param>
        /// <param name="default">The default value to return if the input is out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The truncated value if between 0 and 255
        /// - <paramref name="default"/> if negative or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// decimal d1 = 100.6m;
        /// decimal d2 = -1.5m;
        /// decimal d3 = 256.0m;
        /// byte b1 = d1.ToByte();    // returns 100 (truncated)
        /// byte b2 = d2.ToByte();    // returns 0 (default)
        /// byte b3 = d3.ToByte();    // returns 0 (default)
        /// byte b4 = d2.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        /// <remarks>
        /// This method truncates decimal places rather than rounding.
        /// Unlike floating-point types, decimal cannot represent special values like NaN or Infinity.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this decimal value, byte @default = 0) => value < 0 ? @default : value > byte.MaxValue ? @default : (byte)value;

        /// <summary>
        /// Converts a nullable decimal number to a byte, with a specified default value for null or out-of-range input.
        /// </summary>
        /// <param name="value">The nullable decimal number to convert.</param>
        /// <param name="default">The default value to return if the input is null or out of range. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The truncated value if between 0 and 255
        /// - <paramref name="default"/> if null, negative, or greater than 255
        /// </returns>
        /// <example>
        /// <code>
        /// decimal? d1 = 100.6m;
        /// decimal? d2 = -1.5m;
        /// decimal? d3 = null;
        /// byte b1 = d1.ToByte();    // returns 100 (truncated)
        /// byte b2 = d2.ToByte();    // returns 0 (default)
        /// byte b3 = d3.ToByte();    // returns 0 (default)
        /// byte b4 = d3.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this decimal? value, byte @default = 0) => value?.ToByte(@default) ?? @default;

        /// <summary>
        /// Converts a string representation of a number to a byte, with a specified default value for invalid input.
        /// </summary>
        /// <param name="value">The string to convert. Must represent a valid byte value between 0 and 255.</param>
        /// <param name="default">The default value to return if the input is null, empty, or cannot be parsed. Defaults to 0.</param>
        /// <returns>
        /// A byte value:
        /// - The parsed value if string represents a number between 0 and 255
        /// - <paramref name="default"/> if string is null, empty, or cannot be parsed as a valid byte
        /// </returns>
        /// <example>
        /// <code>
        /// string s1 = "100";
        /// string s2 = "256";
        /// string s3 = "-1";
        /// string s4 = "invalid";
        /// string s5 = null;
        /// string s6 = "";
        /// byte b1 = s1.ToByte();    // returns 100
        /// byte b2 = s2.ToByte();    // returns 0 (default, out of range)
        /// byte b3 = s3.ToByte();    // returns 0 (default, out of range)
        /// byte b4 = s4.ToByte();    // returns 0 (default, invalid format)
        /// byte b5 = s5.ToByte();    // returns 0 (default, null)
        /// byte b6 = s6.ToByte();    // returns 0 (default, empty)
        /// byte b7 = s4.ToByte(255); // returns 255 (custom default)
        /// </code>
        /// </example>
        /// <remarks>
        /// This method uses <see cref="byte.TryParse(string, out byte)"/> internally and accepts
        /// the same string formats that it does. The parsing is culture-sensitive and uses the
        /// current culture's number formatting rules.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("value:null => halt")]
        public static byte ToByte([CanBeNull] this string value, byte @default = 0) => string.IsNullOrEmpty(value) || !byte.TryParse(value, out var result) ? @default : result;

        #endregion
    }
}