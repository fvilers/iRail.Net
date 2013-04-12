using System;
using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class Via
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("timeBetween")]
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan TimeBetween { get; set; }

        [JsonProperty("stationinfo")]
        public Station Station { get; set; }

        [JsonProperty("vehicle")]
        public string Vehicle { get; set; }

        [JsonProperty("direction")]
        public Station Direction { get; set; }
    }
}
