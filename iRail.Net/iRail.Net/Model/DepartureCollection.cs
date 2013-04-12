using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class DepartureCollection
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("departure")]
        public Departure[] Items { get; set; }
    }
}