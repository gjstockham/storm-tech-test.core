using System;
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
		    return queryOver.Where(x =>
		        StringContains(x.Name)
		        || StringContains(x.Type.ToString())
		        || StringContains(x.PlayerClass));
		}

	    private bool StringContains(string input)
	    {
	        return input?.IndexOf(Q, StringComparison.OrdinalIgnoreCase) >= 0;
	    }
	}
}