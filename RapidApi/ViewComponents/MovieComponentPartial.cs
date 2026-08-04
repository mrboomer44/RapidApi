using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class MovieComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public MovieComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:Movie:Url"];
                var host = _configuration["RapidApi:Movie:Host"];

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
                        var movieData = JsonConvert.DeserializeObject<MovieRootViewModel>(body);

                        if (movieData != null && movieData.d != null)
                        {
                            movieData.d = movieData.d
                                .Where(x => x.i != null && !string.IsNullOrEmpty(x.i.imageUrl) && x.y > 0)
                                .Take(1)
                                .ToList();

                            return View(movieData);
                        }
                    }
                }
            }
            catch { }

            return View(new MovieRootViewModel());
        }
    }
}
