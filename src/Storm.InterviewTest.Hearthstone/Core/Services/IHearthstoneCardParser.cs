using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
	public interface IHearthstoneCardParser
	{
		IEnumerable<ICard> ParseArray(string cardsJsonData);
		ICard Parse(string cardsJsonData);
	}
}
