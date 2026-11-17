using System;
using Cysharp.Threading.Tasks;
using Dreamy.Feature.Settings.Integration;
using Dreamy.Template.Gameplay;
using Dreamy.UI;
using UnityEngine;
using Dreamy.Template.Home;

namespace Dreamy.Template
{
    public sealed partial class GameInstaller
    {
        private bool gameplayTransitioning;
        private int selectedLevel;

        private void InstallGameplayPresentation()
        {
            var catalog = dataConfig.GetTable<PuzzleCatalog>();
            presenterFactory.Register<GameplayPanel>(view => GameplayFeatureInstaller.Install(view, catalog.Find(selectedLevel),
                () => NavigateGameplayAsync(true).Forget(),
                () => NavigateGameplayAsync(false).Forget(),
                resume => ShowGameplayPauseAsync(view, resume).Forget(), selectedLevel == 1 ? tutorialService : null,
                dataConfig.GetTable<Dreamy.Tutorial.TutorialCatalogConfig>(), session => ShowVictoryAsync(session).Forget(),
                Dreamy.Audio.DreamyAudio.Service, feedbackHost.Haptic, feedbackHost.Vfx));
        }

        private void RestartGameplay()
        {
            if (PanelManager.Instance.TryGet<GameplayPanel>(out var panel) && panel.gameObject.activeInHierarchy)
                NavigateGameplayAsync(true).Forget();
        }

        private async UniTask NavigateGameplayAsync(bool gameplay)
        {
            if (gameplayTransitioning || State != BootstrapState.Ready) return;
            gameplayTransitioning = true;
            try
            {
                if (gameplay && selectedLevel == 0)
                    selectedLevel = dataConfig.GetTable<PuzzleCatalog>().Find(progression.GetState().CurrentLevel) != null
                        ? progression.GetState().CurrentLevel : 1;
                Dreamy.Audio.DreamyAudio.Play(new Dreamy.Audio.AudioKey("core","level.switch"));
                await SceneLoader.Instance.TransitionContentAsync(async () =>
                {
                    var manager = PanelManager.Instance;
                    await manager.Close<VictoryPanel>();
                    await manager.Close<SettingsPanel>();
                    await manager.Close<GameplayPanel>();
                    await manager.Close<HomePanel>();
                    // Noncached panels use Unity's deferred Destroy. Let the old instance leave
                    // the manager before Create can reuse the same panel type on Restart.
                    await UniTask.NextFrame(cancellationToken: initializationCancellation.Token);
                    if (gameplay) await manager.Show<GameplayPanel>(Address.GameplayPanel);
                    else { selectedLevel = 0; await manager.Show<HomePanel>(Address.HomePanel); }
                }, initializationCancellation.Token);
            }
            catch (OperationCanceledException) { }
            catch (Exception exception) { Debug.LogException(exception, this); }
            finally { gameplayTransitioning = false; }
        }

        private async UniTask ShowGameplayPauseAsync(GameplayPanel owner, Action resume)
        {
            try
            {
                var token = owner.GetCancellationTokenOnDestroy();
                var panel = await PanelManager.Instance.Show<SettingsPanel>(Address.PauseSettingsPanel);
                await UniTask.WaitUntil(() => panel == null || !panel.gameObject.activeInHierarchy,
                    cancellationToken: token);
            }
            catch (OperationCanceledException) { }
            catch (Exception exception) { Debug.LogException(exception, this); }
            finally { resume(); }
        }
    }
}
