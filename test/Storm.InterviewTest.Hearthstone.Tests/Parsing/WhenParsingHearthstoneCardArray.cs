using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Services;
using Storm.InterviewTest.Hearthstone.Data.Domain;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Parsing
{
    public class WhenParsingHearthstoneCardArray : IDisposable
    {
        protected Stream _cardStream;
        protected string _cardsData;

        protected HearthstoneCardParser _parser;

        public WhenParsingHearthstoneCardArray()
        {
            _cardStream = GetCardsDataAsStream();
            using (var reader = new StreamReader(_cardStream))
            {
                var data = reader.ReadToEnd();
                var jsonData = JArray.Parse(data);
                _cardsData = jsonData.ToString();
            }

            _parser = new HearthstoneCardParser();
        }

        protected Stream GetCardsDataAsStream()
        {
            var assemblyLocation = GetType().GetTypeInfo().Assembly.Location;
            var fileLocation = Path.Combine(Path.GetDirectoryName(assemblyLocation), "data", "testcards.json");

            return File.OpenRead(fileLocation);

        }


        [Fact]
        public void ShouldHaveParsedExpectedCardTypes()
        {
            var cards = _parser.ParseArray(_cardsData);

            cards.ShouldNotBeNull();
            cards.Count().ShouldBe(3);
            cards.OfType<MinionCard>().Count().ShouldBe(1);
            cards.OfType<WeaponCard>().Count().ShouldBe(1);
            cards.OfType<SpellCard>().Count().ShouldBe(1);
        }

        public void Dispose()
        {
            _cardStream?.Dispose();
        }
    }
}