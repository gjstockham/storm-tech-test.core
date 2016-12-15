using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Core.Queries.Base
{
	public abstract class SingleCardQueryObject<T> where T : ICard
	{
		public abstract T Execute(IHearthstoneCardCache cache);
	}
}