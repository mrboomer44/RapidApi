using System.Collections.Generic;

namespace RapidApi.Models
{
    public class CoinRankingRootViewModel
    {
        public string status { get; set; }
        public CoinRankingDataViewModel data { get; set; }
    }

    public class CoinRankingDataViewModel
    {
        public List<CoinRankingCoinViewModel> coins { get; set; }
    }

    public class CoinRankingCoinViewModel
    {
        public string uuid { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string iconUrl { get; set; }
        public string price { get; set; }
        public string change { get; set; }
        public int rank { get; set; }
    }
}