﻿using Newtonsoft.Json;

namespace iRail.Net.Model
{
    public class ViaCollection
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("via")]
        public Via[] Items { get; set; }
    }
}
