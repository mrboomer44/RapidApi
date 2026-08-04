using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System.Linq;

namespace RapidApi.ViewComponents
{
    public class MovieComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://online-movie-database.p.rapidapi.com/auto-complete?q=game%20of%20thr"),
                    Headers =
                    {
                        { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                        { "x-rapidapi-host", "online-movie-database.p.rapidapi.com" },
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
                            movieData.d = movieData.d.Where(x => x.i != null && !string.IsNullOrEmpty(x.i.imageUrl) && x.y > 0).Take(1).ToList();
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
