using System;
using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for Int16 (short) type conversions.
    /// </summary>
    public static class ShortTo
    {
        /// <summary>
        /// Converts the short value to Int32.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>The Int32 representation of the short value.</returns>
        /// <remarks>
        /// This conversion is always safe as Int32 has a larger range than Int16.
        /// </remarks>
        /// <example>
        /// <code>
        /// short number = 123;
        /// int result = number.ToInt(); // returns 123
        /// 
        /// short maxShort = short.MaxValue;
        /// int maxResult = maxShort.ToInt(); // safely converts to int
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this short value) => Convert.ToInt32(value);

        /// <summary>
        /// Converts the short value to Int64.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>The Int64 representation of the short value.</returns>
        /// <remarks>
        /// This conversion is always safe as Int64 has a larger range than Int16.
        /// </remarks>
        /// <example>
        /// <code>
        /// short number = 123;
        /// long result = number.ToLong(); // returns 123L
        /// 
        /// short maxShort = short.MaxValue;
        /// long maxResult = maxShort.ToLong(); // safely converts to long
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong(this short value) => Convert.ToInt64(value);

        /// <summary>
        /// Converts the short value to float.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>The float representation of the short value.</returns>
        /// <remarks>
        /// This conversion is always safe as float can exactly represent all Int16 values.
        /// </remarks>
        /// <example>
        /// <code>
        /// short number = 123;
        /// float result = number.ToFloat(); // returns 123.0f
        /// 
        /// short maxShort = short.MaxValue;
        /// float maxResult = maxShort.ToFloat(); // precisely represents the value
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this short value) => Convert.ToSingle(value);

        /// <summary>
        /// Converts the short value to double.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>The double representation of the short value.</returns>
        /// <remarks>
        /// This conversion is always safe as double can exactly represent all Int16 values.
        /// </remarks>
        /// <example>
        /// <code>
        /// short number = 123;
        /// double result = number.ToDouble(); // returns 123.0
        /// 
        /// short maxShort = short.MaxValue;
        /// double maxResult = maxShort.ToDouble(); // precisely represents the value
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this short value) => Convert.ToDouble(value);

        /// <summary>
        /// Converts the short value to decimal.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>The decimal representation of the short value.</returns>
        /// <remarks>
        /// This conversion is always safe as decimal can exactly represent all Int16 values.
        /// </remarks>
        /// <example>
        /// <code>
        /// short number = 123;
        /// decimal result = number.ToDecimal(); // returns 123.0m
        /// 
        /// short maxShort = short.MaxValue;
        /// decimal maxResult = maxShort.ToDecimal(); // precisely represents the value
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(this short value) => Convert.ToDecimal(value);

        /// <summary>
        /// Converts the short value to its absolute value.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <param name="defaultValue">The default value to return if the operation would result in overflow.</param>
        /// <returns>The absolute value of the short.</returns>
        /// <remarks>
        /// This method handles the special case of Int16.MinValue by returning the default value,
        /// as its absolute value cannot be represented in Int16.
        /// </remarks>
        /// <example>
        /// <code>
        /// short negative = -123;
        /// short result = negative.ToAbs(); // returns 123
        /// 
        /// short minValue = short.MinValue;
        /// short minResult = minValue.ToAbs(0); // returns 0 to avoid overflow
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToAbs(this short value, short defaultValue = 0) => value == short.MinValue ? defaultValue : Math.Abs(value);

        /// <summary>
        /// Converts the short value to a fixed-point string representation.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string representation with the specified number of decimal places.</returns>
        /// <remarks>
        /// This method always shows the specified number of decimal places, even for whole numbers.
        /// </remarks>
        /// <example>
        /// <code>
        /// short number = 123;
        /// string result = number.ToFixed(2); // returns "123.00"
        /// 
        /// short negative = -123;
        /// string negativeResult = negative.ToFixed(2); // returns "-123.00"
        /// </code>
        /// </example>
        public static string ToFixed(this short value, int decimals = 2) => value.ToString(Formats.GetFixedPointFormat(decimals));
    }
}