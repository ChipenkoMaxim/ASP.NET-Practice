using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public String Index()
        {
            return "Navigate to URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kayak";
            String productName = myProduct.Name;
            return View("Result", (Object)String.Format("Product name: {0}", productName));
        }

        public ViewResult CreatePoint()
        {
            Product myProduct = new Product()
            {
                Name = "Kyak",
                Category = "Watersports",
                Description = "A boat for one person",
                Price = 100,
                ProductID = 100
            };
            return View("Result",
                (Object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            String[] stringArray = { "apple", "orange", "plum" };
            List<Int32> intList = new List<Int32> { 10, 20, 30, 40 };
            Dictionary<String, Int32> myDict = new Dictionary<String, Int32>
            { { "apple", 10 }, { "orange", 20 }, { "plum", 30 }
            };

            return View("Result", (Object)stringArray[1]);
        }

        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };
            Decimal cartTotal = cart.TotalPrices();
            return View("Result",
                (Object)String.Format("Total: {0:c}", cartTotal));
        }


        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
            };
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            return View("Result",
                (Object)String.Format("Cart Total: {0}, Array Total: {1}",
                cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Category = "WaterSports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };

            Decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += prod.Price;
            }
            return View("Result", (Object)String.Format("Total: {0}", total));
        }

        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name = "MVC", Category = "Pattern"},
                new {Name = "Hat", Category = "Clothing"},
                new {Name = "Apple", Category = "Fruit"}
            };
            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }
            return View("Result", (Object)result.ToString());
        }

        public ViewResult FindProducts()
        {
            Product[] products =
            {
                    new Product {Name = "Kayak", Category = "WaterSports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            //var foundProducts = from match in products
            //                    orderby match.Price descending
            //                    select new
            //                    {
            //                        match.Name,
            //                        match.Price
            //                    };

            var foundProducts = products.OrderByDescending(e => e.Price)
                .Take(3)
                .Select(e => new
                {
                    e.Name,
                    e.Price
                });

            products[2] = new Product { Name = "Stadium", Price = 79600M };
            //Int32 count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);
                //if (++count == 3)
                //{
                //    break;
                //}
            }
            return View("Result", (Object)result.ToString());
        }

        public ViewResult SumProducts()
        {
            Product[] products =
            {
                new Product {Name = "Kayak", Category = "WaterSports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            var results = products.Sum(e => e.Price);

            products[2] = new Product { Name = "Stadium", Price = 79500M };

            return View("Result", (Object)String.Format("Sum: {0:c}", results));
        }
    }
}