using Il2Cpp;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace Blooms_QOL.Better_Fusion_Suite.Patches
{
    [HarmonyPatch(typeof(Plant))]
    public static class Plant_Patch
    {
        [HarmonyPatch(nameof(Plant.Recover))]
        [HarmonyPrefix]
        public static bool Pre_Recover(Plant __instance)
        {
            if((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftShift)) && __instance.thePlantType == PlantType.SuperMachineNut)
            {
                if(__instance.TryGetComponent<PreventRecover>(out PreventRecover preventRecover))
                {
                    UnityEngine.Object.Destroy(preventRecover);
                    return false;
                }
            }

            return true;
        }
    }
}
