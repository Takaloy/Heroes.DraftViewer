using System.Collections.Generic;

namespace Heroes.DraftViewer.Core
{
    public interface IDraftEventModel
    {
        IDictionary<int, DraftAction> Bans { get; }
        IDictionary<int, DraftAction> Picks { get; }
    }


    public class DraftEventModel : IDraftEventModel
    {
        public IDictionary<int, DraftAction> Bans { get; set; }
        public IDictionary<int, DraftAction> Picks { get; set; }
    }
}