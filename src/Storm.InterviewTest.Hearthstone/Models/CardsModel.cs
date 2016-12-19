using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Domain;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class CardsModel
    {
        public string Q { get; set; }
        public string PlayerClass { get; set; }
        public IEnumerable<CardModel> Cards { get; set; }
    }
}