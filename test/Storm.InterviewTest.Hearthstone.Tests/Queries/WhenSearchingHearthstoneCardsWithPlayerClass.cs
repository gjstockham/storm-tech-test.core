using System.Linq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    public class WhenSearchingHearthstoneCardsWithPlayerClass : IClassFixture<RepositoryFixture>
    {
        public RepositoryFixture Fixture { get; }

        public WhenSearchingHearthstoneCardsWithPlayerClass(RepositoryFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void ShouldReturnExpectedSearchResults()
        {
            var result = Fixture.Repository.Query(new SearchCardsQuery(string.Empty, "Mango"));

            result.Count().ShouldBe(2);

        }
    }
}