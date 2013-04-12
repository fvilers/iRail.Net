using Newtonsoft.Json;

namespace iRail.Net.Responses
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public int ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
