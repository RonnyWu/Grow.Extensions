// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for converting Vector3 and Vector3Int to Vector2 and Vector2Int.
    /// </summary>
    /// <remarks>
    /// This class contains a set of extension methods that facilitate the conversion between different vector types in Unity.
    /// All methods are marked with AggressiveInlining for optimal performance in hot paths.
    /// </remarks>
    public static class ToVector2Syntax
    {
        #region Vector3

        /// <summary>
        /// Converts a Vector3 to Vector2 by taking the X and Y components.
        /// </summary>
        /// <param name="vector">The source Vector3 to convert.</param>
        /// <returns>A new Vector2 containing the X and Y components of the source vector.</returns>
        /// <example>
        /// <code>
        /// Vector3 v3 = new Vector3(1f, 2f, 3f);
        /// Vector2 v2 = v3.ToVector2(); // Results in (1, 2)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToVector2(this Vector3 vector) => new(vector.x, vector.y);

        /// <summary>
        /// Converts a Vector3 to Vector2 by taking the X and Z components.
        /// Useful for top-down games where Y represents height.
        /// </summary>
        /// <param name="vector">The source Vector3 to convert.</param>
        /// <returns>A new Vector2 containing the X and Z components of the source vector.</returns>
        /// <example>
        /// <code>
        /// Vector3 v3 = new Vector3(1f, 2f, 3f);
        /// Vector2 v2 = v3.ToVector2XZ(); // Results in (1, 3)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToVector2XZ(this Vector3 vector) => new(vector.x, vector.z);

        /// <summary>
        /// Converts a Vector3 to Vector2 by taking the Y and Z components.
        /// </summary>
        /// <param name="vector">The source Vector3 to convert.</param>
        /// <returns>A new Vector2 containing the Y and Z components of the source vector.</returns>
        /// <example>
        /// <code>
        /// Vector3 v3 = new Vector3(1f, 2f, 3f);
        /// Vector2 v2 = v3.ToVector2YZ(); // Results in (2, 3)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToVector2YZ(this Vector3 vector) => new(vector.y, vector.z);

        #endregion

        #region Vector3Int

        /// <summary>
        /// Converts a Vector3Int to Vector2Int by taking the X and Y components.
        /// </summary>
        /// <param name="vector">The source Vector3Int to convert.</param>
        /// <returns>A new Vector2Int containing the X and Y components of the source vector.</returns>
        /// <example>
        /// <code>
        /// Vector3Int v3 = new Vector3Int(1, 2, 3);
        /// Vector2Int v2 = v3.ToVector2Int(); // Results in (1, 2)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int ToVector2Int(this Vector3Int vector) => new(vector.x, vector.y);

        /// <summary>
        /// Converts a Vector3Int to Vector2Int by taking the X and Z components.
        /// Useful for grid-based top-down games where Y represents height level.
        /// </summary>
        /// <param name="vector">The source Vector3Int to convert.</param>
        /// <returns>A new Vector2Int containing the X and Z components of the source vector.</returns>
        /// <example>
        /// <code>
        /// Vector3Int v3 = new Vector3Int(1, 2, 3);
        /// Vector2Int v2 = v3.ToVector2IntXZ(); // Results in (1, 3)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int ToVector2IntXZ(this Vector3Int vector) => new(vector.x, vector.z);

        /// <summary>
        /// Converts a Vector3Int to Vector2Int by taking the Y and Z components.
        /// </summary>
        /// <param name="vector">The source Vector3Int to convert.</param>
        /// <returns>A new Vector2Int containing the Y and Z components of the source vector.</returns>
        /// <example>
        /// <code>
        /// Vector3Int v3 = new Vector3Int(1, 2, 3);
        /// Vector2Int v2 = v3.ToVector2IntYZ(); // Results in (2, 3)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int ToVector2IntYZ(this Vector3Int vector) => new(vector.y, vector.z);

        #endregion
    }
}