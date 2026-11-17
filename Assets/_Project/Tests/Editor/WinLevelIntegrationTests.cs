using System;
using System.IO;
using Dreamy.Datasave;
using Dreamy.Economy;
using Dreamy.Progression;
using Dreamy.Template.Gameplay;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;

namespace Dreamy.Template.Tests
{
    public sealed class WinLevelIntegrationTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void SaveFailure_RetryReloadsDurableState_AndDeliversOnce(bool afterWrite)
        {
            string directory = Path.Combine(Path.GetTempPath(), "bus-fever-fault-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            try
            {
                var config = JsonConvert.DeserializeObject<ProgressionCatalogConfig>(Resources.Load<TextAsset>("DataConfig/progressionCatalog").text);
                config.Initialize("progressionCatalog");
                var save = new FaultStore(new DatasaveService(new DatasaveOptions { DirectoryName = directory }));
                var wallet = new DatasaveResourceWallet(save);
                var model = new ProgressionModel(config, save, (IResourceWallet)wallet, "test-progression");
                var wins = new WinLevelService(model, model, config);
                var session = new PuzzleSession(new PuzzleDefinition { Id="test", Columns=2, Rows=2, ParkingCount=1,
                    Vehicles=new[] { new VehicleDefinition { Id="blue", Color=VehicleColor.Blue, Direction=ExitDirection.Up, Length=1, Capacity=1 } },
                    Passengers=new[] { VehicleColor.Blue } });
                session.TryDispatch("blue"); session.Arrive("blue"); session.TryBoardNext(out _,out _); session.FinishDeparture("blue");
                save.AfterWrite = afterWrite; save.FailNext = true;
                Assert.That(wins.Record(session), Is.False);
                Assert.That(model.RequiresReload, Is.True);
                Assert.That(wallet.GetBalance(new ResourceId("currency.coin")), Is.Zero);
                Assert.That(wins.Record(session), Is.True);
                Assert.That(wins.Record(session), Is.True);
                Assert.That(wins.RewardDelivered(1), Is.True);
                Assert.That(model.GetState().CurrentLevel, Is.EqualTo(2));
                Assert.That(wallet.GetBalance(new ResourceId("currency.coin")), Is.EqualTo(20));
            }
            finally { Directory.Delete(directory, true); }
        }

        private sealed class FaultStore : IDatasaveService
        {
            private readonly IDatasaveService inner;
            public bool FailNext, AfterWrite;
            public FaultStore(IDatasaveService inner) => this.inner = inner;
            public T Load<T>(string key = null) where T : SaveData, new() => inner.Load<T>(key);
            public void Save<T>(T data, string key = null) where T : SaveData
            {
                bool fail = FailNext && key == "test-progression";
                if (fail) FailNext = false;
                if (fail && !AfterWrite) throw new IOException("Injected before progression write");
                inner.Save(data, key);
                if (fail) throw new IOException("Injected after progression write");
            }
            public void SaveAll() => inner.SaveAll();
            public bool Exists(string key) => inner.Exists(key);
            public void Delete(string key) => inner.Delete(key);
            public void DeleteAll() => inner.DeleteAll();
        }

        [Test]
        public void OnlyWonSessionAdvances_RepeatAndReloadNeverDuplicateTwentyCoins()
        {
            string directory = Path.Combine(Path.GetTempPath(),"bus-fever-win-"+Guid.NewGuid().ToString("N")); Directory.CreateDirectory(directory);
            try
            {
                var config = JsonConvert.DeserializeObject<ProgressionCatalogConfig>(Resources.Load<TextAsset>("DataConfig/progressionCatalog").text);
                config.Initialize("progressionCatalog");
                var save = new DatasaveService(new DatasaveOptions { DirectoryName = directory });
                var wallet = new DatasaveResourceWallet(save);
                var model = new ProgressionModel(config,save,(IResourceWallet)wallet,"test-progression");
                var wins = new WinLevelService(model,model,config);
                Assert.That(wins.CoinReward(1),Is.EqualTo(20));
                Assert.That(wins.CoinReward(2),Is.EqualTo(20),"R029 confirms the Level2 victory reward");
                Assert.That(wins.CoinReward(3),Is.Zero,"Unconfigured reward must not display an invented award");
                var session = new PuzzleSession(new PuzzleDefinition { Id="test",Columns=2,Rows=2,ParkingCount=1,
                    Vehicles=new[] { new VehicleDefinition { Id="blue",Color=VehicleColor.Blue,Direction=ExitDirection.Up,Length=1,Capacity=1 } },
                    Passengers=new[] { VehicleColor.Blue } });
                Assert.That(wins.Record(session),Is.False); Assert.That(model.GetState().CurrentLevel,Is.EqualTo(1));
                session.TryDispatch("blue"); session.Arrive("blue"); session.TryBoardNext(out _,out _); session.FinishDeparture("blue");
                Assert.That(wins.Record(session),Is.True); Assert.That(wins.Record(session),Is.True);
                Assert.That(model.GetState().CurrentLevel,Is.EqualTo(2));
                Assert.That(wallet.GetBalance(new ResourceId("currency.coin")),Is.EqualTo(20));
                var reloadedSave = new DatasaveService(new DatasaveOptions { DirectoryName=directory });
                var reloadedWallet = new DatasaveResourceWallet(reloadedSave);
                var reloaded = new ProgressionModel(config,reloadedSave,(IResourceWallet)reloadedWallet,"test-progression");
                var resumed = new WinLevelService(reloaded,reloaded);
                Assert.That(resumed.Record(session),Is.True); Assert.That(resumed.RewardDelivered(1),Is.True);
                Assert.That(reloadedWallet.GetBalance(new ResourceId("currency.coin")),Is.EqualTo(20));
                Assert.That(reloaded.GetState().CurrentLevel,Is.EqualTo(2));
            }
            finally { Directory.Delete(directory,true); }
        }
    }
}
