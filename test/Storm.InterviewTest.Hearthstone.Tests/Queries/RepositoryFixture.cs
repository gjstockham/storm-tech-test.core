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
                    CreateRandomCardWithId<MinionCard>("M1"),
                    CreateRandomCardWithId<MinionCard>("M2"),
                    CreateRandomCardWithId<SpellCard>("S1"),
                    CreateRandomCardWithId<WeaponCard>("W1")
                 };
            }
        }


        public RepositoryFixture()
        {
            Repository = new HearthstoneCardCache(Cards);

        }

        private ICard CreateRandomCardWithId<T>(string id) where T : class, ICard
        {
            var randomCardWithId = Activator.CreateInstance(typeof(T), id) as T;
            randomCardWithId.Name = typeof(T).Name + " " + id;
            return randomCardWithId;
        }
    }
}