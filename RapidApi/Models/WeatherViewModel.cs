namespace RapidApi.Models
{
    public class WeatherRootViewModel
    {
        public string name { get; set; }
        public WeatherMainViewModel main { get; set; }
        public WeatherWindViewModel wind { get; set; }
        public WeatherDetailViewModel[] weather { get; set; }
    }

    public class WeatherMainViewModel
    {
        public decimal temp { get; set; }
        public decimal feels_like { get; set; }
        public int humidity { get; set; }
    }

    public class WeatherWindViewModel
    {
        public decimal speed { get; set; }
    }

    public class WeatherDetailViewModel
    {
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}