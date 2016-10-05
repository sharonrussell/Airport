using System;

namespace AirportTrafficControl
{
    public class Plane
    {
        public bool Flying { private get; set; }

        public Plane()
        {
            Flying = true;
        }

        public void Land(Airport airport)
        {
            CheckCanLand();

            Flying = false;
            airport.Planes.Add(this);
        }

        public void TakeOff(Airport airport)
        {
            CheckCanTakeOff();

            Flying = true;
            airport.Planes.Remove(this);
        }

        private void CheckCanLand()
        {
            if (!Flying)
                throw new Exception("A grounded plane cannot land");
        }

        private void CheckCanTakeOff()
        {
            if (Flying)
                throw new Exception("A flying plane cannot takeoff");
        }
    }
}