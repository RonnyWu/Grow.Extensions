using System;
using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for double type conversions.
    /// </summary>
    public static class DoubleTo
    {
        /// <summary>
        /// Converts the double value to Int32.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The Int32 representation of the double value.</returns>
        /// <remarks>
        /// This method performs type conversion and always truncates decimal places.
        /// For rounding behavior, use ToRound() instead.
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// int result = number.ToInt(); // returns 123
        /// 
        /// double negative = -123.45;
        /// int negativeResult = negative.ToInt(); // returns -123
        /// 
        /// double overflow = double.MaxValue;
        /// int defaultResult = overflow.ToInt(-1); // returns -1 due to overflow
        /// </code>
        /// </example>
        public static int ToInt(this double value, int defaultValue = 0)
        {
            if (double.IsNaN(value) || double.IsInfinity(value) || value < int.MinValue || value > int.MaxValue) return defaultValue;  
            return (int)value; 
        }

        /// <summary>
        /// Converts the double value to Int64.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The Int64 representation of the double value.</returns>
        /// <remarks>
        /// This method performs type conversion and always truncates decimal places.
        /// For rounding behavior, use ToRound() instead.
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// long result = number.ToLong(); // returns 123
        /// 
        /// double large = 9223372036854775806.5;
        /// long largeResult = large.ToLong(); // returns 9223372036854775806
        /// 
        /// double overflow = double.MaxValue;
        /// long defaultResult = overflow.ToLong(-1); // returns -1 due to overflow
        /// </code>
        /// </example>
        public static long ToLong(this double value, long defaultValue = 0)
        {
            if (double.IsNaN(value) || double.IsInfinity(value) || value < long.MinValue || value > long.MaxValue) return defaultValue;
            return (long)value;
        }

        /// <summary>
        /// Converts the double value to decimal.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The decimal representation of the double value.</returns>
        /// <remarks>
        /// Be aware that converting from double to decimal might result in a loss of precision
        /// due to the different ways these types store numbers internally.
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// decimal result = number.ToDecimal(); // returns 123.45m
        /// 
        /// double scientific = 1.23E-12;
        /// decimal smallResult = scientific.ToDecimal(); // converts scientific notation
        /// 
        /// double invalid = double.NaN;
        /// decimal defaultResult = invalid.ToDecimal(0m); // returns 0m
        /// </code>
        /// </example>
        public static decimal ToDecimal(this double value, decimal defaultValue = 0m)
        {
            if (double.IsNaN(value) || double.IsInfinity(value) || value < (double)decimal.MinValue || value > (double)decimal.MaxValue) return defaultValue;
            return (decimal)value;
        }

        /// <summary>
        /// Rounds a double value to a specified number of decimal places.
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <param name="decimals">The number of decimal places to round to. Default is 2.</param>
        /// <returns>The rounded double value.</returns>
        /// <remarks>
        /// This method uses the default rounding mode (MidpointRounding.ToEven).
        /// For different rounding behaviors, use Math.Round directly with the desired MidpointRounding option.
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 123.456;
        /// double result = number.ToRound(2); // returns 123.46
        /// 
        /// double midpoint = 123.445;
        /// double midResult = midpoint.ToRound(2); // returns 123.44 due to banker's rounding
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRound(this double value, int decimals = 2) => Math.Round(value, decimals);

        /// <summary>
        /// Converts the double value to its absolute value.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The absolute value of the double.</returns>
        /// <remarks>
        /// This method returns the magnitude of a double number without regard to its sign.
        /// </remarks>
        /// <example>
        /// <code>
        /// double negative = -123.45;
        /// double result = negative.ToAbs(); // returns 123.45
        /// 
        /// double positive = 123.45;
        /// double sameResult = positive.ToAbs(); // returns 123.45
        /// 
        /// double zero = 0;
        /// double zeroResult = zero.ToAbs(); // returns 0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToAbs(this double value) => Math.Abs(value);

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the double number.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The ceiling value as double.</returns>
        /// <remarks>
        /// Unlike ToInt() which performs type conversion, this method maintains the double type
        /// and returns the smallest integral value greater than or equal to the input.
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// double result = number.ToCeiling(); // returns 124.0
        /// 
        /// double negative = -123.45;
        /// double negativeResult = negative.ToCeiling(); // returns -123.0
        /// 
        /// double whole = 123.00;
        /// double wholeResult = whole.ToCeiling(); // returns 123.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToCeiling(this double value) => Math.Ceiling(value);

        /// <summary>
        /// Converts the double value to the largest integral value less than or equal to the double number.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The floor of the double value.</returns>
        /// <remarks>
        /// Unlike ToInt() which performs type conversion, this method maintains the double type
        /// and returns the largest integral value less than or equal to the input.
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// double result = number.ToFloor(); // returns 123.0
        /// 
        /// double negative = -123.45;
        /// double negativeResult = negative.ToFloor(); // returns -124.0
        /// 
        /// double whole = 123.00;
        /// double wholeResult = whole.ToFloor(); // returns 123.0
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToFloor(this double value) => Math.Floor(value);

        /// <summary>
        /// Converts the double value to a string with a fixed number of decimal places.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string representation with the specified number of decimal places.</returns>
        /// <remarks>
        /// This method always shows the specified number of decimal places, even if they are zeros.
        /// It does not include a thousand separators.
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 123.456;
        /// string result = number.ToFixed(2); // returns "123.46"
        /// 
        /// double whole = 123;
        /// string wholeResult = whole.ToFixed(2); // returns "123.00"
        /// 
        /// double negative = -123.456;
        /// string negativeResult = negative.ToFixed(2); // returns "-123.46"
        /// </code>
        /// </example>
        public static string ToFixed(this double value, int decimals = 2) => value.ToString(Formats.GetFixedPointFormat(decimals));

        /// <summary>
        /// Converts the double value to a percentage string.
        /// </summary>
        /// <param name="value">The double value to convert (e.g., 0.1234 for 12.34%).</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A formatted percentage string.</returns>
        /// <remarks>
        /// This method multiplies the input value by 100 and appends the % symbol.
        /// The input should be in decimal form (e.g., 0.1234 for 12.34%).
        /// </remarks>
        /// <example>
        /// <code>
        /// double number = 0.1234;
        /// string result = number.ToPercentage(); // returns "12.34%"
        /// 
        /// double small = 0.001;
        /// string smallResult = small.ToPercentage(3); // returns "0.100%"
        /// 
        /// double negative = -0.1234;
        /// string negativeResult = negative.ToPercentage(); // returns "-12.34%"
        /// </code>
        /// </example>
        public static string ToPercentage(this double value, int decimals = 2) => value.ToString(Formats.GetPercentageFormat(decimals));
    }
}