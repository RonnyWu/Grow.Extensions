using System;
using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for float (Single) type conversions.
    /// </summary>
    public static class FloatTo
    {
        /// <summary>
        /// Converts the float value to double.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>The double representation of the float value.</returns>
        /// <remarks>
        /// This conversion is always safe as double has a larger range and precision than float.
        /// </remarks>
        /// <example>
        /// <code>
        /// float number = 123.45f;
        /// double result = number.ToDouble(); // returns 123.45
        /// 
        /// float precise = 123.456789f;
        /// double morePercise = precise.ToDouble(); // maintains all significant digits
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this float value) => Convert.ToDouble(value);

        /// <summary>
        /// Converts the float value to decimal.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>The decimal representation of the float value.</returns>
        /// <remarks>
        /// Be aware that converting from float to decimal might result in precision changes
        /// due to the different ways these types store numbers internally.
        /// </remarks>
        /// <example>
        /// <code>
        /// float number = 123.45f;
        /// decimal result = number.ToDecimal(); // returns 123.45m
        /// 
        /// float invalid = float.NaN;
        /// decimal defaultResult = invalid.ToDecimal(0m); // returns 0m
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(this float value, decimal defaultValue = 0m)
        {
            try { return Convert.ToDecimal(value); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Rounds a float value to a specified number of decimal places.
        /// </summary>
        /// <param name="value">The float value to round.</param>
        /// <param name="decimals">The number of decimal places to round to. Default is 2.</param>
        /// <returns>The rounded float value.</returns>
        /// <remarks>
        /// This method uses the default rounding mode (MidpointRounding.ToEven).
        /// For different rounding behaviors, use MathF.Round directly with the desired MidpointRounding option.
        /// </remarks>
        /// <example>
        /// <code>
        /// float number = 123.456f;
        /// float result = number.ToRound(2); // returns 123.46f
        /// 
        /// float midpoint = 123.445f;
        /// float midResult = midpoint.ToRound(2); // returns 123.44f due to banker's rounding
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRound(this float value, int decimals = 2) => MathF.Round(value, decimals);

        /// <summary>
        /// Converts the float value to its absolute value.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>The absolute value of the float.</returns>
        /// <remarks>
        /// This method returns the magnitude of a float number without regard to its sign.
        /// </remarks>
        /// <example>
        /// <code>
        /// float negative = -123.45f;
        /// float result = negative.ToAbs(); // returns 123.45f
        /// 
        /// float positive = 123.45f;
        /// float sameResult = positive.ToAbs(); // returns 123.45f
        /// 
        /// float zero = 0f;
        /// float zeroResult = zero.ToAbs(); // returns 0f
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToAbs(this float value) => MathF.Abs(value);

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the float number.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>The ceiling value as float.</returns>
        /// <remarks>
        /// Unlike ToInt() which performs type conversion, this method maintains the float type
        /// and returns the smallest integral value greater than or equal to the input.
        /// </remarks>
        /// <example>
        /// <code>
        /// float number = 123.45f;
        /// float result = number.ToCeiling(); // returns 124.0f
        /// 
        /// float negative = -123.45f;
        /// float negativeResult = negative.ToCeiling(); // returns -123.0f
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToCeiling(this float value) => MathF.Ceiling(value);

        /// <summary>
        /// Converts the float value to the largest integral value less than or equal to the float number.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>The floor of the float value.</returns>
        /// <remarks>
        /// Unlike ToInt() which performs type conversion, this method maintains the float type
        /// and returns the largest integral value less than or equal to the input.
        /// </remarks>
        /// <example>
        /// <code>
        /// float number = 123.45f;
        /// float result = number.ToFloor(); // returns 123.0f
        /// 
        /// float negative = -123.45f;
        /// float negativeResult = negative.ToFloor(); // returns -124.0f
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloor(this float value) => MathF.Floor(value);

        /// <summary>
        /// Converts the float value to a string with a fixed number of decimal places.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A string representation with the specified number of decimal places.</returns>
        /// <remarks>
        /// This method always shows the specified number of decimal places, even if they are zeros.
        /// It does not include a thousand separators.
        /// </remarks>
        /// <example>
        /// <code>
        /// float number = 123.456f;
        /// string result = number.ToFixed(2); // returns "123.46"
        /// 
        /// float whole = 123f;
        /// string wholeResult = whole.ToFixed(2); // returns "123.00"
        /// </code>
        /// </example>
        public static string ToFixed(this float value, int decimals = 2) => value.ToString(Formats.GetFixedPointFormat(decimals));

        /// <summary>
        /// Converts the float value to a percentage string.
        /// </summary>
        /// <param name="value">The float value to convert (e.g., 0.1234f for 12.34%).</param>
        /// <param name="decimals">The number of decimal places. Default is 2.</param>
        /// <returns>A formatted percentage string.</returns>
        /// <remarks>
        /// This method multiplies the input value by 100 and appends the % symbol.
        /// The input should be in decimal form (e.g., 0.1234f for 12.34%).
        /// </remarks>
        /// <example>
        /// <code>
        /// float number = 0.1234f;
        /// string result = number.ToPercentage(); // returns "12.34%"
        /// 
        /// float small = 0.001f;
        /// string smallResult = small.ToPercentage(3); // returns "0.100%"
        /// </code>
        /// </example>
        public static string ToPercentage(this float value, int decimals = 2) => value.ToString(Formats.GetPercentageFormat(decimals));
    }
}