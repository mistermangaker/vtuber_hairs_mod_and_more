using RimWorld;
using RimWorld.QuestGen;
using System.Collections.Generic;
using Verse;

namespace MiscVtuberStuff
{
    public class QuestNode_CubeReturned : QuestNode
    {
        private static readonly IntRange MaxDelayTicksRange = new IntRange(6000, 18000);

    
        protected override bool TestRunInt(Slate slate)
        {
            return true;
        }

        protected override void RunInt()
        {
            //Log.Message("Yep");
            Quest quest = QuestGen.quest;
            Slate slate = QuestGen.slate;

            if (!slate.TryGet<Map>("map", out Map map))
            {
                map = QuestGen_Get.GetMap(mustBeInfestable: false, null, false);
            }
    
            string completeSignal = QuestGen.GenerateNewSignal("DelayCompleted");
           // quest.SignalPass(null, null, completeSignal);
            quest.Delay(MaxDelayTicksRange.RandomInRange, delegate
            {
                quest.SignalPass(null, null, completeSignal);
            }, null, null, null, reactivatable: false, null, null, isQuestTimeout: false, null, null, null, tickHistorically: false, QuestPart.SignalListenMode.Always, waitUntilPlayerHasHomeMap: true).debugLabel = "Arrival delay";

            Thing thing = ThingMaker.MakeThing(ThingDefOf.GoldenCube);
            thing.stackCount = 1;
            List<Thing> contents = new List<Thing> { thing };
         
            quest.DropPods(map.Parent, contents, null, null, null, null, false, useTradeDropSpot: false, joinPlayer: false, makePrisoners: false, completeSignal, null, QuestPart.SignalListenMode.OngoingOnly, null, destroyItemsOnCleanup: true, dropAllInSamePod: true);
            quest.Letter(LetterDefOf.NegativeEvent, completeSignal, null, null, null, useColonistsFromCaravanArg: false, QuestPart.SignalListenMode.Always, null, filterDeadPawnsFromLookTargets: false, "[retaliationLetterText]", null, "[retaliationLetterLabel]");
           
           
            quest.End(QuestEndOutcome.Unknown, 0, null, completeSignal);
      
        }

    }
}
