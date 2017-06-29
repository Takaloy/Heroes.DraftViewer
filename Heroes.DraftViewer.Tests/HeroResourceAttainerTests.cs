using System;
using System.Linq;
using Heroes.DraftViewer.Core;
using NUnit.Framework;

namespace Heroes.DraftViewer.Tests
{
    [TestFixture]
    public class HeroResourceAttainerTests
    {
        [Test]
        public void ThisThingDoesNotBlowUp()
        {
            var attainer = new HeroResourceAttainer();
            var collection = attainer.Get().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.That(collection.Count(), Is.GreaterThan(0));
        }
    }
}