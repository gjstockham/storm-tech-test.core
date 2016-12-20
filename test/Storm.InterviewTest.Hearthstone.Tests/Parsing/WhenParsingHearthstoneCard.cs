using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Shouldly;
using Storm.InterviewTest.Hearthstone.Core.Services;
using Storm.InterviewTest.Hearthstone.Data.Domain;
using Xunit;

namespace Storm.InterviewTest.Hearthstone.Tests.Parsing
{
    public class WhenParsingHearthstoneCard : IDisposable
    {
        protected Stream _cardStream;
        protected string _cardData;

        protected HearthstoneCardParser _parser;


        public WhenParsingHearthstoneCard()
        {
            _cardStream = GetCardsDataAsStream();
            using (var reader = new StreamReader(_cardStream))
            {
                var data = reader.ReadToEnd();
                var jsonData = JObject.Parse(data);
                _cardData = jsonData.ToString();
            }

            _parser = new HearthstoneCardParser();
        }

        protected Stream GetCardsDataAsStream()
        {
            var assemblyLocation = GetType().GetTypeInfo().Assembly.Location;
            var fileLocation = Path.Combine(Path.GetDirectoryName(assemblyLocation), "data", "testcard.json");

            return File.OpenRead(fileLocation);

        }

        public void Dispose()
        {
            _cardStream?.Dispose();
        }

        [Fact]
        public void ShouldContainExpectedProperties()
        {
            var card = _parser.Parse(_cardData);

            card.ShouldNotBeNull();
            card.Id.ShouldBe("EX1_066");
            card.ShouldBeOfType(typeof(MinionCard));
        }
    }
}