using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.DotNet.Cli.Utils.CommandParsing;
using Microsoft.EntityFrameworkCore;
using Storm.InterviewTest.Hearthstone.Controllers.Cards.Models;
using Storm.InterviewTest.Hearthstone.Data;
using Storm.InterviewTest.Hearthstone.Data.Domain;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Controllers.Cards
{
    public class Index
    {
        public class Query : IAsyncRequest<Result>
        {
            public string Q { get; set; }
        }

        public class Result
        {
            public string Q { get; set; }
            public IEnumerable<CardModel> Cards { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Query, Result>
        {
            private readonly HearthstoneDbContext _db;
            private readonly IMapper _mapper;

            public Handler(HearthstoneDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<Result> Handle(Query message)
            {
                var searchTerm = message?.Q ?? "";

                var cards = await _db.Cards
                    .Where(x => 
                        x.Name.Contains(searchTerm)
                        || x.Type.ToString() == searchTerm
                        || x.PlayerClass == searchTerm
                    ).ToListAsync();


                return new Result()
                {
                    Q = searchTerm,
                    Cards = _mapper.Map<IEnumerable<Card>, IEnumerable<CardModel>>(cards)
                };
            }
        }
    }
}