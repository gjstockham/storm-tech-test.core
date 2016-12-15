using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
		private readonly string _q;

		public SearchCardsQuery(string q)
		{
			_q = q ?? string.Empty;
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
			return queryOver.Where(x => x.Name.Contains(_q) || x.Type.ToString() == _q || x.PlayerClass == _q);
		}
	}
}