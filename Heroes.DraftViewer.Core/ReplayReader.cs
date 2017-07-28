using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Heroes.ReplayParser;

namespace Heroes.DraftViewer.Core
{
    public interface IReplayReader
    {
        DraftAction GetDraft(string path);
        Task<DraftAction> GetDraftAsync(string path);
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

            var events = replay.TrackerEvents.Where(IsDraftEventType).OrderBy(r => r.TimeSpan).ThenBy(r => r.TrackerEventType);

            var chain = new DraftEventChain().GetEventHandler();
            foreach (var trackerEvent in events)
            {
                var playableHero = new Hero { Name = trackerEvent.Data.dictionary.Values.FirstOrDefault()?.ToString() };
                var draftEvent = new DraftEvent(playableHero, trackerEvent.TrackerEventType);

                chain.Handle(draftEvent);
            }

            return chain;
        }

        public Task<DraftAction> GetDraftAsync(string path)
        {
            return Task.Run(() => GetDraft(path));
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
