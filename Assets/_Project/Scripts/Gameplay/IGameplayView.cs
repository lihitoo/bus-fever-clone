using System;
using System.Collections.Generic;

namespace Dreamy.Template.Gameplay
{
    public interface IGameplayFxView
    {
        void BindEffects(Dreamy.Feedback.IVfxService effects);
    }

    public interface IGameplayView
    {
        event Action<string> VehicleRequested;
        event Action RestartRequested;
        event Action PauseRequested;
        event Action HomeRequested;
        event Action<float> Tick;
        void Initialize(PuzzleDefinition definition, IReadOnlyList<VehicleReadModel> vehicles);
        void Render(IReadOnlyList<VehicleReadModel> vehicles, int passengers, bool complete);
        void BoardPassenger(string vehicleId, VehicleColor color);
        void ShowMessage(string message);
        void SetPaused(bool paused);
        void Clear();
    }
}
