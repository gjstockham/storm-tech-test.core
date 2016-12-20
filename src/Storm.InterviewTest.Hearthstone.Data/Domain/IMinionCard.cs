namespace Storm.InterviewTest.Hearthstone.Data.Domain
{
	public interface IMinionCard : ICard
	{
		string Text { get; set; }
		RarityTypeOptions Rarity { get; set; }
		int Health { get; set; }
		FactionTypeOptions Faction { get; set; }
	}
}