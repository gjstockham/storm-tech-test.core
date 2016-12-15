
using System;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Storm.InterviewTest.Hearthstone.Core.Services;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Mapping
{
    public class HeroResolver : IValueResolver<ICard, CardModel, HeroModel>
    {
        private readonly IHearthstoneCardCache _repository;

        public HeroResolver(IHearthstoneCardCache repository)
        {
            _repository = repository;
        }

        public HeroModel Resolve(ICard source, CardModel destination, HeroModel destMember, ResolutionContext context)
        {
            if (String.IsNullOrEmpty(source.PlayerClass))
                return null;

            var heroCard =  _repository.Query(new FindHeroCardQuery(source.PlayerClass));

            
            return heroCard == null ? null : context.Mapper.Map<HeroCard, HeroModel>(heroCard);
        }
    }
}