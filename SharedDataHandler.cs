using MelonLoader;
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
            InitFetchComponents();
            InitFetchGameObjects();

            // Only mark initialized if the critical references were found.
            if (Data.SettingsManager != null && Data.CharactersInUse != null)
            {
                Data.MarkInitialized();
                MelonLogger.Msg("SharedDataHandler: Initialization successful.");
            }
            else
            {
                MelonLogger.Msg("SharedDataHandler: Initialization incomplete — one or more required references were not found.");
            }
        }

        private void InitFetchComponents()
        {
            FindSettingsManagerComponent();
            FindProgressionCoordinatorComponent();
        }

        private void InitFetchGameObjects()
        {
            FindCharactersInUse();
        }

        private void FindSettingsManagerComponent()
        {
            if (_utility.TryFetchComponentFromGameObj("SettingsManager", "SettingsManager", out Component component))
            {
                Data.SettingsManager = component;
            }
        }

        private void FindProgressionCoordinatorComponent()
        {
            if (_utility.TryFetchComponentFromGameObj("Managers", "ProgressionClientsCoordinator", out Component component))
            {
                Data.ProgressionCoordinator = component;
            }
        }

        private void FindCharactersInUse()
        {
            if (_utility.TryFetchGameObjectFromHierarchy("CharactersInUse", out GameObject gameObject))
            {
                Data.CharactersInUse = gameObject;
            }
        }
    }
}