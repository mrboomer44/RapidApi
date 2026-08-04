using System.Collections.Generic;

namespace RapidApi.Models
{
    public class DeezerMusicRootViewModel
    {
        public List<DeezerTrackViewModel> data { get; set; }
    }

    public class DeezerTrackViewModel
    {
        public string title { get; set; }
        public string link { get; set; }
        public DeezerArtistViewModel artist { get; set; }
        public DeezerAlbumViewModel album { get; set; }
    }

    public class DeezerArtistViewModel
    {
        public string name { get; set; }
    }

    public class DeezerAlbumViewModel
    {
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
    }
}