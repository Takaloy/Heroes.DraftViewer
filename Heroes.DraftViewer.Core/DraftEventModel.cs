using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Heroes.DraftViewer.Core
{

    public interface IDraftEventModel
    {
        IDictionary<int, IPlayableHero> Bans { get; }
        IDictionary<int, IPlayableHero> Picks { get; }
    }


    public class DraftEventModel : IDraftEventModel
    {
        public IDictionary<int, IPlayableHero> Bans { get; set; } = new Dictionary<int, IPlayableHero>();
        public IDictionary<int, IPlayableHero> Picks { get; set; } = new Dictionary<int, IPlayableHero>();
    }
}