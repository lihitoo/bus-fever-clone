using System.Linq;
using Dreamy.Template.Gameplay;
using Dreamy.UI;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Dreamy.Template.Editor
{
    public static class M03VictoryAuthoring
    {
        public static string Build()
        {
            const string art = "Assets/_Project/Art/BusFever/UI/";
            SourceUiRebuilder.Rebuild("VictoryPanel",art+"VictoryPanel.prefab");
            var root = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(art+"VictoryPanel.prefab"));
            try
            {
                root.name = "VictoryPanel"; root.SetActive(false);
                var panel = root.AddComponent<VictoryPanel>();
                var group = root.GetComponent<CanvasGroup>() ?? root.AddComponent<CanvasGroup>(); group.alpha = 1;
                Set(panel,"canvasGroup",group);
                var all = root.transform.Find("All_Empty"); all.gameObject.SetActive(true); all.gameObject.AddComponent<SafeArea>();
                foreach (Transform child in all)
                    if (child.name != "Gold_Img" && child.name != "Btn_Group" && child.name != "Title_Img") child.gameObject.SetActive(false);
                var sourceTitle = all.Find("Title_Img"); sourceTitle.gameObject.SetActive(true);
                foreach (Transform child in sourceTitle) child.gameObject.SetActive(false);
                var background = new GameObject("ModalMask",typeof(RectTransform),typeof(Image));
                background.transform.SetParent(root.transform,false); background.transform.SetAsFirstSibling();
                var rect = background.GetComponent<RectTransform>(); rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.sizeDelta = Vector2.zero;
                background.GetComponent<Image>().color = new Color(0,0,0,.85f);
                var buttons = all.Find("Btn_Group"); buttons.gameObject.SetActive(true);
                foreach (Transform child in buttons) child.gameObject.SetActive(child.name == "Yellow_Button");
                var next = buttons.Find("Yellow_Button/Btn_Yellow").GetComponent<Button>(); next.gameObject.SetActive(true);
                Set(panel,"nextButton",next);
                var gold = all.Find("Gold_Img"); gold.gameObject.SetActive(true);
                Set(panel,"rewardRoot",gold.gameObject);
                Set(panel,"rewardText",gold.Find("Gold_Text").GetComponent<TMP_Text>());
                gold.Find("Gold2_Text").gameObject.SetActive(false);
                var rewardText = gold.Find("Gold_Text").GetComponent<TMP_Text>();
                rewardText.color = new Color(1,.82f,.02f);
                rewardText.fontSharedMaterial = AssetDatabase.LoadAssetAtPath<Material>(RecoveredAssetMigration.Root+"/Material/Poppins-Bold SDF_OutlineBlack3.mat");
                foreach (var label in gold.GetComponentsInChildren<TMP_Text>(true)) label.text = "20";
                var status = Label(all,"RewardStatus",new Vector2(.5f,.32f),new Vector2(900,130),28); Set(panel,"status",status);
                var home = Label(all,"VictoryHome",new Vector2(.5f,.13f),new Vector2(300,90),36); home.text = "Home"; home.raycastTarget = true;
                var button = home.gameObject.AddComponent<Button>(); button.targetGraphic = home; Set(panel,"homeButton",button);
                foreach (var text in next.GetComponentsInChildren<TMP_Text>(true))
                    text.fontSharedMaterial = AssetDatabase.LoadAssetAtPath<Material>(RecoveredAssetMigration.Root+"/Material/Poppins-Bold SDF_OutlineBlack3.mat");
                foreach (var g in root.GetComponentsInChildren<CanvasGroup>(true)) g.alpha = 1;
                const string path = "Assets/_Project/Prefabs/Panel/VictoryPanel.prefab";
                PrefabUtility.SaveAsPrefabAsset(root,path);
                var settings = AddressableAssetSettingsDefaultObject.Settings;
                settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path),settings.DefaultGroup).address = Address.VictoryPanel;
                EditorUtility.SetDirty(settings); AssetDatabase.SaveAssetIfDirty(settings);
                return "Victory native UI bound; character/celebration animation remains a source-art gate.";
            }
            finally { Object.DestroyImmediate(root); }
        }
        private static TMP_Text Label(Transform parent,string name,Vector2 anchor,Vector2 size,float fontSize)
        {
            var label = new GameObject(name,typeof(TextMeshProUGUI)).GetComponent<TMP_Text>(); label.transform.SetParent(parent,false);
            label.rectTransform.anchorMin = label.rectTransform.anchorMax = anchor; label.rectTransform.sizeDelta = size;
            label.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(RecoveredAssetMigration.Root+"/textmesh pro/fonts/fonts & materials/Poppins-Bold SDF.asset");
            label.fontSize = fontSize; label.alignment = TextAlignmentOptions.Center; label.raycastTarget = false; return label;
        }
        private static void Set(Object target,string field,Object value)
        { var serialized = new SerializedObject(target); serialized.FindProperty(field).objectReferenceValue = value; serialized.ApplyModifiedPropertiesWithoutUndo(); }
    }
}
