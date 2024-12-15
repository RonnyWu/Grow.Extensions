// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    /// <summary>
    /// Specifies the accuracy level for time measurements.
    /// Represents different time units from ticks (100ns) to seconds,
    /// following the standard time unit progression.
    /// </summary>
    public enum TimeAccuracy
    {
        Tick, // 100 nanoseconds = 1 tick
        Ns,   // 1000 ns = 1 us (microsecond)
        Us,   // 1000 us = 1 ms (millisecond)
        Ms,   // 1000 ms = 1 s (second)
        Sec   // 1 second
    }

    public static class ToDoubleSyntax
    {
        private const double DefaultDouble = 0.0;

        #region ToDouble - 1 Bits ( bool )

        /// <summary>
        /// Converts a boolean value to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>1.0 for true, 0.0 for false.</returns>
        /// <remarks>
        /// This method provides a consistent way to convert boolean values to double:
        /// <list type="bullet">
        /// <item><description>true converts to 1.0</description></item>
        /// <item><description>false converts to 0.0</description></item>
        /// </list>
        /// The values are defined as constants to ensure consistent representation and optimal performance.
        /// </remarks>
        /// <example>
        /// <code>
        /// bool value1 = true;
        /// double result1 = value1.ToDouble(); // Returns 1.0
        ///   
        /// bool value2 = false;
        /// double result2 = value2.ToDouble(); // Returns 0.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this bool value) => value ? 1.0 : DefaultDouble;

        /// <summary>
        /// Converts a nullable boolean value to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>1.0 for true, 0.0 for false, or the specified default value for null.</returns>
        /// <remarks>
        /// This method extends the boolean conversion to handle nullable values:
        /// <list type="bullet">
        /// <item><description>true converts to 1.0</description></item>
        /// <item><description>false converts to 0.0</description></item>
        /// <item><description>null converts to the specified default value (0.0 if not specified)</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// bool? value1 = true;
        /// double result1 = value1.ToDouble(); // Returns 1.0
        ///   
        /// bool? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        ///   
        /// bool? value3 = null;
        /// double result3 = value3.ToDouble(double.NaN); // Returns double.NaN
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this bool? value, double @default = DefaultDouble) => value?.ToDouble() ?? @default;

        #endregion

        #region ToDouble - 8 Bits (sbyte: -128 to 127, byte: 0 to 255)

        /// <summary>
        /// Converts a signed 8-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The signed 8-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the sbyte range (-128 to 127) is well within double precision range:
        /// <list type="bullet">
        /// <item><description>Minimum sbyte (-128) converts to -128.0</description></item>
        /// <item><description>Maximum sbyte (127) converts to 127.0</description></item>
        /// </list>
        /// The conversion is implemented as a direct cast for optimal performance, as no range checking is required.
        /// </remarks>
        /// <example>
        /// <code>
        /// sbyte value1 = 127;
        /// double result1 = value1.ToDouble(); // Returns 127.0
        ///   
        /// sbyte value2 = -128;
        /// double result2 = value2.ToDouble(); // Returns -128.0
        ///   
        /// sbyte value3 = 0;
        /// double result3 = value3.ToDouble(); // Returns 0.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this sbyte value) => value;

        /// <summary>
        /// Converts a nullable signed 8-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable signed 8-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// sbyte? value1 = 127;
        /// double result1 = value1.ToDouble(); // Returns 127.0
        ///   
        /// sbyte? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        ///   
        /// sbyte? value3 = null;
        /// double result3 = value3.ToDouble(double.NaN); // Returns double.NaN
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this sbyte? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Converts an unsigned 8-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The unsigned 8-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the byte range (0 to 255) is well within double precision range:
        /// <list type="bullet">
        /// <item><description>Minimum byte (0) converts to 0.0</description></item>
        /// <item><description>Maximum byte (255) converts to 255.0</description></item>
        /// </list>
        /// The conversion is implemented as a direct cast for optimal performance, as no range checking is required.
        /// </remarks>
        /// <example>
        /// <code>
        /// byte value1 = 255;
        /// double result1 = value1.ToDouble(); // Returns 255.0
        ///   
        /// byte value2 = 0;
        /// double result2 = value2.ToDouble(); // Returns 0.0
        ///   
        /// byte value3 = 128;
        /// double result3 = value3.ToDouble(); // Returns 128.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this byte value) => value;

        /// <summary>
        /// Converts a nullable unsigned 8-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable unsigned 8-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// byte? value1 = 255;
        /// double result1 = value1.ToDouble(); // Returns 255.0
        ///   
        /// byte? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        ///   
        /// byte? value3 = null;
        /// double result3 = value3.ToDouble(double.NaN); // Returns double.NaN
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this byte? value, double @default = DefaultDouble) => value ?? @default;

        #endregion

        #region ToDouble - 16 Bits (short: -32,768 to 32,767, ushort: 0 to 65,535, char: U+0000 to U+FFFF)

        /// <summary>
        /// Converts a signed 16-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The signed 16-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the short range (-32,768 to 32,767) is well within double precision range:
        /// <list type="bullet">
        /// <item><description>Minimum short (-32,768) converts to -32,768.0</description></item>
        /// <item><description>Maximum short (32,767) converts to 32,767.0</description></item>
        /// </list>
        /// The conversion is implemented as a direct cast for optimal performance, as no range checking is required.
        /// </remarks>
        /// <example>
        /// <code>
        /// short value1 = 32767;
        /// double result1 = value1.ToDouble(); // Returns 32767.0
        ///   
        /// short value2 = -32768;
        /// double result2 = value2.ToDouble(); // Returns -32768.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this short value) => value;

        /// <summary>
        /// Converts a nullable signed 16-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable signed 16-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// short? value1 = 32767;
        /// double result1 = value1.ToDouble(); // Returns 32767.0
        ///   
        /// short? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this short? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Converts an unsigned 16-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The unsigned 16-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the ushort range (0 to 65,535) is well within double precision range:
        /// <list type="bullet">
        /// <item><description>Minimum ushort (0) converts to 0.0</description></item>
        /// <item><description>Maximum ushort (65,535) converts to 65,535.0</description></item>
        /// </list>
        /// The conversion is implemented as a direct cast for optimal performance, as no range checking is required.
        /// </remarks>
        /// <example>
        /// <code>
        /// ushort value1 = 65535;
        /// double result1 = value1.ToDouble(); // Returns 65535.0
        ///   
        /// ushort value2 = 0;
        /// double result2 = value2.ToDouble(); // Returns 0.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this ushort value) => value;

        /// <summary>
        /// Converts a nullable unsigned 16-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable unsigned 16-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// ushort? value1 = 65535;
        /// double result1 = value1.ToDouble(); // Returns 65535.0
        ///   
        /// ushort? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this ushort? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Converts a Unicode character to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The Unicode character to convert.</param>
        /// <returns>The double-precision floating-point representation of the character's Unicode code point.</returns>
        /// <remarks>
        /// This conversion treats the character as its underlying Unicode code point value:
        /// <list type="bullet">
        /// <item><description>Minimum char (U+0000) converts to 0.0</description></item>
        /// <item><description>Maximum char (U+FFFF) converts to 65,535.0</description></item>
        /// </list>
        /// The conversion is implemented as a direct cast for optimal performance, equivalent to converting the character's Unicode value.
        /// </remarks>
        /// <example>
        /// <code>
        /// char value1 = 'A';
        /// double result1 = value1.ToDouble(); // Returns 65.0 (Unicode value of 'A')
        ///   
        /// char value2 = '\u0000';
        /// double result2 = value2.ToDouble(); // Returns 0.0
        ///   
        /// char value3 = '\uffff';
        /// double result3 = value3.ToDouble(); // Returns 65535.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this char value) => value;

        /// <summary>
        /// Converts a nullable Unicode character to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable Unicode character to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the character's Unicode code point, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// char? value1 = 'A';
        /// double result1 = value1.ToDouble(); // Returns 65.0 (Unicode value of 'A')
        ///   
        /// char? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        ///   
        /// char? value3 = null;
        /// double result3 = value3.ToDouble(double.NaN); // Returns double.NaN
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this char? value, double @default = DefaultDouble) => value ?? @default;

        #endregion

        #region ToDouble - 32 Bits (int: ±2.1B, uint: 0~4.2B, float: ±3.4E+38)

        /// <summary>
        /// Converts a signed 32-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The signed 32-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the int range (-2,147,483,648 to 2,147,483,647) is well within double precision range:
        /// <list type="bullet">
        /// <item><description>Minimum int (-2,147,483,648) converts to -2,147,483,648.0</description></item>
        /// <item><description>Maximum int (2,147,483,647) converts to 2,147,483,647.0</description></item>
        /// </list>
        /// The conversion maintains exact precision as double can represent all integer values in this range without loss.
        /// </remarks>
        /// <example>
        /// <code>
        /// int value1 = int.MaxValue;
        /// double result1 = value1.ToDouble(); // Returns 2147483647.0
        ///   
        /// int value2 = int.MinValue;
        /// double result2 = value2.ToDouble(); // Returns -2147483648.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this int value) => value;

        /// <summary>
        /// Converts a nullable signed 32-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable signed 32-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// int? value1 = int.MaxValue;
        /// double result1 = value1.ToDouble(); // Returns 2147483647.0
        ///   
        /// int? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this int? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Converts an unsigned 32-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The unsigned 32-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion is always safe as the uint range (0 to 4,294,967,295) is well within double precision range:
        /// <list type="bullet">
        /// <item><description>Minimum uint (0) converts to 0.0</description></item>
        /// <item><description>Maximum uint (4,294,967,295) converts to 4,294,967,295.0</description></item>
        /// </list>
        /// The conversion maintains exact precision as double can represent all uint values without loss.
        /// </remarks>
        /// <example>
        /// <code>
        /// uint value1 = uint.MaxValue;
        /// double result1 = value1.ToDouble(); // Returns 4294967295.0
        ///   
        /// uint value2 = uint.MinValue;
        /// double result2 = value2.ToDouble(); // Returns 0.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this uint value) => value;

        /// <summary>
        /// Converts a nullable unsigned 32-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable unsigned 32-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// uint? value1 = uint.MaxValue;
        /// double result1 = value1.ToDouble(); // Returns 4294967295.0
        ///   
        /// uint? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this uint? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Converts a single-precision floating-point number to its double-precision representation.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion is safe for all float values but may involve some precision considerations:
        /// <list type="bullet">
        /// <item><description>Range: float (±3.4E+38) fits well within double (±1.7E+308)</description></item>
        /// <item><description>Special values like NaN and Infinity are preserved</description></item>
        /// <item><description>Some minor precision differences may occur due to binary representation</description></item>
        /// </list>
        /// Key characteristics:
        /// <list type="bullet">
        /// <item><description>float.PositiveInfinity converts to double.PositiveInfinity</description></item>
        /// <item><description>float.NegativeInfinity converts to double.NegativeInfinity</description></item>
        /// <item><description>float.NaN converts to double.NaN</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// float value1 = 3.14159f;
        /// double result1 = value1.ToDouble(); // Returns ~3.14159 (possibly with slight precision difference)
        ///   
        /// float value2 = float.PositiveInfinity;
        /// double result2 = value2.ToDouble(); // Returns double.PositiveInfinity
        ///   
        /// float value3 = float.NaN;
        /// double result3 = value3.ToDouble(); // Returns double.NaN
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this float value) => value;

        /// <summary>
        /// Converts a nullable single-precision floating-point number to its double-precision representation.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// float? value1 = 3.14159f;
        /// double result1 = value1.ToDouble(); // Returns ~3.14159
        ///   
        /// float? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        ///   
        /// float? value3 = null;
        /// double result3 = value3.ToDouble(double.NaN); // Returns double.NaN
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this float? value, double @default = DefaultDouble) => value ?? @default;

        #endregion

        #region ToDouble - 64 Bits (long: ±9.2E+18, ulong: 0~18.4E+18, double: ±1.7E+308, DateTime: 1901~2038 UTC)

        /// <summary>
        /// Converts a signed 64-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The signed 64-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion may involve precision loss for large values:
        /// <list type="bullet">
        /// <item><description>Values between -2^53 and 2^53 are converted exactly</description></item>
        /// <item><description>Values outside this range may lose precision due to double's 53-bit mantissa</description></item>
        /// <item><description>The range ±9.2E+18 is fully contained within double's range (±1.7E+308)</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// long value1 = 1L &lt;&lt; 53;
        /// double result1 = value1.ToDouble(); // Exact conversion
        ///   
        /// long value2 = 1L &lt;&lt; 54;
        /// double result2 = value2.ToDouble(); // May lose precision
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this long value) => value;

        /// <summary>
        /// Converts a nullable signed 64-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable signed 64-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this long? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Converts an unsigned 64-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The unsigned 64-bit integer to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion may involve precision loss for large values:
        /// <list type="bullet">
        /// <item><description>Values up to 2^53 are converted exactly</description></item>
        /// <item><description>Values above 2^53 may lose precision due to double's 53-bit mantissa</description></item>
        /// <item><description>The range 0~18.4E+18 is fully contained within double's range</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// ulong value1 = 1UL &lt;&lt; 53;
        /// double result1 = value1.ToDouble(); // Exact conversion
        /// 
        /// ulong value2 = 1UL &lt;&lt; 54;
        /// double result2 = value2.ToDouble(); // May lose precision
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this ulong value) => value;

        /// <summary>
        /// Converts a nullable unsigned 64-bit integer to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable unsigned 64-bit integer to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this ulong? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Returns the input double-precision floating-point number unchanged.
        /// </summary>
        /// <param name="value">The double-precision floating-point number.</param>
        /// <returns>The same value.</returns>
        /// <remarks>
        /// This method exists for API completeness and type consistency:
        /// <list type="bullet">
        /// <item><description>Handles the full double range (±1.7E+308)</description></item>
        /// <item><description>Preserves special values (NaN, ±Infinity)</description></item>
        /// <item><description>No precision loss as it's an identity operation</description></item>
        /// </list>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this double value) => value;

        /// <summary>
        /// Converts a nullable double-precision floating-point number to its non-nullable representation.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The value, or the default value if null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this double? value, double @default = DefaultDouble) => value ?? @default;

        /// <summary>
        /// Converts a DateTime to its double representation as time units since Unix epoch (1970-01-01 UTC).
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <param name="accuracy">The desired time accuracy for the conversion. Defaults to milliseconds.</param>
        /// <returns>The number of time units since Unix epoch, in the specified accuracy.</returns>
        /// <remarks>
        /// Conversion characteristics:
        /// <list type="bullet">
        /// <item><description>All times are converted to UTC before processing</description></item>
        /// <item><description>The Unix epoch (1970-01-01) is used as the reference point</description></item>
        /// <item><description>Supports multiple time accuracy levels for different use cases</description></item>
        /// </list>
        /// Time accuracy options:
        /// <list type="bullet">
        /// <item><description>Ms (Default): Milliseconds - Most commonly used</description></item>
        /// <item><description>Sec: Seconds - Common for Unix timestamps</description></item>
        /// <item><description>Tick: .NET Ticks - High precision, native .NET unit</description></item>
        /// <item><description>Ns: Nanoseconds - Highest precision</description></item>
        /// <item><description>Us: Microseconds - High precision</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// var date = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        ///   
        /// double msResult = date.ToDouble();                    // Milliseconds (default)
        /// double secResult = date.ToDouble(TimeAccuracy.Sec);   // Seconds
        /// double tickResult = date.ToDouble(TimeAccuracy.Tick); // Ticks
        /// double nsResult = date.ToDouble(TimeAccuracy.Ns);     // Nanoseconds
        /// double usResult = date.ToDouble(TimeAccuracy.Us);     // Microseconds
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this DateTime value, TimeAccuracy accuracy = TimeAccuracy.Ms)
        {
            // Ensure UTC and calculate ticks since Unix epoch
            var ticks = (double)(value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime()).Ticks - DateTime.UnixEpoch.Ticks;
            // Convert to requested accuracy using optimal operations order
            return accuracy switch
            {
                TimeAccuracy.Ms => ticks / TimeSpan.TicksPerMillisecond,
                TimeAccuracy.Sec => ticks / TimeSpan.TicksPerSecond,
                TimeAccuracy.Tick => ticks,
                TimeAccuracy.Ns => ticks * 100.0,
                TimeAccuracy.Us => ticks / 10.0,
                _ => ticks / TimeSpan.TicksPerMillisecond
            };
        }

        #endregion

        #region ToDouble - 128+ Bits (decimal: ±7.9E+28, string: parse double)

        /// <summary>
        /// Converts a decimal value to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>The double-precision floating-point representation of the value.</returns>
        /// <remarks>
        /// This conversion may involve precision loss due to different representations:
        /// <list type="bullet">
        /// <item><description>Decimal: 128-bit precision, 28-29 significant digits</description></item>
        /// <item><description>Double: 64-bit precision, 15-17 significant digits</description></item>
        /// </list>
        /// Key characteristics:
        /// <list type="bullet">
        /// <item><description>Range: decimal (±7.9E+28) fits within double (±1.7E+308)</description></item>
        /// <item><description>Precision: decimal has higher precision but smaller range</description></item>
        /// <item><description>Exact for values that can be represented precisely in double</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal value1 = 123.456789m;
        /// double result1 = value1.ToDouble(); // May lose some precision
        ///   
        /// decimal value2 = 1.0m;
        /// double result2 = value2.ToDouble(); // Exact conversion
        ///   
        /// decimal value3 = decimal.MaxValue;
        /// double result3 = value3.ToDouble(); // Converts but loses precision
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this decimal value) => decimal.ToDouble(value);

        /// <summary>
        /// Converts a nullable decimal value to its double-precision floating-point representation.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <param name="default">The default value to return if the input is null. Defaults to 0.0.</param>
        /// <returns>The double-precision floating-point representation of the value, or the default value if null.</returns>
        /// <example>
        /// <code>
        /// decimal? value1 = 123.456789m;
        /// double result1 = value1.ToDouble(); // Converts with possible precision loss
        ///   
        /// decimal? value2 = null;
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        ///   
        /// decimal? value3 = null;
        /// double result3 = value3.ToDouble(double.NaN); // Returns double.NaN
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this decimal? value, double @default = DefaultDouble) => value?.ToDouble() ?? @default;

        /// <summary>
        /// Converts a string representation of a number to its double-precision floating-point equivalent.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="default">The default value to return if the conversion fails. Defaults to 0.0.</param>
        /// <returns>
        /// The double-precision floating-point number equivalent to the numeric value or symbol specified in value,
        /// or the default value if the conversion fails.
        /// </returns>
        /// <remarks>
        /// Parsing behavior:
        /// <list type="bullet">
        /// <item><description>Handles null or empty strings by returning the default value</description></item>
        /// <item><description>Uses current culture for parsing</description></item>
        /// <item><description>Supports scientific notation (e.g., "1.23E-4")</description></item>
        /// <item><description>Recognizes special values like "Infinity", "-Infinity", "NaN"</description></item>
        /// </list>
        /// Performance optimizations:
        /// <list type="bullet">
        /// <item><description>Uses Span&lt;char&gt; to avoid string allocations</description></item>
        /// <item><description>Fast-path for null/empty checks</description></item>
        /// <item><description>Uses TryParse for better performance than Parse</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// string value1 = "123.456";
        /// double result1 = value1.ToDouble(); // Returns 123.456
        ///   
        /// string value2 = "invalid";
        /// double result2 = value2.ToDouble(); // Returns 0.0 (default)
        ///   
        /// string value3 = null;
        /// double result3 = value3.ToDouble(double.NaN); // Returns double.NaN
        ///   
        /// string value4 = "1.23E-4";
        /// double result4 = value4.ToDouble(); // Returns 0.000123
        ///   
        /// string value5 = "Infinity";
        /// double result5 = value5.ToDouble(); // Returns double.PositiveInfinity
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble([CanBeNull] this string value, double @default = DefaultDouble) => string.IsNullOrEmpty(value) ? @default : double.TryParse(value.AsSpan(), out var result) ? result : @default;

        #endregion
    }
}