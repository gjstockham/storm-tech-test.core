using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
	public abstract class HearthstoneCardCacheFactory : IHearthstoneCardCacheFactory
	{
		private readonly IHearthstoneCardParser _parser;

		protected HearthstoneCardCacheFactory(IHearthstoneCardParser parser)
		{
			_parser = parser;
		}

		public IHearthstoneCardCache Create()
		{
			var cards = PopulateCards(_parser);
			return new HearthstoneCardCache(cards.ToList());
		}

		protected abstract IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser);
	}
}