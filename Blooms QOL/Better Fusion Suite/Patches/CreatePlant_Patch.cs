using Il2Cpp;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace Blooms_QOL.Better_Fusion_Suite.Patches
{
    [HarmonyPatch(typeof(CreatePlant))]
    public static class CreatePlant_Patch
    {
        [HarmonyPatch(nameof(CreatePlant.CheckMix))]
        [HarmonyPrefix]
        public static bool Pre_CheckMix(CreatePlant __instance, ref int theColumn, ref int theRow, ref PlantType theUsedType, ref Plant __result)
        {
            if(Input.GetKey(KeyCode.LeftAlt))
            {
                Il2CppSystem.Collections.Generic.List<Plant> gridPlants = Lawnf.Get1x1Plants(theColumn, theRow);
                if (gridPlants != null)
                {
                    foreach (Plant plant in gridPlants)
                    {
                        if (Core.IsPotPlant(plant))
                        {
                            PlantType fusionType = Core.GetMixData(plant.thePlantType, theUsedType);
                            
                            if (fusionType != PlantType.Peashooter)
                            {
                                if (!__instance.Lim(fusionType) && !__instance.LimTravel(fusionType))
                                {
                                    plant.Die(reason: Plant.DieReason.ByMix); 
                                    __result = __instance.SetPlant(theColumn, theRow, fusionType, withEffect: true);
                                    __instance.MixEvent(theUsedType, __result.GetComponent<Plant>(), theRow);
                                    Plant resultPlant = __result.GetComponent<Plant>();
                                    CreateItem.Instance.SetCoin(theColumn, theRow, 0, 0);
                                    Core.CustomEvents(resultPlant);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Il2CppSystem.Collections.Generic.List<Plant> gridPlants = Lawnf.Get1x1Plants(theColumn, theRow);
                if (gridPlants != null)
                {
                    foreach (Plant plant in gridPlants)
                    {
                        if (Core.IsPumpkinPlant(plant))
                        {
                            PlantType fusionType = Core.GetMixData(plant.thePlantType, theUsedType);

                            if (fusionType != PlantType.Peashooter)
                            {
                                if (!__instance.Lim(fusionType) && !__instance.LimTravel(fusionType))
                                {
                                    bool ifvStarException = false;

                                    if (fusionType == PlantType.IFVPumpkin && plant.thePlantType == PlantType.IFVPumpkin)
                                    {
                                        if(plant.gameObject.TryGetComponent(out IFVPumpkin ifvPumpkin))
                                        {
                                            ifvStarException = true;
                                            ifvPumpkin.temp = ifvStarException;
                                        }
                                    }

                                    plant.Die(reason: Plant.DieReason.ByMix);
                                    __result = __instance.SetPlant(theColumn, theRow, fusionType, withEffect: true);
                                    __instance.MixEvent(theUsedType, __result.GetComponent<Plant>(), theRow);
                                    Plant resultPlant = __result.GetComponent<Plant>();
                                    Core.CustomEvents(resultPlant);
                                    if (ifvStarException)
                                    {
                                        resultPlant.Die();
                                    }
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        [HarmonyPatch(nameof(CreatePlant.CheckBox))]
        [HarmonyPrefix]
        public static bool Pre_CheckBox(CreatePlant __instance, ref int theBoxColumn, ref int theBoxRow, ref PlantType theSeedType, ref bool __result)
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Il2CppSystem.Collections.Generic.List<Plant> gridPlants = Lawnf.Get1x1Plants(theBoxColumn, theBoxRow);
                if (gridPlants != null)
                {
                    foreach (Plant plant in gridPlants)
                    {
                        if (Core.IsPotPlant(plant))
                        {
                            PlantType fusionType = Core.GetMixData(plant.thePlantType, theSeedType);
                            if (fusionType != PlantType.Peashooter)
                            {
                                __result = false;
                                return false;
                            }
                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Il2CppSystem.Collections.Generic.List<Plant> gridPlants = Lawnf.Get1x1Plants(theBoxColumn, theBoxRow);
                if (gridPlants != null)
                {
                    foreach (Plant plant in gridPlants)
                    {
                        if (Core.IsPumpkinPlant(plant))
                        {
                            PlantType fusionType = Core.GetMixData(plant.thePlantType, theSeedType);
                            if (fusionType != PlantType.Peashooter)
                            {
                                __result = false;
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
