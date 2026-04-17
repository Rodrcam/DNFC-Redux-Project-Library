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

        public GameObject PlotsContainer { get; set; }
        public GameObject UICanvas { get; set; }
        public GameObject CharactersInUse { get; set; }
        public GameObject VehiclesInUse { get; set; }
        public Component SettingsManager { get; set; }
        public Component FireManager { get; set; }
        public Component BalancingData { get; set; }
        public Component FacilityManager { get; set; }
        public Component TimeManager { get; set; }
        public Component PlayerTier { get; set; }
        public Component DialogueData { get; set; }
        public Component StoryManager { get; set; }
        public Component EndGameManager { get; set; }
        public Component SpecialClientsCoordinator { get; set; }
        public Component ProgressionClientsCoordinator { get; set; }
        public Component MonetaryCycle { get; set; }

        public static Component BankManager { get; set; }

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