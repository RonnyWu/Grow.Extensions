// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for Unity Quaternion manipulation through both direct component access and Euler angles.
    /// </summary>
    /// <remarks>
    /// This utility class offers two approaches to rotation manipulation:
    /// 1. Direct quaternion component modification (With* methods)
    /// 2. Euler angles modification (WithEuler* methods)
    ///   
    /// All methods:
    /// - Return new Quaternion instances (immutable operations)
    /// - Are optimized with AggressiveInlining
    ///   
    /// Important notes:
    /// - Direct component manipulation (With* methods) should be used with caution
    /// - Prefer Euler angle methods (WithEuler*) for standard rotation operations
    /// - All Euler angles are in degrees, matching Unity's convention
    /// - Euler rotation order follows Unity's Z-X-Y convention
    /// </remarks>
    public static class WithQuaternionSyntax
    {
        #region With - Quaternion

        /// <summary>
        /// Creates a new Quaternion with specified component values.
        /// </summary>
        /// <param name="quaternion">The source quaternion (unused, exists for extension method syntax).</param>
        /// <param name="x">The x component of the quaternion.</param>
        /// <param name="y">The y component of the quaternion.</param>
        /// <param name="z">The z component of the quaternion.</param>
        /// <param name="w">The w component of the quaternion.</param>
        /// <returns>A new Quaternion instance with the specified values.</returns>
        /// <remarks>
        /// Warning: Direct component manipulation may result in non-normalized quaternions.
        /// Consider using WithEuler methods for standard rotation operations.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion With(this Quaternion quaternion, float x, float y, float z, float w) =>
            new(x, y, z, w);

        /// <summary>
        /// Creates a new Quaternion with optionally modified component values.
        /// </summary>
        /// <param name="quaternion">The source quaternion to create from.</param>
        /// <param name="x">Optional new x component value.</param>
        /// <param name="y">Optional new y component value.</param>
        /// <param name="z">Optional new z component value.</param>
        /// <param name="w">Optional new w component value.</param>
        /// <returns>A new Quaternion with modified components, retaining original values for unspecified components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion With(this Quaternion quaternion, [CanBeNull] float? x = null, [CanBeNull] float? y = null, [CanBeNull] float? z = null, [CanBeNull] float? w = null) =>
            new(x ?? quaternion.x, y ?? quaternion.y, z ?? quaternion.z, w ?? quaternion.w);

        /// <summary>
        /// Creates a new Quaternion with modified x component.
        /// </summary>
        /// <param name="quaternion">The source quaternion.</param>
        /// <param name="x">New x component value.</param>
        /// <returns>A new Quaternion with modified x component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithX(this Quaternion quaternion, float x) =>
            new(x, quaternion.y, quaternion.z, quaternion.w);

        /// <summary>
        /// Creates a new Quaternion with modified y component.
        /// </summary>
        /// <param name="quaternion">The source quaternion.</param>
        /// <param name="y">New y component value.</param>
        /// <returns>A new Quaternion with modified y component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithY(this Quaternion quaternion, float y) =>
            new(quaternion.x, y, quaternion.z, quaternion.w);

        /// <summary>
        /// Creates a new Quaternion with modified z component.
        /// </summary>
        /// <param name="quaternion">The source quaternion.</param>
        /// <param name="z">New z component value.</param>
        /// <returns>A new Quaternion with modified z component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithZ(this Quaternion quaternion, float z) =>
            new(quaternion.x, quaternion.y, z, quaternion.w);

        /// <summary>
        /// Creates a new Quaternion with modified w component.
        /// </summary>
        /// <param name="quaternion">The source quaternion.</param>
        /// <param name="w">New w component value.</param>
        /// <returns>A new Quaternion with modified w component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithW(this Quaternion quaternion, float w) =>
            new(quaternion.x, quaternion.y, quaternion.z, w);

        #endregion

        #region With - Euler

        /// <summary>
        /// Creates a new rotation with modified Euler angles while preserving unspecified components.
        /// </summary>
        /// <param name="rotation">The source rotation to modify.</param>
        /// <param name="x">Optional new X rotation in degrees (pitch).</param>
        /// <param name="y">Optional new Y rotation in degrees (yaw).</param>
        /// <param name="z">Optional new Z rotation in degrees (roll).</param>
        /// <returns>A new normalized Quaternion with the specified rotation changes.</returns>
        /// <example>
        /// <code>
        /// var rotation = Quaternion.identity;
        /// // Modify only Y rotation (yaw)
        /// var yawOnly = rotation.WithEuler(y: 90f);
        /// // Modify both pitch and roll
        /// var combined = rotation.WithEuler(x: 30f, z: 45f);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithEuler(this Quaternion rotation, [CanBeNull] float? x = null, [CanBeNull] float? y = null, [CanBeNull] float? z = null)
        {
            var euler = rotation.eulerAngles;
            return Quaternion.Euler(x ?? euler.x, y ?? euler.y, z ?? euler.z);
        }

        /// <summary>
        /// Creates a new rotation with modified X Euler angle (pitch).
        /// </summary>
        /// <param name="rotation">The source rotation.</param>
        /// <param name="x">New X rotation in degrees (pitch).</param>
        /// <returns>A new normalized Quaternion with modified pitch.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithEulerX(this Quaternion rotation, float x)
        {
            var euler = rotation.eulerAngles;
            return Quaternion.Euler(x, euler.y, euler.z);
        }

        /// <summary>
        /// Creates a new rotation with modified Y Euler angle (yaw).
        /// </summary>
        /// <param name="rotation">The source rotation.</param>
        /// <param name="y">New Y rotation in degrees (yaw).</param>
        /// <returns>A new normalized Quaternion with modified yaw.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithEulerY(this Quaternion rotation, float y)
        {
            var euler = rotation.eulerAngles;
            return Quaternion.Euler(euler.x, y, euler.z);
        }

        /// <summary>
        /// Creates a new rotation with modified Z Euler angle (roll).
        /// </summary>
        /// <param name="rotation">The source rotation.</param>
        /// <param name="z">New Z rotation in degrees (roll).</param>
        /// <returns>A new normalized Quaternion with modified roll.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion WithEulerZ(this Quaternion rotation, float z)
        {
            var euler = rotation.eulerAngles;
            return Quaternion.Euler(euler.x, euler.y, z);
        }

        #endregion
    }
}