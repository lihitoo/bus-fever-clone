using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dreamy.Feature.Settings.Integration;
using Dreamy.Template.Gameplay;
using Dreamy.Template.Home;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Dreamy.Template.Tests
{
    public sealed class M02GameplayFlowTests
    {
        private GameObject recorder;
        [UnityTearDown]
        public IEnumerator CleanupCapture()
        {
            if (recorder != null) Object.Destroy(recorder);
            yield return null;
        }

        [UnityTest]
        public IEnumerator NormalRoute_BlockedTap_Pause_Restart_Complete_ReturnHome()
        {
#if !DISABLE_DREAMY_DEBUGGER
            LogAssert.Expect(LogType.Log, "[DreamyDebugger] Bug Report handler set to Dreamy.Debugger.DebuggerRuntime+OutboxReportHandler");
#endif
            recorder = new GameObject("M02FlowCapture"); Object.DontDestroyOnLoad(recorder);
            recorder.AddComponent<M02FlowCapture>();
            yield return SceneManager.LoadSceneAsync("BootstrapScene");
            yield return Until(() => Object.FindFirstObjectByType<HomePanel>() != null, "Bootstrap → Home");
            yield return Until(LoadingHidden, "Startup loading closes");
            var sceneHandle = SceneManager.GetActiveScene().handle;
            // Explicit replay fixture; does not reset the user's persisted progression/tutorial.
            typeof(GameInstaller).GetField("selectedLevel",System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.NonPublic)
                .SetValue(Object.FindFirstObjectByType<GameInstaller>(),1);
            Click(Object.FindFirstObjectByType<HomePanel>(), "Play_Btn");
            yield return Until(() => Object.FindFirstObjectByType<GameplayPanel>() != null, "Play → Gameplay");
            var panel = Object.FindFirstObjectByType<GameplayPanel>();
            yield return Until(LoadingHidden, "Play loading closes");
            System.IO.Directory.CreateDirectory("docs/clone-plan/media/current/M02");
            ScreenCapture.CaptureScreenshot("docs/clone-plan/media/current/M02/M02-board.png");
            yield return new WaitForEndOfFrame();
            Assert.That(Object.FindObjectsByType<VehiclePointerTarget>(FindObjectsSortMode.None).Length, Is.EqualTo(6));
            yield return null;

            // Presentation-only reference fixture; never reset the user's durable tutorial cursor.
            panel.RenderTutorial("blue-top");
            yield return new WaitForEndOfFrame();
            var tutorialFrame = ScreenCapture.CaptureScreenshotAsTexture();
            System.IO.File.WriteAllBytes("docs/clone-plan/media/current/M02/M03-tutorial-latest.png", tutorialFrame.EncodeToPNG());
            Object.Destroy(tutorialFrame);
            panel.RenderTutorial(null);

            TapVehicle("red-bottom");
            Assert.That(SceneManager.GetActiveScene().handle, Is.EqualTo(sceneHandle), "Play keeps MainScene");
            Assert.That(Vehicle("red-bottom").gameObject.activeSelf, Is.True, "Wrong tutorial target stays on the board");
            TapVehicle("blue-top");
            var departureFx = GameObject.Find("BusDepartureSmoke(Clone)");
            Assert.That(departureFx, Is.Not.Null, "Accepted dispatch leases source smoke through Dreamy VFX");
            Assert.That(departureFx.GetComponentInChildren<ParticleSystem>().isPlaying, Is.True);
            yield return Until(() => !Vehicle("blue-top").gameObject.activeSelf, "Blue vehicle boards and departs");
            Assert.That(Text(panel, "PassengerCount"), Is.EqualTo("200 passengers"));

            Click(panel, "Btn_Pause");
            yield return Until(() => Object.FindFirstObjectByType<SettingsPanel>() != null, "Gameplay pause popup");
            var pause = Object.FindFirstObjectByType<SettingsPanel>();
            Assert.That(GameObject.Find("BusDepartureSmoke(Clone)"), Is.Null, "Pause releases session effects");
            ScreenCapture.CaptureScreenshot("docs/clone-plan/media/current/M02/M02-pause.png");
            var passenger = GameObject.Find("Passenger-100").transform;
            var position = passenger.position;
            yield return new WaitForSecondsRealtime(.35f);
            Assert.That(Vector3.Distance(position, passenger.position), Is.LessThan(.0001f), "Pause must stop passenger presentation.");
            Click(pause, "Btn_Close");
            yield return Until(() => pause == null || !pause.gameObject.activeInHierarchy, "Pause closes");
            yield return new WaitForSecondsRealtime(.25f);
            Assert.That(Vector3.Distance(position, passenger.position), Is.GreaterThan(.001f), "Closing pause must resume presentation.");

            Click(panel, "Btn_Pause");
            yield return Until(() => Object.FindFirstObjectByType<SettingsPanel>() != null, "Pause reopens");
            Click(Object.FindFirstObjectByType<SettingsPanel>(), "Btn_Green_1");
            yield return Until(() => panel == null && Object.FindFirstObjectByType<GameplayPanel>() != null, "Pause restart creates a fresh session");
            panel = Object.FindFirstObjectByType<GameplayPanel>();
            Assert.That(SceneManager.GetActiveScene().handle, Is.EqualTo(sceneHandle), "Restart keeps MainScene");
            yield return Until(LoadingHidden, "Restart loading closes");
            Assert.That(Text(panel, "PassengerCount"), Is.EqualTo("240 passengers"));
            Assert.That(Object.FindObjectsByType<VehiclePointerTarget>(FindObjectsSortMode.None).Length, Is.EqualTo(6));
            yield return null;

            foreach (string id in new[] { "blue-top", "blue-left", "red-upper", "red-bottom", "yellow-left", "yellow-right" })
            {
                TapVehicle(id);
                yield return new WaitForSeconds(1);
            }
            yield return Until(() => Object.FindFirstObjectByType<VictoryPanel>() != null, "All passengers board; final vehicle departs");
            Assert.That(Text(panel, "PassengerCount"), Is.EqualTo("0 passengers"));
            yield return Until(() => Object.FindFirstObjectByType<VictoryPanel>() != null,"Win opens Victory");
            var victory = Object.FindFirstObjectByType<VictoryPanel>();
            bool renderedFireworks = false;
            float fireworksDeadline = Time.realtimeSinceStartup + 1.8f;
            while (Time.realtimeSinceStartup < fireworksDeadline)
            {
                renderedFireworks |= victory.GetComponentsInChildren<Graphic>().Any(g =>
                    g.GetType().Name == "UIParticleRenderer" && g.canvasRenderer.GetMesh() != null &&
                    g.canvasRenderer.GetMesh().vertexCount > 0);
                yield return null;
            }
            Assert.That(renderedFireworks, Is.True, "Victory source fireworks produce visible UI geometry");
            Assert.That(victory.GetComponentsInChildren<Graphic>().Any(g => g.GetType().FullName == "Spine.Unity.SkeletonGraphic" &&
                g.canvasRenderer.GetMesh() != null && g.canvasRenderer.GetMesh().vertexCount > 0),Is.True,"Victory renders the recovered animated character");
            ScreenCapture.CaptureScreenshot("docs/clone-plan/media/current/M02/M03-victory-latest.png");
            yield return new WaitForEndOfFrame();
            Click(victory,"Btn_Yellow"); Click(victory,"Btn_Yellow");
            yield return Until(() => victory == null && Object.FindFirstObjectByType<GameplayPanel>() != null,"Next opens Level2");
            yield return Until(LoadingHidden,"Level2 transition closes");
            panel=Object.FindFirstObjectByType<GameplayPanel>();
            Assert.That(Object.FindObjectsByType<VehiclePointerTarget>(FindObjectsSortMode.None).Length,Is.EqualTo(12));
            Assert.That(SceneManager.GetActiveScene().handle,Is.EqualTo(sceneHandle));
            yield return new WaitForEndOfFrame();
            var frame = ScreenCapture.CaptureScreenshotAsTexture();
            System.IO.File.WriteAllBytes("docs/clone-plan/media/current/M02/M03-level2.png", frame.EncodeToPNG());
            Object.Destroy(frame);
            yield return new WaitForEndOfFrame();
            Click(panel, "Btn_Pause");
            yield return Until(() => Object.FindFirstObjectByType<SettingsPanel>() != null,"Level2 Pause opens");
            Click(Object.FindFirstObjectByType<SettingsPanel>(),"Btn_Yellow");
            yield return Until(() => Object.FindFirstObjectByType<HomePanel>() != null, "Gameplay → Home");
            yield return Until(LoadingHidden, "Return loading closes");
            Assert.That(GameObject.Find("PuzzleSessionWorld"), Is.Null);
            Assert.That(GameObject.Find("BusDepartureSmoke(Clone)"), Is.Null, "Home leaves no active gameplay effect");
            Assert.That(SceneManager.GetActiveScene().handle, Is.EqualTo(sceneHandle), "Return keeps MainScene");
            Assert.That(Object.FindObjectsByType<GameInstaller>(FindObjectsSortMode.None).Length, Is.EqualTo(1));
            LogAssert.NoUnexpectedReceived();
        }

        private static IEnumerator Until(Func<bool> condition, string step)
        {
            float deadline = Time.realtimeSinceStartup + 60;
            while (!condition() && Time.realtimeSinceStartup < deadline) yield return null;
            Assert.That(condition(), Is.True, step);
        }
        private static string Text(Component root, string name) => root.GetComponentsInChildren<TMP_Text>(true).Single(t => t.name == name).text;
        private static bool LoadingHidden() => !Object.FindFirstObjectByType<UILoadingScreen>(FindObjectsInactive.Include).gameObject.activeInHierarchy;
        private static void Click(Component root, string name)
        {
            var button = root.GetComponentsInChildren<Button>(true).Single(b => b.name == name && b.gameObject.activeInHierarchy);
            Assert.That(button.gameObject.activeInHierarchy && button.interactable, Is.True, name + " available");
            button.onClick.Invoke();
        }
        private static VehiclePointerTarget Vehicle(string id) => Object.FindObjectsByType<VehiclePointerTarget>(FindObjectsInactive.Include, FindObjectsSortMode.None).Single(v => v.name == id);
        private static void TapVehicle(string id)
        {
            var vehicle = Vehicle(id);
            var camera = GameObject.Find("PuzzleSessionWorld").GetComponentInChildren<Camera>();
            var point = camera.WorldToScreenPoint(vehicle.transform.position + Vector3.up * .15f);
            var pointer = new PointerEventData(EventSystem.current) { position = point, button = PointerEventData.InputButton.Left };
            var hits = new List<RaycastResult>(); EventSystem.current.RaycastAll(pointer, hits);
            Assert.That(hits.Count, Is.GreaterThan(0), id + " must have a pointer hit");
            Assert.That(hits[0].gameObject.GetComponentInParent<VehiclePointerTarget>(), Is.SameAs(vehicle), id + " must be the first hit, ahead of UI/world blockers");
            ExecuteEvents.ExecuteHierarchy(hits[0].gameObject, pointer, ExecuteEvents.pointerClickHandler);
        }
    }
}
