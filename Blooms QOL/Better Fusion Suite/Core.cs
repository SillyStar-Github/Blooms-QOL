using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Blooms_QOL.Better_Fusion_Suite
{
    public class Core
    {
        public static PlantType GetMixData(PlantType firstPlant, PlantType secondPlant)
        {
            PlantType fusionPlant = PlantType.Nothing;

            var mixData = MixData._recipes;
            MixData.TryGetMix(firstPlant, secondPlant, out PlantType firstResult);
            MixData.TryGetMix(firstPlant, secondPlant, out PlantType secondResult);
            List<PlantType> plantTypes = new List<PlantType>() { firstResult, secondResult };
            fusionPlant = plantTypes[0] != PlantType.Peashooter ? plantTypes[0] : plantTypes[1];

            return fusionPlant;
        }

        public static void CustomEvents(Plant plant)
        {
            PlantType thePlantType = plant.thePlantType;
            int theColumn = plant.thePlantColumn;
            int theRow = plant.thePlantRow;

            switch(thePlantType)
            {
                case PlantType.MelonPot:
                    CreateItem.Instance.SetCoin(theColumn, theRow, 0, 0);
                    CreateItem.Instance.SetCoin(theColumn, theRow, 0, 0);
                    CreateItem.Instance.SetCoin(theColumn, theRow, 0, 0);
                    CreateItem.Instance.SetCoin(theColumn, theRow, 0, 0);
                    CreateItem.Instance.SetCoin(theColumn, theRow, 0, 0);
                    CreateItem.Instance.SetCoin(theColumn, theRow, 0, 0);
                    break;
                default:
                    break;
            }
        }

        public static bool IsPotPlant(Plant plant) => TypeMgr.IsPot(plant.thePlantType);
        public static bool IsPumpkinPlant(Plant plant) => TypeMgr.IsPumpkin(plant.thePlantType);
    }

    [RegisterTypeInIl2Cpp]
    public class PreventRecover : MonoBehaviour { }
}
