using MelonLoader;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace DNFC_Redux_Library
{
    /// <summary>
    /// Main MelonMod entry point for the DNFC Redux Library.
    /// There should be exactly one MelonMod subclass in this assembly.
    /// </summary>
    public class CoreLib : MelonMod
    {
        public static Util Utility { get; private set; }

        /// <summary>
        /// Whether Developer Mode is currently active.
        /// Toggle with Ctrl+Shift+D. Off by default.
        /// </summary>
        public static bool DeveloperMode { get; private set; } = false;

        private static SharedDataHandler _gameState;

        public override void OnEarlyInitializeMelon()
        {
            Utility = new Util();
            _gameState = new SharedDataHandler();

            MelonLogger.Msg(@"
            ___  _  _ ___ ___   ___        _            _    _ _                      
            |   \| \| | __/ __| | _ \___ __| |_  ___ __ | |  (_) |__ _ _ __ _ _ _ _  _ 
            | |) | .` | _| (__  |   / -_) _` | || \ \ / | |__| | '_ \ '_/ _` | '_| || |
            |___/|_|\_|_| \___| |_|_\___\__,_|\_,_/_\_\ |____|_|_.__/_| \__,_|_|  \_, |
                                                                                |__/ 
            From everyone at the DNFC Redux Project, we hope you enjoy 
            this mod and the work we've put into it. If you have any questions, 
            suggestions, or want to contribute, feel free to join our Discord server!");
        }

        public override void OnUpdate()
        {
            // Enable Developer Mode
            if (Keyboard.current.ctrlKey.isPressed 
                && Keyboard.current.shiftKey.isPressed 
                && Keyboard.current.dKey.wasPressedThisFrame)
            {
                DeveloperMode = !DeveloperMode;
                MelonLogger.Msg($"CoreLib: Developer Mode {(DeveloperMode ? "enabled" : "disabled")}.");
            }
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            switch (sceneName)
            {
                case "MainMenu":
                    _gameState.Data.SceneState = SceneState.MainMenu;
                    break;

                case "Loading":
                    _gameState.Data.SceneState = SceneState.Loading;
                    break;

                case "CityGameplay":
                    _gameState.AttemptInit();
                    _gameState.Data.SceneState = SceneState.InGame;
                    break;

                default:
                    MelonLogger.Msg($"Could not recognize scene: {sceneName}");
                    break;
            }

            MelonLogger.Msg($"Scene loaded: {sceneName}, state: {_gameState.Data.SceneState}");
        }

        /// <summary>
        /// Returns the current scene state.
        /// Mods can use this to check whether the player is in game, the main menu, etc.
        /// </summary>
        public static SceneState GetSceneState()
        {
            return _gameState.Data.SceneState;
        }

        /// <summary>
        /// Result of a <see cref="CoreLib.RequestReturnToMainMenu"/> call.
        /// </summary>
        public enum ReturnToMainMenuResult
        {
            /// <summary>The transition to the main menu was initiated immediately.</summary>
            Success,

            /// <summary>The player had unsaved progress. A warning dialog has been shown.</summary>
            UnsavedProgress,

            /// <summary>The request was made outside of a gameplay scene and was ignored.</summary>
            NotInGame,
        }
    }
}