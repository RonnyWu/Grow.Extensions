// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for immutable component manipulation of Unity's Vector2 and Vector2Int types.
    /// </summary>
    /// <remarks>
    /// This utility class offers a fluent API for creating new vector instances with modified components.
    /// All methods:
    /// - Return new vector instances (immutable operations)
    /// - Are optimized with AggressiveInlining
    /// - Maintain single-component modification for precise control
    ///   
    /// Common use cases:
    /// - UI element positioning
    /// - 2D game mechanics
    /// - Physics calculations
    /// - Grid-based operations (Vector2Int)
    /// </remarks>
    public static class WithVector2Syntax
    {
        #region Vector2

        /// <summary>
        /// Creates a new Vector2 with modified x component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">New x component value.</param>
        /// <returns>A new Vector2 with modified x component.</returns>
        /// <example>
        /// <code>
        /// var position = new Vector2(3f, 4f);
        /// var newPosition = position.WithX(5f); // Results in (5, 4)
        ///   
        /// // Useful for UI positioning
        /// rectTransform.anchoredPosition = rectTransform.anchoredPosition
        ///     .WithX(100f); // Only modify X position
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 WithX(this Vector2 vector, float x) => new(x, vector.y);

        /// <summary>
        /// Creates a new Vector2 with modified y component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="y">New y component value.</param>
        /// <returns>A new Vector2 with modified y component.</returns>
        /// <example>
        /// <code>
        /// var position = new Vector2(3f, 4f);
        /// var newPosition = position.WithY(6f); // Results in (3, 6)
        ///   
        /// // Useful for vertical movement
        /// rigidbody2D.velocity = rigidbody2D.velocity
        ///     .WithY(jumpForce); // Only modify vertical velocity
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 WithY(this Vector2 vector, float y) => new(vector.x, y);

        #endregion

        #region Vector2Int

        /// <summary>
        /// Creates a new Vector2Int with modified x component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="x">New x component value.</param>
        /// <returns>A new Vector2Int with modified x component.</returns>
        /// <example>
        /// <code>
        /// var gridPosition = new Vector2Int(3, 4);
        /// var newPosition = gridPosition.WithX(5); // Results in (5, 4)
        ///   
        /// // Useful for grid-based movement
        /// tilePosition = tilePosition.WithX(targetColumn);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int WithX(this Vector2Int vector, int x) => new(x, vector.y);

        /// <summary>
        /// Creates a new Vector2Int with modified y component.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="y">New y component value.</param>
        /// <returns>A new Vector2Int with modified y component.</returns>
        /// <example>
        /// <code>
        /// var gridPosition = new Vector2Int(3, 4);
        /// var newPosition = gridPosition.WithY(6); // Results in (3, 6)
        ///   
        /// // Useful for grid-based operations
        /// cellCoordinates = cellCoordinates.WithY(targetRow);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int WithY(this Vector2Int vector, int y) => new(vector.x, y);

        #endregion
    }
}