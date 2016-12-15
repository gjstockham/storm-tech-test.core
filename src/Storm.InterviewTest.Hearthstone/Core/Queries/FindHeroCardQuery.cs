using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Queries
{
	public class FindHeroCardQuery : SingleCardLinqQueryObject<HeroCard>
	{
		private readonly string _playerClass;

		public FindHeroCardQuery(string playerClass)
		{
			_playerClass = playerClass;
		}
		
		protected override HeroCard ExecuteLinq(IQueryable<HeroCard> queryOver)
		{
			return queryOver.FirstOrDefault(x => x.PlayerClass == _playerClass && x.Id.StartsWith("HERO"));
		}
	}
}