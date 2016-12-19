using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    public class WhenGettingHeroCards : IClassFixture<ServiceFixture>
    {
        public ServiceFixture Fixture { get; }

        public WhenGettingHeroCards(ServiceFixture fixture)
        {
            Fixture = fixture;

            IEnumerable<HeroCard> cards = new List<HeroCard>() { new HeroCard("1") };
            Fixture.Repository.Setup(x => x.Query(It.IsAny<FindPlayableHeroCardsQuery>())).Returns(cards).Verifiable();
        }

        [Fact]
        public void ShouldReturnCorrectModel()
        {
            var result = Fixture.CardSearchService.GetHeroes();
            
            result.Count().ShouldBe(1);
            result.First().Id.ShouldBe("1");

        }

        [Fact]
        public void ShouldCreateCorrectQuery()
        {
            var result = Fixture.CardSearchService.GetHeroes();

            Fixture.Repository.VerifyAll();

        }
    }
}