using Newtonsoft.Json;
using PressBox.Challenge.Models.BrandData;

namespace PressBox.Challenge.Model.LeagueData
{
    public class Team
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("brand")]
        public BrandForFixture? Brand { get; set; }
    }
}
