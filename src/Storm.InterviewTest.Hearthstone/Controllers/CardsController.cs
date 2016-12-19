using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Storm.InterviewTest.Hearthstone.Core.Services;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
        private ICardSearchService _cardSearchService;

        public CardsController(ICardSearchService cardSearchService)
        {
            _cardSearchService = cardSearchService;
        }

        public IActionResult Index(CardsModel model)
        {
            //TODO: Populate this from DB usually, cached
            ViewData["PlayerClasses"] = new[] { "Warlock", "Druid", "Warrior", "Hunter", "Rogue", "Shaman", "Mage", "Paladin", "Priest" };

            var cards = _cardSearchService.Search(model.Q, model.PlayerClass);
            model.Cards = cards;
            return View(model);
        }
    }
}