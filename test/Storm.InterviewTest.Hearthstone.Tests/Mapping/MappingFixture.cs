using AutoMapper;
using Moq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Mapping;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
    public class MappingFixture
    {
        public HeroCard HeroCard { get; private set; }
        public IMapper Mapper { get; private set; }
        public Mock<IHearthstoneCardCache> Repository { get; private set; }


        public MappingFixture()
        {
            HeroCard = new HeroCard("H1")
            {
                Name = "My Hero",
                PlayerClass = null
            };

            Repository = new Mock<IHearthstoneCardCache>();

            // Mock our repo to only return hero card whenever player class is not null
            Repository.Setup(s => s.Query(It.Is<FindHeroCardQuery>(y => y != null))).Returns(HeroCard);

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CardsMappingProfile>();

            }).CreateMapper(t =>
            {
                // Poor man's dependency injection
                if (t == typeof(HeroResolver))
                    return new HeroResolver(Repository.Object);
                return null;
            });
        }
    }
}