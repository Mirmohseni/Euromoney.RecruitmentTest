using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.DAL;
using ContentConsole.Core;
using NUnit.Framework;


namespace ContentConsole.Test.Unit
{
    [TestFixture]
    class ContentAnalyserTest
    {
        [Test]
        public void CountNegativeWordsTest()
        {
            string content = "The horrible tea tasted horrible.";
            string[] negativeWords = new string[] { "horrible", "bad" };
            IContentAnalyser contentAnalyser = new ContentAnalyser(content, negativeWords);

            Assert.AreEqual(1, contentAnalyser.CountNegativeWords());
            Assert.AreEqual(2, contentAnalyser.CountAllNegativeWords());
        }

        [Test]
        public void FilterContentTest()
        {
            string content = "The horrible tea tasted horrible.";
            string[] negativeWords = new string[] { "horrible", "bad" };
            IContentAnalyser contentAnalyser = new ContentAnalyser(content, negativeWords);

            Assert.AreEqual("The h######e tea tasted h######e.", contentAnalyser.FilterContent());
        }
    }
}
