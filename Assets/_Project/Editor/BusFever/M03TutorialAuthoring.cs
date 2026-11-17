using Dreamy.Template.Gameplay;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Dreamy.Template.Editor
{
    public static class M03TutorialAuthoring
    {
        public static string Build()
        {
            const string art = "Assets/_Project/Art/BusFever/UI/TutorialHand.png";
            var importer = (TextureImporter)AssetImporter.GetAtPath(art);
            importer.textureType = TextureImporterType.Sprite; importer.alphaIsTransparency = true;
            importer.mipmapEnabled = false; importer.SaveAndReimport();
            const string path = "Assets/_Project/Prefabs/Panel/GameplayPanel.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try
            {
                var parent = root.transform.Find("All_Empty");
                var card = parent.Find("TutorialCard") as RectTransform;
                if (card == null)
                {
                    card = new GameObject("TutorialCard",typeof(RectTransform),typeof(Image)).GetComponent<RectTransform>();
                    card.SetParent(parent,false); card.anchorMin = card.anchorMax = new Vector2(.5f,.49f);
                    card.sizeDelta = new Vector2(880,130);
                    var image = card.GetComponent<Image>(); image.color = new Color(1,.94f,.76f); image.raycastTarget = false;
                    var label = new GameObject("Instruction",typeof(TextMeshProUGUI)).GetComponent<TextMeshProUGUI>();
                    label.transform.SetParent(card,false); label.rectTransform.anchorMin = Vector2.zero; label.rectTransform.anchorMax = Vector2.one;
                    label.rectTransform.offsetMin = new Vector2(20,10); label.rectTransform.offsetMax = new Vector2(-20,-10);
                    label.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(RecoveredAssetMigration.Root+"/textmesh pro/fonts/fonts & materials/Poppins-Bold SDF.asset");
                    label.fontSize = 34; label.color = new Color(.4f,.22f,.1f); label.alignment = TextAlignmentOptions.Center;
                    label.text = "Tap the vehicle to match the passengers"; label.raycastTarget = false;
                }
                var hand = parent.Find("TutorialHand") as RectTransform;
                if (hand == null)
                {
                    hand = new GameObject("TutorialHand",typeof(RectTransform),typeof(Image)).GetComponent<RectTransform>();
                    hand.SetParent(parent,false); hand.anchorMin = hand.anchorMax = new Vector2(.5f,.5f);
                    hand.sizeDelta = new Vector2(150,155);
                    var image = hand.GetComponent<Image>(); image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(art); image.raycastTarget = false;
                }
                var serialized = new SerializedObject(root.GetComponent<GameplayPanel>());
                const string cardArt = "Assets/_Project/Art/BusFever/UI/TutorialCard.png";
                var cardImporter = (TextureImporter)AssetImporter.GetAtPath(cardArt);
                cardImporter.textureType = TextureImporterType.Sprite;
                cardImporter.spriteBorder = new Vector4(63,66,61,55);
                cardImporter.alphaIsTransparency = true; cardImporter.mipmapEnabled = false;
                cardImporter.SaveAndReimport();
                card.anchorMin = card.anchorMax = new Vector2(.5f,.208f);
                card.anchoredPosition = Vector2.zero; card.sizeDelta = new Vector2(746,185);
                hand.sizeDelta = new Vector2(190,200);
                var cardImage = card.GetComponent<Image>();
                cardImage.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(cardArt);
                cardImage.type = Image.Type.Sliced; cardImage.color = Color.white;
                var instruction = card.GetComponentInChildren<TMP_Text>(true);
                instruction.text = "Tap the vehicle to\nmatch the passengers";
                instruction.fontSize = 44; instruction.color = new Color(.46f,.28f,.1f);
                instruction.lineSpacing = -12;
                instruction.fontSharedMaterial = instruction.font.material;
                const string outlinePath = "Assets/_Project/Art/BusFever/UI/TutorialVehicleOutline.mat";
                var outline = AssetDatabase.LoadAssetAtPath<Material>(outlinePath);
                if (outline == null)
                {
                    outline = new Material(Shader.Find("BusFever/TutorialVehicleOutline"));
                    AssetDatabase.CreateAsset(outline, outlinePath);
                }
                outline.SetFloat("_Width",.03f);
                EditorUtility.SetDirty(outline);AssetDatabase.SaveAssetIfDirty(outline);
                serialized.FindProperty("tutorialOutlineMaterial").objectReferenceValue = outline;
                serialized.FindProperty("tutorialHand").objectReferenceValue = hand;
                serialized.FindProperty("tutorialCard").objectReferenceValue = card.gameObject;
                serialized.ApplyModifiedPropertiesWithoutUndo();
                hand.gameObject.SetActive(false); card.gameObject.SetActive(false);
                PrefabUtility.SaveAsPrefabAsset(root,path);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
            return "Tutorial source hand + native instruction card bound to GameplayPanel.";
        }
    }
}
