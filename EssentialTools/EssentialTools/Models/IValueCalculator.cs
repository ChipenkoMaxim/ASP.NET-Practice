using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IValueCalculator
    {
        Decimal ValueProducts(IEnumerable<Product> products);
    }
}