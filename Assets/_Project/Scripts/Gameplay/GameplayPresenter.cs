using System;
using Dreamy.UI;

namespace Dreamy.Template.Gameplay
{
    public sealed class GameplayPresenter : IPanelPresenter
    {
        private readonly IGameplayView view;
        private readonly PuzzleDefinition definition;
        private readonly PuzzleSession session;
        private readonly Action restart;
        private readonly Action openHome;
        private readonly Action<Action> openPause;
        private readonly float[] motionTime;
        private float boardingTime;
        private bool bound;
        private readonly GameplayTutorialBridge tutorial;
        private readonly Action<PuzzleSession> completed;
        private bool completionReported;
        private readonly PuzzleFeedback feedback;

        public GameplayPresenter(IGameplayView view, PuzzleDefinition definition, PuzzleSession session,
            Action restart, Action openHome, Action<Action> openPause, GameplayTutorialBridge tutorial, Action<PuzzleSession> completed, PuzzleFeedback feedback)
        {
            this.view = view; this.definition = definition; this.session = session;
            this.restart = restart; this.openHome = openHome; this.openPause = openPause;
            motionTime = new float[session.Vehicles.Count];
            this.tutorial = tutorial;
            this.completed = completed;
            this.feedback = feedback;
        }

        public void Show()
        {
            if (bound) return;
            bound = true;
            view.VehicleRequested += Dispatch;
            view.RestartRequested += restart;
            view.HomeRequested += openHome;
            view.PauseRequested += Pause;
            view.Tick += Update;
            view.Initialize(definition, session.Vehicles);
            tutorial.Show();
            Render();
        }

        public void Dispose()
        {
            if (!bound) return;
            bound = false;
            view.VehicleRequested -= Dispatch;
            view.RestartRequested -= restart;
            view.HomeRequested -= openHome;
            view.PauseRequested -= Pause;
            view.Tick -= Update;
            tutorial.Dispose();
            feedback.Dispose();
            view.Clear();
        }

        private void Dispatch(string id)
        {
            if (!tutorial.Allows(id)) return;
            using var signal = tutorial.Capture(id);
            switch (session.TryDispatch(id))
            {
                case DispatchResult.Blocked: feedback.Play(PuzzleCue.Blocked); view.ShowMessage("Vehicle blocked"); break;
                case DispatchResult.NoParking: view.ShowMessage("No spots available"); break;
                case DispatchResult.Accepted:
                    feedback.Play(PuzzleCue.Dispatch);
                    tutorial.Accepted(signal);
                    view.ShowMessage(""); break;
            }
            Render();
        }

        private void Pause()
        {
            if (session.Paused || !bound) return;
            session.Paused = true;
            feedback.Pause(true);
            tutorial.SetPaused(true);
            view.SetPaused(true);
            openPause(() =>
            {
                if (!bound) return;
                session.Paused = false;
                feedback.Pause(false);
                tutorial.SetPaused(false);
                view.SetPaused(false);
            });
        }

        private void Update(float delta)
        {
            if (!bound || session.Paused || session.IsComplete) return;
            tutorial.Tick(delta);
            // Presentation durations are provisional tuning, not recovered source timings.
            for (int i = 0; i < session.Vehicles.Count; i++)
            {
                var vehicle = session.Vehicles[i];
                if (vehicle.State != VehicleState.Driving && vehicle.State != VehicleState.Departing) { motionTime[i] = 0; continue; }
                motionTime[i] += delta;
                if (motionTime[i] < definition.Motion.TravelDuration) continue;
                motionTime[i] = 0;
                if (vehicle.State == VehicleState.Driving) session.Arrive(vehicle.Definition.Id);
                else session.FinishDeparture(vehicle.Definition.Id);
            }
            boardingTime += delta;
            if (boardingTime >= definition.Motion.BoardingInterval)
            {
                boardingTime = 0;
                if (session.TryBoardNext(out string id, out var color))
                {
                    view.BoardPassenger(id,color); feedback.Play(PuzzleCue.Boarding);
                    foreach (var vehicle in session.Vehicles)
                        if (vehicle.Definition.Id == id && vehicle.State == VehicleState.Departing) feedback.Play(PuzzleCue.Full);
                }
            }
            Render();
        }

        private void Render()
        {
            view.Render(session.Vehicles, session.PassengerCount, session.IsComplete);
            if (session.IsComplete && !completionReported) { completionReported = true; feedback.Play(PuzzleCue.Win); completed?.Invoke(session); }
        }
    }
}
