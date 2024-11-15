using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

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
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
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
        /// 
        /// decimal overflow = decimal.MaxValue;
        /// int defaultResult = overflow.ToInt(-1); // returns -1 due to overflow
        /// </code>
        /// </example>
        public static int ToInt(this decimal value, int defaultValue = 0)
        {
            try { return Convert.ToInt32(value); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Converts the decimal value to Int64.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The Int64 representation of the decimal value.</returns>
        /// <remarks>
        /// This method performs type conversion and always truncates decimal places.
        /// For rounding behavior, use ToRound() instead.
        /// For ceiling value while maintaining decimal type, use ToCeiling() instead.
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal number = 123.45m;
        /// long result = number.ToLong(); // returns 123
        /// 
        /// decimal large = 9223372036854775806.5m;
        /// long largeResult = large.ToLong(); // returns 9223372036854775806
        /// 
        /// decimal overflow = decimal.MaxValue;
        /// long defaultResult = overflow.ToLong(-1); // returns -1 due to overflow
        /// </code>
        /// </example>
        public static long ToLong(this decimal value, long defaultValue = 0)
        {
            try { return Convert.ToInt64(value); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Converts the decimal value to Double.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>The Double representation of the decimal value.</returns>
        /// <remarks>
        /// Be aware that converting from decimal to double might result in a loss of precision
        /// due to the different ways these types store numbers internally.
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal number = 123.45m;
        /// double result = number.ToDouble(); // returns 123.45
        /// 
        /// decimal precise = 123.4567890123456789m;
        /// double lessPercise = precise.ToDouble(); // might lose some precision
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this decimal value) => Convert.ToDouble(value);

        /// <summary>
        /// Rounds a decimal value to a specified number of decimal places.
        /// </summary>
        /// <param name="value">The decimal value to round.</param>
        /// <param name="decimals">The number of decimal places to round to. Default is 2.</param>
        /// <returns>The rounded decimal value.</returns>
        /// <remarks>
        /// This method uses the default rounding mode (MidpointRounding.ToEven).
        /// For different rounding behaviors, use Math.Round directly with the desired MidpointRounding option.
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal number = 123.456m;
        /// decimal result = number.ToRound(2); // returns 123.46m
        /// 
        /// decimal midpoint = 123.445m;
        /// decimal midResult = midpoint.ToRound(2); // returns 123.44m due to banker's rounding
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToRound(this decimal value, int decimals = 2) => Math.Round(value, decimals);

        /// <summary>
        /// Converts the decimal value to its absolute value.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>The absolute value of the decimal.</returns>
        /// <remarks>
        /// This method returns the magnitude of a decimal number without regard to its sign.
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal negative = -123.45m;
        /// decimal result = negative.ToAbs(); // returns 123.45m
        /// 
        /// decimal positive = 123.45m;
        /// decimal sameResult = positive.ToAbs(); // returns 123.45m
        /// 
        /// decimal zero = 0m;
        /// decimal zeroResult = zero.ToAbs(); // returns 0m
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        /// 
        /// decimal whole = 123.00m;
        /// decimal wholeResult = whole.ToCeiling(); // returns 123m
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToCeiling(this decimal value) => Math.Ceiling(value);

        /// <summary>
        /// Converts the decimal value to the largest integral value less than or equal to the decimal number.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>The floor of the decimal value.</returns>
        /// <remarks>
        /// Unlike ToInt() which performs type conversion, this method maintains the decimal type
        /// and returns the largest integral value less than or equal to the input.
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal number = 123.45m;
        /// decimal result = number.ToFloor(); // returns 123m
        /// 
        /// decimal negative = -123.45m;
        /// decimal negativeResult = negative.ToFloor(); // returns -124m
        /// 
        /// decimal whole = 123.00m;
        /// decimal wholeResult = whole.ToFloor(); // returns 123m
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToFloor(this decimal value) => Math.Floor(value);

        /// <summary>
        /// Converts the decimal value to a string with a fixed number of decimal places.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string representation with the specified number of decimal places.</returns>
        /// <remarks>
        /// This method always shows the specified number of decimal places, even if they are zeros.
        /// It does not include a thousand separators.
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal number = 123.456m;
        /// string result = number.ToFixed(2); // returns "123.46"
        /// 
        /// decimal whole = 123m;
        /// string wholeResult = whole.ToFixed(2); // returns "123.00"
        /// 
        /// decimal negative = -123.456m;
        /// string negativeResult = negative.ToFixed(2); // returns "-123.46"
        /// </code>
        /// </example>
        public static string ToFixed(this decimal value, int decimals = 2) => value.ToString($"F{decimals}");

        /// <summary>
        /// Converts a decimal value to a currency string using specified or current culture settings.
        /// </summary>
        /// <param name="value">The monetary value to format.</param>
        /// <param name="culture">
        /// The culture identifier (e.g., "en-US", "zh-CN", "ja-JP") or CultureInfo instance.
        /// If null, uses the current culture.
        /// </param>
        /// <param name="decimals">Number of decimal places (default is 2).</param>
        /// <returns>A formatted currency string according to the specified or current culture.</returns>
        /// <example>
        /// <code>
        /// decimal amount = 1234.56m;
        /// 
        /// // Using current culture (assuming zh-CN)
        /// amount.ToCurrency(); // "¥1,234.56"
        /// amount.ToCurrency(null, 1);// "¥1,234.6"
        /// 
        /// // Using culture string
        /// amount.ToCurrency("en-US");// "$1,234.56"
        /// amount.ToCurrency("ja-JP");// "￥1,234.56"
        /// amount.ToCurrency("de-DE");// "1.234,56 €"
        /// 
        /// // Using CultureInfo instance
        /// var usCulture = new CultureInfo("en-US");
        /// amount.ToCurrency(usCulture);// "$1,234.56"
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>
        /// The currency symbol, its position, and the number format (including group and decimal separators)
        /// are determined by the specified culture or current culture settings.
        /// </para>
        /// <para>
        /// Common culture codes:
        /// - "en-US": United States Dollar ($)
        /// - "zh-CN": Chinese Yuan (¥)
        /// - "ja-JP": Japanese Yen (￥)
        /// - "de-DE": Euro (€)
        /// - "fr-FR": Euro (€)
        /// - "en-GB": British Pound (£)
        /// </para>
        /// <para>
        /// Throws <see cref="CultureNotFoundException"/> if the specified culture string is not recognized.
        /// Throws <see cref="ArgumentOutOfRangeException"/> if decimals is less than 0 or greater than 15.
        /// </para>
        /// </remarks>
        public static string ToCurrency(this decimal value, [CanBeNull] object culture = null, int decimals = 2)
        {
            var cultureInfo = culture switch
            {
                null => CultureInfo.CurrentCulture,
                string cultureName => CultureInfo.GetCultureInfo(cultureName),
                CultureInfo ci => ci,
                _ => throw new ArgumentException("Culture must be either string or CultureInfo", nameof(culture))
            };
            return value.ToString(Formats.GetCurrencyFormat(decimals), cultureInfo);
        }

        /// <summary>
        /// Converts a decimal value to a currency string with a custom currency symbol.
        /// </summary>
        /// <param name="value">The monetary value to format.</param>
        /// <param name="symbol">The custom currency symbol to use (e.g., "BTC", "ETH", "USDT").</param>
        /// <param name="decimals">Number of decimal places (default is 2).</param>
        /// <returns>A formatted currency string with the custom symbol.</returns>
        /// <example>
        /// <code>
        /// decimal amount = 1234.56m;
        /// 
        /// // Using custom symbols
        /// amount.ToCurrencyWithSymbol("BTC"); // "BTC1,234.56"
        /// amount.ToCurrencyWithSymbol("ETH", 3);// "ETH1,234.560"
        /// amount.ToCurrencyWithSymbol("₿"); // "₿1,234.56"
        /// 
        /// // Using Unicode symbols
        /// amount.ToCurrencyWithSymbol("€"); // "€1,234.56"
        /// amount.ToCurrencyWithSymbol("₽"); // "₽1,234.56"
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>
        /// This method maintains the number formatting (thousand separators, decimal points) 
        /// from the current culture but replaces the currency symbol with the specified one.
        /// </para>
        /// <para>
        /// The symbol position (prefix/suffix) follows the current culture's convention.
        /// For example, if the current culture places the symbol after the number,
        /// the custom symbol will also be placed after the number.
        /// </para>
        /// <para>
        /// Throws <see cref="ArgumentNullException"/> if symbol is null.
        /// Throws <see cref="ArgumentOutOfRangeException"/> if decimals is less than 0 or greater than 15.
        /// </para>
        /// </remarks>
        public static string ToCurrencyWithSymbol(this decimal value, [NotNull] string symbol, int decimals = 2)
        {
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentNullException(nameof(symbol));
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.CurrencySymbol = symbol;
            return value.ToString(Formats.GetCurrencyFormat(decimals), culture);
        }

        /// <summary>
        /// Converts the decimal value to a percentage string.
        /// </summary>
        /// <param name="value">The decimal value to convert (e.g., 0.1234 for 12.34%).</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A formatted percentage string.</returns>
        /// <remarks>
        /// This method multiplies the input value by 100 and appends the % symbol.
        /// The input should be in decimal form (e.g., 0.1234 for 12.34%).
        /// </remarks>
        /// <example>
        /// <code>
        /// decimal number = 0.1234m;
        /// string result = number.ToPercentage(); // returns "12.34%"
        /// 
        /// decimal small = 0.001m;
        /// string smallResult = small.ToPercentage(3); // returns "0.100%"
        /// 
        /// decimal negative = -0.1234m;
        /// string negativeResult = negative.ToPercentage(); // returns "-12.34%"
        /// </code>
        /// </example>
        public static string ToPercentage(this decimal value, int decimals = 2) => value.ToString(Formats.GetPercentageFormat(decimals));
    }
}