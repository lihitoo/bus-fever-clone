using System;
using System.Collections.Generic;
using Dreamy.DataConfig;

namespace Dreamy.Template.Gameplay
{
    public enum VehicleColor { Blue, Red, Yellow, Purple, Orange, Pink, Green }
    public enum ExitDirection { Up, Right, Down, Left }

    [Serializable]
    public sealed class PuzzleMotionProfile
    {
        public float TravelDuration { get; set; } = .85f;
        public float BoardingInterval { get; set; } = .12f;
        public float BoardingDuration { get; set; } = .28f;
        public float LoopSpeed { get; set; } = .4f;
    }

    [Serializable]
    public sealed class VehicleDefinition
    {
        public string Id { get; set; }
        public VehicleColor Color { get; set; }
        public ExitDirection Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public int Capacity { get; set; }
        public int Width => Direction == ExitDirection.Left || Direction == ExitDirection.Right ? Length : 1;
        public int Height => Direction == ExitDirection.Up || Direction == ExitDirection.Down ? Length : 1;
    }

    [DataConfig("puzzleLevel")]
    public sealed class PuzzleDefinition : ConfigBase
    {
        public int LevelNumber { get; set; } = 1;
        public string Id { get; set; }
        public string Provenance { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int ParkingCount { get; set; }
        public VehicleDefinition[] Vehicles { get; set; }
        public VehicleColor[] Passengers { get; set; }
        public PuzzleMotionProfile Motion { get; set; } = new();
        public float BoardRotation { get; set; } = 30;
        public float CellSize { get; set; } = .44f;

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id) || Columns < 1 || Rows < 1 || ParkingCount < 1 || ParkingCount > 7)
                throw new ArgumentException("Invalid puzzle dimensions or identity.");
            if (Vehicles == null || Vehicles.Length == 0 || Passengers == null)
                throw new ArgumentException("Puzzle requires vehicles and passengers.");
            if (Motion == null || !Positive(Motion.TravelDuration) || !Positive(Motion.BoardingInterval) ||
                !Positive(Motion.BoardingDuration) || !Positive(Motion.LoopSpeed))
                throw new ArgumentException("Puzzle motion values must be finite and positive.");
            if (!Positive(CellSize) || float.IsNaN(BoardRotation) || float.IsInfinity(BoardRotation))
                throw new ArgumentException("Puzzle presentation dimensions must be finite and valid.");
            var cells = new HashSet<int>();
            var ids = new HashSet<string>(StringComparer.Ordinal);
            var demand = new int[Enum.GetValues(typeof(VehicleColor)).Length];
            foreach (var vehicle in Vehicles)
            {
                if (vehicle == null || string.IsNullOrWhiteSpace(vehicle.Id) || !ids.Add(vehicle.Id) ||
                    vehicle.Length < 1 || vehicle.Capacity < 1 || !Enum.IsDefined(typeof(VehicleColor), vehicle.Color) ||
                    !Enum.IsDefined(typeof(ExitDirection), vehicle.Direction) || vehicle.X < 0 || vehicle.Y < 0 ||
                    vehicle.X + vehicle.Width > Columns || vehicle.Y + vehicle.Height > Rows)
                    throw new ArgumentException("Invalid or duplicate vehicle definition.");
                for (int x = vehicle.X; x < vehicle.X + vehicle.Width; x++)
                    for (int y = vehicle.Y; y < vehicle.Y + vehicle.Height; y++)
                        if (!cells.Add(y * Columns + x)) throw new ArgumentException("Overlapping vehicles.");
                demand[(int)vehicle.Color] += vehicle.Capacity;
            }
            foreach (var color in Passengers)
            {
                if (!Enum.IsDefined(typeof(VehicleColor), color)) throw new ArgumentException("Invalid passenger color.");
                demand[(int)color]--;
            }
            foreach (int remaining in demand)
                if (remaining != 0) throw new ArgumentException("Passenger supply must match vehicle capacities by color.");
        }
        private static bool Positive(float value) => value > 0 && !float.IsInfinity(value) && !float.IsNaN(value);
    }
}
