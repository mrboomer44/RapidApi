using System.Collections.Generic;

namespace RapidApi.Models
{
    public class TastyRecipeRootViewModel
    {
        public int count { get; set; }
        public List<TastyRecipeDetailViewModel> results { get; set; }
    }

    public class TastyRecipeDetailViewModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string thumbnail_url { get; set; }
        public int? cook_time_minutes { get; set; }
        public int? total_time_minutes { get; set; }
        public List<TastyTagViewModel> tags { get; set; }
    }

    public class TastyTagViewModel
    {
        public string display_name { get; set; }
    }
}