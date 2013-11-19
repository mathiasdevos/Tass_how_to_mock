using System;
using NUnit.Framework;
using Moq;
using MockingExample;
using MockingExample.Exceptions;
using MockingExample.Interfaces;
using MockingExample.Adapters;

namespace Tests
{
    [TestFixture]
    public class Test_CompareVersions
    {
        [Test]
        public void Test_SameVersion()
        {
            //Version localVersion;
            IVersion onlineVersion = new VersionAdapter(new Version("1.2.3"));
            int returnValue = 0;
            bool isNewVersionAvailable = false;

            var localVersionMock = new Mock<IVersion>();
            localVersionMock.Setup(localVersion => localVersion.CompareTo(onlineVersion)).Returns(returnValue);

            var comp = new CompareVersions();
            Assert.DoesNotThrow(() => comp.Compare(localVersionMock.Object, onlineVersion));
            Assert.AreEqual(isNewVersionAvailable, comp.IsNewerVersionAvailable);
        }

        [Test]
        public void Test_NewVersionAvailable()
        {
            //Version localVersion;
            IVersion onlineVersion = new VersionAdapter(new Version("1.2.3"));
            int returnValue = -1;
            bool isNewVersionAvailable = true;

            var localVersionMock = new Mock<IVersion>();
            localVersionMock.Setup(localVersion => localVersion.CompareTo(onlineVersion)).Returns(returnValue);

            var comp = new CompareVersions();
            Assert.DoesNotThrow(() => comp.Compare(localVersionMock.Object, onlineVersion));
            Assert.AreEqual(isNewVersionAvailable, comp.IsNewerVersionAvailable);
        }

        [Test]
        public void Test_LocalVersionNewer()
        {
            IVersion onlineVersion = new VersionAdapter(new Version("1.2.3"));
            int returnValue = 1;

            var localVersionMock = new Mock<IVersion>();
            localVersionMock.Setup(localVersion => localVersion.CompareTo(onlineVersion)).Returns(returnValue);

            var comp = new CompareVersions();
            Assert.Throws<LocalVersionNewerException>(() => comp.Compare(localVersionMock.Object, onlineVersion));
        }

        [Test]
        public void Test_test()
        {
            IVersion onlineVersion = new VersionAdapter(new Version("1.2.3"));
            IVersion onlineVersion2 = new VersionAdapter(new Version("1.2.3"));
            int returnValue = 1;
            int returnValue2 = 0;

            var localVersionMock = new Mock<IVersion>();
            localVersionMock.Setup(localVersion => localVersion.CompareTo(onlineVersion2)).Returns(returnValue2);
            localVersionMock.Setup(localVersion => localVersion.CompareTo(onlineVersion)).Returns(returnValue);

            var comp = new CompareVersions();
            Assert.Throws<LocalVersionNewerException>(() => comp.Compare(localVersionMock.Object, onlineVersion));
            Assert.DoesNotThrow(() => comp.Compare(localVersionMock.Object, onlineVersion2));
            Assert.AreEqual(false, comp.IsNewerVersionAvailable);
        }
    }
}
