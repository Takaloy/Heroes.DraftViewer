using Heroes.ReplayParser;

namespace Heroes.DraftViewer.Core
{
    public class SelectHeroAction : DraftAction
    {
        private ReplayTrackerEvents.TrackerEventType _eventTrackerType = ReplayTrackerEvents.TrackerEventType.HeroPickedEvent;

        public SelectHeroAction(int sequence) : base(sequence)
        {
        }

        public override string ToString()
        {
            if (Hero == null)
                return $"{Sequence} : action not yet performed";

            return $"{Sequence} : {Hero} picked";
        }

        public override void Bag(IDraftEventModel model)
        {
            if (Hero == null)
                return;

            model.Picks.Add(Sequence, Hero);

            Successor?.Bag(model);
        }

        public override bool IsRelevantEvent(IDraftEvent draftEvent)
        {
            if (draftEvent.EventType == _eventTrackerType)
                return true;

            return false;
        }
    }
}