using UnityEngine;

namespace DNFC_Redux_Library
{
    /// <summary>
    /// This class is intended for internal use by the REDUX project team, it contains references to all important Game objects and components in the game, as well as important game state information.
    /// </summary>
    public class SharedData
    {
        public SceneState SceneState { get; set; }

        // Private set — IsInitialized should only be controlled by SharedDataHandler.
        public bool IsInitialized { get; private set; }

        public Component SettingsManager { get; set; }
        public GameObject CharactersInUse { get; set; }
        public Component ProgressionCoordinator { get; set; }

        /// <summary>
        /// Marks the data as successfully initialized.
        /// Only callable from within the library assembly.
        /// </summary>
        internal void MarkInitialized()
        {
            IsInitialized = true;
        }
    }

    public enum SceneState
    {
        MainMenu,
        Loading,
        InGame,
    }
}