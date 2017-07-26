using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.DraftViewer.Core;
using Heroes.ReplayParser;
using NUnit.Framework;

namespace Heroes.DraftViewer.Tests
{
    [TestFixture]
    public class ReplayReaderTests
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
            var parser = new ReplayReader();
            var chain = parser.GetDraft(path);

            Console.WriteLine(chain.EventPrint());

            Assert.That(chain, Is.Not.Null);
            Assert.That(chain.GetCurrentEventSequence(), Is.EqualTo(14));
        }
    }
}
