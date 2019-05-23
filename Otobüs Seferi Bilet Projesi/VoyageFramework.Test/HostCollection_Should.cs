using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VoyageFramework.Test
{
    [TestClass]
    public class HostCollection_Should
    {
        [TestMethod]
        public void Add_ANewHost()
        {
            //ARRANGE
            DateTime DateOfBirth = new DateTime(1990, 06, 01);
            Host newHost = new Host("Oktay", "Çelik", DateOfBirth);
            HostCollection<Host> HostCollection = new HostCollection<Host>();
            int Expected = HostCollection.Length + 1;
            //ACT
            HostCollection.Add(newHost);
            int Actual = HostCollection.Length;
            //ASSERT
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void NotAdd_AnExistingHost()
        {
            //ARRANGE
            DateTime DateOfBirth = new DateTime(1990, 06, 01);
            Host newHost = new Host("Oktay", "Çelik", DateOfBirth);
            HostCollection<Host> HostCollection = new HostCollection<Host>();
            HostCollection.Add(newHost);
            int Expected = HostCollection.Length;
            //ACT
            HostCollection.Add(newHost);
            int Actual = HostCollection.Length;
            //ASSERT
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void GetHostAt_GivenIndex0()
        {
            //ARRANGE
            DateTime DateOfBirth = new DateTime(1990, 06, 01);
            Host newHost = new Host("Oktay", "Çelik", DateOfBirth);
            HostCollection<Host> HostCollection = new HostCollection<Host>();
            HostCollection.Add(newHost);
            Host Expected = newHost;
            //ACT
            Host Actual = HostCollection.GetHostAt(0);
            //ASSERT
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void RemoveAt_0AHost()
        {
            //ARRANGE
            DateTime DateOfBirth = new DateTime(1990, 06, 01);
            Host newHost = new Host("Oktay", "Çelik", DateOfBirth);
            HostCollection<Host> HostCollection = new HostCollection<Host>();
            HostCollection.Add(newHost);
            int Expected = HostCollection.Length - 1;
            //ACT
            HostCollection.RemoveAt(0);
            int Actual = HostCollection.Length;
            //ASSERT
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void RemoveAt_1AHost()
        {
            //ARRANGE
            DateTime DateOfBirth = new DateTime(1990, 06, 01);
            Host newHost = new Host("Oktay", "Çelik", DateOfBirth);
            HostCollection<Host> HostCollection = new HostCollection<Host>();
            HostCollection.Add(newHost);
            int Expected = HostCollection.Length - 1;
            //ACT
            HostCollection.RemoveAt(1);
            int Actual = HostCollection.Length;
            //ASSERT
            Assert.AreEqual(Expected, Actual);
        }


    }
}
