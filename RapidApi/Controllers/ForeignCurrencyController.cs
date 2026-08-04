using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.Controllers
{
    public class ForeignCurrencyController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://live-exchange-rates-api-try-based-forex-pairs.p.rapidapi.com/harem_altin/prices/doviz/ebc099879744f4aa3e02ff6762874055"),
                Headers =
                {
                    { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                    { "x-rapidapi-host", "live-exchange-rates-api-try-based-forex-pairs.p.rapidapi.com" },
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

                    return View(filteredData);
                }

                return View(new List<CurrencyDetailViewModel>());
            }
        }
    }
}