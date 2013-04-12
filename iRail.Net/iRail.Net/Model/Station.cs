using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class Station
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("locationX")]
        public string LocationX { get; set; }

        [JsonProperty("locationY")]
        public string LocationY { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("standardname")]
        public string StandardName { get; set; }
    }
}