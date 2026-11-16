using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Dreamy.Template.Editor
{
    public static class SourceUiRebuilder
    {
        public static void Rebuild(string panel, string output)
        {
            string rootPath = "Assets/_Project/Art/BusFever/UI/";
            var data = JObject.Parse(File.ReadAllText(rootPath + panel + ".json"));
            var borders = JObject.Parse(File.ReadAllText(rootPath + "sprite-borders.json"));
            var transforms = new Dictionary<string, RectTransform>();
            GameObject root = null;
            try
            {
                foreach (var node in data["nodes"])
                {
                    string path = (string)node["path"];
                    var gameObject = new GameObject(path.Substring(path.LastIndexOf('/') + 1), typeof(RectTransform));
                    var rect = gameObject.GetComponent<RectTransform>();
                    transforms.Add((string)node["id"], rect);
                    if (root == null) root = gameObject;
                    else rect.SetParent(transforms[(string)node["parent"]], false);
                    foreach (var component in node["components"])
                    {
                        var fields = component["fields"];
                        switch ((string)component["type"])
                        {
                            case "RectTransform":
                                rect.anchorMin = V2(fields["m_AnchorMin"]); rect.anchorMax = V2(fields["m_AnchorMax"]);
                                rect.pivot = V2(fields["m_Pivot"]); rect.sizeDelta = V2(fields["m_SizeDelta"]);
                                rect.anchoredPosition = V2(fields["m_AnchoredPosition"]);
                                var scale = V3(fields["m_LocalScale"]); rect.localScale = scale.sqrMagnitude < .01f ? Vector3.one : scale;
                                break;
                            case "CanvasGroup": gameObject.AddComponent<CanvasGroup>(); break;
                            case "UnityEngine.UI.Image":
                                var image = gameObject.AddComponent<Image>(); image.color = ColorOf(fields["m_Color"]);
                                string spritePath = (string)component["sprite"];
                                if (!string.IsNullOrEmpty(spritePath))
                                {
                                    var importer = (TextureImporter)AssetImporter.GetAtPath(spritePath);
                                    var border = borders[Path.GetFileNameWithoutExtension(spritePath)];
                                    var borderVector = new Vector4((float?)border?["x"] ?? 0, (float?)border?["y"] ?? 0, (float?)border?["z"] ?? 0, (float?)border?["w"] ?? 0);
                                    if (importer.textureType != TextureImporterType.Sprite || importer.spriteBorder != borderVector)
                                    { importer.textureType = TextureImporterType.Sprite; importer.spriteImportMode = SpriteImportMode.Single; importer.spriteBorder = borderVector; importer.alphaIsTransparency = true; importer.mipmapEnabled = false; importer.SaveAndReimport(); }
                                    image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
                                }
                                image.type = image.sprite != null && image.sprite.border.sqrMagnitude > 0 && (int?)fields["m_Type"] == 1 ? Image.Type.Sliced : Image.Type.Simple;
                                image.raycastTarget = false;
                                break;
                            case "TMPro.TextMeshProUGUI":
                                var label = gameObject.AddComponent<TextMeshProUGUI>();
                                label.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(RecoveredAssetMigration.Root + "/textmesh pro/fonts/fonts & materials/Poppins-Bold SDF.asset");
                                label.text = (string)fields["m_text"] ?? "";
                                label.fontSize = (float?)fields["m_fontSize"] ?? 36;
                                label.color = ColorOf(fields["m_fontColor"]);
                                label.horizontalAlignment = (HorizontalAlignmentOptions)((int?)fields["m_HorizontalAlignment"] ?? 2);
                                label.verticalAlignment = (VerticalAlignmentOptions)((int?)fields["m_VerticalAlignment"] ?? 512);
                                label.textWrappingMode = TextWrappingModes.NoWrap;
                                label.raycastTarget = false;
                                break;
                            case "UnityEngine.UI.Button":
                                var button = gameObject.AddComponent<Button>(); button.targetGraphic = gameObject.GetComponent<Graphic>();
                                if (button.targetGraphic != null) button.targetGraphic.raycastTarget = true;
                                break;
                            case "UnityEngine.UI.Toggle":
                                var toggle = gameObject.AddComponent<Toggle>(); toggle.targetGraphic = gameObject.GetComponent<Graphic>();
                                toggle.isOn = (bool?)fields["m_IsOn"] ?? true;
                                if (toggle.targetGraphic != null) toggle.targetGraphic.raycastTarget = true;
                                break;
                            case "UnityEngine.UI.Mask":
                                gameObject.AddComponent<Mask>().showMaskGraphic = (bool?)fields["m_ShowMaskGraphic"] ?? false;
                                break;
                            case "UnityEngine.UI.VerticalLayoutGroup":
                                var vertical = gameObject.AddComponent<VerticalLayoutGroup>();
                                ConfigureLayout(vertical, fields); break;
                            case "UnityEngine.UI.HorizontalLayoutGroup":
                                var horizontal = gameObject.AddComponent<HorizontalLayoutGroup>();
                                ConfigureLayout(horizontal, fields); break;
                            case "UnityEngine.UI.LayoutElement":
                                var element = gameObject.AddComponent<LayoutElement>();
                                element.preferredWidth = (float?)fields["m_PreferredWidth"] ?? -1;
                                element.preferredHeight = (float?)fields["m_PreferredHeight"] ?? -1;
                                break;
                        }
                    }
                    gameObject.SetActive((bool)node["active"]);
                }
                PrefabUtility.SaveAsPrefabAsset(root, output);
            }
            finally { if (root != null) UnityEngine.Object.DestroyImmediate(root); }
        }

        private static void ConfigureLayout(HorizontalOrVerticalLayoutGroup layout, JToken fields)
        {
            layout.spacing = (float?)fields["m_Spacing"] ?? 0;
            layout.childAlignment = (TextAnchor)((int?)fields["m_ChildAlignment"] ?? 0);
            layout.childControlWidth = (bool?)fields["m_ChildControlWidth"] ?? false;
            layout.childControlHeight = (bool?)fields["m_ChildControlHeight"] ?? false;
            layout.childForceExpandWidth = (bool?)fields["m_ChildForceExpandWidth"] ?? false;
            layout.childForceExpandHeight = (bool?)fields["m_ChildForceExpandHeight"] ?? false;
        }
        private static Vector2 V2(JToken v) => new Vector2((float?)v?["x"] ?? 0, (float?)v?["y"] ?? 0);
        private static Vector3 V3(JToken v) => new Vector3((float?)v?["x"] ?? 1, (float?)v?["y"] ?? 1, (float?)v?["z"] ?? 1);
        private static Color ColorOf(JToken v) => v == null ? Color.white : new Color((float?)v["r"] ?? 1, (float?)v["g"] ?? 1, (float?)v["b"] ?? 1, (float?)v["a"] ?? 1);
    }
}
