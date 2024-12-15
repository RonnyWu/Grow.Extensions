using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides fast and efficient conversion of numeric types to their hexadecimal string representation.
    /// Uses direct bit manipulation and stack allocation for optimal performance.
    /// </summary>
    /// <remarks>
    /// Implementation notes:
    /// - Uses stackalloc for small buffers to avoid heap allocations
    /// - Efficient bit manipulation for hex conversion
    /// - Thread-safe implementation
    /// - Optional uppercase and prefix formatting
    ///   
    /// Note: This implementation is considered complete and stable.
    /// The following are potential optimization directions if specific needs arise:
    ///   
    /// - IFormatProvider support if culture-specific formatting becomes necessary
    /// - StringBuilder extensions for bulk string building scenarios
    /// - Parallel processing for large byte arrays if bulk processing becomes a requirement
    /// - TryFormat patterns if custom buffer management is needed
    ///   
    /// These optimizations should only be considered based on concrete performance requirements
    /// or specific use cases, as the current implementation already provides excellent performance
    /// for most scenarios.
    /// </remarks>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ToHexStringSyntax
    {
        #region Constants

        private const int Buffer8Bits = 2, Buffer16Bits = 4, Buffer32Bits = 8, Buffer64Bits = 16, PrefixLength = 2, StackAllocThreshold = 128;
        private const string Prefix = "0x";
        private static readonly char[] HexCharsLower = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        private static readonly char[] HexCharsUpper = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        #endregion

        #region ToHexString - 8 Bits (byte, sbyte)

        /// <summary>
        /// Converts a byte value to its hexadecimal string representation.
        /// The result is always 2 characters (excluding prefix) representing the hex form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses stackalloc for zero-allocation buffer management
        /// - Direct bit manipulation for hex conversion
        /// - Guaranteed minimal allocations
        /// </remarks>
        /// <param name="value">The byte value to convert.</param>
        /// <param name="uppercase">If true, uses uppercase letters (A-F); if false, uses lowercase (a-f).</param>
        /// <param name="prefix">If true, prepends "0x" to the result.</param>
        /// <returns>
        /// A 2-character string (excluding prefix) representing the hex form of the value.
        /// For example:
        /// 42 => "2a" or "0x2a"
        /// 255 => "ff" or "0xff"
        /// 0 => "00" or "0x00"
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this byte value, bool uppercase = false, bool prefix = false)
        {
            var bufferSize = prefix ? Buffer8Bits + PrefixLength : Buffer8Bits;
            Span<char> buffer = stackalloc char[bufferSize];
            var chars = uppercase ? HexCharsUpper : HexCharsLower;
            var position = 0;

            if (prefix)
            {
                Prefix.AsSpan().CopyTo(buffer);
                position = PrefixLength;
            }

            buffer[position++] = chars[value >> 4];
            buffer[position] = chars[value & 0xF];

            return buffer.ToString();
        }

        /// <summary>
        /// Converts a signed byte value to its hexadecimal string representation.
        /// </summary>
        /// <remarks>
        /// This method converts the sbyte to byte and uses the byte conversion method.
        /// The conversion is safe for hexadecimal representation as the bit pattern remains unchanged.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this sbyte value, bool uppercase = false, bool prefix = false) => ((byte)value).ToHexString(uppercase, prefix);

        #endregion

        #region ToHexString - 16 Bits (short, ushort, char)

        /// <summary>
        /// Converts a 16-bit integer to its hexadecimal string representation.
        /// The result is always 4 characters (excluding prefix) representing the hex form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses stackalloc for zero-allocation buffer management
        /// - Efficient bit shifting for hex conversion
        /// - Processes 4 bits at a time
        /// </remarks>
        public static string ToHexString(this short value, bool uppercase = false, bool prefix = false)
        {
            var bufferSize = prefix ? Buffer16Bits + PrefixLength : Buffer16Bits;
            Span<char> buffer = stackalloc char[bufferSize];
            var chars = uppercase ? HexCharsUpper : HexCharsLower;
            var position = 0;

            if (prefix)
            {
                Prefix.AsSpan().CopyTo(buffer);
                position = PrefixLength;
            }

            for (var i = 12; i >= 0; i -= 4) buffer[position++] = chars[value >> i & 0xF];

            return buffer.ToString();
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer to its hexadecimal string representation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this ushort value, bool uppercase = false, bool prefix = false) => ((short)value).ToHexString(uppercase, prefix);

        /// <summary>
        /// Converts a Unicode character to its hexadecimal string representation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this char value, bool uppercase = false, bool prefix = false) => ((short)value).ToHexString(uppercase, prefix);

        #endregion

        #region ToHexString - 32 Bits (int, uint, float)

        /// <summary>
        /// Converts a 32-bit integer to its hexadecimal string representation.
        /// The result is always 8 characters (excluding prefix) representing the hex form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses stackalloc for zero-allocation buffer management
        /// - Efficient bit shifting for hex conversion
        /// - Processes 4 bits at a time
        /// </remarks>
        public static string ToHexString(this int value, bool uppercase = false, bool prefix = false)
        {
            var bufferSize = prefix ? Buffer32Bits + PrefixLength : Buffer32Bits;
            Span<char> buffer = stackalloc char[bufferSize];
            var chars = uppercase ? HexCharsUpper : HexCharsLower;
            var position = 0;

            if (prefix)
            {
                Prefix.AsSpan().CopyTo(buffer);
                position = PrefixLength;
            }

            for (var i = 28; i >= 0; i -= 4) buffer[position++] = chars[value >> i & 0xF];
            return buffer.ToString();
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer to its hexadecimal string representation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this uint value, bool uppercase = false, bool prefix = false) => ((int)value).ToHexString(uppercase, prefix);

        /// <summary>
        /// Converts a single-precision floating-point number to its hexadecimal string representation.
        /// </summary>
        /// <remarks>
        /// Uses BitConverter to get the underlying bit pattern of the float value.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this float value, bool uppercase = false, bool prefix = false) => BitConverter.SingleToInt32Bits(value).ToHexString(uppercase, prefix);

        #endregion

        #region ToHexString - 64 Bits (long, ulong, double)

        /// <summary>
        /// Converts a 64-bit integer to its hexadecimal string representation.
        /// The result is always 16 characters (excluding prefix) representing the hex form of the value.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses stackalloc for zero-allocation buffer management
        /// - Efficient bit shifting for hex conversion
        /// - Processes 4 bits at a time
        /// </remarks>
        public static string ToHexString(this long value, bool uppercase = false, bool prefix = false)
        {
            var bufferSize = prefix ? Buffer64Bits + PrefixLength : Buffer64Bits;
            Span<char> buffer = stackalloc char[bufferSize];
            var chars = uppercase ? HexCharsUpper : HexCharsLower;
            var position = 0;

            if (prefix)
            {
                Prefix.AsSpan().CopyTo(buffer);
                position = PrefixLength;
            }

            for (var i = 60; i >= 0; i -= 4) buffer[position++] = chars[value >> i & 0xF];

            return buffer.ToString();
        }

        /// <summary>
        /// Converts an unsigned 64-bit integer to its hexadecimal string representation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this ulong value, bool uppercase = false, bool prefix = false) => ((long)value).ToHexString(uppercase, prefix);

        /// <summary>
        /// Converts a double-precision floating-point number to its hexadecimal string representation.
        /// </summary>
        /// <remarks>
        /// Uses BitConverter to get the underlying bit pattern of the double value.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString(this double value, bool uppercase = false, bool prefix = false) => BitConverter.DoubleToInt64Bits(value).ToHexString(uppercase, prefix);

        #endregion

        #region ToHexString - ReadOnlySpan<byte>, byte[]

        /// <summary>
        /// Converts a span of bytes to its hexadecimal string representation.
        /// Each byte is converted to two hexadecimal characters.
        /// </summary>
        /// <remarks>
        /// Implementation notes:
        /// - Uses stackalloc for small inputs (≤ 128 bytes)
        /// - Falls back to heap allocation for larger inputs
        /// - Processes each byte individually for maximum compatibility
        /// </remarks>
        /// <param name="value">The span of bytes to convert.</param>
        /// <param name="uppercase">If true, uses uppercase letters (A-F); if false, uses lowercase (a-f).</param>
        /// <param name="prefix">If true, prepends "0x" to the result.</param>
        /// <returns>A string containing the hexadecimal representation of all bytes.</returns>
        public static string ToHexString(ReadOnlySpan<byte> value, bool uppercase = false, bool prefix = false)
        {
            if (value.IsEmpty) return string.Empty;
            var totalLength = value.Length * 2 + (prefix ? PrefixLength : 0);
            var buffer = totalLength <= StackAllocThreshold * 2 ? stackalloc char[totalLength] : new char[totalLength];
            var chars = uppercase ? HexCharsUpper : HexCharsLower;
            var position = prefix ? PrefixLength : 0;
            if (prefix) Prefix.AsSpan().CopyTo(buffer);
            foreach (var b in value)
            {
                buffer[position++] = chars[b >> 4];
                buffer[position++] = chars[b & 0xF];
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Converts a byte array to its hexadecimal string representation.
        /// </summary>
        /// <remarks>
        /// This method is a convenience wrapper around the ReadOnlySpan&lt;byte&gt; implementation.
        /// Returns an empty string for null or empty input.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHexString([CanBeNull] this byte[] value, bool uppercase = false, bool prefix = false) => value == null ? string.Empty : ToHexString(value.AsSpan(), uppercase, prefix);

        #endregion
    }
}