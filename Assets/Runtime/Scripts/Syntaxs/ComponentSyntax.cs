// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for Unity Component management with a fluent syntax.
    /// </summary>
    /// <remarks>
    /// This utility class offers a collection of methods to streamline component operations:
    /// - Component addition and retrieval
    /// - Component removal
    /// - Hierarchical component queries
    /// All methods are optimized for performance with AggressiveInlining where appropriate.
    /// </remarks>
    public static class ComponentSyntax
    {
        #region GetOrAddComponent - in Component

        /// <summary>
        /// Internal helper method to get or add a component to a GameObject.
        /// </summary>
        /// <param name="source">Target GameObject.</param>
        /// <typeparam name="T">Type of component.</typeparam>
        /// <returns>Existing or newly added component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T GetOrAddComponentInternal<T>([NotNull] GameObject source) where T : Component => source.TryGetComponent<T>(out var component) ? component : source.AddComponent<T>();

        /// <summary>
        /// Gets an existing component or adds it if not present.
        /// </summary>
        /// <param name="source">Target GameObject.</param>
        /// <typeparam name="T">Type of component to get or add.</typeparam>
        /// <returns>The existing or newly added component.</returns>
        /// <example>
        /// <code>
        /// // Get or add Rigidbody
        /// var rb = gameObject.GetOrAddComponent&lt;Rigidbody&gt;();
        ///   
        /// // Chain multiple operations
        /// var collider = gameObject
        ///     .GetOrAddComponent&lt;BoxCollider&gt;()
        ///     .gameObject
        ///     .GetOrAddComponent&lt;Rigidbody&gt;();
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrAddComponent<T>([NotNull] this GameObject source) where T : Component => GetOrAddComponentInternal<T>(source);

        /// <summary>
        /// Gets an existing component or adds it if not present on the Transform's GameObject.
        /// </summary>
        /// <param name="source">Target Transform.</param>
        /// <typeparam name="T">Type of component to get or add.</typeparam>
        /// <returns>The existing or newly added component.</returns>
        /// <example>
        /// <code>
        /// // Get or add AudioSource using Transform
        /// var audio = transform.GetOrAddComponent&lt;AudioSource&gt;();
        ///   
        /// // Use with child objects
        /// var childCollider = transform.GetChild(0)
        ///     .GetOrAddComponent&lt;BoxCollider&gt;();
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrAddComponent<T>([NotNull] this Transform source) where T : Component => GetOrAddComponentInternal<T>(source.gameObject);

        /// <summary>
        /// Gets an existing component or adds it and initializes it with the provided action.
        /// </summary>
        /// <param name="source">Target GameObject.</param>
        /// <param name="action">Initialization action for newly added components.</param>
        /// <typeparam name="T">Type of component to get or add.</typeparam>
        /// <returns>The existing or newly added component.</returns>
        /// <example>
        /// <code>
        /// // Initialize new Rigidbody
        /// var rb = gameObject.GetOrAddComponent&lt;Rigidbody&gt;(r => {
        ///     r.mass = 2f;
        ///     r.drag = 0.5f;
        ///     r.useGravity = false;
        /// });
        ///   
        /// // Setup AudioSource with defaults
        /// var audio = gameObject.GetOrAddComponent&lt;AudioSource&gt;(a => {
        ///     a.playOnAwake = false;
        ///     a.spatialBlend = 1f;
        ///     a.volume = 0.8f;
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrAddComponent<T>([NotNull] this GameObject source, [CanBeNull] Action<T> action) where T : Component
        {
            if (source.TryGetComponent<T>(out var component)) return component;
            component = source.AddComponent<T>();
            action?.Invoke(component);
            return component;
        }

        /// <summary>
        /// Gets an existing component or adds it and initializes it with the provided action on the Transform's GameObject.
        /// </summary>
        /// <param name="source">Target Transform.</param>
        /// <param name="onAdd">Initialization action for newly added components.</param>
        /// <typeparam name="T">Type of component to get or add.</typeparam>
        /// <returns>The existing or newly added component.</returns>
        /// <example>
        /// <code>
        /// // Setup Collider on child Transform
        /// var collider = childTransform.GetOrAddComponent&lt;BoxCollider&gt;(c => {
        ///     c.isTrigger = true;
        ///     c.size = new Vector3(2f, 2f, 2f);
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetOrAddComponent<T>([NotNull] this Transform source, [CanBeNull] Action<T> onAdd) where T : Component => GetOrAddComponent(source.gameObject, onAdd);

        #endregion

        #region GetOrAddComponent - by Type

        /// <summary>
        /// Internal helper method to get or add a component of specified Type to a GameObject.
        /// </summary>
        /// <param name="source">Target GameObject.</param>
        /// <param name="type">Type of component to get or add.</param>
        /// <returns>Existing or newly added component.</returns>
        /// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Component GetOrAddComponentInternal([NotNull] this GameObject source, [NotNull] Type type)
        {
            type.ThrowIfNull();
            return source.TryGetComponent(type, out var component) ? component : source.AddComponent(type);
        }

        /// <summary>
        /// Gets an existing component or adds it if not present using runtime Type information.
        /// </summary>
        /// <param name="source">Target GameObject.</param>
        /// <param name="type">Type of component to get or add.</param>
        /// <returns>The existing or newly added component.</returns>
        /// <example>
        /// <code>
        /// // Add component by type variable
        /// Type audioType = typeof(AudioSource);
        /// var audio = gameObject.GetOrAddComponent(audioType);
        ///   
        /// // Dynamic component type handling
        /// foreach (Type componentType in requiredComponents)
        /// {
        ///     var component = gameObject.GetOrAddComponent(componentType);
        ///     InitializeComponent(component);
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// This method is particularly useful for:
        /// - Runtime component management
        /// - Plugin systems with dynamic component types
        /// - Component dependency resolution
        /// - Reflection-based component operations
        ///  
        /// Note: Consider using the generic version GetOrAddComponent&lt;T&gt; when the component
        /// type is known at compile time for better type safety and performance.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Component GetOrAddComponent([NotNull] this GameObject source, [NotNull] Type type) => GetOrAddComponentInternal(source, type);

        /// <summary>
        /// Gets an existing component or adds it if not present using runtime Type information on the Transform's GameObject.
        /// </summary>
        /// <param name="source">Target Transform.</param>
        /// <param name="type">Type of component to get or add.</param>
        /// <returns>The existing or newly added component.</returns>
        /// <example>
        /// <code>
        /// // Add component to child object by type
        /// Type colliderType = typeof(BoxCollider);
        /// var collider = transform.GetChild(0).GetOrAddComponent(colliderType);
        ///   
        /// // Process multiple components on hierarchy
        /// foreach (Transform child in transform)
        /// {
        ///     foreach (Type type in componentTypes)
        ///     {
        ///         var component = child.GetOrAddComponent(type);
        ///         ProcessComponent(component);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// Best practices:
        /// - Cache Type objects when using repeatedly
        /// - Validate Type is a Component type before calling
        /// - Consider performance implications of non-generic component operations
        /// - Use for framework/plugin scenarios where type information is dynamic
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Component GetOrAddComponent([NotNull] this Transform source, [NotNull] Type type) => GetOrAddComponentInternal(source.gameObject, type);

        #endregion

        #region RemoveComponent - in Component

        /// <summary>
        /// Removes a component of type T from the GameObject if it exists.
        /// </summary>
        /// <typeparam name="T">Type of component to remove.</typeparam>
        /// <param name="gameObject">Target GameObject.</param>
        /// <example>
        /// <code>
        /// // Remove specific component
        /// gameObject.RemoveComponent&lt;AudioSource&gt;();
        ///   
        /// // Remove multiple components in sequence
        /// gameObject
        ///     .RemoveComponent&lt;BoxCollider&gt;()
        ///     .RemoveComponent&lt;Rigidbody&gt;();
        /// </code>
        /// </example>
        /// <remarks>
        /// This method is safe to call even if the component doesn't exist.
        /// The component is destroyed immediately but actual removal may be delayed until end of frame.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameObject RemoveComponent<T>([NotNull] this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent(out T component)) Object.Destroy(component);
            return gameObject;
        }

        /// <summary>
        /// Removes a component of type T from the GameObject after executing a cleanup action.
        /// </summary>
        /// <typeparam name="T">Type of component to remove.</typeparam>
        /// <param name="gameObject">Target GameObject.</param>
        /// <param name="action">Cleanup action to execute before removal.</param>
        /// <example>
        /// <code>
        /// // Cleanup AudioSource before removal
        /// gameObject.RemoveComponent&lt;AudioSource&gt;(audio => {
        ///     audio.Stop();
        ///     audio.clip = null;
        ///     OnAudioRemoved(audio);
        /// });
        ///   
        /// // Save state before removing component
        /// gameObject.RemoveComponent&lt;CharacterController&gt;(controller => {
        ///     SaveControllerState(controller);
        ///     UnregisterController(controller);
        /// });
        /// </code>
        /// </example>
        /// <remarks>
        /// Common use cases:
        /// - Resource cleanup before component removal
        /// - State saving before destruction
        /// - Event notification of component removal
        /// - Reference cleanup in other systems
        ///  
        /// Note: The cleanup action is only executed if the component exists.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RemoveComponent<T>([NotNull] this GameObject gameObject, [CanBeNull] Action<T> action) where T : Component
        {
            if (!gameObject.TryGetComponent(out T component)) return;
            action?.Invoke(component);
            Object.Destroy(component);
        }

        #endregion

        #region GetComponents

        /// <summary>
        /// Gets all components of type T from direct children of the transform.
        /// </summary>
        /// <typeparam name="T">Type of components to collect.</typeparam>
        /// <param name="parent">Parent transform to search children of.</param>
        /// <param name="result">List to store found components. Will be cleared before use.</param>
        /// <example>
        /// <code>
        /// var colliders = new List&lt;Collider&gt;();
        /// transform.GetComponentsInDirectChildren(ref colliders);
        /// foreach (var collider in colliders)
        /// {
        ///     collider.enabled = false;
        /// }
        ///   
        /// // Batch process child components
        /// var renderers = new List&lt;MeshRenderer&gt;();
        /// transform.GetComponentsInDirectChildren(ref renderers);
        /// renderers.ForEach(r => r.material = defaultMaterial);
        /// </code>
        /// </example>
        /// <remarks>
        /// Performance considerations:
        /// - Reuse the result list to avoid garbage collection
        /// - Only searches immediate children (depth = 1)
        /// - More efficient than GetComponentsInChildren for shallow hierarchies
        /// - Does not include components on the parent transform
        /// </remarks>
        public static void GetComponentsInDirectChildren<T>([NotNull] this Transform parent, [NotNull] ref List<T> result) where T : Component
        {
            result.Clear();
            var childCount = parent.childCount;
            for (var i = 0; i < childCount; i++)
            {
                if (parent.GetChild(i).TryGetComponent(out T component)) result.Add(component);
            }
        }

        /// <summary>
        /// Gets all components of type T from all children in the hierarchy using depth-first search.
        /// </summary>
        /// <typeparam name="T">Type of components to collect.</typeparam>
        /// <param name="parent">Parent transform to search hierarchy from.</param>
        /// <param name="result">List to store found components. Will be cleared before use.</param>
        /// <example>
        /// <code>
        /// // Process all lights in hierarchy
        /// var lights = new List&lt;Light&gt;();
        /// transform.GetComponentsInAllChildren(ref lights);
        /// foreach (var light in lights)
        /// {
        ///     light.intensity *= 0.5f;
        ///     light.range *= 1.5f;
        /// }
        ///   
        /// // Find and configure particle systems
        /// var particles = new List&lt;ParticleSystem&gt;();
        /// transform.GetComponentsInAllChildren(ref particles);
        /// particles.ForEach(ps => {
        ///     var main = ps.main;
        ///     main.simulationSpeed = gameSpeed;
        /// });
        /// </code>
        /// </example>
        /// <remarks>
        /// Implementation details:
        /// - Uses iterative depth-first search with a stack
        /// - More memory efficient than recursive approaches
        /// - Suitable for deep hierarchies
        /// - Does not allocate temporary collections
        /// - Does not include components on the parent transform
        ///  
        /// Performance tips:
        /// - Cache and reuse the result list
        /// - Consider using GetComponentsInDirectChildren for shallow searches
        /// - Be mindful of hierarchy depth impact on performance
        /// </remarks>
        public static void GetComponentsInAllChildren<T>([NotNull] this Transform parent, [NotNull] ref List<T> result) where T : Component
        {
            result.Clear();
            var stack = new Stack<Transform>();
            stack.Push(parent);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.TryGetComponent(out T component)) result.Add(component);
                var childCount = current.childCount;
                for (var i = 0; i < childCount; i++) stack.Push(current.GetChild(i));
            }
        }

        #endregion
    }
}