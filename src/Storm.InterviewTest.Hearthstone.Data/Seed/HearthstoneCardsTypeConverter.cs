using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Data.Domain;

namespace Storm.InterviewTest.Hearthstone.Core
{
	public class HearthstoneCardsTypeConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;

			var o = JArray.Load(reader);
			return o.Select(item => serializer.Deserialize<Card>(item.CreateReader())).ToList();
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IEnumerable<Card>).IsAssignableFrom(objectType);
		}
	}
}