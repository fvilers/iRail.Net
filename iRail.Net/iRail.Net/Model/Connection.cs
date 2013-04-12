using Newtonsoft.Json;
using System;

namespace iRail.Net.Model
{
    public class Connection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("duration")]
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan Duration { get; set; }

        [JsonProperty("vias")]
        public ViaCollection Vias { get; set; }
    }
}