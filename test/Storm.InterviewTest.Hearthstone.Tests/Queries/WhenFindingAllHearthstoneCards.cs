using System.Linq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    public class WhenFindingAllHearthstoneCards : IClassFixture<RepositoryFixture>
    {
        public RepositoryFixture Fixture { get; }

        public WhenFindingAllHearthstoneCards(RepositoryFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void ShouldReturnExpectedCountOfCards()
        {
            var result = Fixture.Repository.Query(new FindAllCardsQuery());

            result.Count().ShouldBe(Fixture.Cards.Count());

        }
    }
}