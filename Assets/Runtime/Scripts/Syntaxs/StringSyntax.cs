// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for string validation with a fluent syntax.
    /// </summary>
    /// <remarks>
    /// This utility class offers performance-optimized string validation methods:
    /// - Null or empty string checks
    /// - Whitespace validation
    /// All methods are optimized with AggressiveInlining for better performance.
    /// </remarks>
    public static class StringSyntax
    {
        /// <summary>
        /// Indicates whether the specified string is null or empty.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is null or empty; otherwise, false.</returns>
        /// <example>
        /// <code>
        /// // Basic validation
        /// string userInput = GetUserInput();
        /// if (userInput.IsNullOrEmpty())
        /// {
        ///     Debug.LogWarning("Input cannot be empty");
        ///     return;
        /// }
        ///   
        /// // Chain validation with other operations
        /// string processedText = text
        ///     .Trim()
        ///     .ToLowerInvariant()
        ///     .IsNullOrEmpty() ? "default" : text;
        /// </code>
        /// </example>
        /// <remarks>
        /// This method is a fluent wrapper around string.IsNullOrEmpty.
        /// Useful for validation chains and more readable conditionals.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static bool IsNullOrEmpty([CanBeNull] this string source) => string.IsNullOrEmpty(source);

        /// <summary>
        /// Indicates whether the specified string is null, empty, or consists only of whitespace characters.
        /// </summary>
        /// <param name="source">The string to test.</param>
        /// <returns>true if the string is null, empty, or whitespace; otherwise, false.</returns>
        /// <example>
        /// <code>
        /// // Form validation
        /// string username = formData.Username;
        /// if (username.IsNullOrWhiteSpace())
        /// {
        ///     ShowError("Username cannot be blank");
        ///     return;
        /// }
        ///   
        /// // Configuration validation
        /// string setting = config.GetValue();
        /// var value = setting.IsNullOrWhiteSpace()
        ///     ? defaultValue
        ///     : setting.Trim();
        /// </code>
        /// </example>
        /// <remarks>
        /// This method is a fluent wrapper around string.IsNullOrWhiteSpace.
        /// Particularly useful for:
        /// - User input validation
        /// - Configuration string checks
        /// - Data cleaning operations
        /// - Form validation chains
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static bool IsNullOrWhiteSpace([CanBeNull] this string source) => string.IsNullOrWhiteSpace(source);
    }
}