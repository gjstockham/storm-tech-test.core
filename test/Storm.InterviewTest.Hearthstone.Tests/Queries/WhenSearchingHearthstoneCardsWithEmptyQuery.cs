using System.Linq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    public class WhenSearchingHearthstoneCardsWithEmptyQuery : IClassFixture<RepositoryFixture>
    {
        public RepositoryFixture Fixture { get; }

        public WhenSearchingHearthstoneCardsWithEmptyQuery(RepositoryFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void ShouldReturnExpectedSearchResults()
        {
            var result = Fixture.Repository.Query(new SearchCardsQuery(string.Empty, string.Empty));

            result.Count().ShouldBe(4);

        }
    }
}