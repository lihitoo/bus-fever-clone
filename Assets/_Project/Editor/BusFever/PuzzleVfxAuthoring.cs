using System.Linq;
using Dreamy.Feedback;
using UnityEditor;
using UnityEngine;

namespace Dreamy.Template.Editor
{
    public static class PuzzleVfxAuthoring
    {
        public static string Build()
        {
            var source = AssetDatabase.LoadAssetAtPath<GameObject>(RecoveredAssetMigration.Root + "/busjam/game/bundleables/busandpassenger/bus_normal_10.prefab");
            var effect = source.GetComponentsInChildren<Transform>(true).Single(t => t.name == "Effect_SmokeOnce");
            var root = new GameObject("BusDepartureSmoke");
            const string path = "Assets/_Project/Art/BusFever/UI/BusDepartureSmoke.prefab";
            try
            {
                var clone = Object.Instantiate(effect.gameObject, root.transform, false);
                clone.SetActive(true);
                clone.transform.localPosition = Vector3.zero;
                clone.transform.localRotation = Quaternion.identity;
                clone.transform.localScale = Vector3.one * .14f;
                foreach (var ps in clone.GetComponentsInChildren<ParticleSystem>(true))
                {
                    ps.gameObject.SetActive(true);
                    var main = ps.main;
                    main.playOnAwake = false;
                    main.loop = false;
                    main.duration = .5f;
                }
                foreach (var renderer in clone.GetComponentsInChildren<ParticleSystemRenderer>(true))
                {
                    var material = renderer.sharedMaterial;
                    if (material == null) continue;
                    material.shader = Shader.Find("Universal Render Pipeline/Particles/Unlit");
                    material.SetFloat("_Surface", 1);
                    material.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetFloat("_ZWrite", 0);
                    material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
                    material.renderQueue = 3000;
                    EditorUtility.SetDirty(material);
                    AssetDatabase.SaveAssetIfDirty(material);
                }
                root.AddComponent<ParticleVfxInstance>();
                PrefabUtility.SaveAsPrefabAsset(root, path);
            }
            finally { Object.DestroyImmediate(root); }
            var rig = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/_Feature/Dreamy Feedback/0.4.0/Basic Feedback/Generated/Rigs/GameFeedbackRig.prefab");
            var host = new SerializedObject(rig.GetComponent<FeedbackHost>());
            var database = (VfxDatabase)host.FindProperty("vfxDatabase").objectReferenceValue;
            var serialized = new SerializedObject(database);
            var entries = serialized.FindProperty("entries");
            SerializedProperty entry = null;
            for (int i = 0; i < entries.arraySize; i++)
                if (entries.GetArrayElementAtIndex(i).FindPropertyRelative("id").stringValue == "bus.departure") entry = entries.GetArrayElementAtIndex(i);
            if (entry == null) { entries.InsertArrayElementAtIndex(entries.arraySize); entry = entries.GetArrayElementAtIndex(entries.arraySize - 1); }
            entry.FindPropertyRelative("id").stringValue = "bus.departure";
            entry.FindPropertyRelative("prefab").objectReferenceValue = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            entry.FindPropertyRelative("prewarmCount").intValue = 4;
            entry.FindPropertyRelative("despawnMode").enumValueIndex = (int)VfxDespawnMode.FixedLifetime;
            entry.FindPropertyRelative("fixedLifetime").floatValue = 1;
            serialized.ApplyModifiedPropertiesWithoutUndo();
            AssetDatabase.SaveAssetIfDirty(database);
            return "Source-derived smoke registered in existing Dreamy VFX database; scale and duration are provisional.";
        }
    }
}
