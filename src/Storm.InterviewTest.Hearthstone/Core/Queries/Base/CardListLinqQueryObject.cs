using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Core.Queries.Base
{
	public abstract class CardListLinqQueryObject<T> : CardListQueryObject<T> where T : ICard
	{
		public override IEnumerable<T> Execute(IHearthstoneCardCache cache)
		{
			return ExecuteLinq(cache.FindAll<T>().AsQueryable());
		}

		protected abstract IEnumerable<T> ExecuteLinq(IQueryable<T> queryOver);
	}
}