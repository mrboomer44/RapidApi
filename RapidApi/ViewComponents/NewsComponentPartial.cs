using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class NewsComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://real-time-news-data.p.rapidapi.com/search?query=g%C3%BCndem&limit=3&country=TR&lang=tr"),
                    Headers =
                    {
                        { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                        { "x-rapidapi-host", "real-time-news-data.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var newsData = JsonConvert.DeserializeObject<RealTimeNewsRootViewModel>(body);
                        if (newsData != null && newsData.data != null) return View(newsData);
                    }
                }
            }
            catch { }
            return View(new RealTimeNewsRootViewModel());
        }
    }
}
