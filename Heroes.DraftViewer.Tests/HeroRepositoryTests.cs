using System;
using NUnit.Framework;
using Heroes.DraftViewer.Core;

namespace Heroes.DraftViewer.Tests
{
    [TestFixture]
    public class HeroRepositoryTests
    {
        private IHeroRepository _repository;

        [OneTimeSetUp]
        public void Load()
        {
            _repository = new HeroRepository(new HeroResourceAttainer());
        }

        [TestCase("Valeera")]
        [TestCase("valeera")]
        [TestCase("Abathur")]
        public void Get_ForAGivenNameRetrieveCorrectHero(string name)
        {
            var hero = _repository.Get(name).ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.That(hero.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase), Is.True);
        }

        [Test]
        public void Get_ForAGivenNonFoundHero_ReturnNull()
        {
            var hero = _repository.Get("Deathwing").ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.That(hero, Is.Null);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _repository = null;
        }
    }
}
