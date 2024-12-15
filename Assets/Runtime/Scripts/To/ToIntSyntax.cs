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
    public static class ToIntSyntax
    {
        private const decimal DecimalIntMax = int.MaxValue;
        private const decimal DecimalIntMin = int.MinValue;

        #region ToInt - 1 Bits ( bool )

        /// <summary>
        /// Converts a boolean value to its integer representation.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>1 if the value is true; 0 if the value is false.</returns>
        /// <remarks>
        /// This method provides a simple way to convert boolean values to their numeric representation.
        /// Common use cases include:
        /// <list type="bullet">
        /// <item><description>Database operations where boolean values need to be stored as integers</description></item>
        /// <item><description>Arithmetic operations that require boolean values as numbers</description></item>
        /// </list>
        /// Example:
        /// <code>
        /// bool isEnabled = true;
        /// int numericValue = isEnabled.ToInt(); // Returns 1
        /// 
        /// bool isDisabled = false;
        /// int numericValue = isDisabled.ToInt(); // Returns 0
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this bool value) => value ? 1 : 0;

        /// <summary>
        /// Converts a nullable boolean value to its integer representation.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// 1 if the value is true;
        /// 0 if the value is false;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable boolean values by providing a default fallback.
        /// Example:
        /// <code>
        /// bool? nullableTrue = true;
        /// int value1 = nullableTrue.ToInt(); // Returns 1
        /// 
        /// bool? nullableFalse = false;
        /// int value2 = nullableFalse.ToInt(); // Returns 0
        /// 
        /// bool? nullValue = null;
        /// int value3 = nullValue.ToInt(); // Returns 0 (default)
        /// int value4 = nullValue.ToInt(default: -1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this bool? value, int @default = 0) => value?.ToInt() ?? @default;

        #endregion

        #region ToInt - 8 Bits ( sbyte: -128 to 127, byte: 0 to 255 )

        /// <summary>
        /// Converts an 8-bit signed integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The 8-bit signed integer to convert (range: -128 to 127).</param>
        /// <returns>The 32-bit signed integer representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the sbyte range (-128 to 127) is well within the int range.
        /// Example:
        /// <code>
        /// sbyte minValue = sbyte.MinValue; // -128
        /// int convertedMin = minValue.ToInt(); // Returns -128
        /// 
        /// sbyte maxValue = sbyte.MaxValue; // 127
        /// int convertedMax = maxValue.ToInt(); // Returns 127
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this sbyte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit signed integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 8-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation of the value if not null;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable sbyte values by providing a default fallback.
        /// Example:
        /// <code>
        /// sbyte? someValue = 42;
        /// int converted1 = someValue.ToInt(); // Returns 42
        /// 
        /// sbyte? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// int converted3 = nullValue.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this sbyte? value, int @default = 0) => value ?? @default;

        /// <summary>
        /// Converts an 8-bit unsigned integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The 8-bit unsigned integer to convert (range: 0 to 255).</param>
        /// <returns>The 32-bit signed integer representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the byte range (0 to 255) is well within the int range.
        /// Example:
        /// <code>
        /// byte minValue = byte.MinValue; // 0
        /// int convertedMin = minValue.ToInt(); // Returns 0
        /// 
        /// byte maxValue = byte.MaxValue; // 255
        /// int convertedMax = maxValue.ToInt(); // Returns 255
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this byte value) => value;

        /// <summary>
        /// Converts a nullable 8-bit unsigned integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 8-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation of the value if not null;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable byte values by providing a default fallback.
        /// Example:
        /// <code>
        /// byte? someValue = 200;
        /// int converted1 = someValue.ToInt(); // Returns 200
        /// 
        /// byte? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// int converted3 = nullValue.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this byte? value, int @default = 0) => value ?? @default;

        #endregion

        #region ToInt - 16 Bits ( short: -32,768 to 32,767, ushort: 0 to 65,535, char: U+0000 to U+FFFF )

        /// <summary>
        /// Converts a 16-bit signed integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The 16-bit signed integer to convert (range: -32,768 to 32,767).</param>
        /// <returns>The 32-bit signed integer representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the short range (-32,768 to 32,767) is well within the int range.
        /// Example:
        /// <code>
        /// short minValue = short.MinValue; // -32,768
        /// int convertedMin = minValue.ToInt(); // Returns -32,768
        /// 
        /// short maxValue = short.MaxValue; // 32,767
        /// int convertedMax = maxValue.ToInt(); // Returns 32,767
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this short value) => value;

        /// <summary>
        /// Converts a nullable 16-bit signed integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 16-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation of the value if not null;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable short values by providing a default fallback.
        /// Example:
        /// <code>
        /// short? someValue = 12345;
        /// int converted1 = someValue.ToInt(); // Returns 12345
        /// 
        /// short? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// int converted3 = nullValue.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this short? value, int @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a 16-bit unsigned integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer to convert (range: 0 to 65,535).</param>
        /// <returns>The 32-bit signed integer representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the ushort range (0 to 65,535) is well within the int range.
        /// Example:
        /// <code>
        /// ushort minValue = ushort.MinValue; // 0
        /// int convertedMin = minValue.ToInt(); // Returns 0
        /// 
        /// ushort maxValue = ushort.MaxValue; // 65,535
        /// int convertedMax = maxValue.ToInt(); // Returns 65,535
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this ushort value) => value;

        /// <summary>
        /// Converts a nullable 16-bit unsigned integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 16-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation of the value if not null;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable ushort values by providing a default fallback.
        /// Example:
        /// <code>
        /// ushort? someValue = 65000;
        /// int converted1 = someValue.ToInt(); // Returns 65000
        /// 
        /// ushort? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// int converted3 = nullValue.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this ushort? value, int @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a Unicode character to its numeric Unicode code point as a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The Unicode character to convert (range: U+0000 to U+FFFF).</param>
        /// <returns>The Unicode code point of the character as a 32-bit signed integer.</returns>
        /// <remarks>
        /// This conversion represents the character's Unicode code point value.
        /// The conversion is always safe as the char range (U+0000 to U+FFFF) is well within the int range.
        /// Example:
        /// <code>
        /// char letter = 'A'; // U+0041
        /// int codePoint1 = letter.ToInt(); // Returns 65
        /// 
        /// char symbol = '€'; // U+20AC
        /// int codePoint2 = symbol.ToInt(); // Returns 8364
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this char value) => value;

        /// <summary>
        /// Converts a nullable Unicode character to its numeric Unicode code point as a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable Unicode character to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// The Unicode code point of the character as a 32-bit signed integer if not null;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable char values by providing a default fallback.
        /// Example:
        /// <code>
        /// char? someChar = '★'; // U+2605
        /// int codePoint1 = someChar.ToInt(); // Returns 9733
        /// 
        /// char? nullChar = null;
        /// int codePoint2 = nullChar.ToInt(); // Returns 0 (default)
        /// int codePoint3 = nullChar.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this char? value, int @default = 0) => value ?? @default;

        #endregion

        #region ToInt - 32 Bits ( int: ±2.1B, uint: 0~4.2B, float: ±3.4E+38 )

        /// <summary>
        /// Returns the input 32-bit signed integer value unchanged.
        /// </summary>
        /// <param name="value">The 32-bit signed integer (range: -2,147,483,648 to 2,147,483,647).</param>
        /// <returns>The same value as input.</returns>
        /// <remarks>
        /// This method exists for API completeness and consistent usage patterns.
        /// Example:
        /// <code>
        /// int value = 42;
        /// int same = value.ToInt(); // Returns 42
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this int value) => value;

        /// <summary>
        /// Converts a nullable 32-bit signed integer to a non-nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable 32-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.</param>
        /// <returns>
        /// The input value if not null;
        /// The specified default value if the input is null.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to handle nullable integers with a default fallback.
        /// Example:
        /// <code>
        /// int? someValue = 12345;
        /// int converted1 = someValue.ToInt(); // Returns 12345
        /// 
        /// int? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// int converted3 = nullValue.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this int? value, int @default = 0) => value ?? @default;

        /// <summary>
        /// Converts a 32-bit unsigned integer to a 32-bit signed integer with overflow protection.
        /// </summary>
        /// <param name="value">The 32-bit unsigned integer to convert (range: 0 to 4,294,967,295).</param>
        /// <param name="default">The default value to return if the conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation if the value is within valid range;
        /// The specified default value if the input exceeds int.MaxValue.
        /// </returns>
        /// <remarks>
        /// This method safely handles the conversion from uint to int by checking range boundaries.
        /// Values larger than int.MaxValue (2,147,483,647) will return the default value.
        /// Example:
        /// <code>
        /// uint smallValue = 42;
        /// int converted1 = smallValue.ToInt(); // Returns 42
        /// 
        /// uint largeValue = uint.MaxValue; // 4,294,967,295
        /// int converted2 = largeValue.ToInt(); // Returns 0 (default)
        /// int converted3 = largeValue.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this uint value, int @default = 0) => value <= int.MaxValue ? unchecked((int)value) : @default;

        /// <summary>
        /// Converts a nullable 32-bit unsigned integer to a 32-bit signed integer with overflow protection.
        /// </summary>
        /// <param name="value">The nullable 32-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation if the value is within valid range;
        /// The specified default value if the input is null or exceeds int.MaxValue.
        /// </returns>
        /// <remarks>
        /// This method combines null handling with safe uint to int conversion.
        /// Example:
        /// <code>
        /// uint? someValue = 1000;
        /// int converted1 = someValue.ToInt(); // Returns 1000
        /// 
        /// uint? largeValue = uint.MaxValue;
        /// int converted2 = largeValue.ToInt(); // Returns 0 (default)
        /// 
        /// uint? nullValue = null;
        /// int converted3 = nullValue.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this uint? value, int @default = 0) => value?.ToInt(@default) ?? @default;

        /// <summary>
        /// Converts a single-precision floating-point number to a 32-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the conversion is not possible. Defaults to 0.</param>
        /// <returns>
        /// The truncated integer value if the input is finite and within valid range;
        /// The specified default value if the input is NaN, infinite, or outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method performs safe conversion with several checks:
        /// <list type="bullet">
        /// <item><description>Ensures the input is a finite number (not NaN or Infinity)</description></item>
        /// <item><description>Validates the value is within int range</description></item>
        /// <item><description>Truncates decimal places (rounds toward zero)</description></item>
        /// </list>
        /// Example:
        /// <code>
        /// float validValue = 123.45f;
        /// int converted1 = validValue.ToInt(); // Returns 123
        /// 
        /// float infinity = float.PositiveInfinity;
        /// int converted2 = infinity.ToInt(); // Returns 0 (default)
        /// 
        /// float outOfRange = 2.5e9f; // Exceeds int.MaxValue
        /// int converted3 = outOfRange.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")] // Performance optimization
        public static int ToInt(this float value, int @default = 0) => float.IsFinite(value) && value >= int.MinValue && value <= int.MaxValue ? unchecked((int)Math.Truncate(value)) : @default;

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null or conversion is not possible. Defaults to 0.</param>
        /// <returns>
        /// The truncated integer value if the input is not null, finite, and within valid range;
        /// The specified default value if the input is null, NaN, infinite, or outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method combines null handling with safe float to int conversion.
        /// Example:
        /// <code>
        /// float? someValue = 123.45f;
        /// int converted1 = someValue.ToInt(); // Returns 123
        /// 
        /// float? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// 
        /// float? invalid = float.NaN;
        /// int converted3 = invalid.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this float? value, int @default = 0) => value?.ToInt(@default) ?? @default;

        #endregion

        #region ToInt - 64 Bits ( long: ±9.2E+18, ulong: 0~18.4E+18, double: ±1.7E+308, DateTime: 1901~2038 UTC )

        /// <summary>
        /// Converts a 64-bit signed integer to a 32-bit signed integer with overflow protection.
        /// </summary>
        /// <param name="value">The 64-bit signed integer to convert (range: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807).</param>
        /// <param name="default">The default value to return if the conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation if the value is within valid range;
        /// The specified default value if the input is outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method safely handles the conversion from long to int by checking range boundaries.
        /// Example:
        /// <code>
        /// long smallValue = 42L;
        /// int converted1 = smallValue.ToInt(); // Returns 42
        /// 
        /// long largeValue = long.MaxValue;
        /// int converted2 = largeValue.ToInt(); // Returns 0 (default)
        /// 
        /// long negativeValue = -1234L;
        /// int converted3 = negativeValue.ToInt(); // Returns -1234
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")] // Performance optimization
        public static int ToInt(this long value, int @default = 0) => value >= int.MinValue && value <= int.MaxValue ? unchecked((int)value) : @default;

        /// <summary>
        /// Converts a nullable 64-bit signed integer to a 32-bit signed integer with overflow protection.
        /// </summary>
        /// <param name="value">The nullable 64-bit signed integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation if the value is within valid range;
        /// The specified default value if the input is null or outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method combines null handling with safe long to int conversion.
        /// Example:
        /// <code>
        /// long? someValue = 1000L;
        /// int converted1 = someValue.ToInt(); // Returns 1000
        /// 
        /// long? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this long? value, int @default = 0) => value?.ToInt(@default) ?? @default;

        /// <summary>
        /// Converts a 64-bit unsigned integer to a 32-bit signed integer with overflow protection.
        /// </summary>
        /// <param name="value">The 64-bit unsigned integer to convert (range: 0 to 18,446,744,073,709,551,615).</param>
        /// <param name="default">The default value to return if the conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation if the value is within valid range;
        /// The specified default value if the input exceeds int.MaxValue.
        /// </returns>
        /// <remarks>
        /// This method safely handles the conversion from ulong to int by checking range boundaries.
        /// Example:
        /// <code>
        /// ulong smallValue = 42UL;
        /// int converted1 = smallValue.ToInt(); // Returns 42
        /// 
        /// ulong largeValue = ulong.MaxValue;
        /// int converted2 = largeValue.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this ulong value, int @default = 0) => value <= int.MaxValue ? unchecked((int)value) : @default;

        /// <summary>
        /// Converts a nullable 64-bit unsigned integer to a 32-bit signed integer with overflow protection.
        /// </summary>
        /// <param name="value">The nullable 64-bit unsigned integer to convert.</param>
        /// <param name="default">The default value to return if the input is null or conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The 32-bit signed integer representation if the value is within valid range;
        /// The specified default value if the input is null or exceeds int.MaxValue.
        /// </returns>
        /// <remarks>
        /// This method combines null handling with safe ulong to int conversion.
        /// Example:
        /// <code>
        /// ulong? someValue = 1000UL;
        /// int converted1 = someValue.ToInt(); // Returns 1000
        /// 
        /// ulong? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this ulong? value, int @default = 0) => value?.ToInt(@default) ?? @default;

        /// <summary>
        /// Converts a double-precision floating-point number to a 32-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The double-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the conversion is not possible. Defaults to 0.</param>
        /// <returns>
        /// The truncated integer value if the input is finite and within valid range;
        /// The specified default value if the input is NaN, infinite, or outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method performs safe conversion with several checks:
        /// <list type="bullet">
        /// <item><description>Ensures the input is a finite number (not NaN or Infinity)</description></item>
        /// <item><description>Validates the value is within int range</description></item>
        /// <item><description>Truncates decimal places (rounds toward zero)</description></item>
        /// </list>
        /// Example:
        /// <code>
        /// double validValue = 123.45;
        /// int converted1 = validValue.ToInt(); // Returns 123
        /// 
        /// double infinity = double.PositiveInfinity;
        /// int converted2 = infinity.ToInt(); // Returns 0 (default)
        /// 
        /// double outOfRange = 2.5e10; // Exceeds int.MaxValue
        /// int converted3 = outOfRange.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")] // Performance optimization
        public static int ToInt(this double value, int @default = 0) => double.IsFinite(value) && value >= int.MinValue && value <= int.MaxValue ? unchecked((int)Math.Truncate(value)) : @default;

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null or conversion is not possible. Defaults to 0.</param>
        /// <returns>
        /// The truncated integer value if the input is not null, finite, and within valid range;
        /// The specified default value if the input is null, NaN, infinite, or outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method combines null handling with safe double to int conversion.
        /// Example:
        /// <code>
        /// double? someValue = 123.45;
        /// int converted1 = someValue.ToInt(); // Returns 123
        /// 
        /// double? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// 
        /// double? invalid = double.NaN;
        /// int converted3 = invalid.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this double? value, int @default = 0) => value?.ToInt(@default) ?? @default;

        /// <summary>
        /// Converts a DateTime to a Unix timestamp (seconds since Unix epoch) as a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <param name="default">The default value to return if the conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The number of seconds since Unix epoch (1970-01-01 00:00:00 UTC) if within valid range;
        /// The specified default value if the resulting timestamp would be outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method is obsolete due to the limited range of int timestamps.
        /// Valid range is from 1901-12-13 20:45:52 UTC to 2038-01-19 03:14:07 UTC.
        /// Use ToLong() instead for dates outside this range.
        /// Example:
        /// <code>
        /// DateTime someDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// int timestamp1 = someDate.ToInt(); // Returns Unix timestamp for 2024-01-01
        /// 
        /// DateTime futureDate = new DateTime(2040, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// int timestamp2 = futureDate.ToInt(); // Returns 0 (default, out of range)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")] // Performance optimization
        [Obsolete("Use ToLong() instead - int timestamps only support dates from 1901-12-13 20:45:52 to 2038-01-19 03:14:07 UTC")]
        public static int ToInt(this DateTime value, int @default = 0) => (value.ToUniversalTime().Ticks - DateTime.UnixEpoch.Ticks) / TimeSpan.TicksPerSecond is var seconds && seconds >= int.MinValue && seconds <= int.MaxValue ? unchecked((int)seconds) : @default;

        /// <summary>
        /// Converts a nullable DateTime to a Unix timestamp (seconds since Unix epoch) as a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable DateTime value to convert.</param>
        /// <param name="default">The default value to return if the input is null or conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The number of seconds since Unix epoch if the input is not null and within valid range;
        /// The specified default value if the input is null or the resulting timestamp would be outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method is obsolete due to the limited range of int timestamps.
        /// Use ToLong() instead for dates outside the supported range.
        /// Example:
        /// <code>
        /// DateTime? someDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// int timestamp1 = someDate.ToInt(); // Returns Unix timestamp for 2024-01-01
        /// 
        /// DateTime? nullDate = null;
        /// int timestamp2 = nullDate.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Use ToLong() instead - int timestamps only support dates from 1901-12-13 20:45:52 to 2038-01-19 03:14:07 UTC")]
        public static int ToInt([CanBeNull] this DateTime? value, int @default = 0) => value?.ToInt(@default) ?? @default;

        #endregion

        #region ToInt - 128+ Bits ( decimal: ±7.9E+28, string: parse int )

        /// <summary>
        /// Converts a decimal value to a 32-bit signed integer with range validation.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="default">The default value to return if the conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The integer value if the input is within valid range;
        /// The specified default value if the input is outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method performs safe conversion by checking against DecimalIntMin and DecimalIntMax constants.
        /// The decimal type has higher precision than int, so range validation is necessary.
        /// Example:
        /// <code>
        /// decimal validValue = 123.45m;
        /// int converted1 = validValue.ToInt(); // Returns 123
        /// 
        /// decimal largeValue = decimal.MaxValue;
        /// int converted2 = largeValue.ToInt(); // Returns 0 (default)
        /// 
        /// decimal negativeValue = -42.67m;
        /// int converted3 = negativeValue.ToInt(); // Returns -42
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("ReSharper", "MergeIntoPattern")] // For simple judgments, it performs better than Into Pattern
        public static int ToInt(this decimal value, int @default = 0) => value >= DecimalIntMin && value <= DecimalIntMax ? decimal.ToInt32(value) : @default;

        /// <summary>
        /// Converts a nullable decimal value to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <param name="default">The default value to return if the input is null or conversion would overflow. Defaults to 0.</param>
        /// <returns>
        /// The integer value if the input is not null and within valid range;
        /// The specified default value if the input is null or outside the valid range.
        /// </returns>
        /// <remarks>
        /// This method combines null handling with safe decimal to int conversion.
        /// Example:
        /// <code>
        /// decimal? someValue = 123.45m;
        /// int converted1 = someValue.ToInt(); // Returns 123
        /// 
        /// decimal? nullValue = null;
        /// int converted2 = nullValue.ToInt(); // Returns 0 (default)
        /// 
        /// decimal? largeValue = decimal.MaxValue;
        /// int converted3 = largeValue.ToInt(); // Returns 0 (default)
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this decimal? value, int @default = 0) => value?.ToInt(@default) ?? @default;

        /// <summary>
        /// Converts a string representation of a number to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The string to convert. Can be null or empty.</param>
        /// <param name="default">The default value to return if the conversion fails. Defaults to 0.</param>
        /// <returns>
        /// The parsed integer value if the string represents a valid integer;
        /// The specified default value if the input is null, empty, or not a valid integer.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to parse strings to integers with several features:
        /// <list type="bullet">
        /// <item><description>Handles null or empty strings gracefully</description></item>
        /// <item><description>Uses Span-based parsing for better performance</description></item>
        /// <item><description>Returns default value instead of throwing exceptions</description></item>
        /// </list>
        /// Example:
        /// <code>
        /// string validNumber = "123";
        /// int converted1 = validNumber.ToInt(); // Returns 123
        /// 
        /// string invalidNumber = "abc";
        /// int converted2 = invalidNumber.ToInt(); // Returns 0 (default)
        /// 
        /// string nullString = null;
        /// int converted3 = nullString.ToInt(); // Returns 0 (default)
        /// 
        /// string emptyString = "";
        /// int converted4 = emptyString.ToInt(); // Returns 0 (default)
        /// 
        /// string customDefault = "invalid";
        /// int converted5 = customDefault.ToInt(-1); // Returns -1
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt([CanBeNull] this string value, int @default = 0) => string.IsNullOrEmpty(value) ? @default : int.TryParse(value.AsSpan(), out var result) ? result : @default;

        #endregion
    }
}