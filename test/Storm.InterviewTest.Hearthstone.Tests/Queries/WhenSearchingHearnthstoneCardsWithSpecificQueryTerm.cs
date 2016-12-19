using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Storm.InterviewTest.Hearthstone.Core.Services;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    public class WhenSearchingHearnthstoneCardsWithSpecificQueryTerm : IClassFixture<RepositoryFixture>
    {
        public RepositoryFixture Fixture { get; }

        public IEnumerable<ICard> Cards
        {
            get
            {
                return new List<ICard>(Fixture.Cards)
                {
                    new MinionCard("1")
                    {
                        Name = "UPPER CASE",
                        Faction = FactionTypeOptions.Alliance,
                        Rarity = RarityTypeOptions.Legendary
                    },
                    new MinionCard("2")
                    {
                        Name = "Mixed Case",
                        Faction = FactionTypeOptions.Horde,
                        Rarity = RarityTypeOptions.Epic
                    },
                    new MinionCard("3")
                    {
                        Name = "Doesn't have the search term",
                        Faction = FactionTypeOptions.Horde,
                        Rarity = RarityTypeOptions.Epic
                    },
                    new MinionCard("4")
                    {
                        Name = "lower case",
                        Faction = FactionTypeOptions.Neutral,
                        Rarity = RarityTypeOptions.Free
                    }
                };
            }
        }

        public WhenSearchingHearnthstoneCardsWithSpecificQueryTerm(RepositoryFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void FactMethodName()
        {
            var repo = new HearthstoneCardCache(Cards);
            var result = repo.Query(new SearchCardsQuery("case"));

            result.Count().ShouldBe(3);
            result.First().Name.ShouldBe("UPPER CASE");
            result.Last().Name.ShouldBe("lower case");
        }
    }
}