// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides fast and predictable conversion of numeric types to their binary string representation.
    /// Uses a lookup table for consistent O(1) performance across all .NET runtimes.
    /// </summary>
    /// <remarks>
    /// Implementation notes:
    /// - Uses pre-computed lookup table for O(1) byte-to-binary conversion
    /// - Efficient memory management with Span&lt;T&gt; and stackalloc
    /// - Optimized for both small and large inputs
    /// - Thread-safe implementation
    ///   
    /// Note: This implementation is considered complete and stable.
    /// The following are potential optimization directions if specific needs arise:
    ///   
    /// - Specialized no-prefix implementations if prefix-free scenarios become performance-critical
    /// - Parallel processing for large byte arrays if bulk processing becomes a requirement
    /// - Additional formatting options (e.g., grouped digits) if custom output formats are needed
    /// - Span&lt;byte&gt; overloads if direct memory processing becomes necessary
    ///   
    /// These optimizations should only be considered based on concrete performance requirements
    /// or specific use cases, as the current implementation already provides excellent performance
    /// for most scenarios.
    /// </remarks>
    public static class ToBinaryStringSyntax
    {
        #region Constants

        private const string Prefix = "0b";
        private static readonly string[] ByteLookup = new string[256];

        static ToBinaryStringSyntax()
        {
            // Pre-compute all possible byte values for consistent O(1) lookup performance
            for (var i = 0; i < 256; i++) ByteLookup[i] = Convert.ToString(i, 2).PadLeft(8, '0');
        }

        #endregion

        #region ToBinaryString - 8 Bits (byte, sbyte)

        /// <summary>
        /// Converts a byte value to its binary string representation with guaranteed O(1) performance.
        /// The result is always 8 characters (excluding prefix) representing the binary form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses pre-computed lookup table for direct byte-to-binary conversion
        /// - Direct string concatenation for prefix as it's more efficient for 8-bit values
        /// - Guaranteed O(1) performance with minimal allocations
        /// </remarks>
        /// <param name="value">The byte value to convert.</param>
        /// <param name="prefix">
        /// If false, omits the "0b" prefix. This is primarily useful for custom string formatting
        /// or when concatenating multiple binary representations.
        /// Defaults to true for standard binary notation.
        /// </param>
        /// <returns>
        /// An 8-character string (excluding prefix) representing the binary form of the value.
        /// For example:
        /// 42 => "0b00101010"
        /// 255 => "0b11111111"
        /// 0 => "0b00000000"
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this byte value, bool prefix = true) => prefix ? Prefix + ByteLookup[value] : ByteLookup[value];

        /// <summary>
        /// Converts a signed byte value to its binary string representation.
        /// </summary>
        /// <remarks>
        /// This method converts the sbyte to byte and uses <see cref="ToBinaryString(byte, bool)"/>
        /// for the actual conversion. The conversion is safe for binary representation as:
        /// 1. The underlying bit pattern remains unchanged during conversion
        /// 2. The binary string output depends only on the bit pattern, not the numeric interpretation
        /// </remarks>
        /// <param name="value">The signed byte value to convert.</param>
        /// <param name="prefix">If false, omits the "0b" prefix. Defaults to true.</param>
        /// <returns>An 8-character string (excluding prefix) representing the binary form of the value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this sbyte value, bool prefix = true) => ((byte)value).ToBinaryString(prefix);

        #endregion

        #region ToBinaryString - 16 Bits (short, ushort, char)

        /// <summary>
        /// Converts a 16-bit signed integer to its binary string representation with guaranteed O(1) performance.
        /// The result is always 16 characters (excluding prefix) representing the binary form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Direct string concatenation is used for 16-bit values as it's more efficient than Span operations for smaller sizes
        /// - Uses pre-computed lookup table for byte-to-binary conversion
        /// - Guaranteed O(1) performance with minimal allocations
        /// </remarks>
        /// <param name="value">The 16-bit signed integer to convert.</param>
        /// <param name="prefix">
        /// If false, omits the "0b" prefix. This is primarily useful for custom string formatting
        /// or when concatenating multiple binary representations.
        /// Defaults to true for standard binary notation.
        /// </param>
        /// <returns>
        /// A 16-character string (excluding prefix) representing the binary form of the value.
        /// For example:
        /// -1 => "0b1111111111111111"
        /// -32768 => "0b1000000000000000"
        /// 32767 => "0b0111111111111111"
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this short value, bool prefix = true)
        {
            var high = ByteLookup[value >> 8 & 0xFF];
            var low = ByteLookup[value & 0xFF];
            return prefix ? Prefix + high + low : high + low;
        }

        /// <summary>
        /// Converts a 16-bit unsigned integer to its binary string representation.
        /// </summary>
        /// <remarks>
        /// This method converts the ushort to short and uses <see cref="ToBinaryString(short, bool)"/>
        /// for the actual conversion. The conversion is safe for binary representation as:
        /// 1. The underlying bit pattern remains unchanged during conversion
        /// 2. The binary string output depends only on the bit pattern, not the numeric interpretation
        /// </remarks>
        /// <param name="value">The 16-bit unsigned integer to convert.</param>
        /// <param name="prefix">If false, omits the "0b" prefix. Defaults to true.</param>
        /// <returns>A 16-character string (excluding prefix) representing the binary form of the value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this ushort value, bool prefix = true) => ((short)value).ToBinaryString(prefix);

        /// <summary>
        /// Converts a Unicode character to its binary string representation.
        /// </summary>
        /// <remarks>
        /// This method converts the char to short and uses <see cref="ToBinaryString(short, bool)"/>
        /// for the actual conversion. The conversion is safe for binary representation as:
        /// 1. The underlying bit pattern remains unchanged during conversion
        /// 2. The binary string output depends only on the bit pattern, not the numeric interpretation
        /// </remarks>
        /// <param name="value">The Unicode character to convert.</param>
        /// <param name="prefix">If false, omits the "0b" prefix. Defaults to true.</param>
        /// <returns>A 16-character string (excluding prefix) representing the binary form of the value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this char value, bool prefix = true) => ((short)value).ToBinaryString(prefix);

        #endregion

        #region ToBinaryString - 32 Bits (int, uint)

        /// <summary>
        /// Converts a 32-bit signed integer to its binary string representation with guaranteed O(1) performance.
        /// The result is always 32 characters (excluding prefix) representing the binary form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses efficient loop-based implementation
        /// - Direct memory operations with Span&lt;char&gt; to minimize allocations
        /// - Stack allocation (stackalloc) to avoid heap pressure
        /// - Each byte is processed independently using a pre-computed lookup table
        ///   
        /// Performance considerations:
        /// - Optimized loop implementation provides better performance and stability
        /// - Direct memory operations minimize temporary object creation
        /// - Pre-computed lookup table eliminates repeated calculations
        /// </remarks>
        /// <param name="value">The 32-bit signed integer to convert.</param>
        /// <param name="prefix">
        /// If false, omits the "0b" prefix. This is primarily useful for custom string formatting
        /// or when concatenating multiple binary representations.
        /// Defaults to true for standard binary notation.
        /// </param>
        /// <returns>
        /// A 32-character string (excluding prefix) representing the binary form of the value.
        /// For example:
        /// -1 => "0b11111111111111111111111111111111"
        /// -2147483648 => "0b10000000000000000000000000000000"
        /// 2147483647 => "0b01111111111111111111111111111111"
        /// </returns>
        public static string ToBinaryString(this int value, bool prefix = true)
        {
            Span<char> buffer = stackalloc char[prefix ? 34 : 32];
            var position = 0;

            if (prefix)
            {
                Prefix.AsSpan().CopyTo(buffer);
                position = 2;
            }

            for (var i = 24; i >= 0; i -= 8)
            {
                ByteLookup[value >> i & 0xFF].AsSpan().CopyTo(buffer[position..]);
                position += 8;
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Converts a 32-bit unsigned integer to its binary string representation.
        /// </summary>
        /// <remarks>
        /// This method converts the uint to int and uses <see cref="ToBinaryString(int, bool)"/> for the actual conversion.
        /// See the referenced method for detailed implementation notes and examples.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this uint value, bool prefix = true) => ((int)value).ToBinaryString(prefix);

        /// <summary>
        /// Converts a single-precision floating-point number to its IEEE 754 binary representation.
        /// </summary>
        /// <remarks>
        /// This method converts the float to its bit representation using <see cref="BitConverter.SingleToInt32Bits"/>
        /// and then uses <see cref="ToBinaryString(int, bool)"/> for the actual conversion.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this float value, bool prefix = true) => BitConverter.SingleToInt32Bits(value).ToBinaryString(prefix);

        #endregion

        #region ToBinaryString - 64 Bits (long, ulong, double)

        /// <summary>
        /// Converts a 64-bit signed integer to its binary string representation.
        /// The result is always 64 characters (excluding prefix) representing the binary form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses efficient loop-based implementation with Span&lt;char&gt;
        /// - Stack allocation to avoid heap pressure
        /// - Pre-computed lookup table for byte-to-binary conversion
        /// </remarks>
        public static string ToBinaryString(this long value, bool prefix = true)
        {
            Span<char> buffer = stackalloc char[prefix ? 66 : 64];
            var position = 0;

            if (prefix)
            {
                Prefix.AsSpan().CopyTo(buffer);
                position = 2;
            }

            for (var i = 56; i >= 0; i -= 8)
            {
                ByteLookup[value >> i & 0xFF].AsSpan().CopyTo(buffer[position..]);
                position += 8;
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Converts a 64-bit unsigned integer to its binary string representation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this ulong value, bool prefix = true) => ((long)value).ToBinaryString(prefix);

        /// <summary>
        /// Converts a double-precision floating-point number to its IEEE 754 binary representation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToBinaryString(this double value, bool prefix = true) => BitConverter.DoubleToInt64Bits(value).ToBinaryString(prefix);

        #endregion

        #region ToBinaryString - byte[]

        /// <summary>
        /// Converts a byte array to its binary string representation with optimized performance.
        /// Each byte is converted to 8 binary digits, resulting in a string length of (array_length * 8) plus optional prefix.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses pre-computed lookup table for direct byte-to-binary conversion
        /// - Efficient memory management using Span&lt;char&gt;
        /// - Stack allocation for small arrays (≤ 256 bytes) to avoid heap pressure
        /// - Heap allocation for larger arrays to prevent stack overflow
        /// - Direct memory operations to minimize temporary object creation
        ///   
        /// Performance considerations:
        /// - O(n) complexity where n is the length of the input array
        /// - Minimal allocations through efficient buffer management
        /// - Optimized for both small and large arrays
        /// </remarks>
        /// <param name="value">The byte array to convert. Can be null.</param>
        /// <param name="prefix">
        /// If false, omits the "0b" prefix. This is primarily useful for custom string formatting
        /// or when concatenating multiple binary representations.
        /// Defaults to true for standard binary notation.
        /// </param>
        /// <returns>
        /// A binary string representation of the byte array, or empty string if the input is null or empty.
        /// For example:
        /// new byte[] { 42 } => "0b00101010"
        /// new byte[] { 255, 0 } => "0b1111111100000000"
        /// new byte[] { } => ""
        /// null => ""
        /// </returns>
        public static string ToBinaryString(this byte[] value, bool prefix = true)
        {
            if (value == null || value.Length == 0) return string.Empty;
            const int stackAllocThreshold = 256;
            var totalLength = value.Length * 8 + (prefix ? 2 : 0);
            var buffer = totalLength <= stackAllocThreshold ? stackalloc char[totalLength] : new char[totalLength];
            var position = 0;

            if (prefix)
            {
                Prefix.AsSpan().CopyTo(buffer);
                position = 2;
            }

            foreach (var b in value)
            {
                ByteLookup[b].AsSpan().CopyTo(buffer[position..]);
                position += 8;
            }

            return buffer.ToString();
        }

        #endregion
    }
}