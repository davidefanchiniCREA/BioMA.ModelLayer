using BioMA.ModelLayer.NetFramework.Tests.mockups;
using CRA.ModelLayer.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioMA.ModelLayer.NetFramework.Tests
{
    [TestClass]
    public class TestPreconditionsWriter
    {
        [TestMethod]
        public void SimpleWrite()
        {
            var preconditionsWriter = new TestsOutListMockup();
            var preconditions = new Preconditions();
            DateTime dateBeforeTest = DateTime.Now;
            Thread.Sleep(10);

            preconditions.TestsOut(preconditionsWriter, "alfredo", true, "component");

            Thread.Sleep(10);
            DateTime dateAfterTest = DateTime.Now;

            var preconditionsEntries = preconditionsWriter.Entries;

            Assert.AreEqual(1, preconditionsEntries.Count);
            Assert.IsTrue(preconditionsEntries[0].Date > dateBeforeTest);
            Assert.IsTrue(dateAfterTest > preconditionsEntries[0].Date);
            Assert.AreEqual("alfredo", preconditionsEntries[0].Entry);
            Assert.AreEqual("component", preconditionsEntries[0].ComponentName);
        }
    }
}
