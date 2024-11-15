using System;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides commonly used format templates for number and datetime formatting.
    /// </summary>
    /// <remarks>
    /// This class contains predefined format strings as constants to:
    /// <list type="bullet">
    /// <item><description>Improve code readability by using meaningful names instead of magic strings</description></item>
    /// <item><description>Prevent typos and formatting errors</description></item>
    /// <item><description>Centralize format string management</description></item>
    /// <item><description>Optimize performance by reusing constant strings</description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// Basic usage:
    /// <code>
    /// double number = 1234.5678;
    /// Console.WriteLine(number.ToString(Formats.F2));// "1234.57"
    /// Console.WriteLine(number.ToString(Formats.N2));// "1,234.57"
    /// 
    /// DateTime now = DateTime.Now;
    /// Console.WriteLine(now.ToString(Formats.ShortDate));// "2024/01/01"
    /// Console.WriteLine(now.ToString(Formats.FullDateTime));// "2024/01/01 13:45:30"
    /// </code>
    /// </example>
    public static class Formats
    {
        /// <summary>
        /// Format as integer with no decimal places. (F0)
        /// </summary>
        /// <example>1234.56 -> "1235"</example>
        public const string F0 = "F0";

        /// <summary>
        /// Format with 1 decimal place. (F1)
        /// </summary>
        /// <example>1234.56 -> "1234.6"</example>
        public const string F1 = "F1";

        /// <summary>
        /// Format with 2 decimal places. (F2)
        /// </summary>
        /// <example>1234.56 -> "1234.56"</example>
        public const string F2 = "F2";

        /// <summary>
        /// Format with 3 decimal places. (F3)
        /// </summary>
        /// <example>1234.5678 -> "1234.568"</example>
        public const string F3 = "F3";

        /// <summary>
        /// Format with 4 decimal places. (F4)
        /// </summary>
        /// <example>1234.5678 -> "1234.5678"</example>
        public const string F4 = "F4";

        /// <summary>
        /// Format as integer with thousand separators. (N0)
        /// </summary>
        /// <example>1234567.89 -> "1,234,568"</example>
        public const string N0 = "N0";

        /// <summary>
        /// Format with 1 decimal place and thousand separators. (N1)
        /// </summary>
        /// <example>1234567.89 -> "1,234,567.9"</example>
        public const string N1 = "N1";

        /// <summary>
        /// Format with 2 decimal places and thousand separators. (N2)
        /// </summary>
        /// <example>1234567.89 -> "1,234,567.89"</example>
        public const string N2 = "N2";

        /// <summary>
        /// Format with 3 decimal places and thousand separators. (N3)
        /// </summary>
        /// <example>1234567.891 -> "1,234,567.891"</example>
        public const string N3 = "N3";

        /// <summary>
        /// Format with 4 decimal places and thousand separators. (N4)
        /// </summary>
        /// <example>1234567.8912 -> "1,234,567.8912"</example>
        public const string N4 = "N4";

        /// <summary>
        /// Format as percentage with no decimal places. (P0)
        /// </summary>
        /// <example>0.1234 -> "12%"</example>
        public const string P0 = "P0";

        /// <summary>
        /// Format as percentage with 1 decimal place. (P1)
        /// </summary>
        /// <example>0.1234 -> "12.3%"</example>
        public const string P1 = "P1";

        /// <summary>
        /// Format as percentage with 2 decimal places. (P2)
        /// </summary>
        /// <example>0.1234 -> "12.34%"</example>
        public const string P2 = "P2";

        /// <summary>
        /// Format as percentage with 3 decimal places. (P3)
        /// </summary>
        /// <example>0.12345 -> "12.345%"</example>
        public const string P3 = "P3";

        /// <summary>
        /// Format as currency with no decimal places. (C0)
        /// </summary>
        /// <example>1234.56 -> "$1,235" (culture-dependent)</example>
        public const string C0 = "C0";

        /// <summary>
        /// Format as currency with 2 decimal places. (C2)
        /// </summary>
        /// <example>1234.56 -> "$1,234.56" (culture-dependent)</example>
        public const string C2 = "C2";

        /// <summary>
        /// Format as lowercase hexadecimal.
        /// </summary>
        /// <example>255 -> "ff"</example>
        public const string x = "x";

        /// <summary>
        /// Format as uppercase hexadecimal.
        /// </summary>
        /// <example>255 -> "FF"</example>
        public const string X = "X";

        /// <summary>
        /// Format as 2-digit lowercase hexadecimal.
        /// </summary>
        /// <example>255 -> "ff", 15 -> "0f"</example>
        public const string x2 = "x2";

        /// <summary>
        /// Format as 2-digit uppercase hexadecimal.
        /// </summary>
        /// <example>255 -> "FF", 15 -> "0F"</example>
        public const string X2 = "X2";

        /// <summary>
        /// Format as 4-digit lowercase hexadecimal.
        /// </summary>
        /// <example>255 -> "00ff"</example>
        public const string x4 = "x4";

        /// <summary>
        /// Format as 4-digit uppercase hexadecimal.
        /// </summary>
        /// <example>255 -> "00FF"</example>
        public const string X4 = "X4";

        /// <summary>
        /// Format as 8-digit lowercase hexadecimal.
        /// </summary>
        /// <example>255 -> "000000ff"</example>
        public const string x8 = "x8";

        /// <summary>
        /// Format as 8-digit uppercase hexadecimal.
        /// </summary>
        /// <example>255 -> "000000FF"</example>
        public const string X8 = "X8";

        /// <summary>
        /// Format date in short form (yyyy/MM/dd).
        /// </summary>
        /// <example>2024-01-01 13:45:30 -> "2024/01/01"</example>
        public const string ShortDate = "yyyy/MM/dd";

        /// <summary>
        /// Format date in long form with Chinese characters.
        /// </summary>
        /// <example>2024-01-01 13:45:30 -> "2024年01月01日"</example>
        /// <remarks>This format is specifically designed for Chinese locale.</remarks>
        public const string LongDate = "yyyy年MM月dd日";

        /// <summary>
        /// Format time in short form (HH:mm).
        /// </summary>
        /// <example>2024-01-01 13:45:30 -> "13:45"</example>
        public const string ShortTime = "HH:mm";

        /// <summary>
        /// Format time in long form (HH:mm:ss).
        /// </summary>
        /// <example>2024-01-01 13:45:30 -> "13:45:30"</example>
        public const string LongTime = "HH:mm:ss";

        /// <summary>
        /// Format full date and time (yyyy/MM/dd HH:mm:ss).
        /// </summary>
        /// <example>2024-01-01 13:45:30 -> "2024/01/01 13:45:30"</example>
        public const string FullDateTime = "yyyy/MM/dd HH:mm:ss";

        /// <summary>
        /// Format as ISO 8601 date and time (yyyy-MM-ddTHH:mm:ss).
        /// </summary>
        /// <example>2024-01-01 13:45:30 -> "2024-01-01T13:45:30"</example>
        /// <remarks>This format is commonly used for international date exchange and database storage.</remarks>
        public const string Iso8601 = "yyyy-MM-ddTHH:mm:ss";

        /// <summary>
        /// Format date and time in a filename-safe format (yyyyMMdd_HHmmss).
        /// </summary>
        /// <example>2024-01-01 13:45:30 -> "20240101_134530"</example>
        /// <remarks>This format is safe to use in filenames across all operating systems.</remarks>
        public const string FileNameSafe = "yyyyMMdd_HHmmss";

        /// <summary>
        /// Format 4-digit year (yyyy).
        /// </summary>
        /// <example>2024-01-01 -> "2024"</example>
        public const string Year = "yyyy";

        /// <summary>
        /// Format 2-digit month (MM).
        /// </summary>
        /// <example>2024-01-01 -> "01"</example>
        public const string Month = "MM";

        /// <summary>
        /// Format 2-digit day (dd).
        /// </summary>
        /// <example>2024-01-01 -> "01"</example>
        public const string Day = "dd";

        /// <summary>
        /// Format 24-hour clock (HH).
        /// </summary>
        /// <example>13:45:30 -> "13"</example>
        public const string Hour24 = "HH";

        /// <summary>
        /// Format 12-hour clock (hh).
        /// </summary>
        /// <example>13:45:30 -> "01"</example>
        public const string Hour12 = "hh";

        /// <summary>
        /// Format minutes (mm).
        /// </summary>
        /// <example>13:45:30 -> "45"</example>
        public const string Minute = "mm";

        /// <summary>
        /// Format seconds (ss).
        /// </summary>
        /// <example>13:45:30 -> "30"</example>
        public const string Second = "ss";

        /// <summary>
        /// Format milliseconds (fff).
        /// </summary>
        /// <example>13:45:30.123 -> "123"</example>
        public const string Millisecond = "fff";

        /// <summary>
        /// Format types for numeric formatting
        /// </summary>
        private enum FormatType
        {
            Fixed = 'F',
            Numeric = 'N',
            Percentage = 'P',
            Currency = 'C'
        }

        private static string GetFormat(FormatType type, int decimals)
        {
            if (decimals is < 0 or > 15) throw new ArgumentOutOfRangeException(nameof(decimals), decimals, "Number of decimal places must be between 0 and 15.");
            return string.Intern($"{(char)type}{decimals}");
        }

        /// <summary>
        /// Gets a fixed-point format string for the specified number of decimal places.
        /// </summary>
        public static string GetFixedPointFormat(int decimals) => GetFormat(FormatType.Fixed, decimals);

        /// <summary>
        /// Gets a numeric format string with a thousand separators for the specified number of decimal places.
        /// </summary>
        public static string GetNumericFormat(int decimals) => GetFormat(FormatType.Numeric, decimals);

        /// <summary>
        /// Gets a percentage format string for the specified number of decimal places.
        /// </summary>
        public static string GetPercentageFormat(int decimals) => GetFormat(FormatType.Percentage, decimals);

        /// <summary>
        /// Gets a currency format string for the specified number of decimal places.
        /// </summary>
        public static string GetCurrencyFormat(int decimals) => GetFormat(FormatType.Currency, decimals);
    }
}