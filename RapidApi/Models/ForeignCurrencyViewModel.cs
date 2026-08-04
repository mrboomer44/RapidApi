using System.Collections.Generic;

namespace RapidApi.Models
{
    public class ForeignCurrencyRootViewModel
    {
        public bool success { get; set; }
        public List<CurrencyDetailViewModel> data { get; set; }
    }

    public class CurrencyDetailViewModel
    {
        public string kod { get; set; }
        public string satis { get; set; }
    }
}