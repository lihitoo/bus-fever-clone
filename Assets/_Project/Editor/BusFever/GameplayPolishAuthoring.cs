using System.Reflection;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Dreamy.Template.Editor
{
    /// <summary>Rebuild only the affected derived art, preserving panel bindings and source exports.</summary>
    public static class GameplayPolishAuthoring
    {
        public static string Build()
        {
            var missing = AssetDatabase.FindAssets("t:Material", new[] { RecoveredAssetMigration.Root })
                .Select(AssetDatabase.GUIDToAssetPath)
                .Where(path => AssetDatabase.LoadAssetAtPath<Material>(path).shader.name == "Hidden/InternalErrorShader").ToArray();
            RecoveredAssetMigration.MigrateMaterials(missing);
            foreach (var guid in AssetDatabase.FindAssets("t:Material", new[] { RecoveredAssetMigration.Root + "/Material" }))
            {
                var slot = AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(guid));
                if (!slot.name.StartsWith("Car_P")) continue;
                slot.shader = Shader.Find("Universal Render Pipeline/Unlit");
                slot.SetFloat("_Surface", 1);
                slot.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
                slot.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                slot.SetFloat("_ZWrite", 0);
                slot.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
                slot.renderQueue = 3000;
                EditorUtility.SetDirty(slot);
                AssetDatabase.SaveAssetIfDirty(slot);
            }
            var material = AssetDatabase.LoadAssetAtPath<Material>(RecoveredAssetMigration.Root + "/Material/Idle_passenger.mat");
            material.shader = Shader.Find("Universal Render Pipeline/Simple Lit");
            material.DisableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.black);
            EditorUtility.SetDirty(material);
            AssetDatabase.SaveAssetIfDirty(material);
            // This source name describes shaded passenger bodies, not a projected shadow quad.
            var shadedBody = AssetDatabase.LoadAssetAtPath<Material>(RecoveredAssetMigration.Root + "/Material/Idle_passenger_strong_shadow.mat");
            shadedBody.shader = Shader.Find("Universal Render Pipeline/Simple Lit");
            shadedBody.SetFloat("_Surface",0); shadedBody.SetFloat("_SrcBlend",1); shadedBody.SetFloat("_DstBlend",0);
            shadedBody.SetFloat("_ZWrite",1); shadedBody.renderQueue=-1;
            shadedBody.DisableKeyword("_SURFACE_TYPE_TRANSPARENT");
            EditorUtility.SetDirty(shadedBody); AssetDatabase.SaveAssetIfDirty(shadedBody);
            typeof(M02Authoring).GetMethod("PrepareVehicle", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null);
            var pause = PrefabUtility.LoadPrefabContents(PauseSkinAuthoring.Path);
            try
            {
                var home = pause.GetComponentsInChildren<UnityEngine.UI.Button>(true).Single(button => button.name == "Btn_Yellow");
                home.gameObject.SetActive(true); home.interactable = true;
                var serialized = new SerializedObject(pause.GetComponent<Dreamy.Feature.Settings.Integration.SettingsPanel>());
                serialized.FindProperty("homeButton").objectReferenceValue = home;
                serialized.ApplyModifiedPropertiesWithoutUndo();
                PrefabUtility.SaveAsPrefabAsset(pause, PauseSkinAuthoring.Path);
            }
            finally { PrefabUtility.UnloadPrefabContents(pause); }
            return "Lit passengers and longer recovered bus variant authored; visual acceptance remains required.";
        }
    }
}
