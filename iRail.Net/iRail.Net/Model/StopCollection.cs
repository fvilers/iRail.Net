using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class StopCollection
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("stop")]
        public Stop[] Items { get; set; }
    }
}
