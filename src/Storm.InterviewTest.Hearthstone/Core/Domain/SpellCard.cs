namespace Storm.InterviewTest.Hearthstone.Core.Domain
{
	public class SpellCard : Card, ISpellCard
	{
		public SpellCard(string id) : base(id, CardTypeOptions.Spell)
		{
		}
	}
}