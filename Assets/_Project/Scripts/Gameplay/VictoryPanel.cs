using System;
using Dreamy.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Cysharp.Threading.Tasks;
using Dreamy.Economy;
using Dreamy.Feedback;

namespace Dreamy.Template.Gameplay
{
    public sealed class VictoryPanel : UIPanel
    {
        [SerializeField] private Button nextButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private TMP_Text status;
        [SerializeField] private GameObject rewardRoot;
        [SerializeField] private TMP_Text rewardText;
        [SerializeField] private TMP_Text balanceText;
        [SerializeField] private RectTransform balanceTarget;
        [SerializeField] private Sprite coinIcon;
        public event Action NextRequested;
        public event Action HomeRequested;
        public override bool CanBack => false;
        public override bool CanCache => false;
        private void OnEnable() { nextButton.onClick.AddListener(Next); homeButton.onClick.AddListener(Home); }
        protected override void OnDisable()
        { nextButton.onClick.RemoveListener(Next); homeButton.onClick.RemoveListener(Home); base.OnDisable(); }
        private void Next() => NextRequested?.Invoke();
        private void Home() => HomeRequested?.Invoke();
        public void RenderStatus(string message) => status.text = message;
        public void RenderBalance(long amount) => balanceText.text = amount.ToString();
        public FeedbackHandle FlyReward(IIconFlyService service)
        {
            if (service == null || coinIcon == null) return default;
            var options = IconFlyOptions.Create(coinIcon, rewardRoot.transform.position, balanceTarget.position);
            options.Count = 12; options.Target = balanceTarget;
            return service.Fly(options);
        }
        public void SetHomeAvailable(bool value) => homeButton.gameObject.SetActive(value);
        public void RenderReward(long amount)
        {
            rewardRoot.SetActive(amount > 0);
            rewardText.text = amount.ToString();
        }
    }

    public sealed class VictoryPresenter : IPanelPresenter
    {
        private readonly VictoryPanel view;
        private readonly WinLevelService wins;
        private readonly PuzzleSession session;
        private readonly Action home;
        private readonly Action next;
        private bool bound;
        private readonly IResourceBalanceProvider balance;
        private readonly IIconFlyService iconFly;
        private CancellationTokenSource lifetime;
        private FeedbackHandle transfer;
        private bool leaving;
        private long displayedBalance;
        private static readonly ResourceId Coin = new("currency.coin");
        public VictoryPresenter(VictoryPanel view, WinLevelService wins, PuzzleSession session, Action home, Action next,
            IResourceBalanceProvider balance, IIconFlyService iconFly)
        { this.view = view; this.wins = wins; this.session = session; this.home = home; this.next = next;
            this.balance = balance; this.iconFly = iconFly; }
        public void Show()
        {
            if (bound) return; bound = true;
            lifetime = new CancellationTokenSource();
            displayedBalance = balance.GetBalance(Coin); view.RenderBalance(displayedBalance);
            view.SetHomeAvailable(next == null);
            view.NextRequested += Next; view.HomeRequested += Home;
            Render();
        }
        private void Render()
        {
            view.RenderReward(wins.CoinReward(session.LevelNumber));
            bool saved = wins.Record(session);
            view.RenderStatus(!saved ? "Could not save result. Tap Next to retry." : wins.RewardDelivered(session.LevelNumber)
                ? (next != null ? "" : "Next level content is not available yet.") : "Reward pending. Tap Next to retry delivery.");
        }
        private void Next()
        {
            if (leaving || !bound) return;
            if (wins.Record(session) && wins.RewardDelivered(session.LevelNumber) && next != null)
            { leaving = true; LeaveAsync(next, lifetime.Token).Forget(); }
            else Render();
        }
        private void Home()
        {
            if (leaving || !bound) return;
            if (wins.Record(session) && wins.RewardDelivered(session.LevelNumber))
            { leaving = true; LeaveAsync(home, lifetime.Token).Forget(); }
            else Render();
        }
        private async UniTask LeaveAsync(Action leave, CancellationToken token)
        {
            try
            {
                long confirmedBalance = balance.GetBalance(Coin);
                if (confirmedBalance > displayedBalance)
                {
                    transfer = view.FlyReward(iconFly);
                    await transfer.Completion.AsUniTask().AttachExternalCancellation(token);
                }
                token.ThrowIfCancellationRequested();
                view.RenderBalance(confirmedBalance);
                leave();
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested) { }
            catch (Exception exception)
            { if (bound) { leaving=false; view.RenderStatus("Could not finish presentation. Tap Next to retry."); } Debug.LogException(exception); }
        }
        public void Dispose()
        {
            if (!bound) return; bound = false;
            lifetime.Cancel(); transfer.Stop(); lifetime.Dispose(); lifetime=null;
            view.NextRequested -= Next; view.HomeRequested -= Home;
        }
    }
}
