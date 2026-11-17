using System;
using System.Collections.Generic;
using Dreamy.Template.Gameplay;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;

namespace Dreamy.Template.Tests
{
    public sealed class PuzzleSessionTests
    {
        private static VehicleDefinition Vehicle(string id, int x, int y, ExitDirection direction = ExitDirection.Up, VehicleColor color = VehicleColor.Blue)
            => new() { Id = id, X = x, Y = y, Direction = direction, Color = color, Length = 1, Capacity = 1 };
        private static PuzzleDefinition Definition(int slots, params VehicleDefinition[] vehicles)
        {
            var colors = new List<VehicleColor>();
            foreach (var vehicle in vehicles) for (int i = 0; i < vehicle.Capacity; i++) colors.Add(vehicle.Color);
            return new PuzzleDefinition { Id = "fixture", Columns = 6, Rows = 6, ParkingCount = slots, Vehicles = vehicles, Passengers = colors.ToArray() };
        }

        [TestCase(ExitDirection.Up, 2, 3)]
        [TestCase(ExitDirection.Down, 2, 1)]
        [TestCase(ExitDirection.Right, 3, 2)]
        [TestCase(ExitDirection.Left, 1, 2)]
        public void VehicleInExitLane_BlocksWithoutReserving(ExitDirection direction, int x, int y)
        {
            var session = new PuzzleSession(Definition(1, Vehicle("a",2,2,direction), Vehicle("b",x,y)));
            Assert.That(session.TryDispatch("a"), Is.EqualTo(DispatchResult.Blocked));
            Assert.That(session.Vehicles[0].Slot, Is.EqualTo(-1));
            Assert.That(session.Vehicles[0].State, Is.EqualTo(VehicleState.Board));
        }

        [Test]
        public void RepeatTapAndSecondCar_CannotReserveOccupiedSlot()
        {
            var session = new PuzzleSession(Definition(1, Vehicle("a",0,0), Vehicle("b",2,0)));
            Assert.That(session.TryDispatch("a"), Is.EqualTo(DispatchResult.Accepted));
            Assert.That(session.TryDispatch("a"), Is.EqualTo(DispatchResult.Unavailable));
            Assert.That(session.TryDispatch("b"), Is.EqualTo(DispatchResult.NoParking));
            Assert.That(session.PassengerCount, Is.EqualTo(2));
        }

        [Test]
        public void SlotIsReleasedOnlyAfterFullDeparture_AndDuplicateCallbacksDoNothing()
        {
            var session = new PuzzleSession(Definition(1, Vehicle("a",0,0), Vehicle("b",2,0)));
            session.TryDispatch("a");
            Assert.That(session.TryBoardNext(out _, out _), Is.False);
            Assert.That(session.Arrive("a"), Is.True);
            Assert.That(session.Arrive("a"), Is.False);
            Assert.That(session.TryBoardNext(out string target, out _), Is.True);
            Assert.That(target, Is.EqualTo("a"));
            Assert.That(session.Vehicles[0].Remaining, Is.Zero);
            Assert.That(session.TryDispatch("b"), Is.EqualTo(DispatchResult.NoParking));
            Assert.That(session.FinishDeparture("a"), Is.True);
            Assert.That(session.FinishDeparture("a"), Is.False);
            Assert.That(session.TryDispatch("b"), Is.EqualTo(DispatchResult.Accepted));
        }

        [Test]
        public void ParkedPriorityUsesArrivalOrder_AndNeverBoardsAnotherColor()
        {
            var session = new PuzzleSession(Definition(3, Vehicle("a",0,0), Vehicle("b",2,0), Vehicle("red",4,0, color: VehicleColor.Red)));
            session.TryDispatch("a"); session.TryDispatch("b"); session.TryDispatch("red");
            session.Arrive("b"); session.Arrive("a"); session.Arrive("red");
            session.TryBoardNext(out string first, out var color);
            Assert.That(first, Is.EqualTo("b")); Assert.That(color, Is.EqualTo(VehicleColor.Blue));
            session.TryBoardNext(out string second, out _);
            Assert.That(second, Is.EqualTo("a"));
            session.TryBoardNext(out string third, out _);
            Assert.That(third, Is.EqualTo("red"));
            Assert.That(session.IsComplete, Is.False);
            session.FinishDeparture("a"); session.FinishDeparture("b"); session.FinishDeparture("red");
            Assert.That(session.IsComplete, Is.True);
            Assert.That(session.PassengerCount, Is.Zero);
        }

        [Test]
        public void PausePreventsEveryAuthorityTransition()
        {
            var session = new PuzzleSession(Definition(1, Vehicle("a",0,0)));
            session.TryDispatch("a"); session.Paused = true;
            Assert.That(session.Arrive("a"), Is.False);
            Assert.That(session.TryBoardNext(out _, out _), Is.False);
            session.Paused = false; session.Arrive("a"); session.TryBoardNext(out _, out _);
            session.Paused = true;
            Assert.That(session.FinishDeparture("a"), Is.False);
            Assert.That(session.IsComplete, Is.False);
        }

        [Test]
        public void BadConfiguration_IsRejectedBeforeSessionCreation()
        {
            Assert.Throws<ArgumentException>(() => new PuzzleSession(Definition(1, Vehicle("a",0,0), Vehicle("b",0,0))));
            var definition = Definition(1, Vehicle("a",0,0)); definition.Passengers = Array.Empty<VehicleColor>();
            Assert.Throws<ArgumentException>(() => new PuzzleSession(definition));
        }

        [Test]
        public void AuthoredLevel_CanBeSolvedWithoutLosingPassengers()
        {
            var definition = JsonConvert.DeserializeObject<PuzzleDefinition>(Resources.Load<TextAsset>("DataConfig/puzzleLevel").text);
            var session = new PuzzleSession(definition);
            int boarded = 0;
            foreach (string id in new[] { "blue-top", "yellow-left", "yellow-right", "blue-left", "red-upper", "red-bottom" })
            {
                Assert.That(session.TryDispatch(id), Is.EqualTo(DispatchResult.Accepted), id);
                session.Arrive(id);
            }
            while (session.TryBoardNext(out _, out _)) boarded++;
            Assert.That(boarded, Is.EqualTo(definition.Passengers.Length));
            foreach (var vehicle in session.Vehicles) session.FinishDeparture(vehicle.Definition.Id);
            Assert.That(session.IsComplete, Is.True);
        }

        [Test]
        public void FiftySessionScopes_ReleaseAllPresenterSubscriptions()
        {
            for (int i = 0; i < 50; i++)
            {
                var view = new FakeView();
                var presenter = GameplayFeatureInstaller.Install(view, Definition(1, Vehicle("a",0,0)), () => {}, () => {}, resume => resume());
                presenter.Show(); view.Tap("a"); view.Advance(.9f);
                Assert.That(view.Remaining, Is.Zero);
                view.Advance(.9f);
                Assert.That(view.Complete, Is.True);
                presenter.Dispose(); presenter.Dispose();
                int renders = view.RenderCalls; view.Advance(1);
                Assert.That(view.RenderCalls, Is.EqualTo(renders));
                Assert.That(view.ClearCalls, Is.EqualTo(1));
            }
        }

        private sealed class FakeView : IGameplayView
        {
            public event Action<string> VehicleRequested;
            public event Action RestartRequested { add {} remove {} }
            public event Action PauseRequested { add {} remove {} }
            public event Action HomeRequested { add {} remove {} }
            public event Action<float> Tick;
            public int Remaining, RenderCalls, ClearCalls;
            public bool Complete;
            public void Tap(string id) => VehicleRequested?.Invoke(id);
            public void Advance(float delta) => Tick?.Invoke(delta);
            public void Initialize(PuzzleDefinition definition, IReadOnlyList<VehicleReadModel> vehicles) { }
            public void Render(IReadOnlyList<VehicleReadModel> vehicles, int passengers, bool complete)
            { Remaining = passengers; Complete = complete; RenderCalls++; }
            public void ShowMessage(string message) { }
            public void BoardPassenger(string vehicleId, VehicleColor color) { }
            public void SetPaused(bool paused) { }
            public void Clear() => ClearCalls++;
        }
    }
}
