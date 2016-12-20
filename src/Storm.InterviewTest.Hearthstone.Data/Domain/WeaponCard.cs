namespace Storm.InterviewTest.Hearthstone.Data.Domain
{
	public class WeaponCard : Card, IWeaponCard
	{
	    protected WeaponCard()
	    {
	    }

	    public WeaponCard(string id) : base(id, CardTypeOptions.Weapon)
		{
		}

		public int Durability { get; set; }
	}
}