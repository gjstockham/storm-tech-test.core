using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Queries.Base;

namespace Storm.InterviewTest.Hearthstone.Core.Queries
{
    public class FindAllCardsQuery : CardListLinqQueryObject<ICard>
    {
        protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
        {
            return queryOver;
        }
    }
}