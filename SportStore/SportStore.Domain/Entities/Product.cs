using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Entities
{
    public class Product
    {
        public Int32 ProductID { get; set; }
        public Decimal Price { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public String Name { get; set; }
    }
}
