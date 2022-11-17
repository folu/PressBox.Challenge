using Newtonsoft.Json;

namespace PressBox.Challenge.Model.BrandData
{
    public class Brand
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
