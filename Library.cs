using MelonLoader;
using UnityEngine;
using HarmonyLib;

namespace DNFC_Redux_Library
{
    public class SharedData
    {
        public static bool IsInGame { get; set; }
        public static bool IsInLoading { get; set; }
        public static bool IsInMainMenu { get; set; }
        public static bool IsInitialized { get; set; }
        public static Component SettingsManager { get; set; }
        public static int CustomEmployeesPerSlot { get; set; } = 2;
    }
    public static class EmployeeSettings
    {
        public static void ChangeEmployeePerSlot(int x)
        {
            SharedData.CustomEmployeesPerSlot = x;
            MelonLogger.Msg($"Library: Employees per slot updated to {x}");
        }
        [HarmonyPatch("Plot_CompoundAddition", "get_CompoundEmployeesGrantedOnPurchase")]
        public static class EmployeesPatch
        {
            [HarmonyPostfix]
            public static void Postfix(ref int __result)
            {
                __result = SharedData.CustomEmployeesPerSlot;
            }
        }
    }
    public class Library : MelonMod
    {
        public override void OnEarlyInitializeMelon()
        {
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
        public bool IsInGame()
        {
            return SharedData.IsInGame;
        }
        public bool SetIsInGame(bool inGame)
        {
            SharedData.IsInGame = inGame;
            return SharedData.IsInGame;
        }
        public bool IsInLoading()
        {
            return SharedData.IsInLoading;
        }
        public bool SetIsInLoading(bool inLoading)
        {
            SharedData.IsInLoading = inLoading;
            return SharedData.IsInLoading;
        }
        public bool IsInMainMenu()
        {
            return SharedData.IsInMainMenu;
        }
        public bool SetIsInMainMenu(bool inMainMenu)
        {
            SharedData.IsInMainMenu = inMainMenu;
            return SharedData.IsInMainMenu;
        }
        public bool IsInitialized()
        {
            return SharedData.IsInitialized;
        }
        public void SetInitialized(bool initialized)
        {
            SharedData.IsInitialized = initialized;
        }
        public void FindSettingsManagerComponent()
        {
            try
            {
                MelonLogger.Msg("Attempting to find SettingsManager GameObject...");
                Component settingsManager = GameObject.Find("SettingsManager")?.GetComponent("SettingsManager");
                MelonLogger.Msg("SettingsManager GameObject found: " + (settingsManager != null));
                SharedData.SettingsManager = settingsManager;
            }
            catch
            {
                MelonLogger.Msg("Error finding SettingsManager GameObject.");
            }
        }
        public Component GetSettingsManagerComponent()
        {
            if (SharedData.SettingsManager != null)
            {
                return SharedData.SettingsManager;
            }
            else
            {
                MelonLogger.Msg("GetSettingsManager: SettingsManager GameObject is not set.");
                return null;
            }
        }
        public bool GetActiveInHierarchy(GameObject obj)
        {
            if (obj != null)
            {
                return obj.activeInHierarchy;
            }
            else
            {
                MelonLogger.Msg("GetActive: Provided GameObject is null.");
                return false;
            }
        }
    }
}
        }
    }
}


