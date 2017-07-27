namespace Heroes.DraftViewer.Core
{
    public class BanHeroAction : DraftAction
    {
        public BanHeroAction(int sequence) : base(sequence)
        {
        }

        public override string ToString()
        {
            if (Hero == null)
                return $"{Sequence} : action not yet performed";

            return $"{Sequence} : {Hero} banned";
        }

        public override void Bag(IDraftEventModel model)
        {
            if (Hero == null)
                return;

            model.Bans.Add(Sequence, Hero);

            Successor?.Bag(model);
        }
    }
}