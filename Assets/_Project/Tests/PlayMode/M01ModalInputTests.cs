using System.Collections;
using System.Collections.Generic;
using Dreamy.Feature.Settings.Integration;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Dreamy.Template.Tests
{
    public sealed class M01ModalInputTests
    {
        [UnityTest]
        public IEnumerator SettingsMask_BlocksUnderlyingButton_AndReleasesItOnClose()
        {
#if UNITY_EDITOR
            var root = new GameObject("M01 modal input fixture");
            var eventRoot = new GameObject("Fixture EventSystem", typeof(EventSystem));
            var canvasRoot = new GameObject("Canvas", typeof(Canvas), typeof(GraphicRaycaster));
            canvasRoot.transform.SetParent(root.transform);
            canvasRoot.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var underlying = new GameObject("Underlying Home action", typeof(RectTransform), typeof(Image), typeof(Button));
            underlying.transform.SetParent(canvasRoot.transform, false);
            var rect = underlying.GetComponent<RectTransform>();
            rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.sizeDelta = Vector2.zero;
            int clicks = 0;
            underlying.GetComponent<Button>().onClick.AddListener(() => clicks++);
            var panel = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/_Project/_Feature/Dreamy Settings/0.2.2/Settings Feature/Prefabs/SettingsPanel.prefab"), canvasRoot.transform);
            try
            {
                yield return null;
                Canvas.ForceUpdateCanvases();
                var pointer = new PointerEventData(eventRoot.GetComponent<EventSystem>()) { position = new Vector2(10, 10), button = PointerEventData.InputButton.Left };
                var hits = new List<RaycastResult>();
                var raycaster = canvasRoot.GetComponent<GraphicRaycaster>();
                raycaster.Raycast(pointer, hits);
                Assert.That(hits.Count, Is.GreaterThan(0));
                Assert.That(hits[0].gameObject.name, Is.EqualTo("Mask_Img"), "Outside-card tap must stop at the modal mask.");
                ExecuteEvents.ExecuteHierarchy(hits[0].gameObject, pointer, ExecuteEvents.pointerClickHandler);
                Assert.That(clicks, Is.Zero);
                panel.SetActive(false);
                Canvas.ForceUpdateCanvases();
                hits.Clear(); raycaster.Raycast(pointer, hits);
                Assert.That(hits[0].gameObject, Is.SameAs(underlying));
                ExecuteEvents.ExecuteHierarchy(hits[0].gameObject, pointer, ExecuteEvents.pointerClickHandler);
                Assert.That(clicks, Is.EqualTo(1));
            }
            finally { Object.Destroy(root); Object.Destroy(eventRoot); }
#else
            Assert.Ignore("Serialized prefab fixture requires the Editor AssetDatabase.");
            yield break;
#endif
        }
    }
}
