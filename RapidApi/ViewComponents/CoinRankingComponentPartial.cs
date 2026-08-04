using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class CoinRankingComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public CoinRankingComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:CoinRanking:Url"];
                var host = _configuration["RapidApi:CoinRanking:Host"];

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Headers =
                    {
                        { "x-rapidapi-key", apiKey },
                        { "x-rapidapi-host", host },
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
            catch { }

            return View(new List<CoinRankingCoinViewModel>());
        }
    }
}
