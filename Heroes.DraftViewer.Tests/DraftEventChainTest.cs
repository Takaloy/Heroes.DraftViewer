using System;
using System.Collections.Generic;
using System.Linq;
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
        [TestCase(12, 12)]
        [TestCase(15, 12)]
        public void EventChainReturnsExactlyUpTo12Commands(int simulateActions, int expectation)
        {
            var chain = new DraftEventChain().GetEventHandler();

            for (var x = 0; x < simulateActions; x++)
            {
                chain.Handle(new Hero(Guid.NewGuid().ToString()));
            }

            Assert.That(chain.GetCurrentEventSequence, Is.EqualTo(expectation));
        }
    }
}
