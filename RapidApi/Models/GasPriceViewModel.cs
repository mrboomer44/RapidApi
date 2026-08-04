namespace RapidApi.Models
{
    public class GasPriceRootViewModel
    {
        public bool success { get; set; }
        public List<GasPriceViewModel> result { get; set; }
    }

    public class GasPriceViewModel
    {
        public string currency { get; set; }
        public string lpg { get; set; }
        public string diesel { get; set; }
        public string gasoline { get; set; }
        public string country { get; set; }
    }
}