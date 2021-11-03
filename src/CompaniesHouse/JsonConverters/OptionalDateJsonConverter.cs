using System;
using Newtonsoft.Json;

namespace CompaniesHouse.JsonConverters
{
    public class OptionalDateJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ( value is DateTime? ) {
                if ( value != null ) {
                    writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd"));
                }
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value as string == "Unknown")
            {
                return null;
            }
            else
            {
                return serializer.Deserialize<DateTime?>(reader);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
