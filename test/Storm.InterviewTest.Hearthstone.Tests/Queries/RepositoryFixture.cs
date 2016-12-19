using System;
using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Services;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    public class RepositoryFixture
    {
        public IHearthstoneCardCache Repository { get; private set; }

        public IEnumerable<ICard> Cards
        {
            get
            {
                return new[]
                {
                    CreateRandomCardWithIdAndClass<MinionCard>("M1", "Mango"),
                    CreateRandomCardWithIdAndClass<MinionCard>("M2", "Apple"),
                    CreateRandomCardWithIdAndClass<SpellCard>("S1", "Kiwi"),
                    CreateRandomCardWithIdAndClass<WeaponCard>("W1", "Mango")
                 };
            }
        }


        public RepositoryFixture()
        {
            Repository = new HearthstoneCardCache(Cards);

        }

        private ICard CreateRandomCardWithIdAndClass<T>(string id, string playerClass) where T : class, ICard
        {
            var randomCardWithId = Activator.CreateInstance(typeof(T), id) as T;
            randomCardWithId.Name = typeof(T).Name + " " + id;
            randomCardWithId.PlayerClass = playerClass;
            return randomCardWithId;
        }
    }
}