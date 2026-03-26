using Il2Cpp;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace Blooms_QOL.Better_Fusion_Suite.Patches
{
    [HarmonyPatch(typeof(SuperMachineNut))]
    public static class SuperMachineNut_Patch
    {
        [HarmonyPatch(nameof(SuperMachineNut.Summon))]
        [HarmonyPrefix]
        public static bool Pre_Summon(SuperMachineNut __instance)
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                int column = __instance.thePlantColumn;
                int row = __instance.thePlantRow;

                Il2CppSystem.Collections.Generic.List<Plant> gridPlants = Lawnf.Get1x1Plants(column, row);
                if (gridPlants != null)
                {
                    foreach (Plant plant in gridPlants)
                    {
                        if (plant.thePlantType == PlantType.Pot)
                        {
                            if (Mouse.Instance.thePlantTypeOnMouse == PlantType.WallNut)
                            {
                                CreatePlant.Instance.CheckMix(column, row, PlantType.WallNut);
                                __instance.gameObject.AddComponent<PreventRecover>();
                                return false;
                            }
                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                int column = __instance.thePlantColumn;
                int row = __instance.thePlantRow;

                Il2CppSystem.Collections.Generic.List<Plant> gridPlants = Lawnf.Get1x1Plants(column, row);
                if (gridPlants != null)
                {
                    foreach (Plant plant in gridPlants)
                    {
                        if (plant.thePlantType == PlantType.Pumpkin)
                        {
                            if (Mouse.Instance.thePlantTypeOnMouse == PlantType.WallNut)
                            {
                                CreatePlant.Instance.CheckMix(column, row, PlantType.WallNut);
                                __instance.gameObject.AddComponent<PreventRecover>();
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }
    }
}
