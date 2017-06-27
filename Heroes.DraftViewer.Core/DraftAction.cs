using System;
using System.Text;

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

        public string EventPrint()
        {
            if (Successor?.HasBeenApplied() ?? false)
                return $"{ToString()}{Environment.NewLine}{Successor.EventPrint()}";

            return ToString();
            //if (Successor == null || !Successor.HasBeenApplied())
            //    return ToString();

            //return $"{ToString()}{Environment.NewLine}{Successor.EventPrint()}";
        }

        public int GetCurrentEventSequence()
        {
            if (Successor != null && Successor.HasBeenApplied())
                return Successor.GetCurrentEventSequence();

            return Sequence;
        }

        private bool HasBeenApplied() => Hero != null;

    }

    public class SelectHeroAction : DraftAction
    {
        public SelectHeroAction(int sequence) : base(sequence)
        {
        }

        public override string ToString()
        {
            if (Hero == null)
                return $"{Sequence} : action not yet performed";

            return $"{Sequence} : {Hero} picked";
        }
    }

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
    }
}