using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class Product
    {
        private String name;
        public Int32 ProductID { get; set; }
        public String Name 
        {
            get { return ProductID + name; }
            set { name = value; } 
        }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Category { get; set; }
    }
}