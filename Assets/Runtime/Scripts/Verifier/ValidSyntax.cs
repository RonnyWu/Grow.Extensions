// Copyright (c) 2024 Ronny Wu
// Licensed under the MIT License.
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Grow.Extensions
{
    /// <summary>
    /// Provides extension methods for Unity Object validation with fluent syntax.
    /// </summary>
    /// <remarks>
    /// This utility class offers a comprehensive set of validation methods for Unity Objects.
    /// All methods:
    /// - Are optimized with AggressiveInlining for minimal performance impact
    /// - Handle both reference null and Unity's "fake null" cases
    /// - Support method chaining for validation flows
    /// - Provide specialized overloads for GameObject and Component
    ///  
    /// Key features:
    /// - Validation checks (IsValid/IsInvalid)
    /// - Conditional execution (IfValid/IfInvalid)
    /// - Fallback value support
    /// - Type-safe operations
    ///  
    /// Common use cases:
    /// - Safe object access in Update/FixedUpdate
    /// - Component reference validation
    /// - Fallback behavior implementation
    /// - Null-safe event handling
    /// </remarks>
    public static class ValidSyntax
    {
        #region IsValid -- Object(fallback), GameObject, Component

        /// <summary>
        /// Checks if a Unity Object is valid (not null and not destroyed).
        /// </summary>
        /// <param name="source">The object to check.</param>
        /// <typeparam name="T">Type of Unity Object.</typeparam>
        /// <returns>True if the object is valid, false otherwise.</returns>
        /// <example>
        /// <code>
        /// if (transform.IsValid())
        /// {
        ///     // Safe to use transform
        ///     transform.position = Vector3.zero;
        /// }
        ///   
        /// // Chain with other validations
        /// if (camera.IsValid() && target.IsValid())
        /// {
        ///     camera.LookAt(target);
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid<T>([CanBeNull] this T source) where T : Object => source != null && !source.Equals(null);

        /// <summary>
        /// Checks if a GameObject is valid (not null and not destroyed).
        /// </summary>
        /// <param name="source">The GameObject to check.</param>
        /// <returns>True if the GameObject is valid, false otherwise.</returns>
        /// <example>
        /// <code>
        /// if (playerObject.IsValid())
        /// {
        ///     playerObject.SetActive(true);
        /// }
        ///   
        /// // Use in component initialization
        /// void Start()
        /// {
        ///     if (gameObject.IsValid())
        ///     {
        ///         InitializeComponents();
        ///     }
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid([CanBeNull] this GameObject source) => source != null && !source.Equals(null);

        /// <summary>
        /// Checks if a Component is valid (not null and not destroyed).
        /// </summary>
        /// <param name="source">The Component to check.</param>
        /// <returns>True if the Component is valid, false otherwise.</returns>
        /// <example>
        /// <code>
        /// void Update()
        /// {
        ///     if (rigidbody.IsValid())
        ///     {
        ///         rigidbody.AddForce(Vector3.up);
        ///     }
        /// }
        ///   
        /// // Check component references
        /// void OnEnable()
        /// {
        ///     if (animator.IsValid())
        ///     {
        ///         animator.SetTrigger("Start");
        ///     }
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid([CanBeNull] this Component source) => source != null && !source.Equals(null);

        #endregion

        #region IfValid -- Object(fallback)

        /// <summary>
        /// Executes an action if the object is valid.
        /// </summary>
        /// <param name="source">The object to check.</param>
        /// <param name="action">Action to execute if valid.</param>
        /// <typeparam name="T">Type of Unity Object.</typeparam>
        /// <example>
        /// <code>
        /// // Simple action
        /// target.IfValid(() => Debug.Log("Target is valid"));
        ///   
        /// // Use in event handling
        /// void OnTriggerEnter(Collider other)
        /// {
        ///     other.IfValid(() => HandleCollision());
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfValid<T>([CanBeNull] this T source, [CanBeNull] Action action) where T : Object
        {
            if (source.IsValid()) action?.Invoke();
        }

        /// <summary>
        /// Executes an action with the object if it is valid.
        /// </summary>
        /// <param name="source">The object to check.</param>
        /// <param name="action">Action to execute with the object if valid.</param>
        /// <typeparam name="T">Type of Unity Object.</typeparam>
        /// <example>
        /// <code>
        /// // With object reference
        /// playerTransform.IfValid(t => t.position = Vector3.zero);
        ///   
        /// // Complex operation
        /// targetCamera.IfValid(cam => {
        ///     cam.fieldOfView = 60f;
        ///     cam.backgroundColor = Color.black;
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfValid<T>([CanBeNull] this T source, [CanBeNull] Action<T> action) where T : Object
        {
            if (source.IsValid()) action?.Invoke(source);
        }

        #endregion

        #region IfValid -- GameObject

        /// <summary>
        /// Executes an action if the GameObject is valid.
        /// </summary>
        /// <param name="source">The GameObject to check.</param>
        /// <param name="action">Action to execute if valid.</param>
        /// <example>
        /// <code>
        /// // Simple activation
        /// gameObject.IfValid(() => gameObject.SetActive(true));
        ///   
        /// // Scene management
        /// levelObject.IfValid(() => {
        ///     SceneManager.LoadScene("NextLevel");
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfValid([CanBeNull] this GameObject source, [CanBeNull] Action action)
        {
            if (source.IsValid()) action?.Invoke();
        }

        /// <summary>
        /// Executes an action with the GameObject if it is valid.
        /// </summary>
        /// <param name="source">The GameObject to check.</param>
        /// <param name="action">Action to execute with the GameObject if valid.</param>
        /// <example>
        /// <code>
        /// // Component management
        /// playerObject.IfValid(go => {
        ///     go.AddComponent&lt;Rigidbody&gt;();
        ///     go.tag = "Player";
        /// });
        ///   
        /// // Child management
        /// parentObject.IfValid(go => {
        ///     foreach (Transform child in go.transform)
        ///     {
        ///         child.gameObject.SetActive(false);
        ///     }
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfValid([CanBeNull] this GameObject source, [CanBeNull] Action<GameObject> action)
        {
            if (source.IsValid()) action?.Invoke(source);
        }

        #endregion

        #region IfValid -- Component

        /// <summary>
        /// Executes an action if the Component is valid.
        /// </summary>
        /// <param name="source">The Component to check.</param>
        /// <param name="action">Action to execute if valid.</param>
        /// <example>
        /// <code>
        /// // Animation control
        /// animator.IfValid(() => {
        ///     PlayAnimation("Idle");
        /// });
        ///   
        /// // Physics setup
        /// rigidbody.IfValid(() => {
        ///     ConfigurePhysics();
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfValid([CanBeNull] this Component source, [CanBeNull] Action action)
        {
            if (source.IsValid()) action?.Invoke();
        }

        /// <summary>
        /// Executes an action with the Component if it is valid.
        /// </summary>
        /// <param name="source">The Component to check.</param>
        /// <param name="action">Action to execute with the Component if valid.</param>
        /// <example>
        /// <code>
        /// // Transform manipulation
        /// transform.IfValid(t => {
        ///     t.position = Vector3.zero;
        ///     t.rotation = Quaternion.identity;
        /// });
        ///   
        /// // Camera setup
        /// mainCamera.IfValid(cam => {
        ///     cam.clearFlags = CameraClearFlags.SolidColor;
        ///     cam.backgroundColor = Color.black;
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfValid([CanBeNull] this Component source, [CanBeNull] Action<Component> action)
        {
            if (source.IsValid()) action?.Invoke(source);
        }

        #endregion

        #region IsInvalid -- Object(fallback), GameObject, Component

        /// <summary>
        /// Checks if a Unity Object is invalid (null or destroyed).
        /// </summary>
        /// <param name="source">The object to check.</param>
        /// <typeparam name="T">Type of Unity Object.</typeparam>
        /// <returns>True if the object is invalid, false otherwise.</returns>
        /// <example>
        /// <code>
        /// if (target.IsInvalid())
        /// {
        ///     target = FindNewTarget();
        /// }
        ///   
        /// // Resource cleanup
        /// void OnDisable()
        /// {
        ///     if (audioSource.IsInvalid())
        ///     {
        ///         CleanupAudioResources();
        ///     }
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInvalid<T>([CanBeNull] this T source) where T : Object => source == null || source.Equals(null);

        /// <summary>
        /// Checks if a GameObject is invalid (null or destroyed).
        /// </summary>
        /// <param name="source">The GameObject to check.</param>
        /// <returns>True if the GameObject is invalid, false otherwise.</returns>
        /// <example>
        /// <code>
        /// // Object pooling
        /// if (pooledObject.IsInvalid())
        /// {
        ///     pooledObject = CreateNewPoolObject();
        /// }
        ///   
        /// // Scene cleanup
        /// void OnSceneUnloaded()
        /// {
        ///     if (levelObject.IsInvalid())
        ///     {
        ///         CleanupLevelResources();
        ///     }
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInvalid([CanBeNull] this GameObject source) => source == null || source.Equals(null);

        /// <summary>
        /// Checks if a Component is invalid (null or destroyed).
        /// </summary>
        /// <param name="source">The Component to check.</param>
        /// <returns>True if the Component is invalid, false otherwise.</returns>
        /// <example>
        /// <code>
        /// // Component initialization
        /// void Start()
        /// {
        ///     if (renderer.IsInvalid())
        ///     {
        ///         renderer = gameObject.AddComponent&lt;MeshRenderer&gt;();
        ///     }
        /// }
        ///   
        /// // Reference validation
        /// void ValidateReferences()
        /// {
        ///     if (audioListener.IsInvalid())
        ///     {
        ///         Debug.LogWarning("Missing AudioListener component");
        ///     }
        /// }
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInvalid([CanBeNull] this Component source) => source == null || source.Equals(null);

        #endregion

        #region IfInvalid -- Object(fallback)

        /// <summary>
        /// Executes an action if the Unity Object is invalid (null or destroyed).
        /// </summary>
        /// <param name="source">The Unity Object to check.</param>
        /// <param name="action">Action to execute if the object is invalid.</param>
        /// <typeparam name="T">Type of Unity Object.</typeparam>
        /// <example>
        /// <code>
        /// // Log warning when target is lost
        /// target.IfInvalid(() => Debug.LogWarning("Target lost"));
        ///   
        /// // Cleanup and reinitialize when reference becomes invalid
        /// playerReference.IfInvalid(() => {
        ///     CleanupPlayerSystems();
        ///     InitializeNewPlayer();
        /// });
        ///   
        /// // Chain multiple validations
        /// transform
        ///     .IfInvalid(() => Debug.LogError("Transform invalid"))
        ///     .IfValid(t => t.position = Vector3.zero);
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfInvalid<T>([CanBeNull] this T source, [CanBeNull] Action action) where T : Object
        {
            if (source.IsInvalid()) action?.Invoke();
        }

        /// <summary>
        /// Executes an action with the invalid Unity Object as parameter.
        /// </summary>
        /// <param name="source">The Unity Object to check.</param>
        /// <param name="action">Action to execute with the invalid object as parameter.</param>
        /// <typeparam name="T">Type of Unity Object.</typeparam>
        /// <example>
        /// <code>
        /// // Cleanup with object reference
        /// playerRef.IfInvalid(p => {
        ///     Debug.LogWarning($"Player {p.name} became invalid");
        ///     RemoveFromRegistry(p);
        /// });
        ///   
        /// // Handle destroyed components
        /// healthComponent.IfInvalid(h => {
        ///     Debug.Log($"Health component on {h.gameObject.name} was destroyed");
        ///     SpawnHealthPickup(h.transform.position);
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfInvalid<T>([CanBeNull] this T source, [CanBeNull] Action<T> action) where T : Object
        {
            if (source.IsInvalid()) action?.Invoke(source);
        }

        /// <summary>
        /// Returns a fallback value if the Unity Object is invalid.
        /// </summary>
        /// <param name="source">The Unity Object to check.</param>
        /// <param name="action">Function to provide fallback value if the object is invalid.</param>
        /// <typeparam name="T">Type of Unity Object.</typeparam>
        /// <returns>The original object if valid, or the fallback value if invalid.</returns>
        /// <example>
        /// <code>
        /// // Get fallback target when current is invalid
        /// currentTarget = currentTarget.IfInvalid(() => FindNextTarget());
        ///   
        /// // Use default transform when main is invalid
        /// transform = mainTransform.IfInvalid(() => defaultTransform);
        ///   
        /// // Chain with other validation methods
        /// weapon = currentWeapon
        ///     .IfInvalid(() => weaponInventory.GetDefaultWeapon())
        ///     .IfValid(w => w.Initialize());
        /// </code>
        /// </example>
        /// <remarks>
        /// This method is particularly useful for:
        /// - Implementing fallback logic for destroyed objects
        /// - Maintaining valid object references in Update loops
        /// - Creating self-healing object references
        /// - Implementing graceful degradation of functionality
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T IfInvalid<T>([CanBeNull] this T source, [NotNull] Func<T> action) where T : Object => source.IsInvalid() ? action.Invoke() : source;

        #endregion

        #region IfInvalid -- GameObject

        /// <summary>
        /// Executes an action if the GameObject is invalid (null or destroyed).
        /// </summary>
        /// <param name="source">The GameObject to check.</param>
        /// <param name="action">Action to execute if the GameObject is invalid.</param>
        /// <example>
        /// <code>
        /// // Spawn new player when current is destroyed
        /// playerObject.IfInvalid(() => {
        ///     SpawnNewPlayer();
        ///     UpdatePlayerReferences();
        /// });
        ///   
        /// // Handle pooled object destruction
        /// pooledObject.IfInvalid(() => {
        ///     RemoveFromActivePool();
        ///     RequestNewPoolObject();
        /// });
        ///   
        /// // UI element validation
        /// buttonObject.IfInvalid(() => {
        ///     Debug.LogWarning("UI Button was destroyed");
        ///     RebuildUILayout();
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfInvalid([CanBeNull] this GameObject source, [CanBeNull] Action action)
        {
            if (source.IsInvalid()) action?.Invoke();
        }

        /// <summary>
        /// Executes an action with the invalid GameObject as parameter.
        /// </summary>
        /// <param name="source">The GameObject to check.</param>
        /// <param name="action">Action to execute with the invalid GameObject as parameter.</param>
        /// <example>
        /// <code>
        /// // Log destruction with object details
        /// enemyObject.IfInvalid(go => {
        ///     Debug.Log($"Enemy {go.name} at {go.transform.position} was destroyed");
        ///     UpdateEnemyCounter();
        /// });
        ///   
        /// // Cleanup scene references
        /// targetObject.IfInvalid(go => {
        ///     string objectPath = GetGameObjectPath(go);
        ///     Debug.LogWarning($"Object at {objectPath} was destroyed");
        ///     CleanupReferences(go);
        /// });
        ///   
        /// // Handle prefab instance destruction
        /// instanceObject.IfInvalid(go => {
        ///     RemoveInstanceFromRegistry(go);
        ///     NotifyInstanceDestroyed(go.scene);
        /// });
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfInvalid([CanBeNull] this GameObject source, [CanBeNull] Action<GameObject> action)
        {
            if (source.IsInvalid()) action?.Invoke(source);
        }

        /// <summary>
        /// Returns a fallback GameObject if the source is invalid.
        /// </summary>
        /// <param name="source">The GameObject to check.</param>
        /// <param name="action">Function to provide fallback GameObject if the source is invalid.</param>
        /// <returns>The original GameObject if valid, or the fallback GameObject if invalid.</returns>
        /// <example>
        /// <code>
        /// // Get fallback target with instantiation
        /// currentTarget = currentTarget.IfInvalid(() =>
        ///     Instantiate(targetPrefab, spawnPoint.position, Quaternion.identity));
        ///   
        /// // Use placeholder object when main is destroyed
        /// activeObject = mainObject.IfInvalid(() => placeholderObject);
        ///   
        /// // Chain with component access
        /// Transform transform = gameObject
        ///     .IfInvalid(() => fallbackObject)
        ///     .transform;
        /// </code>
        /// </example>
        /// <remarks>
        /// This method is particularly useful for:
        /// - Implementing object pooling systems
        /// - Handling destroyed prefab instances
        /// - Managing UI element references
        /// - Maintaining scene hierarchy integrity
        /// - Implementing fallback game mechanics
        ///  
        /// Performance considerations:
        /// - The fallback function is only called when needed (lazy evaluation)
        /// - Optimized with AggressiveInlining for minimal overhead
        /// - Safe to use in Update loops
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameObject IfInvalid([CanBeNull] this GameObject source, [NotNull] Func<GameObject> action) => source.IsInvalid() ? action.Invoke() : source;

        #endregion

        #region IfInvalid -- Component

        /// <summary>
        /// Executes an action if the Component is invalid (null or destroyed).
        /// </summary>
        /// <param name="source">The Component to check.</param>
        /// <param name="action">Action to execute if the Component is invalid.</param>
        /// <example>
        /// <code>
        /// // Handle destroyed health component
        /// healthComponent.IfInvalid(() => {
        ///     EnableInvulnerability();
        ///     StartHealthRegenerationTimer();
        /// });
        ///   
        /// // React to missing renderer
        /// renderer.IfInvalid(() => {
        ///     DisablePostProcessing();
        ///     NotifyRendererMissing();
        /// });
        ///   
        /// // Chain multiple component validations
        /// animator
        ///     .IfInvalid(() => EnableRagdoll())
        ///     .IfValid(a => a.SetTrigger("Respawn"));
        /// </code>
        /// </example>
        /// <remarks>
        /// Common use cases:
        /// - Component dependency validation
        /// - Fallback behavior implementation
        /// - Safe component access in Update/FixedUpdate
        /// - Component lifecycle management
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfInvalid([CanBeNull] this Component source, [CanBeNull] Action action)
        {
            if (!source.IsValid()) action?.Invoke();
        }

        /// <summary>
        /// Executes an action with the invalid Component as parameter.
        /// </summary>
        /// <param name="source">The Component to check.</param>
        /// <param name="action">Action to execute with the invalid Component as parameter.</param>
        /// <example>
        /// <code>
        /// // Log component destruction with context
        /// rigidbody.IfInvalid(rb => {
        ///     Debug.LogWarning($"Rigidbody on {rb.gameObject.name} was destroyed");
        ///     UpdatePhysicsSystem(rb.gameObject);
        /// });
        ///   
        /// // Handle script removal
        /// controller.IfInvalid(c => {
        ///     string objectPath = GetComponentPath(c);
        ///     Debug.Log($"Controller at {objectPath} was removed");
        ///     ResetControllerBindings(c.gameObject);
        /// });
        ///   
        /// // Cleanup component references
        /// audioSource.IfInvalid(audio => {
        ///     RemoveFromAudioManager(audio);
        ///     StopRelatedSoundEffects(audio.gameObject);
        /// });
        /// </code>
        /// </example>
        /// <remarks>
        /// Particularly useful for:
        /// - Debugging component lifecycle
        /// - Maintaining component registries
        /// - Handling component dependencies
        /// - Managing system state changes
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfInvalid([CanBeNull] this Component source, [CanBeNull] Action<Component> action)
        {
            if (!source.IsValid()) action?.Invoke(source);
        }

        /// <summary>
        /// Returns a fallback Component if the source is invalid.
        /// </summary>
        /// <param name="source">The Component to check.</param>
        /// <param name="action">Function to provide fallback Component if the source is invalid.</param>
        /// <returns>The original Component if valid, or the fallback Component if invalid.</returns>
        /// <example>
        /// <code>
        /// // Get backup camera when main is disabled
        /// activeCamera = mainCamera.IfInvalid(() =>
        ///     GetComponent&lt;Camera&gt;() ?? Camera.main);
        ///   
        /// // Use default transform for calculations
        /// targetTransform = moveTarget.transform.IfInvalid(() =>
        ///     defaultTarget.transform);
        ///   
        /// // Chain with type casting
        /// Rigidbody rb = physicsHandler
        ///     .IfInvalid(() => GetDefaultPhysicsHandler())
        ///     .GetComponent&lt;Rigidbody&gt;();
        /// </code>
        /// </example>
        /// <remarks>
        /// This method is particularly useful for:
        /// - Implementing component fallback systems
        /// - Handling missing or destroyed components
        /// - Managing component dependencies
        /// - Creating self-healing component references
        /// - Implementing graceful degradation
        ///  
        /// Best practices:
        /// - Keep fallback logic lightweight
        /// - Consider caching fallback components
        /// - Use type-specific versions when possible
        /// - Handle potential null returns from fallback
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Component IfInvalid([CanBeNull] this Component source, [NotNull] Func<Component> action) => source.IsInvalid() ? action.Invoke() : source;

        #endregion
    }
}