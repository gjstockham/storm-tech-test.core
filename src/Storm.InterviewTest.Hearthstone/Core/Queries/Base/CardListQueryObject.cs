using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Core.Queries.Base
{
    public abstract class CardListQueryObject<T> where T : ICard
    {
        public abstract IEnumerable<T> Execute(IHearthstoneCardCache cache);
    }
}