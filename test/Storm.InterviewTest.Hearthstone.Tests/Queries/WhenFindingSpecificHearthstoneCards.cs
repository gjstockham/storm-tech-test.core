using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    public class WhenFindingSpecificHearthstoneCards : IClassFixture<RepositoryFixture>
    {
        public RepositoryFixture Fixture { get; }

        public WhenFindingSpecificHearthstoneCards(RepositoryFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void ShouldReturnExpectedCard()
        {
            
        }
    }
}