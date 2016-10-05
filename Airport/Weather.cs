namespace AirportTrafficControl
{
    public class Weather
    {
        public bool IsBad => Conditions.Equals("stormy");

        private string Conditions { get; }

        public Weather(string conditions)
        {
            Conditions = conditions;
        }
    }
}