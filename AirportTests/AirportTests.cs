using System;
using Airport;
using NUnit.Framework;

namespace AirportTests
{
    [TestFixture]
    public class AirportTests
    {
        [Test]
        public void CanLandPlaneInAirport()
        {
            var airport = new Airport.Airport();

            airport.Land(new Plane());

            Assert.That(airport.Planes.Count, Is.EqualTo(1));
        }

        [Test]
        public void PlaneCanTakeOffFromAirport()
        {
            var airport = new Airport.Airport();
            var plane = new Plane();
            airport.Planes.Add(plane);

            airport.TakeOff(plane);

            Assert.That(airport.Planes.Count, Is.EqualTo(0));
        }

        [Test]
        public void PlaneCannotLandIfAirportFull()
        {
            var airport = new Airport.Airport();
            airport.Land(new Plane());
            airport.Land(new Plane());
            airport.Land(new Plane());
            airport.Land(new Plane());
            airport.Land(new Plane());

            Assert.Throws<Exception>(() => airport.Land(new Plane()));
        }

        [Test]
        
        public void PlaneCannotTakeOffIfNotInAirport()
        {
            var airport = new Airport.Airport();    
        }
    }
}
