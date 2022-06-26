using UnboundLib;
using UnboundLib.Cards;
using BepInEx;
using HarmonyLib;
using CoolCards.Cards;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace MyModNameSpace
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class CoolCards : BaseUnityPlugin
    {
        public static CoolCards instance { get; private set; }
        private const string ModId = "CoolCards";
        private const string ModName = "CoolCards";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "CC";
        


        void Awake()
        {

            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
            
        }
        void Start()
        {
            CustomCard.BuildCard<SuperMan>();
            instance = this;
        }
    }
}
