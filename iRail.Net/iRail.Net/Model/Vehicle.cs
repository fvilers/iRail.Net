using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class Vehicle
    {
        [JsonProperty("locationX")]
        public string LocationX { get; set; }

        [JsonProperty("locationY")]
        public string LocationY { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
