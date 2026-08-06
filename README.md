# 🚀 RapidAPI Multi-Service Dashboard

[![.NET Core](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://docs.microsoft.com/en-us/aspnet/core/)
[![RapidAPI](https://img.shields.io/badge/RapidAPI-Entegrasyon-0052CC?style=for-the-badge&logo=rapid&logoColor=white)](https://rapidapi.com/)
[![License](https://img.shields.io/badge/License-MIT-blue.style=for-the-badge)](LICENSE)

**RapidAPI Dashboard**, 10 farklı canlı API servisinden eş zamanlı veri çekerek kullanıcıya modüler, performanslı ve görsel açıdan zengin bir kontrol paneli sunan modern bir **ASP.NET Core MVC** projesidir.

Projede her API entegrasyonu **`ViewComponent`** mimarisine dönüştürülmüş olup, tüm konfigürasyonlar (API Key, URL, Host) `.env` ve `appsettings.json` üzerinden esnek ve güvenli bir şekilde yönetilmektedir.

---

## 🌟 Öne Çıkan Özellikler

- 🧱 **Modüler ViewComponent Mimarisi:** Her API servisi kendi bağımsız C# mantığına (`{Name}ComponentPartial.cs`) ve özel tasarlanmış UI bileşenine (`Default.cshtml`) sahiptir.
- 🔑 **Güvenli Konfigürasyon (.env & appsettings.json):** API anahtarları ve endpoint adresleri kod içerisine gömülü (hardcoded) değildir. Dependency Injection ile `IConfiguration` üzerinden okunur.
- 🎨 **Modern Dark Mode UI:** Custom CSS tokens, Glassmorphism detaylar, FontAwesome 6 ikonları ve `JetBrains Mono` tipografisi ile zenginleştirilmiş kullanıcı arayüzü.
- 🛡️ **Fail-Safe Hata Yönetimi:** Herhangi bir API kotasına takılındığında veya servis yanıt vermediğinde sayfa çökmez (crash olmaz). Kullanıcıya şık bir uyarılı bilgilendirme kartı (fallback UI) sunar.
- ⚡ **Asenkron Veri Çekme:** Tüm HTTP istekleri `async/await` mimarisiyle performanslı bir şekilde işlenir.

---

## 📊 Entegre Edilen 10 RapidAPI Servisi

| Widget | Bileşen (ViewComponent) | Açıklama | RapidAPI Bağlantısı |
| :--- | :--- | :--- | :--- |
| ⛽ **Akaryakıt Fiyatları** | `GasPriceComponentPartial` | Benzin (95), Motorin ve LPG güncel fiyat verileri | [Gas Price API](https://rapidapi.com/collectapi/api/gas-price) |
| 💱 **Döviz Kurları** | `ForeignCurrencyComponentPartial` | USD/TRY, EUR/TRY, GBP/TRY serbest piyasa canlı kurları | [Live Exchange Rates API](https://rapidapi.com/smokinyazilim/api/live-exchange-rates-api-try-based-forex-pairs) |
| 🪙 **Kripto Paralar** | `CoinRankingComponentPartial` | BTC, ETH, SOL, BNB 24s fiyat ve değişim yüzdeleri | [Coinranking API](https://rapidapi.com/Coinranking/api/coinranking1) |
| ☀️ **Hava Durumu** | `WeatherComponentPartial` | Şehir bazlı anlık sıcaklık, nem, rüzgar hızı ve SVG ikonu | [Open Weather API](https://rapidapi.com/worldapi/api/open-weather13) |
| 🍳 **Günün Yemek Önerisi** | `TastyRecipeComponentPartial` | Pratik menü önerisi, hazırlanma süresi, görsel ve etiketler | [Tasty API](https://rapidapi.com/apidojo/api/tasty) |
| ⚽ **Futbol Maç Sonucu** | `MatchComponentPartial` | Canlı/Sonlanan maç skoru, takım isimleri, lig ve stadyum bilgisi | [SofaScore API](https://rapidapi.com/apidojo/api/sofascore) |
| 📰 **Güncel Haber İçeriği** | `NewsComponentPartial` | Son dakika haber başlıkları, özetleri, görselleri ve kaynakları | [Real-Time News Data API](https://rapidapi.com/letscrape-6bRBa3QguO5/api/real-time-news-data) |
| 🎬 **Günün Filmi & IMDb** | `MovieComponentPartial` | Popüler film afişi, çıkış yılı, oyuncular ve **★ IMDb Puanı** | [Online Movie Database API](https://rapidapi.com/apidojo/api/online-movie-database) |
| 🎵 **Günün Şarkısı** | `MusicComponentPartial` | En çok dinlenen hit şarkı, albüm kapağı ve medya oynatıcı UI | [Deezer API](https://rapidapi.com/deezerdevs/api/deezer-1) |
| 💬 **Motivasyon Sözü** | `QuoteComponentPartial` | Rastgele motivasyon sözü ve tek tıkla **Panoya Kopyalama** | [Quotes API](https://rapidapi.com/ipworld/api/quotes-inspirational-quotes-motivational-quotes) |

---

## 🛠️ Teknoloji Yığını (Tech Stack)

* **Framework:** .NET 9.0 / ASP.NET Core MVC
* **Mimari:** ASP.NET Core ViewComponents, Dependency Injection, Async/Await
* **Veri Formatı:** JSON (Newtonsoft.Json)
* **Frontend:** HTML5, CSS3 (Custom Dark Theme), Bootstrap 5, FontAwesome 6, Google Fonts (`Plus Jakarta Sans` & `JetBrains Mono`)
* **API Entegrasyonu:** RapidAPI Client (HttpClient)

---

## 📁 Proje Klasör Yapısı

```
RapidApi/
├── Controllers/
│   └── HomeController.cs                # Dashboard ana sayfa controller'ı
├── Models/                              # API yanıtları için ViewModel sınıfları
│   ├── CoinRankingViewModel.cs
│   ├── WeatherViewModel.cs
│   ├── ForeignCurrencyViewModel.cs
│   └── ...
├── ViewComponents/                      # Bağımsız API C# mantık bileşenleri
│   ├── CoinRankingComponentPartial.cs
│   ├── GasPriceComponentPartial.cs
│   ├── WeatherComponentPartial.cs
│   └── ...
├── Views/
│   ├── Home/
│   │   └── Index.cshtml                 # ViewComponent'lerin birleştiği ana sayfa
│   └── Shared/
│       ├── _Layout.cshtml               # Ana şablon ve header
│       └── Components/                  # ViewComponent Razor View'ları
│           ├── CoinRankingComponentPartial/Default.cshtml
│           ├── WeatherComponentPartial/Default.cshtml
│           └── ...
├── wwwroot/                             # Statik dosyalar (CSS, JS, Lib)
│   ├── css/dashboard.css
│   └── js/dashboard.js
├── .env                                 # Ortam değişkenleri (API Keys & Endpoints)
└── appsettings.json                    # Uygulama konfigürasyonu
```

---

## 🚀 Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

### 1. Depoyu Klonlayın
```bash
git clone https://github.com/KULLANICI_ADI/RapidApi.git
cd RapidApi/RapidApi
```

### 2. `.env` veya `appsettings.json` Dosyasını Yapılandırın
Projenin kök dizininde bulunan `.env` veya `appsettings.json` dosyasına kendi **RapidAPI Key** anahtarınızı ekleyin:

```json
"RapidApi": {
  "ApiKey": "YOUR_RAPIDAPI_KEY_HERE",
  "Weather": {
    "Url": "https://openweather43.p.rapidapi.com/weather?q=Istanbul&units=metric",
    "Host": "openweather43.p.rapidapi.com"
  },
  ...
}
```

### 3. Bağımlılıkları Yükleyin ve Çalıştırın
```bash
dotnet restore
dotnet build
dotnet run
```

Tarayıcınızda `http://localhost:5000` veya `https://localhost:7001` adresine giderek Dashboard'u görüntüleyebilirsiniz! 🎉

---

## 🤝 Katkıda Bulunma (Contributing)

1. Bu depoyu çatallayın (Fork edin)
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/YeniOzellik`)
3. Değişikliklerinizi işleyin (`git commit -m 'feat: Yeni widget eklendi'`)
4. Dalınıza itin (`git push origin feature/YeniOzellik`)
5. Bir Çekme İsteği (Pull Request) açın

---

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.
