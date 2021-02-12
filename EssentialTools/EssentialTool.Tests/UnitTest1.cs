using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using System;

namespace EssentialTool.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            IDiscountHelper target = getTestObject();
            Decimal total = 200;

            var discountedTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            IDiscountHelper target = getTestObject();
            Decimal TenDollarDiscount = target.ApplyDiscount(10);
            Decimal HundredDollarDiscount = target.ApplyDiscount(100);
            Decimal FiftyDollarDiscount = target.ApplyDiscount(50);

            Assert.AreEqual(5, TenDollarDiscount, "10$ discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "100$ discount is wrong");
            Assert.AreEqual(45, FiftyDollarDiscount, "50$ discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            IDiscountHelper target = getTestObject();

            Decimal discount5 = target.ApplyDiscount(5);
            Decimal disocunt0 = target.ApplyDiscount(0);

            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, disocunt0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            IDiscountHelper target = getTestObject();
            target.ApplyDiscount(-1);
        }
    }
}
