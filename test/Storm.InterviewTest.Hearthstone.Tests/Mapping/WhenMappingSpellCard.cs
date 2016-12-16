using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Models;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
    public class WhenMappingSpellCard : IClassFixture<MappingFixture>
    {
        public MappingFixture Fixture { get; }
        private SpellCard _card;

        public WhenMappingSpellCard(MappingFixture fixture)
        {
            Fixture = fixture;
            _card = new SpellCard("M1")
            {
                PlayerClass = "Mage",
                Name = "Fireball",
                Faction = FactionTypeOptions.Neutral,
                Rarity = RarityTypeOptions.Common,
                Attack = 6,
                Cost = 9,
                Text = "Deal $6 fire damage"
            };
        }

        [Fact]
        public void ShouldMapHeroModelCorrectly()
        {
            var result = Fixture.Mapper.Map<SpellCard, SpellModel>(_card);

            result.Name.ShouldBe(_card.Name);
            result.ImageUrl.ShouldBe(_card.ImageUrl.ToString());
            result.PlayerClass.ShouldBeOfType(typeof(HeroModel));
            result.PlayerClass.Name.ShouldBe("My Hero");
            result.Attack.ShouldBe(_card.Attack);
        }
    }
}