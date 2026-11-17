using System;
using Dreamy.Tutorial;

namespace Dreamy.Template.Gameplay
{
    public interface IGameplayTutorialView { void RenderTutorial(string vehicleId); }

    /// <summary>Game adapter only. Dreamy owns tokens, cursor, persistence, pending retry and terminal status.</summary>
    public sealed class GameplayTutorialBridge : IDisposable
    {
        private readonly ITutorialService service;
        private readonly TutorialCatalogConfig catalog;
        private readonly IGameplayView view;
        private float retryDelay;
        public GameplayTutorialBridge(ITutorialService service, TutorialCatalogConfig catalog, IGameplayView view)
        { this.service = service; this.catalog = catalog; this.view = view; }
        public void Show()
        {
            if (service == null) return;
            service.StateChanged += Render;
            service.TryStart("level-one");
            if (service.GetState().Status == TutorialStatus.Suspended) service.Resume();
            Ready(); Render();
        }
        private void Ready()
        {
            var state = service.GetState();
            if (state.Status == TutorialStatus.WaitingForTarget) service.SetTargetAvailable(state.StepToken,true);
        }
        public bool Allows(string id)
        {
            if (service == null) return true;
            var state = service.GetState();
            if (state.CanRetry || state.Status == TutorialStatus.Suspended) return false;
            if (state.Step == null) return state.ErrorCode == TutorialErrorCode.None;
            if (state.Step.TargetId == id) return state.Status == TutorialStatus.ActiveStep;
            // Recreated boards retain all cars: permit already-taught prerequisites without replaying checkpoints.
            foreach (var flow in catalog.Flows)
                if (flow.Id == state.FlowId)
                    foreach (var step in flow.Steps)
                    { if (step.Id == state.Step.Id) return false; if (step.TargetId == id) return true; }
            return false;
        }
        public TutorialSignalHandle Capture(string id)
        {
            var state = service?.GetState();
            return state?.Step?.TargetId == id && state.Status == TutorialStatus.ActiveStep
                ? new TutorialSignalHandle(service,state.Step.SignalKey) : null;
        }
        public void Accepted(TutorialSignalHandle signal)
        {
            if (service == null) return;
            signal?.ReportSuccess(); Ready(); Render();
        }
        public void SetPaused(bool paused)
        { if (service == null) return; if (paused) service.Suspend(); else { service.Resume(); Ready(); } }
        public void Tick(float delta)
        {
            if (service == null || !service.GetState().CanRetry) return;
            retryDelay += delta; if (retryDelay < 1) return; retryDelay = 0;
            var pending = ((ITutorialPersistence)service).PendingOperation;
            if (pending != null) ((ITutorialPersistence)service).RetryPending(pending.Id);
            Ready(); Render();
        }
        private void Render()
        {
            var state = service.GetState();
            (view as IGameplayTutorialView)?.RenderTutorial(state.Step?.TargetId);
            if (state.CanRetry) view.ShowMessage("Saving tutorial… retrying");
        }
        public void Dispose()
        {
            if (service == null) return;
            service.StateChanged -= Render; service.Suspend();
            (view as IGameplayTutorialView)?.RenderTutorial(null);
        }
    }
}
