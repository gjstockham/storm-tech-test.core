namespace Storm.InterviewTest.Hearthstone.Data.Domain
{
	public class MinionCard : Card, IMinionCard
	{
		public int Health { get; set; }

	    protected MinionCard()
	    {
	        
	    }

		public MinionCard(string id)
			: base(id, CardTypeOptions.Minion)
		{
		}

		protected MinionCard(string id, CardTypeOptions type) : base(id, type) { }

	}
}