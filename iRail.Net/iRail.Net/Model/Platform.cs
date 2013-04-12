using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class Platform
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("normal")]
        public string Normal { get; set; }
    }
}
