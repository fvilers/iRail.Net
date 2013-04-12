using iRail.Net.Model;
using Newtonsoft.Json;

namespace iRail.Net.Responses
{
    public class LiveboardResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("station")]
        public string StationValue { get; set; }

        [JsonProperty("stationinfo")]
        public Station Station { get; set; }

        [JsonProperty("departures")]
        public DepartureCollection Departures { get; set; }
    }
}
