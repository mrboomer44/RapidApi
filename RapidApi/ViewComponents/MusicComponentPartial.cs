using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System.Linq;

namespace RapidApi.ViewComponents
{
    public class MusicComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
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
                        if (musicData != null && musicData.data != null)
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
