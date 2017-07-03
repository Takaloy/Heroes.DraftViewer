using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.ReplayParser;
using NUnit.Framework;

namespace Heroes.DraftViewer.Tests
{
    [TestFixture]
    public class ReplayParserTests
    {
        private readonly string path = $@"{TestContext.CurrentContext.TestDirectory}\Sample\Battlefield of Eternity (398).StormReplay";

        [Test]
        public void LetUsVerifyThatSampleFileExist()
        {
            
            Console.WriteLine(path);
            Assert.That(File.Exists(path), Is.True);
        }

        [Test]
        public void DataParserCanParseStuffDecently()
        {
            var replayParseResult = DataParser.ParseReplay(path, false, false);

            if (replayParseResult.Item1 != DataParser.ReplayParseResult.Success)
            {
                throw new Exception("unsuccessful replay load");
            }

            var replay = replayParseResult.Item2;

            var events = replay.TrackerEvents.Where(Interested).OrderBy(r => r.TimeSpan);
            foreach (var trackerEvent in events)
            {
                Console.WriteLine(trackerEvent.Data.dictionary.Values.FirstOrDefault());
            }
        }

        private bool Interested(TrackerEvent e)
        {
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
