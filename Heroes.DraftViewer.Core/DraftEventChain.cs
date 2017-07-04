namespace Heroes.DraftViewer.Core
{
    public class DraftEventChain
    {
        public DraftAction GetEventHandler()
        {
            var actions = new DraftAction[]
            {
                new BanHeroAction(1),
                new BanHeroAction(2),

                new SelectHeroAction(3),
                new SelectHeroAction(4), new SelectHeroAction(5),

                new BanHeroAction(6),
                new BanHeroAction(7),

                new SelectHeroAction(8), new SelectHeroAction(9),
                new SelectHeroAction(10), new SelectHeroAction(11),
                new SelectHeroAction(12)
            };

            for (var i = 0; i < actions.Length - 1; i++)
                actions[i].SetSuccessor(actions[i + 1]);

            return actions[0];
        }
    }
}