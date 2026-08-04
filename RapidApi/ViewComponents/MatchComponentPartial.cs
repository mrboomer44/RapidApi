using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class MatchComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public MatchComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:Match:Url"];
                var host = _configuration["RapidApi:Match:Host"];

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
                        var matchData = JsonConvert.DeserializeObject<MatchRootViewModel>(body);

                        if (matchData != null && matchData.eventData != null)
                        {
                            return View(matchData);
                        }
                    }
                }
            }
            catch { }

            return View(new MatchRootViewModel());
        }
    }
}
