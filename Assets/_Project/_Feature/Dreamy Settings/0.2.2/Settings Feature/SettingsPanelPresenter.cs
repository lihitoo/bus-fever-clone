using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Dreamy.SDK;
using Dreamy.UI;

namespace Dreamy.Feature.Settings.Integration
{
    /// <summary>Project SDK actions extend the package presenter without putting vendor calls in the view.</summary>
    public sealed class SettingsPanelPresenter : IPanelPresenter
    {
        private readonly IPanelPresenter settings;
        private readonly SettingsPanel view;
        private CancellationTokenSource lifetime;
        private bool busy;
        private readonly Action restart;
        private readonly Action home;

        public SettingsPanelPresenter(IPanelPresenter settings, SettingsPanel view, Action restart = null, Action home = null)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.restart = restart;
            this.home = home;
        }

        public void Show()
        {
            if (lifetime != null) return;
            lifetime = new CancellationTokenSource();
            view.ExternalActionRequested += Request;
            view.RestartRequested += Restart;
            view.HomeRequested += Home;
            settings.Show();
        }
        public void Dispose()
        {
            view.ExternalActionRequested -= Request;
            view.RestartRequested -= Restart;
            view.HomeRequested -= Home;
            lifetime?.Cancel(); lifetime?.Dispose(); lifetime = null;
            settings.Dispose();
        }
        private void Request(SettingsExternalAction action)
        {
            if (lifetime == null || busy) return;
            RunAsync(action, lifetime.Token).Forget();
        }
        private void Restart()
        {
            if (restart != null) restart();
            else view.RenderOperationStatus("No gameplay session active");
        }
        private void Home() => home?.Invoke();
        private async UniTask RunAsync(SettingsExternalAction action, CancellationToken token)
        {
            busy = true;
            try
            {
                SDKResult result;
                switch (action)
                {
                    case SettingsExternalAction.Contact: result = await DreamySDK.OpenContactAsync(token); break;
                    case SettingsExternalAction.Terms: result = await DreamySDK.OpenTermsAsync(token); break;
                    case SettingsExternalAction.Privacy: result = await DreamySDK.OpenPrivacyAsync(token); break;
                    default: result = await DreamySDK.RestorePurchasesAsync(token); break;
                }
                if (!token.IsCancellationRequested) view.RenderOperationStatus(result.Message);
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested) { }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogException(exception);
                if (!token.IsCancellationRequested) view.RenderOperationStatus("SDK operation failed");
            }
            finally { busy = false; }
        }
    }

    public enum SettingsExternalAction { Contact, Terms, Privacy, Restore }
}
