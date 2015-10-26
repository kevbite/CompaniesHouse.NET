using System;
using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.JsonConverters
{
    public class DateOfCessationJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
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
