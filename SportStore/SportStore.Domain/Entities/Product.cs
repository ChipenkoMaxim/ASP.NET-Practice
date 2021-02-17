using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public Int32 ProductID { get; set; }
        public Decimal Price { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        public String Category { get; set; }
        public String Name { get; set; }
    }
}
