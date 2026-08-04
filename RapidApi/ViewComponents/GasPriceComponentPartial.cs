using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class GasPriceComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public GasPriceComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:GasPrice:Url"];
                var host = _configuration["RapidApi:GasPrice:Host"];

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
            catch { }

            return View(new GasPriceViewModel());
        }
    }
}
