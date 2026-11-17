using System;
using System.IO;
using Dreamy.Datasave;
using Dreamy.Tutorial;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;

namespace Dreamy.Template.Tests
{
    public sealed class DreamyTutorialIntegrationTests
    {
        [Test]
        public void AcceptedSignalPersistsCheckpoint_RejectsStaleSignal_CompletedFlowDoesNotReplay()
        {
            string directory = Path.Combine(Path.GetTempPath(),"bus-fever-tutorial-"+Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            try
            {
                var catalog = JsonConvert.DeserializeObject<TutorialCatalogConfig>(Resources.Load<TextAsset>("DataConfig/tutorialCatalog").text);
                var save = new DatasaveService(new DatasaveOptions { DirectoryName = directory });
                var model = new TutorialModel(catalog,save,"test-onboarding");
                Assert.That(model.TryStart("level-one"),Is.EqualTo(TutorialResult.Started));
                var first = model.GetState(); model.SetTargetAvailable(first.StepToken,true);
                using var stale = new TutorialSignalHandle(model,first.Step.SignalKey);
                Assert.That(model.ReportSignal("wrong",first.StepToken),Is.EqualTo(TutorialResult.InvalidAction));
                Assert.That(model.GetState().Step.Id,Is.EqualTo(first.Step.Id));
                using (var accepted = new TutorialSignalHandle(model,first.Step.SignalKey)) accepted.ReportSuccess();
                Assert.That(stale.ReportSuccess(),Is.EqualTo(TutorialResult.InvalidToken));
                var reloaded = new TutorialModel(catalog,new DatasaveService(new DatasaveOptions { DirectoryName = directory }),"test-onboarding");
                reloaded.TryStart("level-one");
                Assert.That(reloaded.GetState().Step.Id,Is.Not.EqualTo(first.Step.Id));
                for (int i = 0; i < 10 && reloaded.GetState().Step != null; i++)
                {
                    var state = reloaded.GetState(); reloaded.SetTargetAvailable(state.StepToken,true);
                    using var signal = new TutorialSignalHandle(reloaded,state.Step.SignalKey); signal.ReportSuccess();
                }
                var completed = new TutorialModel(catalog,new DatasaveService(new DatasaveOptions { DirectoryName = directory }),"test-onboarding");
                Assert.That(completed.TryStart("level-one"),Is.EqualTo(TutorialResult.AlreadyCompleted));
            }
            finally { Directory.Delete(directory,true); }
        }
    }
}
