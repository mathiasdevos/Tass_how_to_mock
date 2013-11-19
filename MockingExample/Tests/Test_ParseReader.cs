using System;
using NUnit.Framework;
using Moq;
using System.IO;
using MockingExample;
using MockingExample.Exceptions;

namespace Tests
{
    [TestFixture]
    public class Test_ParseReader
    {
        [Test]
        public void Test_NoHeaderLines()
        {
            string version = "1.2.3";

            var readerMock = new Mock<TextReader>();
            readerMock.Setup(reader => reader.ReadLine()).Returns(version);
            
            var parser = new ParseReader();

            Assert.AreEqual(version, parser.Parse(readerMock.Object, 0));
        }

        [Test]
        public void Test_NoContent()
        {
            string version = null;

            var readerMock = new Mock<TextReader>();
            readerMock.Setup(reader => reader.ReadLine()).Returns(version);

            var parser = new ParseReader();

            Assert.Throws<FileToShortException>(() => parser.Parse(readerMock.Object, 0));
        }

        [Test]
        public void Test_TwoHeaderLines()
        {
            string version = "1.3.7";
            string[] returnValues = new string[] { "dummy", "dummy", version };
            int i = 0;

            var readerMock = new Mock<TextReader>();
            readerMock.Setup(reader => reader.ReadLine()).Returns(() => returnValues[i]).Callback(() => i++);

            var parser = new ParseReader();

            Assert.AreEqual(version, parser.Parse(readerMock.Object, 2));
        }

        [Test]
        public void Test_ToShort()
        {
            string version = "1.3.7";
            string[] returnValues = new string[] { "dummy", "dummy", version, null, null };
            int i = 0;

            var readerMock = new Mock<TextReader>();
            readerMock.Setup(reader => reader.ReadLine()).Returns(() => returnValues[i]).Callback(() => i++);

            var parser = new ParseReader();

            Assert.Throws<FileToShortException>(() => parser.Parse(readerMock.Object, 4));
        }
    }
}
