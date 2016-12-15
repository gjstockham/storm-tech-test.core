using System;

namespace Storm.InterviewTest.Hearthstone.Core.Domain
{
	public interface ICard
	{
		string Id { get; }
		string Name { get; set; }
		CardTypeOptions Type { get; }
		int Cost { get; set; }
		int Attack { get; set; }
		string PlayerClass { get; set; }
		Uri ImageUrl { get; }
	}
}