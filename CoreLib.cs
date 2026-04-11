using MelonLoader;

namespace DNFC_Redux_Library
{
    /// <summary>
    /// Main MelonMod entry point for the DNFC Redux Library.
    /// There should be exactly one MelonMod subclass in this assembly.
    /// </summary>
    public class CoreLib : MelonMod
    {
        public static Util Utility { get; private set; }
        private SharedDataHandler _gameState;

        public override void OnEarlyInitializeMelon()
        {
            // Safe place to construct objects that don't require the scene to be loaded.
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
    suggestions, or want to contribute, feel free to join our Discord server!
");
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
                    // AttemptInit first — only mark initialized if it succeeds.
                    _gameState.AttemptInit();
                    _gameState.Data.SceneState = SceneState.InGame;
                    break;

                default:
                    MelonLogger.Msg($"Could not recognize scene: {sceneName}");
                    break;
            }

            MelonLogger.Msg($"Scene loaded: {sceneName}, state: {_gameState.Data.SceneState}");
        }
    }
}