namespace Storm.InterviewTest.Hearthstone.Core.Domain
{
	public class HeroCard : MinionCard
	{
		public HeroCard(string id) : base(id, CardTypeOptions.Hero)
		{
			Health = 30;
		}
	}
}