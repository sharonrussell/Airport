using System;
using AirportTrafficControl;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AirportTests
    {
        private Airport _airport;

        [SetUp]
        public void SetUp()
        {
            var sunnyWeather = new Weather("sunny");
            _airport = new Airport(sunnyWeather);
        }

        [Test]
        public void CanLandPlaneInAirport()
        {
            _airport.Land(new Plane());

            Assert.That(_airport.Planes.Count, Is.EqualTo(1));
        }

        [Test]
        public void PlaneCanTakeOffFromAirport()
        {
            var plane = new Plane();
            _airport.Land(plane);

            _airport.TakeOff(plane);

            Assert.That(_airport.Planes.Count, Is.EqualTo(0));
        }

        [Test]
        public void PlaneCannotLandIfAirportFull()
        {
            _airport.Land(new Plane());
            _airport.Land(new Plane());
            _airport.Land(new Plane());
            _airport.Land(new Plane());
            _airport.Land(new Plane());

            Assert.Throws<Exception>(() => _airport.Land(new Plane()));
        }

        [Test]
        
        public void PlaneCannotTakeOffIfNotInAirport()
        {
            Assert.Throws<Exception>(() => _airport.TakeOff(new Plane()));
        }

        [Test]
        public void AFlyingPlaneCannotTakeOff()
        {
            var plane = new Plane();
            _airport.Land(plane);

            plane.Flying = true;

            Assert.Throws<Exception>(() => _airport.TakeOff(plane));
        }

        [Test]
        public void AGroundedPlaneCannotLand()
        {
            var plane = new Plane();

            _airport.Land(plane);

            Assert.Throws<Exception>(() => _airport.Land(plane));
        }

        [Test]
        public void APlaneCannotLandInStormyWeather()
        {
            var stormyWeather = new Weather("stormy");
            _airport = new Airport(stormyWeather);
            var plane = new Plane();

            Assert.Throws<Exception>(() => _airport.Land(plane));
        }

        [Test]
        public void APlaneCannotTakeOffInStormyWeather()
        {
            var plane = new Plane();
            _airport.Land(plane);

            _airport.Weather = new Weather("stormy");

            Assert.Throws<Exception>(() => _airport.TakeOff(plane));
        }
    }
}
