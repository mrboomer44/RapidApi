using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class ForeignCurrencyComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public ForeignCurrencyComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:ForeignCurrency:Url"];
                var host = _configuration["RapidApi:ForeignCurrency:Host"];

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
                        var result = JsonConvert.DeserializeObject<ForeignCurrencyRootViewModel>(body);
                        var targetCurrencies = new[] { "USDTRY", "EURTRY", "GBPTRY" };

                        var filteredData = result?.data?
                            .Where(x => targetCurrencies.Contains(x.kod))
                            .ToList();

                        if (filteredData != null && filteredData.Any())
                        {
                            return View(filteredData);
                        }
                    }
                }
            }
            catch { }

            return View(new List<CurrencyDetailViewModel>());
        }
    }
}
