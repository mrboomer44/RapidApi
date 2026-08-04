using System.Collections.Generic;

namespace RapidApi.Models
{
    // Kök nesne - API data: [...] şeklinde liste döndürüyor
    public class RealTimeNewsRootViewModel
    {
        public string status { get; set; }
        public List<ArticleViewModel> data { get; set; }
    }

    public class ArticleViewModel
    {
        public string title { get; set; }        // Haber Başlığı
        public string link { get; set; }         // Detay Linki
        public string snippet { get; set; }      // Özet
        public string photo_url { get; set; }    // Görsel
        public string source_name { get; set; }  // Kaynak (Örn: Milliyet)
    }
}