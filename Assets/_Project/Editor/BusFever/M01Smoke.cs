using System;
using System.IO;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Dreamy.Feature.Settings.Integration;
using Dreamy.Template.Home;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dreamy.Template.Editor
{
    public static class M01Smoke
    {
        public static string Status { get; private set; } = "not-run";
        public static void Start() => RunAsync().Forget();

        private static async UniTask RunAsync()
        {
            Status = "running";
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(90));
            var token = timeout.Token;
            bool? original = null;
            int cycles = 0;
            try
            {
                if (!Application.isPlaying) throw new InvalidOperationException("Run from normal Bootstrap play mode.");
                await UniTask.WaitUntil(() => UnityEngine.Object.FindFirstObjectByType<HomePanel>() != null, cancellationToken: token);
                var home = UnityEngine.Object.FindFirstObjectByType<HomePanel>();
                var settingsButton = home.GetComponentsInChildren<Button>().Single(b => b.name == "Btn_Setting");
                bool expected = false;
                for (int i = 0; i < 20; i++)
                {
                    settingsButton.onClick.Invoke();
                    await UniTask.WaitUntil(() => UnityEngine.Object.FindFirstObjectByType<SettingsPanel>() != null, cancellationToken: token);
                    var panel = UnityEngine.Object.FindFirstObjectByType<SettingsPanel>();
                    await UniTask.Delay(300, cancellationToken: token);
                    var music = panel.GetComponentsInChildren<Toggle>().Single(t => t.name == "Music_Btn");
                    if (i == 0) { original = music.isOn; expected = !music.isOn; music.isOn = expected; }
                    else if (music.isOn != expected) throw new InvalidOperationException("Music lost persisted state on reopen.");
                    foreach (var name in new[] { "Contact_Btn", "Terms_Btn", "Privacy_Btn", "Restore_Btn" })
                    {
                        panel.GetComponentsInChildren<Button>().Single(b => b.name == name).onClick.Invoke();
                        var message = panel.GetComponentsInChildren<TMP_Text>().Single(t => t.name == "OperationStatus").text;
                        if (string.IsNullOrEmpty(message) || !message.Contains("DreamySDK test stub"))
                            throw new InvalidOperationException(name + " did not report a stub SDK result.");
                    }
                    if (i == 19) music.isOn = original.Value;
                    panel.GetComponentsInChildren<Button>().Single(b => b.name == "Btn_Close").onClick.Invoke();
                    await UniTask.WaitUntil(() => UnityEngine.Object.FindFirstObjectByType<SettingsPanel>() == null, cancellationToken: token);
                    cycles++;
                    if (UnityEngine.Object.FindObjectsByType<HomePanel>(FindObjectsSortMode.None).Length != 1)
                        throw new InvalidOperationException("Home duplicated during popup navigation.");
                }
                Status = "pass";
                File.WriteAllText("docs/clone-plan/evidence/M01/runtime-smoke.json", Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    status = Status, cycles, viewport = new[] { Screen.width, Screen.height },
                    checks = new[] { "Normal Bootstrap to Home", "Settings opened/closed 20 times", "Music persisted across reopen and original preference restored", "Contact/Terms/Privacy/Restore emitted explicit SDK stub results", "Exactly one Home panel" },
                    sdk = "test stub, no external app/network/payment", observedAt = DateTime.UtcNow.ToString("O")
                }, Newtonsoft.Json.Formatting.Indented));
            }
            catch (Exception exception)
            {
                Status = "fail";
                // Restore a user preference if interrupted while the view is still open.
                var panel = UnityEngine.Object.FindFirstObjectByType<SettingsPanel>();
                if (panel != null && original.HasValue)
                    panel.GetComponentsInChildren<Toggle>().Single(t => t.name == "Music_Btn").isOn = original.Value;
                File.WriteAllText("docs/clone-plan/evidence/M01/runtime-smoke.json", Newtonsoft.Json.JsonConvert.SerializeObject(new { status = Status, cycles, error = exception.ToString() }, Newtonsoft.Json.Formatting.Indented));
                Debug.LogException(exception);
            }
        }
    }
}
