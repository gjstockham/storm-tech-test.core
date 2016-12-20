
using System;
using System.Linq;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Controllers.Cards.Models;
using Storm.InterviewTest.Hearthstone.Data;
using Storm.InterviewTest.Hearthstone.Data.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Mapping
{
    public class HeroResolver : IValueResolver<ICard, CardModel, HeroModel>
    {
        private readonly HearthstoneDbContext _db;

        public HeroResolver(HearthstoneDbContext db)
        {
            _db = db;
        }

        public HeroModel Resolve(ICard source, CardModel destination, HeroModel destMember, ResolutionContext context)
        {
            if (String.IsNullOrEmpty(source.PlayerClass))
                return null;

            var card =  _db.Cards
                .FirstOrDefault(x => x.PlayerClass == source.PlayerClass && x.Id.StartsWith("HERO"));

            var heroCard = card as HeroCard;

            return heroCard == null ? null : context.Mapper.Map<HeroCard, HeroModel>(heroCard);
        }
    }
}