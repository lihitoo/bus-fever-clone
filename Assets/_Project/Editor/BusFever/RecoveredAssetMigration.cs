using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dreamy.Template.Editor
{
    public static class RecoveredAssetMigration
    {
        public const string Root = "Assets/_Project/Art/BusFever/Recovered";

        public static string MigrateMaterials(string[] selectedPaths = null)
        {
            int count = 0;
            var paths = selectedPaths ?? Array.ConvertAll(AssetDatabase.FindAssets("t:Material", new[] { Root }), AssetDatabase.GUIDToAssetPath);
            foreach (string path in paths)
            {
                var material = AssetDatabase.LoadAssetAtPath<Material>(path);
                var properties = new SerializedObject(material);
                var textures = properties.FindProperty("m_SavedProperties.m_TexEnvs");
                Texture texture = null;
                for (int i = 0; i < textures.arraySize; i++)
                {
                    var entry = textures.GetArrayElementAtIndex(i);
                    if (entry.FindPropertyRelative("first").stringValue == "_MainTex")
                        texture = entry.FindPropertyRelative("second.m_Texture").objectReferenceValue as Texture;
                }
                bool font = material.name.Contains("SDF") || material.name.Contains("Poppins");
                bool shadow = material.name.IndexOf("shadow", StringComparison.OrdinalIgnoreCase) >= 0;
                bool scenery = material.name.Contains("Home_BG") || material.name.IndexOf("cloud", StringComparison.OrdinalIgnoreCase) >= 0;
                bool glass = material.name.IndexOf("boli", StringComparison.OrdinalIgnoreCase) >= 0;
                bool glow = material.name == "Bus_MainScreen_Light_01";
                material.shader = Shader.Find(font ? "TextMeshPro/Distance Field" : shadow || scenery || glow || glass ? "Universal Render Pipeline/Unlit" : "Universal Render Pipeline/Simple Lit");
                material.SetShaderPassEnabled("SRPDefaultUnlit", true);
                material.SetShaderPassEnabled("UniversalForward", true);
                if (texture != null) material.SetTexture(font ? "_MainTex" : "_BaseMap", texture);
                if (!font)
                {
                    material.SetColor("_BaseColor", Color.white);
                    bool transparent = glass || glow || material.name.IndexOf("shadow", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        material.name.IndexOf("cloud", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        material.name.Contains("Home_BG");
                    if (transparent)
                    {
                        material.SetFloat("_Surface", 1);
                        material.SetFloat("_SrcBlend", (float)BlendMode.SrcAlpha);
                        material.SetFloat("_DstBlend", (float)BlendMode.OneMinusSrcAlpha);
                        material.SetFloat("_ZWrite", 0);
                        material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
                        material.renderQueue = 3000;
                        if (glass) material.SetColor("_BaseColor", new Color(1,1,1,.18f));
                        if (glow)
                        {
                            material.SetFloat("_Blend", 2);
                            material.SetFloat("_DstBlend", (float)BlendMode.One);
                            material.SetColor("_BaseColor", new Color(1,1,1,.06f));
                        }
                        if (material.name.IndexOf("shadow", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            material.SetFloat("_Blend", 3);
                            material.SetFloat("_SrcBlend", (float)BlendMode.DstColor);
                            material.SetFloat("_DstBlend", (float)BlendMode.Zero);
                        }
                    }
                    material.SetFloat("_Cull", 0);
                }
                EditorUtility.SetDirty(material);
                AssetDatabase.SaveAssetIfDirty(material);
                count++;
            }
            return $"Migrated {count} selected materials. Visual comparison still required.";
        }
    }
}
