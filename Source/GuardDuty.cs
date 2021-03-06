﻿using System.Reflection;
using Harmony;
using UnityEngine;
using Verse;

namespace GuardDuty
{
    public class GuardDuty : Mod
    {
        public static bool BellOn = false;
        public static MyModSettings latest;
        private MyModSettings _settings;

        public GuardDuty(ModContentPack content) : base(content)
        {
            latest = this._settings = GetSettings<MyModSettings>();
            
            //Harmony Kickofff
            var harmony = HarmonyInstance.Create(typeof(GuardDuty).Assembly.FullName+"-harmony");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

        }

        public override string SettingsCategory() => "Guard Duty";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            var topHalf = inRect.TopHalf();
            var fourth = topHalf.TopHalf();
            var mySlice = fourth.TopHalf();
            
            
            Widgets.CheckboxLabeled(mySlice.RightHalf().ContractedBy(4f), "Auto Capture", ref _settings.autoCapture);
        }
    }
    
    public class MyModSettings : ModSettings
    {
        public bool autoCapture = true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref this.autoCapture, "autoCapture", true);
            
        }

       
    }
}