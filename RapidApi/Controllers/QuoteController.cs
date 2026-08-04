using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidApi.Controllers
{
    public class QuoteController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://quotes-inspirational-quotes-motivational-quotes.p.rapidapi.com/quote?token=ipworld.info"),
                Headers =
                {
                    { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                    { "x-rapidapi-host", "quotes-inspirational-quotes-motivational-quotes.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var quoteData = JsonConvert.DeserializeObject<QuoteViewModel>(body);

                    if (quoteData != null)
                    {
                        return View(quoteData);
                    }
                }
            }

            return View(new QuoteViewModel());
        }
    }
}