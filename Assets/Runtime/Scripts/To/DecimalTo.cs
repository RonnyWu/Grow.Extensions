using System;

namespace Grow.Extensions
{
    /// <summary>  
    /// Provides extension methods for decimal type conversions.  
    /// </summary>  
    public static class DecimalTo
    {
        /// <summary>  
        /// Converts the decimal value to Int32, truncating any decimal places.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <returns>The Int32 value with truncated decimal places.</returns>  
        /// <remarks>  
        /// This method performs type conversion and always truncates decimal places.  
        /// For rounding behavior, use ToRound() instead.  
        /// For ceiling value while maintaining decimal type, use ToCeiling() instead.  
        /// </remarks>  
        /// <example>  
        /// <code>  
        /// decimal number = 123.45m;  
        /// int result = number.ToInt(); // returns 123  
        ///   
        /// decimal negative = -123.45m;  
        /// int negativeResult = negative.ToInt(); // returns -123  
        /// </code>  
        /// </example>  
        public static int ToInt(this decimal value) => Convert.ToInt32(value);

        /// <summary>  
        /// Converts the decimal value to Int64.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <returns>The Int64 representation of the decimal value.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = 123.45m;  
        /// long result = number.ToLong(); // returns 123  
        /// </code>  
        /// </example>  
        public static long ToLong(this decimal value) => Convert.ToInt64(value);

        /// <summary>  
        /// Converts the decimal value to Double.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <returns>The Double representation of the decimal value.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = 123.45m;  
        /// double result = number.ToDouble(); // returns 123.45  
        /// </code>  
        /// </example>  
        public static double ToDouble(this decimal value) => Convert.ToDouble(value);

        /// <summary>  
        /// Rounds a decimal value to a specified number of decimal places.  
        /// </summary>  
        /// <param name="value">The decimal value to round.</param>  
        /// <param name="decimals">The number of decimal places to round to. Default is 2.</param>  
        /// <returns>The rounded decimal value.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = 123.456m;  
        /// decimal result = number.ToRound(2); // returns 123.46m  
        /// </code>  
        /// </example>  
        public static decimal ToRound(this decimal value, int decimals = 2) => Math.Round(value, decimals);

        /// <summary>  
        /// Converts the decimal value to a string with a fixed number of decimal places.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <param name="decimals">The number of decimal places. Default is 2.</param>  
        /// <returns>A string representation with the specified number of decimal places.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = 123.456m;  
        /// string result = number.ToFixed(2); // returns "123.46"  
        /// </code>  
        /// </example>  
        public static string ToFixed(this decimal value, int decimals = 2) => value.ToString($"F{decimals}");

        /// <summary>  
        /// Converts the decimal value to a currency string with a specified symbol.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <param name="symbol">The currency symbol. Default is "¥".</param>  
        /// <param name="decimals">The number of decimal places. Default is 2.</param>  
        /// <returns>A formatted currency string.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = 1234.56m;  
        /// string result = number.ToCurrency(); // returns "¥1,234.56"  
        /// string result2 = number.ToCurrency("$"); // returns "$1,234.56"  
        /// </code>  
        /// </example>  
        public static string ToCurrency(this decimal value, string symbol = "¥", int decimals = 2) => $"{symbol}{value.ToString($"N{decimals}")}";

        /// <summary>  
        /// Converts the decimal value to a percentage string.  
        /// </summary>  
        /// <param name="value">The decimal value to convert (e.g., 0.1234 for 12.34%).</param>  
        /// <param name="decimals">The number of decimal places. Default is 2.</param>  
        /// <returns>A formatted percentage string.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = 0.1234m;  
        /// string result = number.ToPercentage(); // returns "12.34%"  
        /// </code>  
        /// </example>  
        public static string ToPercentage(this decimal value, int decimals = 2) => (value * 100).ToString($"F{decimals}") + "%";

        /// <summary>  
        /// Converts the decimal value to its absolute value.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <returns>The absolute value of the decimal.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = -123.45m;  
        /// decimal result = number.ToAbs(); // returns 123.45m  
        /// </code>  
        /// </example>  
        public static decimal ToAbs(this decimal value) => Math.Abs(value);

        /// <summary>  
        /// Returns the smallest integral value that is greater than or equal to the decimal number.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <returns>The ceiling value as decimal.</returns>  
        /// <remarks>  
        /// Unlike ToInt() which performs type conversion, this method maintains the decimal type  
        /// and returns the smallest integral value greater than or equal to the input.  
        /// </remarks>  
        /// <example>  
        /// <code>  
        /// decimal number = 123.45m;  
        /// decimal result = number.ToCeiling(); // returns 124m  
        ///   
        /// decimal negative = -123.45m;  
        /// decimal negativeResult = negative.ToCeiling(); // returns -123m  
        /// </code>  
        /// </example>  
        public static decimal ToCeiling(this decimal value) => Math.Ceiling(value);

        /// <summary>  
        /// Converts the decimal value to the largest integral value less than or equal to the decimal number.  
        /// </summary>  
        /// <param name="value">The decimal value to convert.</param>  
        /// <returns>The floor of the decimal value.</returns>  
        /// <example>  
        /// <code>  
        /// decimal number = 123.45m;  
        /// decimal result = number.ToFloor(); // returns 123m  
        ///   
        /// decimal negativeNumber = -123.45m;  
        /// decimal negativeResult = negativeNumber.ToFloor(); // returns -124m  
        /// </code>  
        /// </example>  
        public static decimal ToFloor(this decimal value) => Math.Floor(value);
    }
}