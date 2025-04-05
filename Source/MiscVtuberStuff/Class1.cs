using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using RimWorld.QuestGen;
using UnityEngine;
using Verse;

namespace MiscVtuberStuff
{
    [StaticConstructorOnStartup]
    public class HarmonyPatches
    {


        static HarmonyPatches()
        {
            new Harmony("vtuberstuff").PatchAll(Assembly.GetExecutingAssembly());
        }

        

    }
        public class CustomApperal : Apparel
    {

        private Graphic newGraphic;

        public override Color DrawColor => Color.white;

        private Graphic NewGraphic
        {
            get
            {
                if (newGraphic == null)
                {
                    if (def.graphicData == null)
                    {
                        return BaseContent.BadGraphic;
                    }
                    newGraphic = def.graphicData.Graphic;
                }
                return newGraphic;
            }
        }
        public override Graphic Graphic => NewGraphic;

    }

   

}
