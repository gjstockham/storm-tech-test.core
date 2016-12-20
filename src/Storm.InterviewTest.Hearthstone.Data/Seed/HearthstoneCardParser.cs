using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Data.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
	/// <summary>
	/// Parses json objects or arrays from the card datasets available from http://hearthstonejson.com/
	/// Some cards have been removed i.e. Hero Cards and Powers
	/// </summary>
	public class HearthstoneCardParser 
	{
		private readonly JsonSerializer _jsonSerializer;
		
		public HearthstoneCardParser() 
		{
			_jsonSerializer = new JsonSerializer();
			_jsonSerializer.Converters.Add(new HearthstoneCardsTypeConverter());
			_jsonSerializer.Converters.Add(new HearthstoneCardTypeConverter());
		}

		public IEnumerable<Card> ParseArray(string cardsJsonData)
		{
			var j = JToken.Parse(cardsJsonData);
			if(j.Type != JTokenType.Array) return Enumerable.Empty<Card>();

			return _jsonSerializer.Deserialize<IEnumerable<Card>>(j.CreateReader());
		}

		public Card Parse(string cardJson)
		{
			var j = JToken.Parse(cardJson);
			return j.Type != JTokenType.Object ? null : _jsonSerializer.Deserialize<Card>(j.CreateReader());
		}
	}
}