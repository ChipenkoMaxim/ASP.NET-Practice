using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        Decimal ApplyDiscount(Decimal totalParam);
    }
    public class Discount : IDiscountHelper
    {
        public Decimal discountSize;
        public Discount(Decimal discountParam)
        {
            discountSize = discountParam;
        }
        public Decimal ApplyDiscount(Decimal totalParam)
        {
            return (totalParam - (discountSize / 100m * totalParam));
        }
    }
}