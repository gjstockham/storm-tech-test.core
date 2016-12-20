namespace Storm.InterviewTest.Hearthstone.Data.Domain
{
    public interface IWeaponCard : ICard
	{
		int Durability { get; set; }
	}
}