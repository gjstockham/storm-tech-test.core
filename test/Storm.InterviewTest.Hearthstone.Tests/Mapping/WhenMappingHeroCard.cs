using Shouldly;
using Storm.InterviewTest.Hearthstone.Controllers.Cards.Models;
using Storm.InterviewTest.Hearthstone.Data.Domain;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
    public class WhenMappingHeroCard : IClassFixture<MappingFixture>
    {
        public MappingFixture Fixture { get; }
        private HeroCard _card;

        public WhenMappingHeroCard(MappingFixture fixture)
        {
            Fixture = fixture;
            _card = new HeroCard("M1")
            {
                PlayerClass = "Priest",
                Name = "Anduin",
                Faction = FactionTypeOptions.Neutral,
                Rarity = RarityTypeOptions.Legendary,
                Attack = 0,
                Cost = 0,
                Health = 30
            };
        }

        [Fact]
        public void ShouldMapHeroModelCorrectly()
        {
            var result = Fixture.Mapper.Map<HeroCard, HeroModel>(_card);

            result.Name.ShouldBe(_card.Name);
            result.ImageUrl.ShouldBe(_card.ImageUrl.ToString());
            result.PlayerClass.ShouldBeNull();
            result.PlayerClass.ShouldBeNull();
            result.Health.ShouldBe(_card.Health);
            result.Attack.ShouldBe(_card.Attack);
        }
    }
}