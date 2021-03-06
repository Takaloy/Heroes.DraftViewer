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

        public virtual void Handle(IDraftEvent draftEvent)
        {
            if (draftEvent == null)
                throw new ArgumentNullException(nameof(draftEvent));

            if (Hero == null && IsRelevantEvent(draftEvent))
                Hero = draftEvent.Hero;
            else
                Successor?.Handle(draftEvent);
        }

        public abstract bool IsRelevantEvent(IDraftEvent draftEvent);

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