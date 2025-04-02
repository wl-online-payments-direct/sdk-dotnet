using System;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Json
{
    internal class DateOnlyConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("yyyy-MM-dd"));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dateString = (string)reader.Value;
            return DateTime.ParseExact(dateString, "yyyy-MM-dd", null);
        }
    }
}
