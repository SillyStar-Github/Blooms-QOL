using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassidy_QOL.Mods.SaveShowHP
{
    public class Core
    {
        public static void Main()
        {
            Config();
        }

        public static void Config()
        {
            MelonPreferences.CreateEntry<int>("CassidyQOL", "ShowPlantHP", 0);
            MelonPreferences.CreateEntry<bool>("CassidyQOL", "ShowZombieHP", false);
        }
    }
}
