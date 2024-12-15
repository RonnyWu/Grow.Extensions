// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for immutable component manipulation of Unity's Vector4 type.
    /// </summary>
    /// <remarks>
    /// This utility class offers a fluent API for creating new Vector4 instances with modified components.
    /// All methods:
    /// - Return new vector instances (immutable operations)
    /// - Are optimized with AggressiveInlining
    /// - Support both selective and individual component updates
    ///  
    /// Common use cases:
    /// - Shader parameters
    /// - Particle system properties
    /// - Homogeneous coordinates
    /// - Color with alpha (RGBA)
    /// - Texture coordinates (UVST)
    /// </remarks>
    public static class WithVector4Syntax
    {
        /// <summary>
        /// Creates a new Vector4 with selectively modified components.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">Optional new x component value.</param>
        /// <param name="y">Optional new y component value.</param>
        /// <param name="z">Optional new z component value.</param>
        /// <param name="w">Optional new w component value.</param>
        /// <returns>A new Vector4 with specified components modified.</returns>
        /// <example>
        /// <code>
        /// // Shader parameter manipulation
        /// material.SetVector("_CustomVector", currentValue.With(w: 1.0f));
        ///   
        /// // Color with alpha modification
        /// Color color = new Vector4(1f, 0f, 0f, 0.5f);
        /// color = color.With(w: 1.0f); // Adjust alpha to fully opaque
        ///   
        /// // Texture coordinates
        /// Vector4 uvst = currentUVST.With(z: tiling, w: offset);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 With(this Vector4 vector, [CanBeNull] float? x = null, [CanBeNull] float? y = null, [CanBeNull] float? z = null, [CanBeNull] float? w = null) => new(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);

        /// <summary>
        /// Creates a new Vector4 with modified x component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">New x component value.</param>
        /// <returns>A new Vector4 with modified x component.</returns>
        /// <example>
        /// <code>
        /// // Modify red channel in RGBA color
        /// colorVector = colorVector.WithX(1.0f);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 WithX(this Vector4 vector, float x) => new(x, vector.y, vector.z, vector.w);

        /// <summary>
        /// Creates a new Vector4 with modified y component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="y">New y component value.</param>
        /// <returns>A new Vector4 with modified y component.</returns>
        /// <example>
        /// <code>
        /// // Modify green channel in RGBA color
        /// colorVector = colorVector.WithY(0.5f);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 WithY(this Vector4 vector, float y) => new(vector.x, y, vector.z, vector.w);

        /// <summary>
        /// Creates a new Vector4 with modified z component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="z">New z component value.</param>
        /// <returns>A new Vector4 with modified z component.</returns>
        /// <example>
        /// <code>
        /// // Modify blue channel in RGBA color
        /// colorVector = colorVector.WithZ(0.7f);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 WithZ(this Vector4 vector, float z) => new(vector.x, vector.y, z, vector.w);

        /// <summary>
        /// Creates a new Vector4 with modified w component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="w">New w component value.</param>
        /// <returns>A new Vector4 with modified w component.</returns>
        /// <example>
        /// <code>
        /// // Modify alpha channel in RGBA color
        /// colorVector = colorVector.WithW(0.5f); // Set 50% transparency
        ///   
        /// // Modify texture offset
        /// textureVector = textureVector.WithW(offset);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 WithW(this Vector4 vector, float w) => new(vector.x, vector.y, vector.z, w);
    }
}