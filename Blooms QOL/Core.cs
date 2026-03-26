using MelonLoader;

[assembly: MelonInfo(typeof(Blooms_QOL.Core), "Blooms QOL", "1.0.0", "cassidy", null)]
[assembly: MelonGame("LanPiaoPiao", "PlantsVsZombiesRH")]

namespace Blooms_QOL
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Persistent_HP_Toggle.Core.Main();
        }
    }
}