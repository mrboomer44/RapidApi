using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class NewsComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public NewsComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:News:Url"];
                var host = _configuration["RapidApi:News:Host"];

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
                        var newsData = JsonConvert.DeserializeObject<RealTimeNewsRootViewModel>(body);

                        if (newsData != null && newsData.data != null)
                        {
                            return View(newsData);
                        }
                    }
                }
            }
            catch { }

            return View(new RealTimeNewsRootViewModel());
        }
    }
}
