using RimWorld;
using RimWorld.Planet;
using RimWorld.QuestGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MiscVtuberStuff
{
    [DefOf]
    public static class QuestScriptsDefOf
    {
       public static readonly QuestScriptDef CubeReturned;
    }
    public class CompDroppedGoldenCube : ThingComp
    {

        public override void Notify_AbandonedAtTile(PlanetTile tile)
        {
            QuestUtility.GenerateQuestAndMakeAvailable(QuestScriptsDefOf.CubeReturned, 999);
        }
    }

    public class CompProperties_CompDroppedGoldenCube : CompProperties
    {
        public CompProperties_CompDroppedGoldenCube()
        {
            compClass = typeof(CompDroppedGoldenCube);
        }
    }
}
