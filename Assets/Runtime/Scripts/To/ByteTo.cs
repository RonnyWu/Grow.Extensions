using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    namespace Grow.Extensions
    {
        /// <summary>
        /// Provides extension methods for byte type conversions.
        /// </summary>
        public static class ByteTo
        {
            /// <summary>
            /// Converts the byte value to an integer.
            /// </summary>
            /// <param name="value">The byte value to convert.</param>
            /// <returns>Integer representation of the byte value.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int ToInt(this byte value) => value;

            /// <summary>
            /// Converts the byte value to a character.
            /// </summary>
            /// <param name="value">The byte value to convert.</param>
            /// <returns>Character representation of the byte value.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static char ToChar(this byte value) => (char)value;

            /// <summary>
            /// Converts the byte to a hexadecimal string representation.
            /// </summary>
            /// <param name="value">The byte value to convert.</param>
            /// <returns>Hexadecimal string representation (e.g., "FF" for 255).</returns>
            public static string ToHex(this byte value) => value.ToString(Formats.X2);
        }
    }
}