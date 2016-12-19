using Microsoft.Extensions.Logging;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    public class WhenFindingCardById : IClassFixture<ServiceFixture>
    {
        public ServiceFixture Fixture { get; }

        public WhenFindingCardById(ServiceFixture fixture)
        {
            Fixture = fixture;

            ICard card = new WeaponCard("1");
            Fixture.Repository.Setup(x => x.GetById<ICard>("1")).Returns(card).Verifiable();
        }

        [Fact]
        public void ShouldReturnCorrectModel()
        {
            var result = Fixture.CardSearchService.FindById("1");

            result.Id.ShouldBe("1");

        }
    }
}