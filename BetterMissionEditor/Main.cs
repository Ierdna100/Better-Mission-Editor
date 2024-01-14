using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Harmony;

namespace BetterMissionEditor
{
    public class Main : VTOLMOD
    {
        public static AssetBundle assetBundle;

        public override void ModLoaded()
        {
            AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(ModFolder, "bettermissioneditor"));
            if (assetBundle == null)
            {
                Logger.LogPretty("Assetbundle was null!");
                return;
            }
            Main.assetBundle = assetBundle;
            Logger.LogPretty("Asset bundle contains:");
            foreach (string assetName in assetBundle.GetAllAssetNames())
            {
                Logger.LogPretty(assetName);
            }

            VTOLAPI.SceneLoaded += SceneLoaded;

            GameObject UIManager = new GameObject("UI Manager", typeof(UIManager));
            DontDestroyOnLoad(UIManager);

            HarmonyInstance harmony = HarmonyInstance.Create("ierdna100.bettermissioneditor");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            base.ModLoaded();
        }

        private void SceneLoaded(VTOLScenes scene)
        {
            switch(scene)
            {
                case VTOLScenes.CustomMapBase:
                    UIManager.instance.LoadExtraScenarioEditorMenusFromAssetBundle();
                    break;
                case VTOLScenes.VTEditMenu:
                    break;
            }
        }
    }
}
