using System;
using Dreamy.Feature.Settings.Integration;
using Dreamy.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Dreamy.Template.Editor
{
    public static class PauseSkinAuthoring
    {
        public const string Path = "Assets/_Project/Art/BusFever/UI/PauseSettingsPanel.prefab";
        public static void Build()
        {
            var root = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/Art/BusFever/UI/PausePanel.prefab"));
            root.name = "PauseSettingsPanel";
            root.SetActive(false);
            try
            {
                var panel = root.AddComponent<SettingsPanel>();
                Set(panel,"canvasGroup",root.GetComponent<CanvasGroup>());
                var safe = root.transform.Find("SafeArea"); safe.gameObject.AddComponent<SafeArea>();
                var mask = root.transform.Find("Mask_Img").gameObject.AddComponent<Image>();
                mask.color = new Color(0,0,0,.65f); mask.raycastTarget = true;
                foreach (var animator in root.GetComponentsInChildren<Animator>(true)) Object.DestroyImmediate(animator);
                foreach (var group in root.GetComponentsInChildren<CanvasGroup>(true)) group.alpha=1;
                var fields = new[] { "musicToggle", "sfxToggle", "hapticsToggle" };
                var names = new[] { "Music_Btn", "Sound_Btn", "Viber_Btn" };
                for(int i=0;i<names.Length;i++)
                {
                    var toggle = Find<Toggle>(root,names[i]); Set(panel,fields[i],toggle); toggle.graphic=null;
                    var visual=toggle.gameObject.AddComponent<SettingsToggleVisual>();
                    Set(visual,"onVisual",toggle.transform.Find("All_Anim/Open_Img").gameObject);
                    Set(visual,"offVisual",toggle.transform.Find("All_Anim/Close_Img").gameObject);
                }
                Set(panel,"closeButton",Find<Button>(root,"Btn_Close"));
                Set(panel,"restartButton",Find<Button>(root,"Btn_Green_1"));
                var statusRoot=new GameObject("OperationStatus",typeof(RectTransform));statusRoot.transform.SetParent(safe,false);
                var status=statusRoot.AddComponent<TextMeshProUGUI>();status.text="";status.fontSize=26;status.alignment=TextAlignmentOptions.Center;status.raycastTarget=false;
                status.rectTransform.anchoredPosition=new Vector2(0,-560);status.rectTransform.sizeDelta=new Vector2(700,80);
                Set(panel,"operationStatus",status);
                var transition=root.AddComponent<UITweenPlayer>();root.AddComponent<UITweenFade>();Set(panel,"tweenPlayer",transition);
                root.SetActive(true);
                PrefabUtility.SaveAsPrefabAsset(root,Path);
            }
            finally { Object.DestroyImmediate(root); }
        }
        private static T Find<T>(GameObject root,string name) where T:Component
        {
            foreach(var component in root.GetComponentsInChildren<T>(true))if(component.name==name)return component;
            throw new InvalidOperationException("Pause source binding missing: "+name);
        }
        private static void Set(Object target,string field,Object value)
        {
            var serialized=new SerializedObject(target);serialized.FindProperty(field).objectReferenceValue=value;serialized.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}
