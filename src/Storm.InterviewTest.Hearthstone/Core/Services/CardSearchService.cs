using System.Collections.Generic;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
    public class CardSearchService : ICardSearchService
	{
		private readonly IHearthstoneCardCache _cardCache;
        private readonly IMapper _mapper;

		public CardSearchService(IHearthstoneCardCache cardCache, IMapper mapper)
		{
			_cardCache = cardCache;
            _mapper = mapper;
		}

		public CardModel FindById(string id)
		{
			var card = _cardCache.GetById<ICard>(id);
			return _mapper.Map<ICard, CardModel>(card);
		}

		public IEnumerable<CardModel> Search(string searchTerm, string playerClass)
		{
			var cards = _cardCache.Query(new SearchCardsQuery(searchTerm, playerClass));
			return _mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(cards);
		}

		public IEnumerable<CardModel> GetHeroes()
		{
			var heroes = _cardCache.Query(new FindPlayableHeroCardsQuery());
			return _mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(heroes);
		}
	}
}
