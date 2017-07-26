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

                new BanHeroAction(8),
                new BanHeroAction(9),


                new SelectHeroAction(3),
                new SelectHeroAction(4), new SelectHeroAction(5),
                new SelectHeroAction(6), new SelectHeroAction(7),

                new SelectHeroAction(10), new SelectHeroAction(11),
                new SelectHeroAction(12), new SelectHeroAction(13),
                new SelectHeroAction(14)
            };

            for (var i = 0; i < actions.Length - 1; i++)
                actions[i].SetSuccessor(actions[i + 1]);

            return actions[0];
        }
    }
}