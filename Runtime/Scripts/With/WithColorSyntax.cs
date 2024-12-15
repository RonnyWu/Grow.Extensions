// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for modifying Unity Color and Color32 values immutably.
    /// </summary>
    /// <remarks>
    /// This utility class offers a fluent API for creating new color instances with modified components.
    /// All methods are implemented as pure functions, returning new instances rather than modifying existing ones.
    /// Methods are optimized with AggressiveInlining for better performance in hot paths.
    /// Color values are clamped automatically by Unity's Color/Color32 constructors.
    /// </remarks>
    public static class WithColorSyntax
    {
        #region Color

        /// <summary>
        /// Creates a new Color instance with optionally modified RGBA components.
        /// </summary>
        /// <param name="color">The source Color to create from.</param>
        /// <param name="r">Optional red component (0-1 range).</param>
        /// <param name="g">Optional green component (0-1 range).</param>
        /// <param name="b">Optional blue component (0-1 range).</param>
        /// <param name="a">Optional alpha component (0-1 range).</param>
        /// <returns>A new Color instance with the specified modifications.</returns>
        /// <example>
        /// <code>
        /// var original = Color.white;
        /// var modified = original.With(r: 0.5f, a: 0.7f);
        /// // Results in Color(0.5, 1, 1, 0.7)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color With(this Color color, [CanBeNull] float? r = null, [CanBeNull] float? g = null, [CanBeNull] float? b = null, [CanBeNull] float? a = null) => new(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);

        /// <summary>
        /// Creates a new Color instance with modified red component.
        /// </summary>
        /// <param name="color">The source Color to create from.</param>
        /// <param name="r">New red component value (0-1 range).</param>
        /// <returns>A new Color instance with the modified red component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithR(this Color color, float r) => new(r, color.g, color.b, color.a);

        /// <summary>
        /// Creates a new Color instance with modified green component.
        /// </summary>
        /// <param name="color">The source Color to create from.</param>
        /// <param name="g">New green component value (0-1 range).</param>
        /// <returns>A new Color instance with the modified green component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithG(this Color color, float g) => new(color.r, g, color.b, color.a);

        /// <summary>
        /// Creates a new Color instance with modified blue component.
        /// </summary>
        /// <param name="color">The source Color to create from.</param>
        /// <param name="b">New blue component value (0-1 range).</param>
        /// <returns>A new Color instance with the modified blue component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithB(this Color color, float b) => new(color.r, color.g, b, color.a);

        /// <summary>
        /// Creates a new Color instance with modified alpha component.
        /// </summary>
        /// <param name="color">The source Color to create from.</param>
        /// <param name="a">New alpha component value (0-1 range).</param>
        /// <returns>A new Color instance with the modified alpha component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithA(this Color color, float a) => new(color.r, color.g, color.b, a);

        #endregion

        #region Color32

        /// <summary>
        /// Creates a new Color32 instance with optionally modified RGBA components.
        /// </summary>
        /// <param name="color">The source Color32 to create from.</param>
        /// <param name="r">Optional red component (0-255 range).</param>
        /// <param name="g">Optional green component (0-255 range).</param>
        /// <param name="b">Optional blue component (0-255 range).</param>
        /// <param name="a">Optional alpha component (0-255 range).</param>
        /// <returns>A new Color32 instance with the specified modifications.</returns>
        /// <example>
        /// <code>
        /// var original = new Color32(255, 255, 255, 255);
        /// var modified = original.With(r: 128, a: 180);
        /// // Results in Color32(128, 255, 255, 180)
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 With(this Color32 color, [CanBeNull] byte? r = null, [CanBeNull] byte? g = null, [CanBeNull] byte? b = null, [CanBeNull] byte? a = null) => new(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);

        /// <summary>
        /// Creates a new Color32 instance with modified red component.
        /// </summary>
        /// <param name="color">The source Color32 to create from.</param>
        /// <param name="r">New red component value (0-255 range).</param>
        /// <returns>A new Color32 instance with the modified red component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 WithR(this Color32 color, byte r) => new(r, color.g, color.b, color.a);

        /// <summary>
        /// Creates a new Color32 instance with modified green component.
        /// </summary>
        /// <param name="color">The source Color32 to create from.</param>
        /// <param name="g">New green component value (0-255 range).</param>
        /// <returns>A new Color32 instance with the modified green component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 WithG(this Color32 color, byte g) => new(color.r, g, color.b, color.a);

        /// <summary>
        /// Creates a new Color32 instance with modified blue component.
        /// </summary>
        /// <param name="color">The source Color32 to create from.</param>
        /// <param name="b">New blue component value (0-255 range).</param>
        /// <returns>A new Color32 instance with the modified blue component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 WithB(this Color32 color, byte b) => new(color.r, color.g, b, color.a);

        /// <summary>
        /// Creates a new Color32 instance with modified alpha component.
        /// </summary>
        /// <param name="color">The source Color32 to create from.</param>
        /// <param name="a">New alpha component value (0-255 range).</param>
        /// <returns>A new Color32 instance with the modified alpha component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 WithA(this Color32 color, byte a) => new(color.r, color.g, color.b, a);

        #endregion
    }
}