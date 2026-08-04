using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class GasPriceComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                    Headers =
                    {
                        { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                        { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();

                        var apiResponse = JsonConvert.DeserializeObject<GasPriceRootViewModel>(body);

                        var turkeyData = apiResponse?.result?
                            .FirstOrDefault(x => x.country != null && x.country.Equals("Turkey", StringComparison.OrdinalIgnoreCase));

                        if (turkeyData != null)
                        {
                            return View(turkeyData);
                        }
                    }
                }
            }
            catch
            {
                // API hatası durumunda boş model ile devam et
            }

            return View(new GasPriceViewModel());
        }
    }
}
