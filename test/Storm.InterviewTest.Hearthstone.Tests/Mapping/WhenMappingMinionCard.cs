using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Models;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
    public class WhenMappingMinionCard : IClassFixture<MappingFixture>
    {
        public MappingFixture Fixture { get; }
        private MinionCard _card;

        public WhenMappingMinionCard(MappingFixture fixture)
        {
            Fixture = fixture;
            _card = new MinionCard("M1")
            {
                PlayerClass = "Warrior",
                Name = "Whirlwind",
                Faction = FactionTypeOptions.Alliance,
                Rarity = RarityTypeOptions.Legendary,
                Health = 10,
                Attack = 4,
                Cost = 9,
                Text = "It's just a card"
            };
        }

        [Fact]
        public void ShouldMapHeroModelCorrectly()
        {
            var result = Fixture.Mapper.Map<MinionCard, MinionModel>(_card);

            result.Name.ShouldBe(_card.Name);
            result.ImageUrl.ShouldBe(_card.ImageUrl.ToString());
            result.PlayerClass.ShouldBeOfType(typeof(HeroModel));
            result.PlayerClass.Name.ShouldBe("My Hero");
            result.Health.ShouldBe(_card.Health);
            result.Attack.ShouldBe(_card.Attack);
            result.Health.ShouldBe(_card.Health);
        }
    }
}