using System;
using System.Collections.Generic;

namespace AirportTrafficControl
{
    public class Airport
    {
        public List<Plane> Planes { get; }
        public Weather Weather { private get; set; }

        private readonly int _capacity;
        private bool IsFull => Planes.Count >= _capacity;
        private bool BadWeather => Weather.IsBad;

        public Airport(Weather weather, int capacity = 5)
        {
            Weather = weather;
            _capacity = capacity;
            Planes = new List<Plane>();
        }

        public void Land(Plane plane)
        {
            CheckCapacity();
            CheckWeather("land");

            plane.Land(this);
        }

        public void TakeOff(Plane plane)
        {
            CheckPlaneInAirport(plane);
            CheckWeather("take off");

            plane.TakeOff(this);
        }

        private void CheckCapacity()
        {
            if (IsFull)
                throw new Exception("The airport is full, can't land");
        }

        private void CheckPlaneInAirport(Plane plane)
        {
            if (!Planes.Contains(plane))
                throw new Exception("Can't take off, plane is not in the airport");

        }

        private void CheckWeather(string action)
        {
            if (BadWeather)
                throw new Exception($"Cannot {action} in bad weather");
        }
    }
}
