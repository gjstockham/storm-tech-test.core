namespace Storm.InterviewTest.Hearthstone.Data.Domain
{
	public class HeroCard : MinionCard
	{
	    protected HeroCard()
	    {
	        
	    }

		public HeroCard(string id) : base(id, CardTypeOptions.Hero)
		{
			Health = 30;
		}
	}
}