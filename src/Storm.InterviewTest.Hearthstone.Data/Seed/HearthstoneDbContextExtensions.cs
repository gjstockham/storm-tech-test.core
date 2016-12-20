using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Services;
using Storm.InterviewTest.Hearthstone.Data.Domain;

namespace Storm.InterviewTest.Hearthstone.Data.Seed
{
    public static class HearthstoneDbContextExtensions
    {
        public static void EnsureSeedData(this HearthstoneDbContext context)
        {
            if (!context.Cards.Any())
            {
                context.Cards.AddRange(PopulateCards());

                context.SaveChanges();
            }
        }

        private static IEnumerable<Card> PopulateCards()
        {
            var assembly = typeof(HearthstoneDbContext).GetTypeInfo().Assembly;

            var parser = new HearthstoneCardParser();

            var resourceStream =
                assembly.GetManifestResourceStream("Storm.InterviewTest.Hearthstone.Data.Seed.cards.json");

            using (var reader = new StreamReader((resourceStream)))
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