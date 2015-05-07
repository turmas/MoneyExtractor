using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyExtractor.Core.Processors;
using System.Diagnostics.CodeAnalysis;

namespace MoneyExtractor.Test.MoneyExtractor.Core.Test {

    /// <summary>
    /// Summary description for BillProcessorTest
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BillProcessorTest {

        [TestMethod]
        public void CalculateChange_ChangeFor1600_Test() {

            BillProcessor billProcessor = new BillProcessor();

            Dictionary<long, long> result = billProcessor.CalculateChange(1600);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Any(p => p.Key == 1000 && p.Value == 1));
            Assert.IsTrue(result.Any(p => p.Key == 500 && p.Value == 1));

        }

    }
}
