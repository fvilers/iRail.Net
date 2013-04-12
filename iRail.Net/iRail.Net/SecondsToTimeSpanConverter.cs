using Newtonsoft.Json;
using System;

namespace iRail.Net
{
    public class SecondsToTimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var seconds = (long)((TimeSpan)value).TotalSeconds;

            writer.WriteValue(seconds);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var seconds = Convert.ToInt32(reader.Value);

            return new TimeSpan(0, 0, seconds);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }
    }
}
