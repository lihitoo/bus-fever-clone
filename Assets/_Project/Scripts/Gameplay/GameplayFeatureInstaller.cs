using System;
using Dreamy.UI;
using VContainer;

namespace Dreamy.Template.Gameplay
{
    /// <summary>One VContainer per puzzle session. Only this root resolves; views/domain have no container access.</summary>
    public static class GameplayFeatureInstaller
    {
        public static IPanelPresenter Install(IGameplayView view, PuzzleDefinition definition,
            Action restart, Action home, Action<Action> pause,
            Dreamy.Tutorial.ITutorialService tutorial = null, Dreamy.Tutorial.TutorialCatalogConfig tutorialCatalog = null,
            Action<PuzzleSession> completed = null, Dreamy.Audio.IAudioService audio = null, Dreamy.Feedback.IHapticService haptics = null,
            Dreamy.Feedback.IVfxService effects = null)
        {
            if (view is IGameplayFxView fxView) fxView.BindEffects(effects);
            var builder = new ContainerBuilder();
            builder.RegisterInstance(definition);
            builder.Register<PuzzleSession>(Lifetime.Scoped);
            builder.RegisterInstance(view);
            builder.RegisterInstance(new GameplayTutorialBridge(tutorial,tutorialCatalog,view));
            builder.RegisterInstance(new PuzzleFeedback(audio,haptics));
            builder.Register<GameplayPresenter>(Lifetime.Scoped)
                .WithParameter("restart", restart).WithParameter("openHome", home).WithParameter("openPause", pause)
                .WithParameter("completed",completed);
            var scope = builder.Build();
            try { return new SessionLifetime(scope, scope.Resolve<GameplayPresenter>()); }
            catch { scope.Dispose(); throw; }
        }

        private sealed class SessionLifetime : IPanelPresenter
        {
            private readonly IObjectResolver scope;
            private readonly GameplayPresenter presenter;
            private bool disposed;
            public SessionLifetime(IObjectResolver scope, GameplayPresenter presenter) { this.scope = scope; this.presenter = presenter; }
            public void Show() { if (!disposed) presenter.Show(); }
            public void Dispose()
            {
                if (disposed) return;
                disposed = true;
                // Unbind and release world objects before the container disposes its session graph.
                presenter.Dispose();
                scope.Dispose();
            }
        }
    }
}
