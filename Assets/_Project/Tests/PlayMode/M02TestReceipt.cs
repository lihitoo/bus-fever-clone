using System;
using System.IO;
using NUnit.Framework.Interfaces;
using UnityEngine.TestRunner;

[assembly: TestRunCallback(typeof(Dreamy.Template.Tests.M02TestReceipt))]

namespace Dreamy.Template.Tests
{
    /// <summary>Retain NUnit's actual leaf result across the bridge's scene/domain reloads.</summary>
    public sealed class M02TestReceipt : ITestRunCallback
    {
        public void RunStarted(ITest test) { }
        public void RunFinished(ITestResult result) { }
        public void TestStarted(ITest test) { }
        public void TestFinished(ITestResult result)
        {
#if UNITY_EDITOR
            if (result.Test.IsSuite || !result.FullName.StartsWith("Dreamy.Template.Tests.M02GameplayFlowTests.")) return;
            const string directory = "docs/clone-plan/evidence/M02/tests";
            Directory.CreateDirectory(directory);
            File.WriteAllText(Path.Combine(directory, "flow-" + DateTime.UtcNow.ToString("yyyyMMdd-HHmmss-fff") + ".xml"), result.ToXml(true).OuterXml);
#endif
        }
    }
}
