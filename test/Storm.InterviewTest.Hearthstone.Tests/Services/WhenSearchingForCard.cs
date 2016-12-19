using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    public class WhenSearchingForCard : IClassFixture<ServiceFixture>
    {
        public ServiceFixture Fixture { get; }

        public WhenSearchingForCard(ServiceFixture fixture)
        {
            Fixture = fixture;

            IEnumerable<Card> cards = new List<Card>() { new WeaponCard("1") };
            Fixture.Repository.Setup(x => x.Query<ICard>(It.IsAny<SearchCardsQuery>())).Returns(cards).Verifiable();
        }

        [Fact]
        public void ShouldReturnCorrectModel()
        {
            var result = Fixture.CardSearchService.Search("my search term", string.Empty);

            result.Count().ShouldBe(1);
            result.First().Id.ShouldBe("1");

        }

        [Fact]
        public void ShouldCreateCorrectQuery()
        {
            var result = Fixture.CardSearchService.Search("my search term", string.Empty);

            Fixture.Repository.Verify(x => x.Query(It.Is<SearchCardsQuery>(y => y.Q == "my search term")));

        }
    }
}