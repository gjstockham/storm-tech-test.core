using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Services
{
	public interface ICardSearchService
	{
		CardModel FindById(string id);
		IEnumerable<CardModel> Search(string searchTerm);
		IEnumerable<CardModel> GetHeroes();
	}
}