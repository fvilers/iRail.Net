using iRail.Net.Model;
using Newtonsoft.Json;

namespace iRail.Net.Responses
{
    public class SchedulesResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("connection")]
        public Connection[] Connections { get; set; }
    }
}
