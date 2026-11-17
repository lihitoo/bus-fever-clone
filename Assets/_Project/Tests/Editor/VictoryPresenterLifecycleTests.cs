using System;
using System.IO;
using System.Reflection;
using System.Collections;
using Dreamy.Datasave;
using Dreamy.Economy;
using Dreamy.Feedback;
using Dreamy.Progression;
using Dreamy.Template.Gameplay;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Dreamy.Template.Tests
{
    public sealed class VictoryPresenterLifecycleTests
    {
        [UnityTest]
        public IEnumerator FreshWin_CompletedTransferNavigatesOnce() => RunTransfer(true);
        [UnityTest]
        public IEnumerator ClosingVictory_StopsTransferWithoutNavigation() => RunTransfer(false);

        private IEnumerator RunTransfer(bool completeImmediately)
        {
            string directory = Path.Combine(Path.GetTempPath(), "bus-fever-victory-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            GameObject root = null;
            VictoryPresenter presenter = null;
            try
            {
                var config = JsonConvert.DeserializeObject<ProgressionCatalogConfig>(Resources.Load<TextAsset>("DataConfig/progressionCatalog").text);
                config.Initialize("progressionCatalog");
                var save = new DatasaveService(new DatasaveOptions { DirectoryName = directory });
                var wallet = new DatasaveResourceWallet(save);
                var model = new ProgressionModel(config,save,(IResourceWallet)wallet,"test-progression");
                var session = new PuzzleSession(new PuzzleDefinition { Id="test", Columns=2, Rows=2, ParkingCount=1,
                    Vehicles=new[] { new VehicleDefinition { Id="blue", Color=VehicleColor.Blue, Direction=ExitDirection.Up, Length=1, Capacity=1 } },
                    Passengers=new[] { VehicleColor.Blue } });
                session.TryDispatch("blue"); session.Arrive("blue"); session.TryBoardNext(out _,out _); session.FinishDeparture("blue");
                root = UnityEngine.Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/Prefabs/Panel/VictoryPanel.prefab"));
                var fx = new TransferFixture(completeImmediately);
                int navigations = 0;
                presenter = new VictoryPresenter(root.GetComponent<VictoryPanel>(),new WinLevelService(model,model,config),session,
                    () => navigations++, () => navigations++, wallet, fx);
                presenter.Show();
                Assert.That(wallet.GetBalance(new ResourceId("currency.coin")),Is.EqualTo(20));
                var next = typeof(VictoryPresenter).GetMethod("Next",BindingFlags.Instance|BindingFlags.NonPublic);
                next.Invoke(presenter,null); next.Invoke(presenter,null);
                Assert.That(fx.Calls,Is.EqualTo(1));
                if (completeImmediately)
                {
                    double deadline = UnityEditor.EditorApplication.timeSinceStartup + 3;
                    while (navigations == 0 && UnityEditor.EditorApplication.timeSinceStartup < deadline) yield return null;
                }
                Assert.That(navigations,Is.EqualTo(completeImmediately ? 1 : 0));
                presenter.Dispose(); presenter.Dispose();
                if (!completeImmediately)
                {
                    Assert.That(fx.Playback.Status,Is.EqualTo(FeedbackStatus.Stopped));
                    fx.Playback.Finish();
                    yield return null;
                    Assert.That(navigations,Is.Zero,"Closed panel must not navigate after animation ends");
                }
                Assert.That(wallet.GetBalance(new ResourceId("currency.coin")),Is.EqualTo(20));
            }
            finally
            {
                presenter?.Dispose();
                if (root != null) UnityEngine.Object.DestroyImmediate(root);
                Directory.Delete(directory,true);
            }
        }

        private sealed class TransferFixture : IIconFlyService
        {
            private readonly bool immediate;
            public int Calls;
            public readonly FeedbackPlayback Playback = new();
            public TransferFixture(bool immediate) => this.immediate=immediate;
            public FeedbackHandle Fly(IconFlyOptions options)
            {
                Calls++;
                Assert.That(options.Icon,Is.Not.Null);
                Assert.That(options.Target,Is.Not.Null);
                if (immediate) Playback.Finish();
                return Playback.Handle;
            }
            public void Clear() => Playback.Stop();
        }
    }
}
