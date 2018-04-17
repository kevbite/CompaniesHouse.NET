using System;
using System.Collections.Generic;
using CompaniesHouse.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.JsonConverters
{
    public class FilingSubcategoryConverter : JsonConverter
    {
        private readonly StringEnumConverter _stringEnumConverter;

        public FilingSubcategoryConverter()
        {
            _stringEnumConverter = new StringEnumConverter();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(FilingSubcategory[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var l = new List<FilingSubcategory>();
                reader.Read();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    var filingSubcategory = ReadValue(reader, existingValue, serializer);
                    l.Add(filingSubcategory);

                    reader.Read();
                }

                return l.ToArray();
            }

            return new []{ ReadValue(reader, existingValue, serializer) };
        }

        private FilingSubcategory ReadValue(JsonReader reader, object existingValue, JsonSerializer serializer)
        {
            var filingSubcategory =
                (FilingSubcategory)_stringEnumConverter.ReadJson(reader, typeof(FilingSubcategory), existingValue, serializer);
            return filingSubcategory;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}