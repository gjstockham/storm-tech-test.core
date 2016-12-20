using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Storm.InterviewTest.Hearthstone.Controllers.Cards;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
        private IMediator _mediator;
        
        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(Index.Query query)
        {
            var model = await _mediator.SendAsync(query);

            return View(model);
        }

        public async Task<IActionResult> Details(Details.Query query)
        {
            var model = await _mediator.SendAsync(query);

            return View(model);
        }
    }
}