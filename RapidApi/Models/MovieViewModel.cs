using System.Collections.Generic;

namespace RapidApi.Models
{
    // En dıştaki kök nesne
    public class MovieRootViewModel
    {
        public List<MovieItemViewModel> d { get; set; } // API "d" adıyla dönüyor
    }

    public class MovieItemViewModel
    {
        public string id { get; set; }
        public string l { get; set; }  // Film/Dizi Adı (l = label)
        public string s { get; set; }  // Oyuncular/Açıklama (s = stars)
        public int y { get; set; }     // Çıkış Yılı (y = year)
        public int rank { get; set; }  // IMDb Sıralaması / Popülerlik
        public double? chartRating { get; set; } // IMDb Puanı
        public ImageInfoViewModel i { get; set; } // Resim nesnesi
    }

    public class ImageInfoViewModel
    {
        public string imageUrl { get; set; } // Film Afiş Resim Linki
    }
}
