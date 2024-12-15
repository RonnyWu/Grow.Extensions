// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Object = UnityEngine.Object;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for argument validation with fluent throw syntax.
    /// </summary>
    /// <remarks>
    /// This utility class offers a concise way to validate method arguments using a fluent syntax.
    /// All methods:
    /// - Are optimized with AggressiveInlining for minimal performance impact
    /// - Throw appropriate exceptions for invalid arguments
    /// - Support method chaining for multiple validations
    /// - Follow Unity's null checking conventions for UnityEngine.Object
    ///  
    /// Best practices:
    /// - Use at the beginning of methods to fail fast
    /// - Chain multiple checks when needed
    /// - Consider using in property setters for validation
    /// </remarks>
    public static class ThrowsSyntax
    {
        /// <summary>
        /// Throws ArgumentNullException if the source object is null.
        /// </summary>
        /// <param name="source">The object to check.</param>
        /// <exception cref="ArgumentNullException">Thrown when source is null.</exception>
        /// <example>
        /// <code>
        /// public void ProcessData(DataObject data)
        /// {
        ///     data.ThrowIfNull();
        ///     // Process data safely...
        /// }
        ///   
        /// // Chain multiple validations
        /// public void ProcessUser(User user, string userId)
        /// {
        ///     user.ThrowIfNull();
        ///     userId.ThrowIfNullOrEmpty();
        ///     // Process user safely...
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull([NoEnumeration] this object source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
        }

        /// <summary>
        /// Throws ArgumentException if the Unity Object is invalid (null or destroyed).
        /// </summary>
        /// <param name="source">The Unity Object to check.</param>
        /// <exception cref="ArgumentException">Thrown when source is invalid.</exception>
        /// <example>
        /// <code>
        /// public void ProcessComponent(Component component)
        /// {
        ///     component.ThrowIfInvalid();
        ///     // Use component safely...
        /// }
        ///   
        /// // Use in property setter
        /// private Transform _target;
        /// public Transform Target
        /// {
        ///     set
        ///     {
        ///         value.ThrowIfInvalid();
        ///         _target = value;
        ///     }
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfInvalid([NoEnumeration] this Object source)
        {
            if (source.IsInvalid()) throw new ArgumentException(nameof(source));
        }

        /// <summary>
        /// Throws ArgumentNullException if the string is null or empty.
        /// </summary>
        /// <param name="source">The string to check.</param>
        /// <exception cref="ArgumentNullException">Thrown when source is null or empty.</exception>
        /// <example>
        /// <code>
        /// public void ProcessName(string name)
        /// {
        ///     name.ThrowIfNullOrEmpty();
        ///     // Use name safely...
        /// }
        ///   
        /// // Use in configuration validation
        /// public void Initialize(string configPath, string userId)
        /// {
        ///     configPath.ThrowIfNullOrEmpty();
        ///     userId.ThrowIfNullOrEmpty();
        ///     // Initialize with valid strings...
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNullOrEmpty([NoEnumeration] this string source)
        {
            if (source.IsNullOrEmpty()) throw new ArgumentNullException(nameof(source));
        }
    }
}