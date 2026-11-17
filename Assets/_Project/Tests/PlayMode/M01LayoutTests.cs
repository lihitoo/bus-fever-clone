using System.Collections;
using System.Linq;
using System.Reflection;
using Dreamy.Template.Home;
using Dreamy.UI;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Dreamy.Template.Tests
{
    public sealed class M01LayoutTests
    {
        [UnityTest] public IEnumerator Baseline() => CheckLayout(1080, 1920, 0, 0);
        [UnityTest] public IEnumerator TallWithInsets() => CheckLayout(1080, 2400, 100, 96);
        [UnityTest] public IEnumerator Narrow() => CheckLayout(720, 1600, 48, 32);

        private IEnumerator CheckLayout(int width, int height, int top, int bottom)
        {
#if UNITY_EDITOR
            var root = new GameObject("M01 layout fixture");
            var cameraRoot = new GameObject("Fixture camera", typeof(Camera)); cameraRoot.transform.SetParent(root.transform);
            var camera = cameraRoot.GetComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            var texture = new RenderTexture(width, height, 16); texture.Create(); camera.targetTexture = texture;
            var canvasRoot = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler)); canvasRoot.transform.SetParent(root.transform);
            var canvas = canvasRoot.GetComponent<Canvas>(); canvas.renderMode = RenderMode.ScreenSpaceCamera; canvas.worldCamera = camera; canvas.planeDistance = 10;
            var scaler = canvasRoot.GetComponent<CanvasScaler>(); scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1080,1920); scaler.matchWidthOrHeight = .5f;
            var inactive = new GameObject("Inactive staging"); inactive.SetActive(false);
            var home = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/Prefabs/Panel/HomePanel.prefab"), inactive.transform);
            typeof(HomePanel).GetField("backdropPrefab", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(home.GetComponent<HomePanel>(), null);
            home.transform.SetParent(canvasRoot.transform, false);
            var settings = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/_Feature/Dreamy Settings/0.2.2/Settings Feature/Prefabs/SettingsPanel.prefab"), canvasRoot.transform);
            try
            {
                yield return null;
                foreach (var safe in root.GetComponentsInChildren<SafeArea>(true))
                {
                    safe.enabled = false;
                    var rect = (RectTransform)safe.transform;
                    rect.anchorMin = new Vector2(0, (float)bottom/height);
                    rect.anchorMax = new Vector2(1, 1f-(float)top/height);
                }
                Canvas.ForceUpdateCanvases(); yield return null; Canvas.ForceUpdateCanvases();
                foreach (string name in new[] { "Btn_Setting", "UserProfileAvatarButton", "Play_Btn", "ShopTab", "HomeTab", "RankingTab" })
                {
                    var button = home.GetComponentsInChildren<Button>(true).Single(b => b.name == name);
                    AssertInside((RectTransform)button.transform,camera,width,height,top,bottom,name);
                }
                AssertInside((RectTransform)settings.transform.Find("SafeArea/GameObject/Board_Bg"),camera,width,height,top,bottom,"Settings card");
            }
            finally { camera.targetTexture=null; texture.Release(); Object.Destroy(texture); Object.Destroy(root); Object.Destroy(inactive); }
#else
            Assert.Ignore("Editor-only serialized prefab fixture."); yield break;
#endif
        }

        private static void AssertInside(RectTransform rect, Camera camera, int width, int height, int top, int bottom, string label)
        {
            var corners = new Vector3[4]; rect.GetWorldCorners(corners);
            foreach(var corner in corners)
            {
                var pixel = camera.WorldToScreenPoint(corner);
                Assert.That(pixel.x, Is.InRange(-1f,width+1f),label+" horizontal bounds");
                Assert.That(pixel.y, Is.InRange(bottom-1f,height-top+1f),label+" safe-area bounds");
            }
        }
    }
}
