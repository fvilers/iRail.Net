using iRail.Net.Model;
using Newtonsoft.Json;

namespace iRail.Net.Responses
{
    public class VehicleResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("vehicle")]
        public string VehicleValue { get; set; }

        [JsonProperty("vehicleinfo")]
        public Vehicle Vehicle { get; set; }

        [JsonProperty("stops")]
        public StopCollection Stops { get; set; }
    }
}
