using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using DeathAnnounce.Patches;

namespace DeathAnnounce
{
    [BepInPlugin("DeathAnnounce", "WolfenGamesMods", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("DeathAnnounce");

        private static Plugin PluginInstance;

        internal static ManualLogSource Log;

        public static Plugin GetInstance()
        {
            return PluginInstance;
        }

        void Awake()
        {
            if (PluginInstance == null)
            {
                PluginInstance = this;
            }

            Log = BepInEx.Logging.Logger.CreateLogSource("DeathAnnounce");

            Log.LogInfo("WolfenGamesMods <DeathAnnounce> loaded");

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
