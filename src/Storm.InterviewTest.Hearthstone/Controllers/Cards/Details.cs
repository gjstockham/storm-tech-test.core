using System.Threading.Tasks;
using MediatR;

namespace Storm.InterviewTest.Hearthstone.Controllers.Cards
{
    public class Details
    {
        public class Query : IAsyncRequest<Result>
        {
            
        }

        public class Result
        {
            
        }

        public class Handler : IAsyncRequestHandler<Query, Result>
        {
            public Task<Result> Handle(Query message)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}