using System;
using System.Linq;
using Dreamy.Feature.Settings.Integration;
using Dreamy.Economy.UI;
using Dreamy.Audio.Components;
using Dreamy.Template.Home;
using Dreamy.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Dreamy.Template.Editor
{
    /// <summary>Editor-only, repeatable cutover of the two existing sample prefabs; keeps their GUIDs.</summary>
    public static class PanelReskinAuthoring
    {
        private const string Art = RecoveredAssetMigration.Root;
        private const string HomePath = "Assets/_Project/Prefabs/Panel/HomePanel.prefab";
        private const string SettingsPath = "Assets/_Project/_Feature/Dreamy Settings/0.2.2/Settings Feature/Prefabs/SettingsPanel.prefab";

        public static string DryRun() => $"Home: {AssetDatabase.AssetPathToGUID(HomePath)}; Settings: {AssetDatabase.AssetPathToGUID(SettingsPath)}. Replaces child art; keeps root panel identity and addresses.";

        public static void RepairM01InputAndNavigation()
        {
            var home = PrefabUtility.LoadPrefabContents(HomePath);
            try
            {
                ConfigureNavigation(home, home.transform.Find("BottomNavigation"));
                PrefabUtility.SaveAsPrefabAsset(home, HomePath);
            }
            finally { PrefabUtility.UnloadPrefabContents(home); }
            var settings = PrefabUtility.LoadPrefabContents(SettingsPath);
            try
            {
                settings.transform.Find("Mask_Img").GetComponent<Image>().raycastTarget = true;
                PrefabUtility.SaveAsPrefabAsset(settings, SettingsPath);
            }
            finally { PrefabUtility.UnloadPrefabContents(settings); }
        }

        public static void ConfigureBackdrop()
        {
            var controller = AssetDatabase.LoadAssetAtPath<UnityEditor.Animations.AnimatorController>(Art + "/AnimatorController/Ani_Home_Bus.controller");
            foreach (var layer in controller.layers)
                foreach (var child in layer.stateMachine.states)
                    if (child.state.name == "Ani_Home_Bus_Stay")
                    {
                        child.state.writeDefaultValues = false;
                        EditorUtility.SetDirty(child.state);
                    }
            EditorUtility.SetDirty(controller);
            AssetDatabase.SaveAssetIfDirty(controller);
            string path = Art + "/GameObject/Empty_All.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try
            {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(Art + "/textmesh pro/fonts/fonts & materials/Poppins-Bold SDF.asset");
                string materialPath = "Assets/_Project/Art/BusFever/UI/LevelSignMaterial.mat";
                var material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
                if (material == null)
                {
                    material = new Material(font.material);
                    material.SetColor("_FaceColor", new Color(.03f,.04f,.12f));
                    AssetDatabase.CreateAsset(material, materialPath);
                }
                foreach (var node in root.GetComponentsInChildren<Transform>(true))
                {
                    // Source runtime selects one of these variants; overlapping both causes z-fighting.
                    if (node.name == "Bus_MainScreen_Blue_02") node.gameObject.SetActive(false);
                    if (node.name != "LEVEL") continue;
                    var sprite = node.GetComponent<SpriteRenderer>();
                    if (sprite != null) Object.DestroyImmediate(sprite);
                    var label = node.GetComponent<TextMeshPro>() ?? node.gameObject.AddComponent<TextMeshPro>();
                    label.font = font; label.fontSharedMaterial = material;
                    label.fontSize = 24; label.alignment = TextAlignmentOptions.Center;
                    label.text = "LEVEL  1"; // Initial project level; presenter supplies the live read model.
                    label.textWrappingMode = TextWrappingModes.NoWrap;
                }
                PrefabUtility.SaveAsPrefabAsset(root, path);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
        }

        public static void ApplyHome()
        {
            var root = PrefabUtility.LoadPrefabContents(HomePath);
            try
            {
                ClearOldSkin(root);
                CopyChildren("Assets/_Project/Art/BusFever/UI/HomePanel.prefab", root.transform);
                var navigation = AddRect(root.transform, "BottomNavigation");
                CopyChildren(Art + "/busjam/home/bundleables/BottomNavigationBar.prefab", navigation);
                ConfigureNavigation(root, navigation);
                var safe = root.transform.Find("All_Empty");
                if (safe != null && safe.GetComponent<SafeArea>() == null) safe.gameObject.AddComponent<SafeArea>();
                // M01 reference state has no active timed events yet.
                foreach (var node in root.GetComponentsInChildren<Transform>(true))
                    if (node.name == "TaskBarPanel" || node.name == "Left_Empty" || node.name == "DailyBonusEntrance" || node.name == "ColorGuess_Btn" || node.name == "RankingHomeEntrance" || node.name == "Play_Img2") node.gameObject.SetActive(false);
                var panel = root.GetComponent<HomePanel>();
                Set(panel, "settingsButton", Find<Button>(root, "Btn_Setting"));
                Set(panel, "shopButton", Find<Button>(root, "ShopTab"));
                Set(panel, "demoButton", null);
                Set(panel, "backdropPrefab", AssetDatabase.LoadAssetAtPath<GameObject>(Art + "/GameObject/Empty_All.prefab"));
                var coinPosition = root.transform.Find("All_Empty/Top_Empty/CoinPosition");
                var coin = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/Art/BusFever/UI/Btn_Gold.prefab"), coinPosition, false);
                var holder = coin.AddComponent<ResourceUIHolder>();
                Set(holder, "amountText", coin.GetComponentInChildren<TMP_Text>(true));
                coinPosition.GetComponent<RectTransform>().anchoredPosition = new Vector2(390,-188);
                var top = root.transform.Find("All_Empty/Top_Empty").GetComponent<RectTransform>();
                top.offsetMin = new Vector2(45, top.offsetMin.y);
                top.offsetMax = new Vector2(-53, top.offsetMax.y);
                foreach (Transform control in top) control.localScale = Vector3.one * .85f;
                var avatar = top.Find("UserProfileAvatarButton").GetComponent<RectTransform>();
                avatar.anchoredPosition += new Vector2(0,20);
                var settings = top.Find("Btn_Setting").GetComponent<RectTransform>();
                settings.anchoredPosition += new Vector2(0,24);
                var right = root.transform.Find("All_Empty/Right_Empty").GetComponent<RectTransform>();
                right.localScale = Vector3.one * .85f;
                right.anchoredPosition += new Vector2(-50,180);
                var bottom = root.transform.Find("All_Empty/Bottom_Empty").GetComponent<RectTransform>();
                bottom.localScale = Vector3.one * .885f;
                bottom.anchoredPosition += new Vector2(0,10);
                foreach (string tabName in new[] { "ShopTab", "RankingTab" })
                {
                    var tab = Find<Button>(root, tabName).transform;
                    tab.Find("Selected").localScale = Vector3.one * .65f;
                    tab.Find("Selected/Title").gameObject.SetActive(false);
                    tab.Find("Selected/IconOuterLine_Img").gameObject.SetActive(false);
                }
                PrepareGraphics(root);
                var playText = Find<TMP_Text>(root, "Play_Text");
                playText.fontSharedMaterial = AssetDatabase.LoadAssetAtPath<Material>(Art + "/Material/Poppins-Bold SDF_OutlineBlack3.mat");
                BindUnavailable(root, panel);
                PrefabUtility.SaveAsPrefabAsset(root, HomePath);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
        }

        public static void ApplySettings()
        {
            var root = PrefabUtility.LoadPrefabContents(SettingsPath);
            try
            {
                ClearOldSkin(root);
                CopyChildren("Assets/_Project/Art/BusFever/UI/SettingPanel.prefab", root.transform);
                var safe = root.transform.Find("SafeArea");
                if (safe.GetComponent<SafeArea>() == null) safe.gameObject.AddComponent<SafeArea>();
                var panel = root.GetComponent<SettingsPanel>();
                var mask = root.transform.Find("Mask_Img").gameObject.AddComponent<Image>();
                mask.color = new Color(0,0,0,.65f); mask.raycastTarget = true;
                Set(panel, "musicToggle", Find<Toggle>(root, "Music_Btn"));
                Set(panel, "sfxToggle", Find<Toggle>(root, "Sound_Btn"));
                Set(panel, "hapticsToggle", Find<Toggle>(root, "Viber_Btn"));
                Set(panel, "closeButton", Find<Button>(root, "Btn_Close"));
                Set(panel, "gdprButton", Find<Button>(root, "GDPR_Btn"));
                Set(panel, "restorePurchasesButton", Find<Button>(root, "Restore_Btn"));
                Set(panel, "openRateUsButton", Find<Button>(root, "SaveSync_Btn"));
                Set(panel, "languageDropdown", null); Set(panel, "languageError", null); Set(panel, "languageLabel", null);
                Set(panel, "contactButton", Find<Button>(root, "Contact_Btn"));
                Set(panel, "termsButton", Find<Button>(root, "Terms_Btn"));
                Set(panel, "privacyButton", Find<Button>(root, "Privacy_Btn"));
                var operationStatus = AddRect(root.transform.Find("SafeArea/GameObject/Board_Bg"), "OperationStatus").gameObject.AddComponent<TextMeshProUGUI>();
                operationStatus.rectTransform.anchorMin = operationStatus.rectTransform.anchorMax = new Vector2(.5f,.205f);
                operationStatus.rectTransform.sizeDelta = new Vector2(650,110); operationStatus.fontSize = 25; operationStatus.alignment = TextAlignmentOptions.Center;
                operationStatus.color = new Color(.3f,.2f,.1f); operationStatus.raycastTarget = false;
                Set(panel, "operationStatus", operationStatus);
                var transition = root.AddComponent<UITweenPlayer>();
                var fade = root.AddComponent<UITweenFade>();
                Set(fade, "canvasGroup", root.GetComponent<CanvasGroup>());
                var card = root.transform.Find("SafeArea/GameObject/Board_Bg").gameObject;
                var scale = card.AddComponent<UITweenScale>();
                var timing = new SerializedObject(scale);
                timing.FindProperty("inactiveScale").floatValue = .85f;
                timing.FindProperty("activeScale").floatValue = 1;
                timing.ApplyModifiedPropertiesWithoutUndo();
                Set(panel, "tweenPlayer", transition);
                foreach (var toggle in root.GetComponentsInChildren<Toggle>(true))
                {
                    toggle.onValueChanged.RemoveAllListeners();
                    toggle.graphic = null;
                    var visual = toggle.gameObject.AddComponent<SettingsToggleVisual>();
                    Set(visual, "onVisual", toggle.transform.Find("All_Anim/Open_Img")?.gameObject);
                    Set(visual, "offVisual", toggle.transform.Find("All_Anim/Close_Img")?.gameObject);
                }
                foreach (var text in root.GetComponentsInChildren<TMP_Text>(true))
                    if (text.name == "Version_Text") text.text = "DEV · " + Application.version;
                PrepareGraphics(root);
                PrefabUtility.SaveAsPrefabAsset(root, SettingsPath);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
        }

        private static void ClearOldSkin(GameObject root)
        {
            foreach (var availability in root.GetComponents<FeatureAvailabilityView>()) Object.DestroyImmediate(availability);
            foreach (var tween in root.GetComponents<UITweenPlayer>()) Object.DestroyImmediate(tween);
            foreach (Transform child in root.transform.Cast<Transform>().ToArray()) Object.DestroyImmediate(child.gameObject);
            var image = root.GetComponent<Image>();
            if (image != null) { image.color = Color.clear; image.raycastTarget = false; }
            var panel = root.GetComponent<UIPanel>();
            Set(panel, "canvasGroup", root.GetComponent<CanvasGroup>());
            Set(panel, "tweenPlayer", null);
        }

        private static void ConfigureNavigation(GameObject root, Transform navigation)
        {
            if (navigation.GetComponent<SafeArea>() == null) navigation.gameObject.AddComponent<SafeArea>();
            var tabs = (RectTransform)navigation.Find("All/Tabs");
            tabs.anchorMin = new Vector2(0,0); tabs.anchorMax = new Vector2(1,0);
            tabs.pivot = new Vector2(.5f,0); tabs.sizeDelta = new Vector2(0,200); tabs.anchoredPosition = Vector2.zero;
            var names = new[] { "ShopTab", "HomeTab", "RankingTab" };
            for (int i = 0; i < names.Length; i++)
            {
                var tab = (RectTransform)tabs.Find(names[i]);
                tab.anchorMin = new Vector2(i/3f,0); tab.anchorMax = new Vector2((i+1)/3f,1);
                tab.sizeDelta = Vector2.zero; tab.anchoredPosition = Vector2.zero;
            }
            var selected = (RectTransform)tabs.Find("Selected");
            selected.anchorMin = new Vector2(1f/3,0); selected.anchorMax = new Vector2(2f/3,1);
            selected.sizeDelta = Vector2.zero; selected.anchoredPosition = Vector2.zero;
            for (int i=1;i<=2;i++)
            {
                var divider = (RectTransform)tabs.Find("Divider"+i+"_Img");
                divider.anchorMin = divider.anchorMax = new Vector2(i/3f,.5f); divider.anchoredPosition = Vector2.zero;
            }
            // Keep full-bleed decoration outside the safe controls, including the gesture strip.
            var source = navigation.Find("All/Bg").GetComponent<Image>();
            var existingBleed = root.transform.Find("NavigationBleed");
            var bleed = existingBleed != null ? (RectTransform)existingBleed : AddRect(root.transform,"NavigationBleed").GetComponent<RectTransform>();
            bleed.SetSiblingIndex(navigation.GetSiblingIndex());
            bleed.anchorMin = Vector2.zero; bleed.anchorMax = new Vector2(1,0); bleed.pivot = new Vector2(.5f,0);
            bleed.sizeDelta = new Vector2(0,200);
            var image = bleed.GetComponent<Image>() ?? bleed.gameObject.AddComponent<Image>(); image.sprite = source.sprite; image.color = source.color; image.raycastTarget = false;
        }

        private static void CopyChildren(string source, Transform target)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(source);
            if (prefab == null) throw new InvalidOperationException("Missing recovered prefab: " + source);
            var clone = Object.Instantiate(prefab);
            foreach (Transform child in clone.transform.Cast<Transform>().ToArray()) child.SetParent(target, false);
            Object.DestroyImmediate(clone);
        }

        private static Transform AddRect(Transform parent, string name)
        {
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.SetParent(parent, false); rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.sizeDelta = Vector2.zero;
            return rect;
        }

        private static T Find<T>(GameObject root, params string[] names) where T : Component
            => root.GetComponentsInChildren<T>(true).FirstOrDefault(c => names.Contains(c.name));

        private static void PrepareGraphics(GameObject root)
        {
            // Recovered UI controllers target unavailable game scripts. Rebuild view motion explicitly later.
            foreach (var animator in root.GetComponentsInChildren<Animator>(true)) Object.DestroyImmediate(animator);
            foreach (var group in root.GetComponentsInChildren<CanvasGroup>(true)) group.alpha = 1;
            foreach (var graphic in root.GetComponentsInChildren<Graphic>(true))
                graphic.raycastTarget = graphic.name == "Mask_Img" || graphic.GetComponent<Selectable>() != null;
            foreach (var button in root.GetComponentsInChildren<Button>(true))
                if (button.GetComponent<AudioButtonTrigger>() == null) button.gameObject.AddComponent<AudioButtonTrigger>();
            foreach (var text in root.GetComponentsInChildren<TMP_Text>(true))
                if (text.text != null && text.text.Contains("{0}")) text.text = "0";
        }

        private static void BindUnavailable(GameObject root, HomePanel panel)
        {
            var status = AddRect(root.transform, "DevelopmentStatus").gameObject.AddComponent<TextMeshProUGUI>();
            status.fontSize = 24; status.alignment = TextAlignmentOptions.Center; status.raycastTarget = false;
            var rect = status.rectTransform; rect.anchorMin = rect.anchorMax = new Vector2(.5f,.15f); rect.sizeDelta = new Vector2(850,70);
            var availability = root.AddComponent<FeatureAvailabilityView>();
            var serialized = new SerializedObject(availability);
            var buttons = root.GetComponentsInChildren<Button>(true).Where(b => b.name != "Btn_Setting" && b.name != "HomeTab" && !b.name.Contains("Shop")).ToArray();
            var array = serialized.FindProperty("buttons"); array.arraySize = buttons.Length;
            for (int i=0;i<buttons.Length;i++) array.GetArrayElementAtIndex(i).objectReferenceValue = buttons[i];
            serialized.FindProperty("message").objectReferenceValue = status; serialized.ApplyModifiedPropertiesWithoutUndo();
        }

        private static void Set(Object target, string field, Object value)
        {
            var serialized = new SerializedObject(target);
            var property = serialized.FindProperty(field);
            if (property == null) throw new InvalidOperationException(target.name + ": missing " + field);
            property.objectReferenceValue = value;
            serialized.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}
