using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
	public class HearthstoneCardCache : IHearthstoneCardCache
	{
		private readonly IEnumerable<ICard> _cards;

		public HearthstoneCardCache(IEnumerable<ICard> cards)
		{
			_cards = cards;
		}

		public TCard GetById<TCard>(string id) where TCard : ICard
		{
			return _cards.OfType<TCard>().FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<TCard> FindAll<TCard>() where TCard : ICard
		{
			return _cards.OfType<TCard>();
		}

		public IEnumerable<TCard> Query<TCard>(CardListQueryObject<TCard> query) where TCard : ICard
		{
			var result = query.Execute(this);
			return result.ToList();
		}

		public TCard Query<TCard>(SingleCardQueryObject<TCard> query) where TCard : ICard
		{
			return query.Execute(this);
		}
	}
}