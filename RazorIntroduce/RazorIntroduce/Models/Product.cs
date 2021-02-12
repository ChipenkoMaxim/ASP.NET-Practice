using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorIntroduce.Models
{
    public class Product
    {
        public Int32 ProductID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Category { get; set; }
    }
}