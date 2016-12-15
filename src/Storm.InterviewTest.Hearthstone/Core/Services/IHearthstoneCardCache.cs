using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
	public interface IHearthstoneCardCache
	{
		TCard GetById<TCard>(string id) where TCard : ICard;
		IEnumerable<TCard> FindAll<TCard>() where TCard : ICard;
		IEnumerable<TCard> Query<TCard>(CardListQueryObject<TCard> query) where TCard : ICard;
		TCard Query<TCard>(SingleCardQueryObject<TCard> query) where TCard : ICard;
	}
}