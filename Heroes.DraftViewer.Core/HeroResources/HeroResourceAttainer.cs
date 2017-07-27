using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace Heroes.DraftViewer.Core
{
    public interface IHeroResourceAttainer
    {
        Task<IEnumerable<IPlayableHero>> Get();
    }

    public class HeroResourceAttainer : IHeroResourceAttainer
    {
        private IEnumerable<IPlayableHero> _playableHeroes;
        private const string HEROES_REQUEST = "https://api.masterleague.net//heroes/?format=json";    //I hate hardcodes!

        public async Task<IEnumerable<IPlayableHero>> Get()
        {
            if (_playableHeroes != null)
                return _playableHeroes;

            var heroesCollection = new List<Hero>();

            var next = HEROES_REQUEST;

            do
            {
                var restClient = new RestClient(next);
                var response = await restClient.ExecuteGetTaskAsync<HeroResponseRoot>(new RestRequest());

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    heroesCollection.AddRange(response.Data.Results);
                    next = response.Data.Next;
                }
                else
                {
                    next = null;
                }
            } while (!string.IsNullOrEmpty(next));

            _playableHeroes = heroesCollection;
            return _playableHeroes;
        }
    }

    /// <summary>
    /// data structure describing api.masterleague.net response style
    /// </summary>
    public class HeroResponseRoot
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Hero> Results { get; set; }
    }
}