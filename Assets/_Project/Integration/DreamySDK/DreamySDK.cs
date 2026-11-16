using System.Threading;
using Cysharp.Threading.Tasks;

namespace Dreamy.SDK
{
    /// <summary>
    /// Temporary local SDK facade. All methods are test stubs; no vendor SDK or network is invoked.
    /// Replace this integration with the future Dreamy SDK while retaining feature adapters.
    /// </summary>
    public static class DreamySDK
    {
        public static bool IsTestMode => true;
        public static UniTask<SDKResult> OpenContactAsync(CancellationToken token = default)
            => Complete("Contact opened (DreamySDK test stub)", token);
        public static UniTask<SDKResult> OpenTermsAsync(CancellationToken token = default)
            => Complete("Terms opened (DreamySDK test stub)", token);
        public static UniTask<SDKResult> OpenPrivacyAsync(CancellationToken token = default)
            => Complete("Privacy opened (DreamySDK test stub)", token);
        public static UniTask<SDKResult> RestorePurchasesAsync(CancellationToken token = default)
            => Complete("Nothing to restore (DreamySDK test stub)", token);
        public static UniTask<SDKResult> ShowConsentAsync(CancellationToken token = default)
            => Complete("Consent completed (DreamySDK test stub)", token);
        public static UniTask<SDKResult> OpenStoreAsync(CancellationToken token = default)
            => Complete("Store opened (DreamySDK test stub)", token);
        public static UniTask<SDKResult> RequestReviewAsync(CancellationToken token = default)
            => Complete("Review completed (DreamySDK test stub)", token);
        public static UniTask<SDKResult> PurchaseAsync(string productId, CancellationToken token = default)
            => Cancel("Purchase cancelled (DreamySDK test stub)", token);
        public static UniTask<SDKResult> ShowRewardedAdAsync(string placementId, CancellationToken token = default)
            => Cancel("Rewarded ad cancelled (DreamySDK test stub)", token);

        private static UniTask<SDKResult> Complete(string message, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return UniTask.FromResult(new SDKResult(SDKStatus.Completed, message));
        }
        private static UniTask<SDKResult> Cancel(string message, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return UniTask.FromResult(new SDKResult(SDKStatus.Cancelled, message));
        }
    }
}
