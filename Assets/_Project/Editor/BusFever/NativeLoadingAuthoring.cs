using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Dreamy.Template.Editor
{
    public static class NativeLoadingAuthoring
    {
        public static string Build()
        {
            const string path = "Assets/_Project/Prefabs/[LoadingScreen].prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try
            {
                foreach (Transform child in root.transform)
                    child.gameObject.SetActive(false);
                var previous = root.transform.Find("NativeSkyTransition");
                if (previous != null) Object.DestroyImmediate(previous.gameObject);
                var previousBlocker = root.transform.Find("TransitionInputBlocker");
                if (previousBlocker != null) Object.DestroyImmediate(previousBlocker.gameObject);
                var source = AssetDatabase.LoadAssetAtPath<GameObject>(RecoveredAssetMigration.Root + "/busjam/game/effect/prefabs/Effect_SkyTransition.prefab");
                var sky = Object.Instantiate(source.transform.Find("All_Anim").gameObject, root.transform, false);
                sky.name = "NativeSkyTransition";
                sky.SetActive(true);
                var skyRect = (RectTransform)sky.transform;
                skyRect.localScale = Vector3.one; // Original Loading host activates this zero-scale exported container.
                skyRect.anchorMin = Vector2.zero; skyRect.anchorMax = Vector2.one;
                skyRect.offsetMin = Vector2.zero; skyRect.offsetMax = Vector2.zero;
                skyRect.pivot = new Vector2(.5f, .5f);
                foreach (var camera in sky.GetComponentsInChildren<Camera>(true)) camera.enabled = false;
                foreach (var particles in sky.GetComponentsInChildren<ParticleSystem>(true)) particles.gameObject.SetActive(false);
                foreach (var image in sky.GetComponentsInChildren<Image>(true)) image.material = null;
                var canvas = sky.GetComponentInChildren<Canvas>(true);
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.overrideSorting = true;
                canvas.sortingOrder = 32700;
                var scaler = canvas.GetComponent<CanvasScaler>() ?? canvas.gameObject.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1080, 1920);
                scaler.matchWidthOrHeight = .5f;
                if (canvas.GetComponent<GraphicRaycaster>() == null) canvas.gameObject.AddComponent<GraphicRaycaster>();
                var blocker = new GameObject("TransitionInputBlocker", typeof(RectTransform), typeof(Image));
                blocker.transform.SetParent(root.transform, false);
                blocker.transform.SetAsFirstSibling();
                var rect = (RectTransform)blocker.transform;
                rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.sizeDelta = Vector2.zero;
                blocker.GetComponent<Image>().color = Color.clear;
                root.GetComponent<Canvas>().sortingOrder = 32699;
                // Decorative clouds cover the whole display. No HUD is placed under display cutouts.
                var loading = root.GetComponent<UILoadingScreen>();
                var serialized = new SerializedObject(loading);
                serialized.FindProperty("nativeTransition").objectReferenceValue = sky.GetComponentsInChildren<Animator>(true).Single();
                serialized.ApplyModifiedPropertiesWithoutUndo();
                var oldAnimator = root.GetComponent<Animator>();
                if (oldAnimator != null) oldAnimator.enabled = false;
                PrefabUtility.SaveAsPrefabAsset(root, path);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
            return "Source SkyTransition controller/clips bound to existing loading prefab; camera and unsupported UI particles disabled.";
        }
    }
}
