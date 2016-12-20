namespace Storm.InterviewTest.Hearthstone.Data.Domain
{
	public class SpellCard : Card, ISpellCard
	{
	    protected SpellCard()
	    {
	        
	    }

		public SpellCard(string id) : base(id, CardTypeOptions.Spell)
		{
		}
	}
}