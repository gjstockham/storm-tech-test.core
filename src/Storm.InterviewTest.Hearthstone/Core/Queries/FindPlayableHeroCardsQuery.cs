using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class FindPlayableHeroCardsQuery : CardListLinqQueryObject<HeroCard>
	{
		protected override IEnumerable<HeroCard> ExecuteLinq(IQueryable<HeroCard> queryOver)
		{
			return queryOver.Where(x => x.Id.StartsWith("HERO"));
		}
	}
}