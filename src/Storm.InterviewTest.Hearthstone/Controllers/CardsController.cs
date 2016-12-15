using Microsoft.AspNetCore.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
        private ICardSearchService _cardSearchService;
        
        public CardsController(ICardSearchService cardSearchService)
        {
            _cardSearchService = cardSearchService;
        }

        public IActionResult Index(string q = null)
        {
           var cards = _cardSearchService.Search(q);

            return View(cards);
        }
    }
}