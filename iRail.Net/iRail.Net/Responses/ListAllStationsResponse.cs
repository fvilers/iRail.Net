using iRail.Net.Model;
using Newtonsoft.Json;

namespace iRail.Net.Responses
{
    public class ListAllStationsResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("station")]
        public Station[] Stations { get; set; }
    }
}
