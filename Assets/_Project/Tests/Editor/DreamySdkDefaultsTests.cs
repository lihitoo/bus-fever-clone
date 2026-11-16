using System;
using System.Threading;
using Dreamy.SDK;
using NUnit.Framework;

namespace Dreamy.Template.Tests
{
    public sealed class DreamySdkDefaultsTests
    {
        [Test]
        public void RestoreDefault_HasNoEntitlements_AndRewardedDefaultHasNoReward()
        {
            var restore = DreamySDK.RestorePurchasesAsync().GetAwaiter().GetResult();
            Assert.That(restore.Status, Is.EqualTo(SDKStatus.Completed));
            Assert.That(restore.RestoredEntitlements, Is.Zero);
            Assert.That(restore.IsTestResult, Is.True);
            Assert.That(DreamySDK.ShowRewardedAdAsync("extra-spot").GetAwaiter().GetResult().Status,
                Is.EqualTo(SDKStatus.Cancelled));
        }

        [Test]
        public void ClosedOwner_CancelsExternalActionsInsteadOfCompleting()
        {
            using var lifetime = new CancellationTokenSource();
            lifetime.Cancel();
            Assert.Throws<OperationCanceledException>(() => DreamySDK.OpenContactAsync(lifetime.Token).GetAwaiter().GetResult());
            Assert.Throws<OperationCanceledException>(() => DreamySDK.RestorePurchasesAsync(lifetime.Token).GetAwaiter().GetResult());
        }
    }
}
