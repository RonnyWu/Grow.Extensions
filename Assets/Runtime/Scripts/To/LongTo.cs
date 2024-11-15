using System;
using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for Int64 (long) type conversions.
    /// </summary>
    public static class LongTo
    {
        /// <summary>
        /// Converts the long value to Int32.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The Int32 representation of the long value.</returns>
        /// <remarks>
        /// This method will return the default value if the long value exceeds Int32 range.
        /// </remarks>
        /// <example>
        /// <code>
        /// long number = 123L;
        /// int result = number.ToInt(); // returns 123
        /// 
        /// long large = long.MaxValue;
        /// int defaultResult = large.ToInt(-1); // returns -1 due to overflow
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this long value, int defaultValue = 0) => value is > int.MaxValue or < int.MinValue ? defaultValue : Convert.ToInt32(value);

        /// <summary>
        /// Converts the long value to float.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <returns>The float representation of the long value.</returns>
        /// <remarks>
        /// This conversion may lose precision for values beyond float's precision range.
        /// </remarks>
        /// <example>
        /// <code>
        /// long number = 123L;
        /// float result = number.ToFloat(); // returns 123.0f
        /// 
        /// long large = 9223372036854775807L;
        /// float largeResult = large.ToFloat(); // may lose precision
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this long value) => Convert.ToSingle(value);

        /// <summary>
        /// Converts the long value to double.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <returns>The double representation of the long value.</returns>
        /// <remarks>
        /// This conversion may lose precision for values beyond double's precision range.
        /// </remarks>
        /// <example>
        /// <code>
        /// long number = 123L;
        /// double result = number.ToDouble(); // returns 123.0
        /// 
        /// long precise = 9223372036854775807L;
        /// double preciseResult = precise.ToDouble(); // maintains precision better than float
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this long value) => Convert.ToDouble(value);

        /// <summary>
        /// Converts the long value to decimal.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <returns>The decimal representation of the long value.</returns>
        /// <remarks>
        /// This conversion is safe as decimal can represent all Int64 values precisely.
        /// </remarks>
        /// <example>
        /// <code>
        /// long number = 123L;
        /// decimal result = number.ToDecimal(); // returns 123.0m
        /// 
        /// long maxLong = long.MaxValue;
        /// decimal maxResult = maxLong.ToDecimal(); // precisely represents the value
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(this long value) => Convert.ToDecimal(value);

        /// <summary>
        /// Converts the long value to its absolute value.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <param name="defaultValue">The default value to return if the operation would result in overflow.</param>
        /// <returns>The absolute value of the long.</returns>
        /// <remarks>
        /// This method handles the special case of Int64.MinValue by returning the default value,
        /// as its absolute value cannot be represented in Int64.
        /// </remarks>
        /// <example>
        /// <code>
        /// long negative = -123L;
        /// long result = negative.ToAbs(); // returns 123
        /// 
        /// long minValue = long.MinValue;
        /// long minResult = minValue.ToAbs(0); // returns 0 to avoid overflow
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToAbs(this long value, long defaultValue = 0) => value == long.MinValue ? defaultValue : Math.Abs(value);

        /// <summary>
        /// Converts the long value to a fixed-point string representation.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string representation with the specified number of decimal places.</returns>
        /// <remarks>
        /// This method always shows the specified number of decimal places, even for whole numbers.
        /// </remarks>
        /// <example>
        /// <code>
        /// long number = 123L;
        /// string result = number.ToFixed(2); // returns "123.00"
        /// 
        /// long negative = -123L;
        /// string negativeResult = negative.ToFixed(2); // returns "-123.00"
        /// </code>
        /// </example>
        public static string ToFixed(this long value, int decimals = 2) => value.ToString(Formats.GetFixedPointFormat(decimals));
    }
}