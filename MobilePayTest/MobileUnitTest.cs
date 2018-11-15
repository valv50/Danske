using MobilePay;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobilePayTest
{
    [TestClass]
    public class MobileUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CalculateFee calculateFee = new CalculateFee();
            object[][] data =
                new object[][] 
                { 
                    new object[] { "7-ELEVEN", 100M, 30M }, 
                    new object[] { "CIRCLE_K", 100M, 29.70M },
                };
            decimal expected;
            decimal actual;
            foreach (object[] values in data)
            {
                expected = (decimal)values[2];
                actual = calculateFee
                    .CalculateClientFees(
                    values[0].ToString(),
                    (decimal)values[1]);

                Assert.AreEqual(expected, actual, 
                    string.Format(
                    "{0} fee is not correct"
                    , values[0].ToString())
                    , null
                    );
            }
        }
    }
}
