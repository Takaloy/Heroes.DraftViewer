using Heroes.ReplayParser;

namespace Heroes.DraftViewer.Core
{
    public interface IDraftEvent
    {
        ReplayTrackerEvents.TrackerEventType EventType { get; }
        IPlayableHero Hero { get; }
    }
}