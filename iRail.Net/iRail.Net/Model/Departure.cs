using Newtonsoft.Json;
using System;

namespace iRail.Net.Model
{
    public class Departure
    {
        [JsonProperty("delay")]
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan Delay { get; set; }

        [JsonProperty("stationinfo")]
        public Station Station { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixTimestampToDateTimeConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("vehicle")]
        public string Vehicle { get; set; }

        [JsonProperty("platforminfo")]
        public Platform Platform { get; set; }

        [JsonProperty("direction")]
        public Station Direction { get; set; }
    }
}
