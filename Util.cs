using System;
using MelonLoader;
using UnityEngine;

namespace DNFC_Redux_Library
{
    /// <summary>
    /// Utility class for basic utilities like fetching components and GameObjects.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Attempts to fetch a component by name from a named GameObject in the hierarchy.
        /// </summary>
        /// <param name="gameObjectName">Name of the GameObject to search for.</param>
        /// <param name="componentName">Name of the component to get.</param>
        /// <param name="component">When this method returns, contains the component or <c>null</c> if not found.</param>
        /// <returns><c>true</c> if the component was found; otherwise <c>false</c>.</returns>
        internal bool TryFetchComponentFromGameObj(string gameObjectName, string componentName, out Component component)
        {
            component = null;
            try
            {
                MelonLogger.Msg($"Attempting to find GameObject '{gameObjectName}'...");
                GameObject gameObject = GameObject.Find(gameObjectName);
                if (gameObject == null)
                {
                    MelonLogger.Msg($"No GameObject with name '{gameObjectName}' was found.");
                    return false;
                }

                MelonLogger.Msg($"Found GameObject '{gameObjectName}'. Searching for component '{componentName}'...");
                component = gameObject.GetComponent(componentName);
                if (component == null)
                {
                    MelonLogger.Msg($"No component '{componentName}' found on '{gameObjectName}'.");
                    return false;
                }

                MelonLogger.Msg($"Found component '{componentName}' on '{gameObjectName}'.");
                return true; // Fixed: was incorrectly returning false on success.
            }
            catch (Exception ex)
            {
                MelonLogger.Msg($"Error fetching component '{componentName}' on '{gameObjectName}': {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Attempts to find a GameObject by name in the scene hierarchy.
        /// </summary>
        /// <param name="gameObjectName">Name of the GameObject to find.</param>
        /// <param name="gameObject">When this method returns, contains the found GameObject, or <c>null</c> if not found.</param>
        /// <returns><c>true</c> if the GameObject was found; otherwise <c>false</c>.</returns>
        public bool TryFetchGameObjectFromHierarchy(string gameObjectName, out GameObject gameObject)
        {
            gameObject = GameObject.Find(gameObjectName);
            if (gameObject == null)
            {
                MelonLogger.Msg($"No GameObject with name '{gameObjectName}' was found.");
                return false;
            }

            MelonLogger.Msg($"Found GameObject '{gameObjectName}'.");
            return true;
        }
    }
}