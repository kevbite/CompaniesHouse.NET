using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Core.JsonConverters
{
    public class StringArrayOrFieldEnumConverter : JsonConverter
    {
        private readonly StringEnumConverter _stringEnumConverter;

        public StringArrayOrFieldEnumConverter()
        {
            _stringEnumConverter = new StringEnumConverter();
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsArray && _stringEnumConverter.CanConvert(objectType.GetElementType()))
            {
                return true;
            }

            return false;
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var elementType = objectType.GetElementType();

            var list = new List<object>() as IList;

            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    var value = ReadValue(reader, elementType, existingValue, serializer);
                    list.Add(value);

                    reader.Read();
                }
            }
            else
            {
                var value = ReadValue(reader, elementType, existingValue, serializer);
                list.Add(value);
            }

            var array = (Array)Activator.CreateInstance(elementType.MakeArrayType(), list.Count);
            list.CopyTo(array, 0);

            return array;
        }

        private object ReadValue(JsonReader reader, Type elementType, object existingValue, JsonSerializer serializer)
        {
            return _stringEnumConverter.ReadJson(reader, elementType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}