using GameNetcodeStuff;
using HarmonyLib;

namespace DeathAnnounce.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("KillPlayer")]
        [HarmonyPostfix]
        private static void AnnounceDeath(PlayerControllerB __instance)
        {
            if (__instance.IsOwner && __instance.isPlayerDead)
            {
                string message = __instance.playerUsername + " has died to <color=#00ff00ff>" + __instance.causeOfDeath.ToString() + "</color>!";
                // Make the message red.
                message = "<color=#ff0000ff>" + message + "</color>";

                HUDManager.Instance.AddTextToChatOnServer(message);
            }
        }
    }
}
