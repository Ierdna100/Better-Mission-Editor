using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BetterMissionEditor;

class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public void Start()
    {
        instance = this;
    }

    public void OnReloadMissionFile(ScenarioEditorToolbar __instance)
    {
        Logger.LogPretty("Reloading mission file!");
        VTResources.ReloadCustomScenario(__instance.editor.currentScenario.scenarioID, __instance.editor.currentScenario.campaignID);
        __instance.editor.LoadScenario(VTResources.GetCustomScenario(__instance.editor.currentScenario.scenarioID, VTScenarioEditor.currentCampaign));
        __instance.editor.popupMessages.DisplayMessage("Reloaded scenario", 3f, Color.white);
    }

    public void OnReloadMissionsInMemory(ScenarioEditorToolbar __instance)
    {
        Logger.LogPretty("Reloading all missions in memory!");
        VTResources.LoadCustomScenarios(false);
        __instance.editor.popupMessages.DisplayMessage("Reloaded all scenarios", 3f, Color.white);
    }

    public void LoadExtraScenarioEditorMenusFromAssetBundle()
    {
        Logger.LogPretty("GOT HERE");
        GameObject controlShortcutsMenuRef = Main.assetBundle.LoadAsset<GameObject>("assets/prefabs/bme shortcuts.prefab");
        Logger.LogPretty(controlShortcutsMenuRef.ToString());
        var controlShortcutsMenu = Instantiate(controlShortcutsMenuRef);
        Logger.LogPretty(controlShortcutsMenu.ToString());

        VTScenarioEditor scenarioEditor = GetComponent<VTScenarioEditor>();
        Logger.LogPretty(scenarioEditor.ToString());
        controlShortcutsMenu.transform.parent = scenarioEditor.controlsWindow.transform;
    }
}
