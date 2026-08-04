using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Models;
using System.Linq;

namespace RapidApi.ViewComponents
{
    public class TastyRecipeComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=1&tags=under_30_minutes"),
                    Headers =
                    {
                        { "x-rapidapi-key", "7bac634cd7msh9f45e7c153e8dbep14a7cdjsn8f633fd9100f" },
                        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var apiResult = JsonConvert.DeserializeObject<TastyRecipeRootViewModel>(body);
                        var firstRecipe = apiResult?.results?.FirstOrDefault();
                        if (firstRecipe != null) return View(firstRecipe);
                    }
                }
            }
            catch { }
            return View(new TastyRecipeDetailViewModel());
        }
    }
}
