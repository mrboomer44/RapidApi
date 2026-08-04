using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RapidApi.Models;

namespace RapidApi.ViewComponents
{
    public class TastyRecipeComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public TastyRecipeComponentPartial(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var apiKey = _configuration["RapidApi:ApiKey"];
                var url = _configuration["RapidApi:TastyRecipe:Url"];
                var host = _configuration["RapidApi:TastyRecipe:Host"];

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
                        var apiResult = JsonConvert.DeserializeObject<TastyRecipeRootViewModel>(body);
                        var firstRecipe = apiResult?.results?.FirstOrDefault();

                        if (firstRecipe != null)
                        {
                            return View(firstRecipe);
                        }
                    }
                }
            }
            catch { }

            return View(new TastyRecipeDetailViewModel());
        }
    }
}
