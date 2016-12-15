
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
	public class LocalJsonFeedHearthstoneCardCacheFactory : HearthstoneCardCacheFactory
	{
		private readonly IHostingEnvironment _hostingEnvironment;
		public LocalJsonFeedHearthstoneCardCacheFactory(IHearthstoneCardParser parser, IHostingEnvironment hostingEnvironment) : base(parser)
		{
			_hostingEnvironment = hostingEnvironment;
		}

		protected override IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser)
		{
			using (var reader = File.OpenText(Path.Combine(_hostingEnvironment.ContentRootPath, "App_Data/cards.json")))
			{
				var cardSets = JObject.Parse(reader.ReadToEnd());
				JToken cards;
				if (cardSets.TryGetValue("Basic", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
				if (cardSets.TryGetValue("Classic", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
				if (cardSets.TryGetValue("Curse of Naxxramas", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
				if (cardSets.TryGetValue("Goblins vs Gnomes", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
			}
		}
	}
}