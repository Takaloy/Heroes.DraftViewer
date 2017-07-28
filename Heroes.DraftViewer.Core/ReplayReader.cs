using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Heroes.ReplayParser;

namespace Heroes.DraftViewer.Core
{
    public interface IReplayReader
    {
        Task<DraftAction> GetDraftAsync();
    }

    public class ReplayReader : IReplayReader
    {
        private readonly Replay _replay;

        public ReplayReader(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            _replay = GetReplay(path);
        }

        public DraftAction GetDraft()
        {
            var events = _replay.TrackerEvents.Where(IsDraftEventType).OrderBy(r => r.TimeSpan).ThenBy(r => r.TrackerEventType);

            var chain = new DraftEventChain().GetEventHandler();
            foreach (var trackerEvent in events)
            {
                var trackerEventStructure = trackerEvent.Data.dictionary.Values.FirstOrDefault();
                var playableHero = new Hero { Name = trackerEventStructure?.blobText };
                var draftEvent = new DraftEvent(playableHero, trackerEvent.TrackerEventType);

                chain.Handle(draftEvent);
            }

            return chain;
        }

        private static Replay GetReplay(string path)
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
            return replay;
        }

        public async Task<DraftAction> GetDraftAsync()
        {
            return await Task.Run(() => GetDraft());
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
