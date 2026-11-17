using Dreamy.Template.Gameplay;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;

namespace Dreamy.Template.Tests
{
    public sealed class PuzzleCatalogTests
    {
        [TestCase(1,6,7)]
        [TestCase(2,12,4)]
        public void ObservedCatalog_HasExpectedLayoutAndSolvesWithConservedPassengers(int level,int count,int parking)
        {
            var catalog=JsonConvert.DeserializeObject<PuzzleCatalog>(Resources.Load<TextAsset>("DataConfig/puzzleCatalog").text);
            catalog.Initialize("puzzleCatalog");var definition=catalog.Find(level);
            Assert.That(definition.Vehicles.Length,Is.EqualTo(count));Assert.That(definition.ParkingCount,Is.EqualTo(parking));
            var session=new PuzzleSession(definition);int boarded=0;
            for(int tick=0;tick<10000&&!session.IsComplete;tick++)
            {
                foreach(var vehicle in session.Vehicles)
                    if(vehicle.State==VehicleState.Board && session.TryDispatch(vehicle.Definition.Id)==DispatchResult.Accepted)
                        session.Arrive(vehicle.Definition.Id);
                if(session.TryBoardNext(out _,out _))boarded++;
                foreach(var vehicle in session.Vehicles)
                    if(vehicle.State==VehicleState.Departing)session.FinishDeparture(vehicle.Definition.Id);
            }
            Assert.That(session.IsComplete,Is.True);Assert.That(boarded,Is.EqualTo(definition.Passengers.Length));
            Assert.That(session.PassengerCount,Is.Zero);
        }
    }
}
