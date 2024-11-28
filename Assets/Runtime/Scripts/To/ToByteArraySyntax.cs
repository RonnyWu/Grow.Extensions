using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides high-performance extension methods for converting various types to byte arrays.
    /// All methods use stack allocation for better performance when possible.
    /// </summary>
    /// <remarks>
    /// This class provides a set of extension methods to convert different data types to byte arrays.
    /// The implementation focuses on high performance by utilizing stack allocation and modern C# features.
    /// <list type="bullet">
    /// <item><description>All numeric types are converted using their binary representation</description></item>
    /// <item><description>Boolean values are converted to a single byte (0 or 1)</description></item>
    /// <item><description>Strings are converted using the specified encoding (defaults to UTF8)</description></item>
    /// <item><description>Nullable types return an empty array when null</description></item>
    /// </list>
    /// Example usage:
    /// <code>
    /// byte[] boolBytes = true.ToByteArray();     // Returns: [1]
    /// byte[] intBytes = 42.ToByteArray();        // Returns binary representation of 42
    /// byte[] strBytes = "Hello".ToByteArray();   // Returns UTF8 encoded bytes
    /// </code>
    /// </remarks>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ToByteArraySyntax
    {
        /// <summary>
        /// Maximum size in bytes for stack allocation. Larger allocations will use the heap instead.
        /// </summary>
        /// <remarks>
        /// This threshold is used primarily for string encoding to prevent stack overflow
        /// in cases where the input string might result in a large byte array.
        /// </remarks>
        private const int StackAllocThreshold = 256;

        #region ToByteArray - 1 Bits (bool)

        /// <summary>
        /// Converts a boolean value to a byte array.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>A byte array containing a single byte: 1 for true, 0 for false.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 1.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this bool value)
        {
            Span<byte> span = stackalloc byte[1];
            span[0] = value ? (byte)1 : (byte)0;
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable boolean value to a byte array.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(bool)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this bool? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        #endregion

        #region ToByteArray - 8 Bits (sbyte, byte)

        /// <summary>
        /// Converts a signed byte value to a byte array.
        /// </summary>
        /// <param name="value">The signed byte value to convert.</param>
        /// <returns>A byte array containing the unchecked cast of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 1.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this sbyte value)
        {
            Span<byte> span = stackalloc byte[1];
            span[0] = unchecked((byte)value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable signed byte value to a byte array.
        /// </summary>
        /// <param name="value">The nullable signed byte value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(sbyte)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this sbyte? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts a byte value to a byte array.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <returns>A byte array containing the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 1.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this byte value)
        {
            Span<byte> span = stackalloc byte[1];
            span[0] = value;
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable byte value to a byte array.
        /// </summary>
        /// <param name="value">The nullable byte value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(byte)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this byte? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        #endregion

        #region ToByteArray - 16 Bits (short, ushort, char)

        /// <summary>
        /// Converts a short value to a byte array.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 2.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this short value)
        {
            Span<byte> span = stackalloc byte[sizeof(short)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable short value to a byte array.
        /// </summary>
        /// <param name="value">The nullable short value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(short)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this short? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts an unsigned short value to a byte array.
        /// </summary>
        /// <param name="value">The unsigned short value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 2.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this ushort value)
        {
            Span<byte> span = stackalloc byte[sizeof(ushort)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable unsigned short value to a byte array.
        /// </summary>
        /// <param name="value">The nullable unsigned short value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(ushort)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this ushort? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts a character value to a byte array.
        /// </summary>
        /// <param name="value">The character value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 2.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this char value)
        {
            Span<byte> span = stackalloc byte[sizeof(char)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable character value to a byte array.
        /// </summary>
        /// <param name="value">The nullable character value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(char)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this char? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        #endregion

        #region ToByteArray - 32 Bits (int, uint, float)

        /// <summary>
        /// Converts an integer value to a byte array.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 4.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this int value)
        {
            Span<byte> span = stackalloc byte[sizeof(int)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable integer value to a byte array.
        /// </summary>
        /// <param name="value">The nullable integer value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(int)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this int? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts an unsigned integer value to a byte array.
        /// </summary>
        /// <param name="value">The unsigned integer value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 4.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this uint value)
        {
            Span<byte> span = stackalloc byte[sizeof(uint)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable unsigned integer value to a byte array.
        /// </summary>
        /// <param name="value">The nullable unsigned integer value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(uint)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this uint? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts a float value to a byte array.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 4.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this float value)
        {
            Span<byte> span = stackalloc byte[sizeof(float)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable float value to a byte array.
        /// </summary>
        /// <param name="value">The nullable float value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(float)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this float? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        #endregion

        #region ToByteArray - 64 Bits (long, ulong, double)

        /// <summary>
        /// Converts a long value to a byte array.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 8.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this long value)
        {
            Span<byte> span = stackalloc byte[sizeof(long)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable long value to a byte array.
        /// </summary>
        /// <param name="value">The nullable long value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(long)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this long? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts an unsigned long value to a byte array.
        /// </summary>
        /// <param name="value">The unsigned long value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 8.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this ulong value)
        {
            Span<byte> span = stackalloc byte[sizeof(ulong)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable unsigned long value to a byte array.
        /// </summary>
        /// <param name="value">The nullable unsigned long value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(ulong)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this ulong? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts a double value to a byte array.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>A byte array containing the binary representation of the value.</returns>
        /// <remarks>
        /// This method uses stack allocation for optimal performance.
        /// The resulting array will always have a length of 8.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToByteArray(this double value)
        {
            Span<byte> span = stackalloc byte[sizeof(double)];
            MemoryMarshal.Write(span, ref value);
            return span.ToArray();
        }

        /// <summary>
        /// Converts a nullable double value to a byte array.
        /// </summary>
        /// <param name="value">The nullable double value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(double)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this double? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        #endregion

        #region ToByteArray - 128+ Bits (decimal, string)

        /// <summary>
        /// Converts a decimal value to a byte array.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>A byte array containing the binary representation of the decimal.</returns>
        /// <remarks>
        /// This method:
        /// <list type="bullet">
        /// <item><description>Uses stack allocation for the 16-byte decimal representation</description></item>
        /// <item><description>Preserves the exact decimal value including scale and precision</description></item>
        /// <item><description>Always returns an array of length 16</description></item>
        /// </list>
        /// </remarks>
        public static byte[] ToByteArray(this decimal value)
        {
            var bits = decimal.GetBits(value);
            Span<byte> bytes = stackalloc byte[16];
            for (var i = 0; i < 4; i++) MemoryMarshal.Write(bytes.Slice(i * 4, 4), ref bits[i]);
            return bytes.ToArray();
        }

        /// <summary>
        /// Converts a nullable decimal value to a byte array.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <returns>A byte array containing the value, or an empty array if the input is null.</returns>
        /// <remarks>
        /// For non-null values, the behavior is identical to <see cref="ToByteArray(decimal)"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("null => null; notnull => notnull")]
        public static byte[] ToByteArray([CanBeNull] this decimal? value) => value.HasValue ? value.Value.ToByteArray() : Array.Empty<byte>();

        /// <summary>
        /// Converts a string to a byte array using the specified encoding.
        /// </summary>
        /// <param name="value">The string to convert. Can be null.</param>
        /// <param name="encoding">The encoding to use. Defaults to UTF8 if null.</param>
        /// <returns>A byte array containing the encoded string, or an empty array if the input is null or empty.</returns>
        /// <remarks>
        /// This method optimizes memory usage by:
        /// <list type="bullet">
        /// <item><description>Using stack allocation for strings that encode to less than 256 bytes</description></item>
        /// <item><description>Falling back to heap allocation for larger strings</description></item>
        /// <item><description>Returning an empty array for null or empty strings</description></item>
        /// </list>
        /// Example:
        /// <code>
        /// byte[] utf8Bytes = "Hello".ToByteArray();                    // Uses UTF8
        /// byte[] asciiBytes = "Hello".ToByteArray(Encoding.ASCII);     // Uses ASCII
        /// </code>
        /// </remarks>
        public static byte[] ToByteArray([CanBeNull] this string value, [CanBeNull] Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value)) return Array.Empty<byte>();
            encoding ??= Encoding.UTF8;
            var maxByteCount = encoding.GetMaxByteCount(value.Length);
            if (maxByteCount > StackAllocThreshold) return encoding.GetBytes(value);
            Span<byte> bytes = stackalloc byte[maxByteCount];
            var actualByteCount = encoding.GetBytes(value, bytes);
            return bytes[..actualByteCount].ToArray();
        }

        #endregion
    }
}