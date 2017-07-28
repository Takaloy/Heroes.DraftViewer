using System;
using System.IO;
using Heroes.DraftViewer.Core;
using NUnit.Framework;

namespace Heroes.DraftViewer.Tests
{
    [TestFixture]
    public class ReplayReaderTests
    {
        private readonly string _path =
            $@"{TestContext.CurrentContext.TestDirectory}\Sample\Battlefield of Eternity (398).StormReplay";

        [Test]
        public void DataParserCanParseStuffDecently()
        {
            var parser = new ReplayReader(_path);
            var chain = parser.GetDraftAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            Console.WriteLine(chain.EventPrint());

            Assert.That(chain, Is.Not.Null);
            Assert.That(chain.GetCurrentEventSequence(), Is.EqualTo(14));
        }

        [Test]
        public void LetUsVerifyThatSampleFileExist()
        {
            Console.WriteLine(_path);
            Assert.That(File.Exists(_path), Is.True);
        }
    }
}