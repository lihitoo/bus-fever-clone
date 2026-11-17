using System;
using Dreamy.Progression;

namespace Dreamy.Template.Gameplay
{
    /// <summary>Host win validation; Dreamy Progression owns durable advancement, reward intent and recovery.</summary>
    public sealed class WinLevelService
    {
        private readonly IProgressionService progression;
        private readonly IProgressionRewardService rewards;
        private readonly ProgressionCatalogConfig catalog;
        public WinLevelService(IProgressionService progression, IProgressionRewardService rewards, ProgressionCatalogConfig catalog = null)
        { this.progression = progression; this.rewards = rewards; this.catalog = catalog; }
        public long CoinReward(int wonLevel)
        {
            if (catalog == null) return 0;
            foreach (var entry in catalog.Levels)
                if (entry.Level == wonLevel + 1 && entry.HasReward && !entry.IsBundle &&
                    entry.Reward.ResourceId.Equals(new Dreamy.Economy.ResourceId("currency.coin"))) return entry.Reward.Amount;
            return 0;
        }
        public bool Record(PuzzleSession session)
        {
            if (session == null || !session.IsComplete) return false;
            if (rewards.RequiresReload) rewards.Reload();
            var state = progression.GetState();
            if (state.CurrentLevel < session.LevelNumber) return false;
            if (state.CurrentLevel == session.LevelNumber)
            {
                var result = progression.AdvanceNext("bus-fever.win.level-" + session.LevelNumber);
                if (!result.Succeeded && result.Status != ProgressionAdvanceStatus.AlreadyProcessed) return false;
            }
            rewards.RetryPendingRewards();
            return true;
        }
        public bool RewardDelivered(int wonLevel)
        {
            foreach (var reward in rewards.GetRewardStates())
                if (reward.Level == wonLevel + 1) return reward.Status == ProgressionRewardStatus.Delivered;
            return progression.GetState().CurrentLevel > wonLevel;
        }
    }
}
