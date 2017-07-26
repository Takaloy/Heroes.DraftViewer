using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Heroes.DraftViewer.Core;
using NUnit.Framework;

namespace Heroes.DraftViewer.Tests
{
    [TestFixture]
    public class DraftEventChainTest
    {
        [TestCase(5,5)]
        [TestCase(14, 14)]
        [TestCase(15, 14)]
        public void EventChainReturnsExactlyUpTo14Commands(int simulateActions, int expectation)
        {
            var chain = new DraftEventChain().GetEventHandler();

            for (var x = 0; x < simulateActions; x++)
            {
                chain.Handle(new Hero
                {
                    Id = x,
                    Name = Guid.NewGuid().ToString()
                });
            }

            Assert.That(chain.GetCurrentEventSequence, Is.EqualTo(expectation));
        }

        [Test]
        public void Bag_CreatesExpectedModel()
        {
            var chain = new DraftEventChain().GetEventHandler();

            for (var x = 0; x < 14; x++)
            {
                chain.Handle(new Hero
                {
                    Id = x,
                    Name = Guid.NewGuid().ToString()
                });
            }

            var model = new DraftEventModel();
            chain.Bag(model);

            Assert.That(model.Bans.Count, Is.EqualTo(4));
            Assert.That(model.Picks.Count, Is.EqualTo(10));

            CollectionAssert.AreEqual(model.Bans.Keys, new[] {1, 2, 8, 9});
            CollectionAssert.AreEqual(model.Picks.Keys, new[] {3, 4, 5, 6, 7, 10, 11, 12, 13, 14});
        }
    }
}
