using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Harmony;

[HarmonyPatch(typeof(ScenarioEditorToolbar))]
[HarmonyPatch("OnSetupToolbar")]
class Patch_ScenarioEditorToolbar
{
    public static bool Prefix(ScenarioEditorToolbar __instance)
    {
        __instance.AddToolbarFunction(
            "Better Mission Editor/Reload All Scenarios From Disk",
            () => UIManager.instance.OnReloadMissionsInMemory(__instance), 
            new KeyCombo(KeyCode.LeftAlt, KeyCode.F));
        __instance.AddToolbarFunction(
            "Better Mission Editor/Reload Current Scenario From Disk", 
            () => UIManager.instance.OnReloadMissionFile(__instance), 
            new KeyCombo(KeyCode.LeftControl, KeyCode.F));
        return true;
    }
}
