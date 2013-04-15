using System;
using iRail.Net.JsonConverters;
using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class Stop
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("stationinfo")]
        public Station Station { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixTimestampToDateTimeConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("delay")]
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan Delay { get; set; }
    }
}