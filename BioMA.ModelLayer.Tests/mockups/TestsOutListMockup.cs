using CRA.ModelLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMA.ModelLayer.NetFramework.Tests.mockups
{
    public class TestsOutListMockup : ITestsOutput
    {
        public TestsOutListMockup()
        {
            Entries = new List<PreconditionsEntry>();
        }

        public List<PreconditionsEntry> Entries { get; }

        public void TestsOut(string testResult, bool saveLog, string componentName)
        {
            Entries.Add(new PreconditionsEntry()
            {
                ComponentName = componentName,
                Entry = testResult,
                Date = DateTime.Now
            });
        }
    }

    public class PreconditionsEntry
    {
        public DateTime Date { get; set; }
        public string ComponentName { get; set; }
        public string Entry { get; set; }
    }
}
