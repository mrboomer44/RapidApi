using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidApi.Controllers
{
    public class MatchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sofascore.p.rapidapi.com/matches/detail?matchId=8897222"),
                Headers =
                {
                    { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                    { "x-rapidapi-host", "sofascore.p.rapidapi.com" },
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

            return View(new MatchRootViewModel());
        }
    }
}