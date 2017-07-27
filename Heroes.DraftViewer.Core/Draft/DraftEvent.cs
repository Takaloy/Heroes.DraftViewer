using System;
using Heroes.ReplayParser;

namespace Heroes.DraftViewer.Core
{
    public class DraftEvent : IDraftEvent
    {
        public DraftEvent(IPlayableHero hero, ReplayTrackerEvents.TrackerEventType eventType)
        {
            if (hero == null)
                throw new ArgumentNullException(nameof(hero));

            Hero = hero;
            EventType = eventType;
        }

        public ReplayTrackerEvents.TrackerEventType EventType { get; }
        public IPlayableHero Hero { get; }
    }
}