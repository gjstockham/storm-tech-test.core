using AutoMapper;
using Moq;
using Storm.InterviewTest.Hearthstone.Core.Mapping;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    public class ServiceFixture 
    {
        public Mock<IHearthstoneCardCache> Repository { get; private set; }
        public ICardSearchService CardSearchService { get; private set; }
        protected IMapper Mapper { get; private set; }


        public ServiceFixture()
        {
            Repository = new Mock<IHearthstoneCardCache>();

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

            CardSearchService = new CardSearchService(Repository.Object, Mapper);
        }
    }
}