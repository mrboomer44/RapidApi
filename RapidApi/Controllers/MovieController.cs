using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidApi.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> Index()
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

                    // JSON'ı ViewModel'e çeviriyoruz
                    var movieData = JsonConvert.DeserializeObject<MovieRootViewModel>(body);

                    if (movieData != null && movieData.d != null)
                    {
                        // Sadece afiş görseli (i) ve yılı (y) dolu olan film/dizileri alıp 1 tane seçiyoruz
                        movieData.d = movieData.d
                            .Where(x => x.i != null && !string.IsNullOrEmpty(x.i.imageUrl) && x.y > 0)
                            .Take(1)
                            .ToList();

                        return View(movieData);
                    }
                }
            }

            return View(new MovieRootViewModel());
        }
    }
}