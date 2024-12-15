// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for modifying Unity Bounds properties immutably.
    /// </summary>
    /// <remarks>
    /// This utility class offers a fluent API for creating new Bounds instances with modified properties.
    /// All methods are implemented as pure functions, returning new Bounds instances rather than modifying existing ones.
    /// Methods are optimized with AggressiveInlining for better performance in hot paths.
    /// </remarks>
    public static class WithBoundsSyntax
    {
        /// <summary>
        /// Creates a new Bounds instance with optionally modified center and size vectors.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="center">Optional new center vector. If null, uses the original center.</param>
        /// <param name="size">Optional new size vector. If null, uses the original size.</param>
        /// <returns>A new Bounds instance with the specified modifications.</returns>
        /// <example>
        /// <code>
        /// var original = new Bounds(Vector3.zero, Vector3.one);
        /// var modified = original.With(center: new Vector3(1, 1, 1));
        /// // Results in Bounds with center (1,1,1) and size (1,1,1)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds With(this Bounds bounds, [CanBeNull] Vector3? center = null, [CanBeNull] Vector3? size = null) => new(center ?? bounds.center, size ?? bounds.size);

        /// <summary>
        /// Creates a new Bounds instance with individually specified center and size components.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="cx">Optional X coordinate of the center.</param>
        /// <param name="cy">Optional Y coordinate of the center.</param>
        /// <param name="cz">Optional Z coordinate of the center.</param>
        /// <param name="sx">Optional X component of the size.</param>
        /// <param name="sy">Optional Y component of the size.</param>
        /// <param name="sz">Optional Z component of the size.</param>
        /// <returns>A new Bounds instance with the specified modifications.</returns>
        /// <example>
        /// <code>
        /// var original = new Bounds(Vector3.zero, Vector3.one);
        /// var modified = original.With(cx: 1f, sy: 2f);
        /// // Results in Bounds with center (1,0,0) and size (1,2,1)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds With(this Bounds bounds, [CanBeNull] float? cx = null, [CanBeNull] float? cy = null, [CanBeNull] float? cz = null, [CanBeNull] float? sx = null, [CanBeNull] float? sy = null, [CanBeNull] float? sz = null) =>
            new(new Vector3(cx ?? bounds.center.x, cy ?? bounds.center.y, cz ?? bounds.center.z), new Vector3(sx ?? bounds.size.x, sy ?? bounds.size.y, sz ?? bounds.size.z));

        /// <summary>
        /// Creates a new Bounds instance with modified center coordinates.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="x">Optional X coordinate of the center.</param>
        /// <param name="y">Optional Y coordinate of the center.</param>
        /// <param name="z">Optional Z coordinate of the center.</param>
        /// <returns>A new Bounds instance with the modified center.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithCenter(this Bounds bounds, [CanBeNull] float? x = null, [CanBeNull] float? y = null, [CanBeNull] float? z = null) => new(new Vector3(x ?? bounds.center.x, y ?? bounds.center.y, z ?? bounds.center.z), bounds.size);

        /// <summary>
        /// Creates a new Bounds instance with modified center X coordinate.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="x">New X coordinate of the center.</param>
        /// <returns>A new Bounds instance with the modified center X coordinate.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithCenterX(this Bounds bounds, float x) => new(new Vector3(x, bounds.center.y, bounds.center.z), bounds.size);

        /// <summary>
        /// Creates a new Bounds instance with modified center Y coordinate.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="y">New Y coordinate of the center.</param>
        /// <returns>A new Bounds instance with the modified center Y coordinate.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithCenterY(this Bounds bounds, float y) => new(new Vector3(bounds.center.x, y, bounds.center.z), bounds.size);

        /// <summary>
        /// Creates a new Bounds instance with modified center Z coordinate.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="z">New Z coordinate of the center.</param>
        /// <returns>A new Bounds instance with the modified center Z coordinate.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithCenterZ(this Bounds bounds, float z) => new(new Vector3(bounds.center.x, bounds.center.y, z), bounds.size);

        /// <summary>
        /// Creates a new Bounds instance with modified size components.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="x">Optional X component of the size.</param>
        /// <param name="y">Optional Y component of the size.</param>
        /// <param name="z">Optional Z component of the size.</param>
        /// <returns>A new Bounds instance with the modified size.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithSize(this Bounds bounds, [CanBeNull] float? x = null, [CanBeNull] float? y = null, [CanBeNull] float? z = null) => new(bounds.center, new Vector3(x ?? bounds.size.x, y ?? bounds.size.y, z ?? bounds.size.z));

        /// <summary>
        /// Creates a new Bounds instance with modified size X component.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="x">New X component of the size.</param>
        /// <returns>A new Bounds instance with the modified size X component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithSizeX(this Bounds bounds, float x) => new(bounds.center, new Vector3(x, bounds.size.y, bounds.size.z));

        /// <summary>
        /// Creates a new Bounds instance with modified size Y component.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="y">New Y component of the size.</param>
        /// <returns>A new Bounds instance with the modified size Y component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithSizeY(this Bounds bounds, float y) => new(bounds.center, new Vector3(bounds.size.x, y, bounds.size.z));

        /// <summary>
        /// Creates a new Bounds instance with modified size Z component.
        /// </summary>
        /// <param name="bounds">The source Bounds to create from.</param>
        /// <param name="z">New Z component of the size.</param>
        /// <returns>A new Bounds instance with the modified size Z component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds WithSizeZ(this Bounds bounds, float z) => new(bounds.center, new Vector3(bounds.size.x, bounds.size.y, z));
    }
}