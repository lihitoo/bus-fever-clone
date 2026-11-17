using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using Dreamy.Template.Gameplay;

namespace Dreamy.Template.Editor
{
    public static class LevelCatalogAuthoring
    {
        public static string BindColors()
        {
            var paths = ((JArray)JObject.Parse(System.IO.File.ReadAllText("docs/clone-plan/evidence/M02/level2-assets.json"))["assets"])
                .Select(x => (string)x["target"]).Where(p => p.EndsWith(".mat")).Distinct()
                .Where(p => AssetDatabase.LoadAssetAtPath<Material>(p).shader.name == "Hidden/InternalErrorShader").ToArray();
            RecoveredAssetMigration.MigrateMaterials(paths);
            const string path = "Assets/_Project/Prefabs/Panel/GameplayPanel.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try
            {
                var serialized = new SerializedObject(root.GetComponent<GameplayPanel>());
                var prefabs = serialized.FindProperty("passengerPrefabs"); prefabs.arraySize=7;
                var materials = serialized.FindProperty("vehicleMaterials"); materials.arraySize=7;
                var colors = new[] { "blue","red","yellow","purple","orange","pink","green" };
                for(int i=3;i<colors.Length;i++)
                {
                    prefabs.GetArrayElementAtIndex(i).objectReferenceValue = AssetDatabase.LoadAssetAtPath<GameObject>(RecoveredAssetMigration.Root+"/busjam/game/bundleables/busandpassenger/passenger_"+colors[i]+".prefab");
                    materials.GetArrayElementAtIndex(i).objectReferenceValue = AssetDatabase.LoadAssetAtPath<Material>(RecoveredAssetMigration.Root+"/Material/Car_"+colors[i]+"_new.mat");
                }
                serialized.ApplyModifiedPropertiesWithoutUndo(); PrefabUtility.SaveAsPrefabAsset(root,path);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
            return "Seven source color variants bound for Level1/2.";
        }
    }
}
