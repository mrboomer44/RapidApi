using Newtonsoft.Json;

namespace RapidApi.Models
{
    // En dıştaki kök sınıf
    public class MatchRootViewModel
    {
        [JsonProperty("event")]
        public MatchEventViewModel eventData { get; set; } // JSON'daki "event" nesnesi
    }

    public class MatchEventViewModel
    {
        public int id { get; set; }
        public TeamViewModel homeTeam { get; set; }
        public TeamViewModel awayTeam { get; set; }
        public ScoreViewModel homeScore { get; set; }
        public ScoreViewModel awayScore { get; set; }
        public TournamentViewModel tournament { get; set; }
        public VenueViewModel venue { get; set; }
        public StatusViewModel status { get; set; }
    }

    public class TeamViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
    }

    public class ScoreViewModel
    {
        public int current { get; set; }
    }

    public class TournamentViewModel
    {
        public string name { get; set; }
    }

    public class VenueViewModel
    {
        public StadiumViewModel stadium { get; set; }
        public string name { get; set; }
    }

    public class StadiumViewModel
    {
        public string name { get; set; }
    }

    public class StatusViewModel
    {
        public string description { get; set; }
        public string type { get; set; }
    }
}