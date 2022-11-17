using Newtonsoft.Json;

namespace PressBox.Challenge.Model.BrandData
{
    public class BrandDetails
    {
        [JsonProperty("teamId")]
        public string TeamID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("primaryColor")]
        public string PrimaryColor { get; set; }
        [JsonProperty("abbreviation")]
        public string? Abbreviation { get; set; }
    }
}
