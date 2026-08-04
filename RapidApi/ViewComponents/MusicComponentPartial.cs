using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class MusicComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public MusicComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:Music:Url"];
                var host = _configuration["RapidApi:Music:Host"];

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
                        var musicData = JsonConvert.DeserializeObject<DeezerMusicRootViewModel>(body);

                        if (musicData != null && musicData.data != null && musicData.data.Any())
                        {
                            musicData.data = musicData.data.Take(1).ToList();
                            return View(musicData);
                        }
                    }
                }
            }
            catch { }

            return View(new DeezerMusicRootViewModel());
        }
    }
}
