using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Core.JsonConverters
{
    public class OptionalStringEnumConverter<T> : StringEnumConverter
	{
		private readonly T _defaultValue;

		public OptionalStringEnumConverter(T defaultValue)
		{
			_defaultValue = defaultValue;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return _defaultValue;
			}

			return base.ReadJson(reader, objectType, existingValue, serializer);
		}
	}
}
