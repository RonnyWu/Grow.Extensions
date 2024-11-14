using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for char type conversions.
    /// </summary>
    public static class CharTo
    {
        /// <summary>
        /// Converts the char value to an integer (Unicode code point).
        /// </summary>
        /// <param name="value">The char value to convert.</param>
        /// <returns>Integer representation of the char value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this char value) => value;

        /// <summary>
        /// Converts the char value to a byte.
        /// </summary>
        /// <param name="value">The char value to convert.</param>
        /// <param name="defaultValue">The default value to return if conversion fails.</param>
        /// <returns>Byte representation of the char value, or defaultValue if conversion fails.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(this char value, byte defaultValue = 0)
        {
            unchecked
            {
                return value <= byte.MaxValue ? (byte)value : defaultValue;
            }
        }
    }
}