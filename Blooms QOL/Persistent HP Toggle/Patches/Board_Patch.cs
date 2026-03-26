using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms_QOL.Persistent_HP_Toggle.Patches
{
    [HarmonyPatch(typeof(Board))]
    public static class Board_Patch
    {
        [HarmonyPatch(nameof(Board.Start))]
        [HarmonyPostfix]
        public static void Post_Start(Board __instance) 
        {
            __instance.showPlantHealth = MelonPreferences.GetEntry<int>("BloomsQOL", "ShowPlantHP").Value - 1;
            __instance.showZombieHealth = !MelonPreferences.GetEntry<bool>("BloomsQOL", "ShowZombieHP").Value;

            __instance.ShowPlantHealth();
            __instance.ShowZombieHealth();
        }

        [HarmonyPatch(nameof(Board.ShowPlantHealth))]
        [HarmonyPostfix]
        public static void Post_ShowPlantHealth(Board __instance)
        {
            MelonPreferences.SetEntryValue<int>("BloomsQOL", "ShowPlantHP", __instance.showPlantHealth);
        }

        [HarmonyPatch(nameof(Board.ShowZombieHealth))]
        [HarmonyPostfix]
        public static void Post_ShowZombieHealth(Board __instance)
        {
            MelonPreferences.SetEntryValue<bool>("BloomsQOL", "ShowZombieHP", __instance.showZombieHealth);
        }
    }
}
