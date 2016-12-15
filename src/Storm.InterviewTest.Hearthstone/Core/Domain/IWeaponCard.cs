namespace Storm.InterviewTest.Hearthstone.Core.Domain
{
    public interface IWeaponCard : ICard
	{
		int Durability { get; set; }
	}
}