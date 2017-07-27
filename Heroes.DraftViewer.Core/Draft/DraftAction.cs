using System;

namespace Heroes.DraftViewer.Core
{
    public abstract class DraftAction
    {
        protected IPlayableHero Hero;
        protected DraftAction Successor;

        protected DraftAction(int sequence)
        {
            Sequence = sequence;
        }

        public int Sequence { get; }

        public void SetSuccessor(DraftAction successor)
        {
            Successor = successor;
        }

        public virtual void Handle(IPlayableHero hero)
        {
            if (hero == null)
                throw new ArgumentNullException(nameof(hero));

            if (Hero == null)
                Hero = hero;
            else
                Successor?.Handle(hero);
        }

        public abstract void Bag(IDraftEventModel model);

        public string EventPrint()
        {
            if (Successor?.HasBeenApplied() ?? false)
                return $"{ToString()}{Environment.NewLine}{Successor.EventPrint()}";

            return ToString();
        }

        public int GetCurrentEventSequence()
        {
            if (Successor != null && Successor.HasBeenApplied())
                return Successor.GetCurrentEventSequence();

            return Sequence;
        }

        private bool HasBeenApplied()
        {
            return Hero != null;
        }
    }
}