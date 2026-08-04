using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidApi.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/istanbul/EN"),
                Headers =
                {
                    { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                    { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<WeatherRootViewModel>(body);

                    if (weatherData != null && weatherData.main != null)
                    {
                        if (weatherData.main.temp > 40)
                        {
                            weatherData.main.temp = (weatherData.main.temp - 32) * 5 / 9;
                            weatherData.main.feels_like = (weatherData.main.feels_like - 32) * 5 / 9;
                        }

                        return View(weatherData);
                    }
                }
            }

            return View(new WeatherRootViewModel());
        }
    }
}