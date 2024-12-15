// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for Vector3 operations with a fluent syntax.
    /// </summary>
    /// <remarks>
    /// This utility class offers performance-optimized Vector3 operations:
    /// - Range checking without square root calculations
    /// - Distance calculations with readable syntax
    /// All methods are optimized with AggressiveInlining for better performance.
    /// </remarks>
    public static class Vector3Syntax
    {
        /// <summary>
        /// Checks if another Vector3 is within the specified range of this vector.
        /// </summary>
        /// <param name="source">The source position.</param>
        /// <param name="other">The target position to check.</param>
        /// <param name="range">The maximum distance between the points.</param>
        /// <returns>true if the points are within range; otherwise, false.</returns>
        /// <example>
        /// <code>
        /// // Check if player is in range of an item
        /// Vector3 itemPosition = transform.position;
        /// Vector3 playerPosition = player.position;
        /// if (itemPosition.InRange(playerPosition, 5f))
        /// {
        ///     PickupItem();
        /// }
        ///   
        /// // Area trigger check
        /// void OnUpdate()
        /// {
        ///     Vector3 targetPos = target.position;
        ///     if (transform.position.InRange(targetPos, detectionRadius))
        ///     {
        ///         OnTargetInRange(targetPos);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// Performance optimization:
        /// - Uses sqrMagnitude to avoid expensive square root calculations
        /// - Suitable for frequent checks like triggers or AI logic
        /// - More efficient than Distance/magnitude comparisons
        ///   
        /// Common use cases:
        /// - Proximity detection
        /// - Trigger zones
        /// - AI decision making
        /// - Item collection ranges
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static bool InRange(this Vector3 source, Vector3 other, float range) => (source - other).sqrMagnitude <= range * range;

        /// <summary>
        /// Calculates the distance between this vector and another point.
        /// </summary>
        /// <param name="vector">The source position.</param>
        /// <param name="other">The target position.</param>
        /// <returns>The distance between the two points.</returns>
        /// <example>
        /// <code>
        /// // Calculate distance for UI display
        /// void UpdateDistanceUI()
        /// {
        ///     float distance = transform.position.DistanceTo(target.position);
        ///     distanceText.text = $"Distance: {distance:F1}m";
        /// }
        ///   
        /// // Distance-based effect scaling
        /// void UpdateEffect()
        /// {
        ///     float dist = effectSource.DistanceTo(listener.position);
        ///     float intensity = Mathf.Lerp(maxIntensity, minIntensity,
        ///         dist / maxDistance);
        ///     ApplyEffect(intensity);
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// Usage considerations:
        /// - More readable than Vector3.Distance
        /// - Involves square root calculation
        /// - For simple range checks, prefer InRange method
        /// - Suitable for actual distance calculations needed for:
        ///   * UI display
        ///   * Effect intensity scaling
        ///   * Path length calculations
        ///   * Scoring systems
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static float DistanceTo(this Vector3 vector, Vector3 other) => Vector3.Distance(vector, other);
    }
}