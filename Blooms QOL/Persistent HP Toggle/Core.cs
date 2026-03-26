using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms_QOL.Persistent_HP_Toggle
{
    public class Core
    {
        public static void Main()
        {
            Config();
        }

        public static void Config()
        {
            MelonPreferences.CreateEntry<int>("BloomsQOL", "ShowPlantHP", 0);
            MelonPreferences.CreateEntry<bool>("BloomsQOL", "ShowZombieHP", false);
        }
    }
}
