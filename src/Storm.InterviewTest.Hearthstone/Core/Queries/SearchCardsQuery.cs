using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
		public string Q { get; protected set; }

		public SearchCardsQuery(string q)
		{
			Q = q ?? string.Empty;
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
			return queryOver.Where(x => x.Name.Contains(Q) || x.Type.ToString() == Q || x.PlayerClass == Q);
		}
	}
}