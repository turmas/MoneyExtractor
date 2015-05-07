using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyExtractor.Core.Processors;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MoneyExtractor.Test.MoneyExtractor.Core.Test {

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CoinProcessorTest {

        [TestMethod]
        public void CalculateChange_ChangeFor123_Test() {

            CoinProcessor coinProcessor = new CoinProcessor();

            Dictionary<long, long> result = coinProcessor.CalculateChange(123);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result.Any(p => p.Key == 100 && p.Value == 1));
            Assert.IsTrue(result.Any(p => p.Key == 10 && p.Value == 2));
            Assert.IsTrue(result.Any(p => p.Key == 1 && p.Value == 3));
        }

        [TestMethod]
        public void CalculateChange_ChangeFor0_Test() {
            CoinProcessor coinProcessor = new CoinProcessor();

            Dictionary<long, long> result = coinProcessor.CalculateChange(0);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
            
        }
    }
}
