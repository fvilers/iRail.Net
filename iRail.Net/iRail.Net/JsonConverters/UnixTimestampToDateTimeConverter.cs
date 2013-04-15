using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iRail.Net.JsonConverters
{
    public class UnixTimestampToDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long ticks;

            if (value is DateTime)
            {
                var epoch = new DateTime(1970, 1, 1);
                var delta = ((DateTime)value) - epoch;
                ticks = (long)delta.TotalSeconds;
            }
            else
            {
                throw new Exception("Expected DateTime object value.");
            }

            writer.WriteValue(ticks);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ticks = Convert.ToInt64(reader.Value);
            var date = new DateTime(1970, 1, 1);

            return date.AddSeconds(ticks);
        }
    }
}
