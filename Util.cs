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
                LogMessage($"Attempting to find GameObject '{gameObjectName}'...");
                GameObject gameObject = GameObject.Find(gameObjectName);
                if (gameObject == null)
                {
                    LogWarning($"No GameObject with name '{gameObjectName}' was found.");
                    return false;
                }

                LogMessage($"Found GameObject '{gameObjectName}'. Searching for component '{componentName}'...");
                component = gameObject.GetComponent(componentName);
                
                if (component == null)
                {
                    LogWarning($"No component '{componentName}' found on '{gameObjectName}'.");
                    return false;
                }

                LogMessage($"Found component '{componentName}' on '{gameObjectName}'.");
                return true;
            }
            catch (Exception ex)
            {
                LogError($"Error fetching component '{componentName}' on '{gameObjectName}': {ex.Message}", ex);
                return false;
            }
        }

        /// <summary>
        /// Attempts to find a GameObject by name in the scene hierarchy.
        /// </summary>
        /// <param name="gameObjectName">Name of the GameObject to find.</param>
        /// <param name="gameObject">When this method returns, contains the found GameObject, or <c>null</c> if not found.</param>
        /// <returns><c>true</c> if the GameObject was found; otherwise <c>false</c>.</returns>
        internal bool TryFetchGameObjectFromHierarchy(string gameObjectName, out GameObject gameObject)
        {
            try
            {
                LogMessage($"Attempting to find GameObject '{gameObjectName}'...");

                gameObject = GameObject.Find(gameObjectName);
                if (gameObject == null)
                {
                    LogWarning($"No GameObject with name '{gameObjectName}' was found.");
                    return false;
                }

                LogMessage($"Found GameObject '{gameObjectName}'.");
                return true;
            }catch(Exception ex)
            {
                LogError($"Error fetching Game Object '{gameObjectName}': {ex.Message}", ex);
                gameObject = null;
                return false;
            }
        }

        /// <summary>
        /// Log a message
        /// </summary>
        /// <param name="message">Message to log</param>
        internal void LogMessage(string message)
        {
            MelonLogger.Msg(message);
        }
        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="message">Warning message to log</param>
        internal void LogWarning(string message)
        {
            MelonLogger.Warning(message);
        }
        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="message">Error message to log</param>
        internal void LogError(string message)
        {
            MelonLogger.Error(message);
        }
        /// <summary>
        /// Log an error message with an exception
        /// </summary>
        /// <param name="message">Error message to log</param>
        /// <param name="exception">Exception to log<seealso cref="Exception"/></param>
        internal void LogError(string message, Exception exception)
        {
            MelonLogger.Error(message, exception);
        }
    }
}