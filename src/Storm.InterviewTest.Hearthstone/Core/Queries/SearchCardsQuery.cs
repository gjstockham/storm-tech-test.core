using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
	    public string PlayerClass { get; }
	    public string Q { get; }

		public SearchCardsQuery(string q, string playerClass)
		{
		    PlayerClass = playerClass;
		    Q = q ?? string.Empty;
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
		    var query = queryOver.Where(x =>
		        StringContains(x.Name)
		        || StringContains(x.Type.ToString())
		        || StringContains(x.PlayerClass));

		    if (!String.IsNullOrEmpty(PlayerClass))
		    {
		        query = query.Where(x => x.PlayerClass == PlayerClass);
		    }

		    return query;
		}

	    private bool StringContains(string input)
	    {
	        return input?.IndexOf(Q, StringComparison.OrdinalIgnoreCase) >= 0;
	    }
	}
}