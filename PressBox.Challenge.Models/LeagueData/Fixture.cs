using Newtonsoft.Json;

namespace PressBox.Challenge.Model.LeagueData
{
    public class Fixture
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("gameWeek")]
        public int GameWeek { get; set; }
        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }
        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }
        [JsonProperty("venue")]
        public string Venue { get; set; }
    }
}
