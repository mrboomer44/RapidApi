using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidApi.Controllers
{
    public class MusicController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://deezerdevs-deezer.p.rapidapi.com/search?q=pop"),
                Headers =
                {
                    { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                    { "x-rapidapi-host", "deezerdevs-deezer.p.rapidapi.com" },
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
                        // Sadece ilk sıradaki popüler şarkıyı alıp gonderiyoruz
                        musicData.data = musicData.data.Take(1).ToList();
                        return View(musicData);
                    }
                }
            }

            return View(new DeezerMusicRootViewModel());
        }
    }
}