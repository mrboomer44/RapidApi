using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class QuoteComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public QuoteComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:Quote:Url"];
                var host = _configuration["RapidApi:Quote:Host"];

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
                        var quoteData = JsonConvert.DeserializeObject<QuoteViewModel>(body);

                        if (quoteData != null)
                        {
                            return View(quoteData);
                        }
                    }
                }
            }
            catch { }

            return View(new QuoteViewModel());
        }
    }
}
