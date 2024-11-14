using System;
using System.Globalization;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for String type conversions.
    /// </summary>
    public static class StringTo
    {
        /// <summary>
        /// Converts the string value to Int32.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The Int32 representation of the string value, or default value if conversion fails.</returns>
        /// <remarks>
        /// This method handles null, empty strings, and invalid formats by returning the default value.
        /// </remarks>
        /// <example>
        /// <code>
        /// string number = "123";
        /// int result = number.ToInt(); // returns 123
        /// 
        /// string invalid = "abc";
        /// int defaultResult = invalid.ToInt(-1); // returns -1
        /// </code>
        /// </example>
        public static int ToInt(this string value, int defaultValue = 0)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return int.TryParse(value, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string value to Int64.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The Int64 representation of the string value, or default value if conversion fails.</returns>
        /// <remarks>
        /// This method handles null, empty strings, and invalid formats by returning the default value.
        /// </remarks>
        /// <example>
        /// <code>
        /// string number = "123";
        /// long result = number.ToLong(); // returns 123L
        /// 
        /// string invalid = "abc";
        /// long defaultResult = invalid.ToLong(-1L); // returns -1L
        /// </code>
        /// </example>
        public static long ToLong(this string value, long defaultValue = 0L)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return long.TryParse(value, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string value to float.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The float representation of the string value, or default value if conversion fails.</returns>
        /// <remarks>
        /// This method handles null, empty strings, and invalid formats by returning the default value.
        /// Uses invariant culture for parsing.
        /// </remarks>
        /// <example>
        /// <code>
        /// string number = "123.45";
        /// float result = number.ToFloat(); // returns 123.45f
        /// 
        /// string invalid = "abc";
        /// float defaultResult = invalid.ToFloat(-1f); // returns -1f
        /// </code>
        /// </example>
        public static float ToFloat(this string value, float defaultValue = 0f)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string value to double.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The double representation of the string value, or default value if conversion fails.</returns>
        /// <remarks>
        /// This method handles null, empty strings, and invalid formats by returning the default value.
        /// Uses invariant culture for parsing.
        /// </remarks>
        /// <example>
        /// <code>
        /// string number = "123.45";
        /// double result = number.ToDouble(); // returns 123.45
        /// 
        /// string invalid = "abc";
        /// double defaultResult = invalid.ToDouble(-1.0); // returns -1.0
        /// </code>
        /// </example>
        public static double ToDouble(this string value, double defaultValue = 0d)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string value to decimal.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The decimal representation of the string value, or default value if conversion fails.</returns>
        /// <remarks>
        /// This method handles null, empty strings, and invalid formats by returning the default value.
        /// Uses invariant culture for parsing.
        /// </remarks>
        /// <example>
        /// <code>
        /// string number = "123.45";
        /// decimal result = number.ToDecimal(); // returns 123.45m
        /// 
        /// string invalid = "abc";
        /// decimal defaultResult = invalid.ToDecimal(-1m); // returns -1m
        /// </code>
        /// </example>
        public static decimal ToDecimal(this string value, decimal defaultValue = 0m)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts the string value to boolean.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The boolean representation of the string value, or default value if conversion fails.</returns>
        /// <remarks>
        /// This method handles null, empty strings, and invalid formats by returning the default value.
        /// Recognizes "true", "false" (case-insensitive) and "1", "0" as valid inputs.
        /// </remarks>
        /// <example>
        /// <code>
        /// string value = "true";
        /// bool result = value.ToBool(); // returns true
        /// 
        /// string number = "1";
        /// bool numResult = number.ToBool(); // returns true
        /// 
        /// string invalid = "abc";
        /// bool defaultResult = invalid.ToBool(false); // returns false
        /// </code>
        /// </example>
        public static bool ToBool(this string value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return value.Trim().ToLowerInvariant() switch
            {
                "1" or "true" => true,
                "0" or "false" => false,
                _ => defaultValue
            };
        }

        /// <summary>
        /// Converts the string value to DateTime using specified formats.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <param name="formats">One or more date formats to try.</param>
        /// <returns>The DateTime representation of the string value, or default value if conversion fails.</returns>
        /// <remarks>
        /// Uses invariant culture for parsing to ensure consistent behavior across different regions.
        /// </remarks>
        /// <example>
        /// <code>
        /// string date = "2023-12-31";
        /// DateTime result1 = date.ToDateTime("yyyy-MM-dd"); // returns DateTime(2023, 12, 31)
        /// 
        /// string date2 = "2023/12/31";
        /// DateTime result2 = date2.ToDateTime(DateTime.MinValue, "yyyy-MM-dd", "yyyy/MM/dd"); // tries both formats
        /// 
        /// string dateTime = "20231231235959";
        /// DateTime result3 = dateTime.ToDateTime("yyyyMMddHHmmss"); // returns DateTime(2023, 12, 31, 23, 59, 59)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this string value, DateTime defaultValue = default, params string[] formats)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            if (formats == null || formats.Length == 0) return DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result1) ? result1 : defaultValue;
            return DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result2) ? result2 : defaultValue;
        }
    }
}