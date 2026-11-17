using System;
using System.Collections.Generic;

namespace Dreamy.Template.Gameplay
{
    public enum VehicleState { Board, Driving, Parked, Departing, Complete }
    public enum DispatchResult { Accepted, Blocked, NoParking, Unavailable }

    public sealed class VehicleReadModel
    {
        public VehicleDefinition Definition { get; }
        public VehicleState State { get; internal set; }
        public int Slot { get; internal set; } = -1;
        public int Remaining { get; internal set; }
        internal long ArrivalOrder;
        internal VehicleReadModel(VehicleDefinition definition) { Definition = definition; Remaining = definition.Capacity; }
    }

    /// <summary>Session authority. No Unity, container, tween, save, or UI calls.</summary>
    public sealed class PuzzleSession
    {
        private readonly List<VehicleReadModel> vehicles = new();
        private readonly Queue<VehicleColor> passengers;
        private readonly bool[] slots;
        private long arrivalOrder;
        public IReadOnlyList<VehicleReadModel> Vehicles => vehicles;
        public int PassengerCount => passengers.Count;
        public bool Paused { get; set; }
        public bool IsComplete { get; private set; }
        public int LevelNumber { get; }

        public PuzzleSession(PuzzleDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            definition.Validate();
            LevelNumber = definition.LevelNumber;
            // Snapshot authored objects so callers cannot change active occupancy through config references.
            foreach (var source in definition.Vehicles)
                vehicles.Add(new VehicleReadModel(new VehicleDefinition { Id = source.Id, Color = source.Color,
                    Direction = source.Direction, X = source.X, Y = source.Y, Length = source.Length, Capacity = source.Capacity }));
            passengers = new Queue<VehicleColor>(definition.Passengers);
            slots = new bool[definition.ParkingCount];
        }

        public DispatchResult TryDispatch(string id)
        {
            var vehicle = Find(id);
            if (Paused || IsComplete || vehicle == null || vehicle.State != VehicleState.Board) return DispatchResult.Unavailable;
            foreach (var other in vehicles)
                if (other != vehicle && (other.State == VehicleState.Board || other.State == VehicleState.Driving) && Blocks(vehicle.Definition, other.Definition))
                    return DispatchResult.Blocked;
            int slot = Array.FindIndex(slots, reserved => !reserved);
            if (slot < 0) return DispatchResult.NoParking;
            slots[slot] = true; // Reserve synchronously, before presentation starts.
            vehicle.Slot = slot;
            vehicle.State = VehicleState.Driving;
            return DispatchResult.Accepted;
        }

        public bool Arrive(string id)
        {
            var vehicle = Find(id);
            if (Paused || vehicle == null || vehicle.State != VehicleState.Driving) return false;
            vehicle.State = VehicleState.Parked;
            vehicle.ArrivalOrder = ++arrivalOrder;
            return true;
        }

        // Provisional FIFO parking priority; the source's tie-break policy remains an audit gate.
        public bool TryBoardNext(out string vehicleId, out VehicleColor color)
        {
            vehicleId = null; color = default;
            if (Paused || IsComplete || passengers.Count == 0) return false;
            color = passengers.Peek();
            VehicleReadModel target = null;
            foreach (var vehicle in vehicles)
                if (vehicle.State == VehicleState.Parked && vehicle.Definition.Color == color &&
                    (target == null || vehicle.ArrivalOrder < target.ArrivalOrder)) target = vehicle;
            passengers.Dequeue();
            if (target == null) { passengers.Enqueue(color); return false; }
            target.Remaining--;
            vehicleId = target.Definition.Id;
            if (target.Remaining == 0) target.State = VehicleState.Departing;
            return true;
        }

        public bool FinishDeparture(string id)
        {
            var vehicle = Find(id);
            if (Paused || vehicle == null || vehicle.State != VehicleState.Departing) return false;
            slots[vehicle.Slot] = false;
            vehicle.Slot = -1;
            vehicle.State = VehicleState.Complete;
            IsComplete = passengers.Count == 0 && vehicles.TrueForAll(v => v.State == VehicleState.Complete);
            return true;
        }

        private VehicleReadModel Find(string id) => vehicles.Find(v => v.Definition.Id == id);

        private static bool Blocks(VehicleDefinition a, VehicleDefinition b)
        {
            bool sameX = a.X < b.X + b.Width && b.X < a.X + a.Width;
            bool sameY = a.Y < b.Y + b.Height && b.Y < a.Y + a.Height;
            return a.Direction switch
            {
                ExitDirection.Up => sameX && b.Y >= a.Y + a.Height,
                ExitDirection.Down => sameX && b.Y + b.Height <= a.Y,
                ExitDirection.Right => sameY && b.X >= a.X + a.Width,
                ExitDirection.Left => sameY && b.X + b.Width <= a.X,
                _ => true
            };
        }
    }
}
