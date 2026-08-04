using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class CoinRankingComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    // Top 50 coini çekiyoruz, USD reference currency uuid = yhjMzLPhuIDl kullanıyoruz
                    RequestUri = new Uri("https://coinranking1.p.rapidapi.com/coins?referenceCurrencyUuid=yhjMzLPhuIDl&timePeriod=24h&tiers%5B0%5D=1&orderBy=marketCap&orderDirection=desc&limit=50&offset=0"),
                    Headers =
                    {
                        { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                        { "x-rapidapi-host", "coinranking1.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<CoinRankingRootViewModel>(body);

                        var targetSymbols = new[] { "BTC", "ETH", "SOL", "BNB" };

                        var filteredCoins = result?.data?.coins?
                            .Where(c => targetSymbols.Contains(c.symbol))
                            .ToList();
                        if (filteredCoins != null && filteredCoins.Any())
                        {
                            return View(filteredCoins);
                        }
                    }
                }
            }
            catch
            {

            }
            return View(new List<CoinRankingCoinViewModel>());
        }
    }
}
