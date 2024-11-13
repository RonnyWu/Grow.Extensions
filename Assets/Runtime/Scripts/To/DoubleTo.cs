using System;

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
        /// <returns>The Int32 representation of the double value.</returns>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// int result = number.ToInt(); // returns 123
        /// </code>
        /// </example>
        public static int ToInt(this double value) => Convert.ToInt32(value);

        /// <summary>
        /// Converts the double value to Int64.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The Int64 representation of the double value.</returns>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// long result = number.ToLong(); // returns 123
        /// </code>
        /// </example>
        public static long ToLong(this double value) => Convert.ToInt64(value);

        /// <summary>
        /// Converts the double value to decimal.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The decimal representation of the double value.</returns>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// decimal result = number.ToDecimal(); // returns 123.45m
        /// </code>
        /// </example>
        public static decimal ToDecimal(this double value) => Convert.ToDecimal(value);

        /// <summary>
        /// Converts the double value to its absolute value.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The absolute value of the double.</returns>
        /// <example>
        /// <code>
        /// double number = -123.45;
        /// double result = number.ToAbs(); // returns 123.45
        /// </code>
        /// </example>
        public static double ToAbs(this double value) => Math.Abs(value);

        /// <summary>
        /// Converts the double value to the smallest integral value that is greater than or equal to the double number.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The ceiling of the double value.</returns>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// double result = number.ToCeiling(); // returns 124.0
        /// </code>
        /// </example>
        public static double ToCeiling(this double value) => Math.Ceiling(value);

        /// <summary>
        /// Converts the double value to the largest integral value less than or equal to the double number.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The floor of the double value.</returns>
        /// <example>
        /// <code>
        /// double number = 123.45;
        /// double result = number.ToFloor(); // returns 123.0
        /// </code>
        /// </example>
        public static double ToFloor(this double value) => Math.Floor(value);

        /// <summary>
        /// Rounds a double value to a specified number of decimal places.
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <param name="decimals">The number of decimal places to round to. Default is 2.</param>
        /// <returns>The rounded double value.</returns>
        /// <example>
        /// <code>
        /// double number = 123.456;
        /// double result = number.ToRound(2); // returns 123.46
        /// </code>
        /// </example>
        public static double ToRound(this double value, int decimals = 2) => Math.Round(value, decimals);

        /// <summary>
        /// Converts the double value to a string with a fixed number of decimal places.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string representation with the specified number of decimal places.</returns>
        /// <example>
        /// <code>
        /// double number = 123.456;
        /// string result = number.ToFixed(2); // returns "123.46"
        /// </code>
        /// </example>
        public static string ToFixed(this double value, int decimals = 2) => value.ToString($"F{decimals}");

        /// <summary>
        /// Converts the double value to a scientific notation string.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string in scientific notation.</returns>
        /// <example>
        /// <code>
        /// double number = 12345.6789;
        /// string result = number.ToScientific(2); // returns "1.23E+004"
        /// </code>
        /// </example>
        public static string ToScientific(this double value, int decimals = 2) => value.ToString($"E{decimals}");

        /// <summary>
        /// Truncates the decimal part of the double value.
        /// </summary>
        /// <param name="value">The double value to truncate.</param>
        /// <returns>The integral part of the double value.</returns>
        /// <example>
        /// <code>
        /// double number = 123.456;
        /// double result = number.ToTruncate(); // returns 123.0
        /// </code>
        /// </example>
        public static double ToTruncate(this double value) => Math.Truncate(value);
    }
}