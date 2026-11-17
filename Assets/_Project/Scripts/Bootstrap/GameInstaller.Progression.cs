using System;
using Cysharp.Threading.Tasks;
using Dreamy.Core;
using Dreamy.Progression;
using Dreamy.Template.Gameplay;
using Dreamy.UI;
using UnityEngine;

namespace Dreamy.Template
{
    public sealed partial class GameInstaller
    {
        private IProgressionService progression;
        private IProgressionRewardService progressionRewards;
        private WinLevelService wins;
        private PuzzleSession winningSession;
        private void InstallProgression()
        {
            ServiceLocator.TryGet<IProgressionRewardService>(out var previousRewards);
            TrackFeatureInstallation<IProgressionService>(() => progression = ProgressionInstaller.Install(
                dataConfig.GetTable<ProgressionCatalogConfig>(),datasave,wallet,"bus-fever.progression"));
            progressionRewards = (IProgressionRewardService)progression;
            TrackRegistration(progressionRewards,previousRewards,false);
            progressionRewards.RetryPendingRewards();
            wins = new WinLevelService(progression,progressionRewards,dataConfig.GetTable<ProgressionCatalogConfig>());
            presenterFactory.Register<VictoryPanel>(view => new VictoryPresenter(view,wins,winningSession,
                () => NavigateGameplayAsync(false).Forget(),
                dataConfig.GetTable<PuzzleCatalog>().Find(winningSession.LevelNumber+1) == null ? null :
                    () => { if (gameplayTransitioning) return; selectedLevel = winningSession.LevelNumber+1; NavigateGameplayAsync(true).Forget(); },
                (Dreamy.Economy.IResourceBalanceProvider)wallet, feedbackHost.IconFly));
        }
        private async UniTask ShowVictoryAsync(PuzzleSession session)
        {
            if (session == null || !session.IsComplete) return;
            winningSession = session;
            try { await PanelManager.Instance.Show<VictoryPanel>(Address.VictoryPanel); }
            catch (Exception exception) { Debug.LogException(exception,this); }
        }
    }
}
