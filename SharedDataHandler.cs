using System;
using System.Collections.Generic;
using UnityEngine;

namespace DNFC_Redux_Library
{
    public class SharedDataHandler
    {
        private readonly Util _utility = CoreLib.Utility;

        // Data is initialized here so it is never null.
        public SharedData Data { get; private set; } = new SharedData();

        public SharedDataHandler()
        {
            // Data object is initialized via property initializer above.
            // Add any other constructor logic here if needed.
        }

        /// <summary>
        /// Attempts to find and cache all required game objects and components.
        /// Should only be called once the gameplay scene is fully loaded.
        /// </summary>
        internal void AttemptInit()
        {
            InitFetchSharedData();

            // Only mark initialized if the critical references were found.
            if (Data.SettingsManager != null && Data.CharactersInUse != null)
            {
                Data.MarkInitialized();
                _utility.LogMessage("SharedDataHandler: Initialization successful.");
            }
            else
            {
                _utility.LogMessage("SharedDataHandler: Initialization incomplete — one or more required references were not found.");
            }
        }

        /// <summary>
        /// Initialize all shared data
        /// </summary>
        private void InitFetchSharedData()
        {
            // A single source to initialize each of the shared data variables.
            // ( "GameObject Name" "Component Name", Type, Setter Action )
            var sharedDataContract = new List<(string gameObject, string component, Type expectedType, Action<object> setter)>{
                ( "PlotsContainer", "", typeof(GameObject), val => Data.PlotsContainer = (GameObject)val),
                ( "UI_Gameplay/Canvas", "", typeof(GameObject), val => Data.UICanvas = (GameObject)val),
                ( "CharactersInUse", "", typeof(GameObject),val => Data.CharactersInUse = (GameObject)val),
                ( "VehiclesInUse", "", typeof(GameObject),val => Data.VehiclesInUse = (GameObject)val),
                ( "SettingsManager", "SettingsManager", typeof(Component), val => Data.SettingsManager = (Component)val ),
                ( "Managers", "BalancingData", typeof(Component), val => Data.BalancingData = (Component)val),
                ( "Managers", "FacilityManager", typeof(Component), val => Data.FacilityManager = (Component)val ),
                ( "Managers", "TimeManager", typeof(Component), val => Data.TimeManager = (Component)val),
                ( "Managers", "PlayerTier", typeof(Component), val => Data.PlayerTier = (Component)val),
                ( "Managers", "DialogueData", typeof(Component), val => Data.DialogueData = (Component)val),
                ( "Managers", "StoryManager", typeof(Component), val => Data.StoryManager = (Component)val),
                ( "Managers", "EndGameManager", typeof(Component), val => Data.EndGameManager = (Component)val),
                ( "Managers", "SpecialClientsCoordinator", typeof(Component), val => Data.SpecialClientsCoordinator = (Component)val ),
                ( "Managers", "ProgressionClientsCoordinator", typeof(Component), val => Data.ProgressionClientsCoordinator = (Component)val ),
                ( "Managers", "MonetaryCycle", typeof(Component), val => Data.MonetaryCycle = (Component)val)
            };

            foreach (var (gameObject, component, expectedType, setter) in sharedDataContract)
            {
                try
                {
                    FetchSharedDataObject(gameObject, component, expectedType, setter);
                }
                catch (Exception e)
                {
                    _utility.LogError($"Error fetching {gameObject} {component}", e);
                }
            }
        }

        /// <summary>
        /// Fetches the specified game object or component and sets the shared data value.
        /// </summary>
        /// <param name="gameObjectName">Game Object name</param>
        /// <param name="componentName">Component name</param>
        /// <param name="expectedType">Type of the data value object</param>
        /// <param name="setter">Action delegate to set the data value</param>
        private void FetchSharedDataObject(string gameObjectName, string componentName, Type expectedType, Action<object> setter)
        {
            _utility.LogMessage($"Fetching {gameObjectName} {componentName} for {expectedType.Name}");

            if (expectedType == typeof(GameObject))
            {
                if (_utility.TryFetchGameObjectFromHierarchy(gameObjectName, out GameObject gameObj))
                {
                    setter(gameObj);
                }
            }
            else if (typeof(Component).IsAssignableFrom(expectedType))
            {
                if (_utility.TryFetchComponentFromGameObj(gameObjectName, componentName, out Component component))
                {
                    setter(component);
                }
            }
        }
    }
}