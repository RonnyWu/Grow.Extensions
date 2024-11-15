using System;
using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for Int32 type conversions.
    /// </summary>
    public static class IntTo
    {
        /// <summary>
        /// Converts the integer value to Int64.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>The Int64 representation of the integer value.</returns>
        /// <remarks>
        /// This conversion is always safe as Int64 has a larger range than Int32.
        /// </remarks>
        /// <example>
        /// <code>
        /// int number = 123;
        /// long result = number.ToLong(); // returns 123L
        /// 
        /// int maxInt = int.MaxValue;
        /// long maxResult = maxInt.ToLong(); // safely converts to long
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this int value) => Convert.ToInt64(value);

        /// <summary>
        /// Converts the integer value to float.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>The float representation of the integer value.</returns>
        /// <remarks>
        /// This conversion is safe for most integers, but may lose precision for very large values.
        /// </remarks>
        /// <example>
        /// <code>
        /// int number = 123;
        /// float result = number.ToFloat(); // returns 123.0f
        /// 
        /// int large = 16777216; // 2^24
        /// float largeResult = large.ToFloat(); // may lose precision
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this int value) => Convert.ToSingle(value);

        /// <summary>
        /// Converts the integer value to double.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>The double representation of the integer value.</returns>
        /// <remarks>
        /// This conversion is always safe as double can exactly represent all integer values.
        /// </remarks>
        /// <example>
        /// <code>
        /// int number = 123;
        /// double result = number.ToDouble(); // returns 123.0
        /// 
        /// int maxInt = int.MaxValue;
        /// double maxResult = maxInt.ToDouble(); // precisely represents the value
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this int value) => Convert.ToDouble(value);

        /// <summary>
        /// Converts the integer value to decimal.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>The decimal representation of the integer value.</returns>
        /// <remarks>
        /// This conversion is always safe as decimal can exactly represent all integer values.
        /// </remarks>
        /// <example>
        /// <code>
        /// int number = 123;
        /// decimal result = number.ToDecimal(); // returns 123.0m
        /// 
        /// int maxInt = int.MaxValue;
        /// decimal maxResult = maxInt.ToDecimal(); // precisely represents the value
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(this int value) => Convert.ToDecimal(value);

        /// <summary>
        /// Converts the integer value to its absolute value.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <param name="defaultValue">The default value to return if the operation would result in overflow.</param>
        /// <returns>The absolute value of the integer.</returns>
        /// <remarks>
        /// This method handles the special case of Int32.MinValue by returning the default value,
        /// as its absolute value cannot be represented in Int32.
        /// </remarks>
        /// <example>
        /// <code>
        /// int negative = -123;
        /// int result = negative.ToAbs(); // returns 123
        /// 
        /// int minValue = int.MinValue;
        /// int minResult = minValue.ToAbs(0); // returns 0 to avoid overflow
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToAbs(this int value, int defaultValue = 0) => value == int.MinValue ? defaultValue : Math.Abs(value);

        /// <summary>
        /// Converts the integer value to a fixed-point string representation.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string representation with the specified number of decimal places.</returns>
        /// <remarks>
        /// This method always shows the specified number of decimal places, even for whole numbers.
        /// </remarks>
        /// <example>
        /// <code>
        /// int number = 123;
        /// string result = number.ToFixed(2); // returns "123.00"
        /// 
        /// int negative = -123;
        /// string negativeResult = negative.ToFixed(2); // returns "-123.00"
        /// </code>
        /// </example>
        public static string ToFixed(this int value, int decimals = 2) => value.ToString(Formats.GetFixedPointFormat(decimals));
    }
}