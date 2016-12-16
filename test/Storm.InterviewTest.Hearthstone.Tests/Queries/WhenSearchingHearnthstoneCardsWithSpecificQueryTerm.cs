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
                    new MinionCard("99")
                    {
                        Name = "my special card",
                        Faction = FactionTypeOptions.Alliance,
                        Rarity = RarityTypeOptions.Legendary
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
            var result = repo.Query(new SearchCardsQuery("special"));

            result.Count().ShouldBe(1);
            result.First().Name.ShouldBe("my special card");
        }
    }
}