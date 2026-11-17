using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dreamy.Template
{
    public class UILoadingScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private Image progressBarFill;
        [SerializeField] private TMP_Text loadingText;
        [SerializeField] private Animator animator;
        [SerializeField] private Animator nativeTransition;
        private static readonly int NativeShow = Animator.StringToHash("Show");
        private static readonly int NativeEnter = Animator.StringToHash("Base Layer.Effect_SkyTransition");
        private static readonly int NativeCovered = Animator.StringToHash("Effect_SkyTransitionStay");
        private static readonly int NativeIdle = Animator.StringToHash("Ani_SkyTransition_Idle");

        [SerializeField] private float progressAnimDuration = 0.3f;
        [SerializeField] private int loadingTextDelayMs = 300;

        private float currentPercent;
        private CancellationTokenSource cts;
        private DG.Tweening.Tween progressTween;

        private readonly string[] loadingTexts = { "Loading", "Loading.", "Loading..", "Loading..." };

        private void Awake()
        {
            progressBarFill.fillAmount = 0;
        }

        public void Show()
        {
            gameObject.SetActive(true);

            CancelLoadingTask();

            cts = CancellationTokenSource.CreateLinkedTokenSource(
                this.GetCancellationTokenOnDestroy()
            );

            if (nativeTransition != null)
            {
                nativeTransition.updateMode = AnimatorUpdateMode.UnscaledTime;
                nativeTransition.SetBool(NativeShow, true);
                nativeTransition.Play(NativeEnter, 0, 0);
                nativeTransition.Update(0);
                return;
            }

            ShowLoading(cts.Token).Forget();

            currentPercent = 0;
            progressBarFill.fillAmount = 0;
            progressText.text = "0%";
        }

        public void Hide()
        {
            if (nativeTransition != null)
            {
                nativeTransition.SetBool(NativeShow, false);
                RevealNativeAsync(cts.Token).Forget();
                return;
            }
            CancelLoadingTask();
            animator.SetTrigger("Close");
        }

        public async UniTask WaitUntilCoveredAsync(CancellationToken token)
        {
            if (nativeTransition == null)
            {
                await UniTask.Delay(150, ignoreTimeScale: true, cancellationToken: token);
                return;
            }
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(token, this.GetCancellationTokenOnDestroy());
            using var timer = timeout.CancelAfterSlim(TimeSpan.FromSeconds(3), DelayType.UnscaledDeltaTime);
            await UniTask.WaitUntil(() => nativeTransition.GetCurrentAnimatorStateInfo(0).shortNameHash == NativeCovered,
                cancellationToken: timeout.Token);
        }

        private async UniTask RevealNativeAsync(CancellationToken token)
        {
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(token);
            using var timer = timeout.CancelAfterSlim(TimeSpan.FromSeconds(3), DelayType.UnscaledDeltaTime);
            try
            {
                await UniTask.WaitUntil(() => nativeTransition.GetCurrentAnimatorStateInfo(0).shortNameHash == NativeIdle,
                    cancellationToken: timeout.Token);
                Deactive();
            }
            catch (OperationCanceledException)
            {
                if (!token.IsCancellationRequested)
                {
                    Debug.LogError("Native loading transition did not reach its idle state.", this);
                    Deactive();
                }
            }
        }

        public void Deactive()
        {
            CancelLoadingTask();
            gameObject.SetActive(false);
        }

        private void CancelLoadingTask()
        {
            progressTween?.Kill();
            cts?.Cancel();
            cts?.Dispose();
            cts = null;
        }

        public void SetProgress(float progress)
        {
            if (nativeTransition != null) return;
            progress = Mathf.Clamp01(progress);

            progressTween?.Kill();

            progressTween = DOVirtual.Float(
                currentPercent,
                progress,
                progressAnimDuration,
                value =>
                {
                    currentPercent = value;
                    progressBarFill.fillAmount = value;
                    progressText.text = Mathf.RoundToInt(value * 100) + "%";
                }
            );
        }

        private async UniTask ShowLoading(CancellationToken token)
        {
            int index = 0;

            while (!token.IsCancellationRequested)
            {
                loadingText.text = loadingTexts[index];
                index = (index + 1) % loadingTexts.Length;

                await UniTask.Delay(loadingTextDelayMs, cancellationToken: token);
            }
        }

        private void OnDestroy()
        {
            CancelLoadingTask();
            progressTween?.Kill();
        }
    }
}
