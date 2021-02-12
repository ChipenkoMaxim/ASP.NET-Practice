using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using System;
using Moq;
using System.Linq;

namespace EssentialTool.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products =
        {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<Decimal>()))
                .Returns<Decimal>(total => total);

            var target = new LinqValueCalculator(mock.Object);

            var result = target.ValueProducts(products);

            Assert.AreEqual(products.Sum(e => e.Price), result);
        }

        private Product[] createProduct(Decimal value)
        {
            return new[] { new Product { Price = value } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<Decimal>()))
                .Returns<Decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<Decimal>(v => v == 0)))
                .Throws<ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<Decimal>(v => v > 100)))
                .Returns<Decimal>(total => (total * 0.9M));
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<Decimal>(10, 100, Range.Inclusive)))
                .Returns<Decimal>(total => total - 5);

            var target = new LinqValueCalculator(mock.Object);

            Decimal FiveDollarDiscount = target.ValueProducts(createProduct(5));
            Decimal TenDollarDiscount = target.ValueProducts(createProduct(10));
            Decimal FiftyDollarDiscount = target.ValueProducts(createProduct(50));
            Decimal HundredDollarDiscount = target.ValueProducts(createProduct(100));
            Decimal FiveHundredDollarDiscount = target.ValueProducts(createProduct(500));

            Assert.AreEqual(5, FiveDollarDiscount, "$5 dollar fail");
            Assert.AreEqual(5, TenDollarDiscount, "$10 dollar fail");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 dollar fail");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 dollar fail");
            Assert.AreEqual(450, FiveHundredDollarDiscount, "$500 dollar fail");
            target.ValueProducts(createProduct(0));
        }
    }
}
