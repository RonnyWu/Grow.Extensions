// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for immutable component manipulation of Unity's Vector3 and Vector3Int types.
    /// </summary>
    /// <remarks>
    /// This utility class offers a fluent API for creating new vector instances with modified components.
    /// All methods:
    /// - Return new vector instances (immutable operations)
    /// - Are optimized with AggressiveInlining
    /// - Support both selective and individual component updates
    ///  
    /// Common use cases:
    /// - Transform position/scale manipulation
    /// - Physics calculations
    /// - Camera positioning
    /// - Voxel-based operations (Vector3Int)
    /// </remarks>
    public static class WithVector3Syntax
    {
        #region Vector3

        /// <summary>
        /// Creates a new Vector3 with selectively modified components.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">Optional new x component value.</param>
        /// <param name="y">Optional new y component value.</param>
        /// <param name="z">Optional new z component value.</param>
        /// <returns>A new Vector3 with specified components modified.</returns>
        /// <example>
        /// <code>
        /// var position = new Vector3(1f, 2f, 3f);
        ///   
        /// // Modify specific components
        /// position = position.With(x: 5f, z: 7f); // Results in (5, 2, 7)
        ///   
        /// // Common transform manipulation
        /// transform.position = transform.position
        ///     .With(y: groundLevel); // Snap to ground
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 With(this Vector3 vector, [CanBeNull] float? x = null, [CanBeNull] float? y = null, [CanBeNull] float? z = null) => new(x ?? vector.x, y ?? vector.y, z ?? vector.z);

        /// <summary>
        /// Creates a new Vector3 with modified x component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">New x component value.</param>
        /// <returns>A new Vector3 with modified x component.</returns>
        /// <example>
        /// <code>
        /// transform.position = transform.position
        ///     .WithX(targetX); // Only modify X position
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithX(this Vector3 vector, float x) => new(x, vector.y, vector.z);

        /// <summary>
        /// Creates a new Vector3 with modified y component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="y">New y component value.</param>
        /// <returns>A new Vector3 with modified y component.</returns>
        /// <example>
        /// <code>
        /// transform.position = transform.position
        ///     .WithY(jumpHeight); // Vertical movement
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithY(this Vector3 vector, float y) => new(vector.x, y, vector.z);

        /// <summary>
        /// Creates a new Vector3 with modified z component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="z">New z component value.</param>
        /// <returns>A new Vector3 with modified z component.</returns>
        /// <example>
        /// <code>
        /// transform.position = transform.position
        ///     .WithZ(targetDepth); // Depth adjustment
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithZ(this Vector3 vector, float z) => new(vector.x, vector.y, z);

        #endregion

        #region Vector3Int

        /// <summary>
        /// Creates a new Vector3Int with selectively modified components.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">Optional new x component value.</param>
        /// <param name="y">Optional new y component value.</param>
        /// <param name="z">Optional new z component value.</param>
        /// <returns>A new Vector3Int with specified components modified.</returns>
        /// <example>
        /// <code>
        /// var gridPos = new Vector3Int(1, 2, 3);
        ///   
        /// // Modify specific components
        /// gridPos = gridPos.With(x: 5, z: 7); // Results in (5, 2, 7)
        ///   
        /// // Useful for voxel operations
        /// chunkPosition = chunkPosition.With(y: heightLevel);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int With(this Vector3Int vector, [CanBeNull] int? x = null, [CanBeNull] int? y = null, [CanBeNull] int? z = null) => new(x ?? vector.x, y ?? vector.y, z ?? vector.z);

        /// <summary>
        /// Creates a new Vector3Int with modified x component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">New x component value.</param>
        /// <returns>A new Vector3Int with modified x component.</returns>
        /// <example>
        /// <code>
        /// gridPosition = gridPosition.WithX(targetColumn);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithX(this Vector3Int vector, int x) => new(x, vector.y, vector.z);

        /// <summary>
        /// Creates a new Vector3Int with modified y component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="y">New y component value.</param>
        /// <returns>A new Vector3Int with modified y component.</returns>
        /// <example>
        /// <code>
        /// voxelPosition = voxelPosition.WithY(heightLevel);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithY(this Vector3Int vector, int y) => new(vector.x, y, vector.z);

        /// <summary>
        /// Creates a new Vector3Int with modified z component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="z">New z component value.</param>
        /// <returns>A new Vector3Int with modified z component.</returns>
        /// <example>
        /// <code>
        /// chunkPosition = chunkPosition.WithZ(layerIndex);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithZ(this Vector3Int vector, int z) => new(vector.x, vector.y, z);

        #endregion
    }
}