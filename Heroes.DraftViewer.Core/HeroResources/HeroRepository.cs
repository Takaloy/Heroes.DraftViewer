using System;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.DraftViewer.Core
{
    public interface IHeroRepository
    {
        Task<IPlayableHero> Get(string name);
    }

    public class HeroRepository : IHeroRepository
    {
        private readonly IHeroResourceAttainer _heroResourceAttainer;

        public HeroRepository(IHeroResourceAttainer heroResourceAttainer)
        {
            if (heroResourceAttainer == null)
                throw new ArgumentNullException(nameof(heroResourceAttainer));

            _heroResourceAttainer = heroResourceAttainer;
        }

        public async Task<IPlayableHero> Get(string name)
        {
            var heroes = await _heroResourceAttainer.Get();
            return heroes.FirstOrDefault(n => string.Equals(n.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}