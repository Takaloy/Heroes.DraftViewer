using System;
using System.IO;
using System.Linq;
using Heroes.ReplayParser;

namespace Heroes.DraftViewer.Core
{
    public interface IReplayReader
    {
        DraftAction GetDraft(string path);
    }

    public class ReplayReader : IReplayReader
    {
        public DraftAction GetDraft(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"{path} could not be found. oops.");
            
            if (!path.EndsWith(".StormReplay", StringComparison.CurrentCultureIgnoreCase))
                throw new InvalidDataException($"{path} is not a valid replay file");

            var replayParseResult = DataParser.ParseReplay(path, false, false);

            if (replayParseResult.Item1 != DataParser.ReplayParseResult.Success)
            {
                throw new UnexpectedReplayException("unsuccessful replay load");
            }

            var replay = replayParseResult.Item2;

            var events = replay.TrackerEvents.Where(IsDraftEventType).OrderBy(r => r.TimeSpan);

            var chain = new DraftEventChain().GetEventHandler();
            foreach (var trackerEvent in events)
            {
                chain.Handle(new Hero { Name = trackerEvent.Data.dictionary.Values.FirstOrDefault()?.ToString() });
            }

            return chain;
        }

        private static bool IsDraftEventType(TrackerEvent e)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.TrackerEventType)
            {
                case ReplayTrackerEvents.TrackerEventType.HeroBannedEvent:
                case ReplayTrackerEvents.TrackerEventType.HeroPickedEvent:
                    return true;
                default:
                    return false;
            }
        }
    }
}
