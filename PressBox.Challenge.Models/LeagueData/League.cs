using Newtonsoft.Json;

namespace PressBox.Challenge.Model.LeagueData
{
    public class League
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
