using System;
using iRail.Net.JsonConverters;
using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class Arrival
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
