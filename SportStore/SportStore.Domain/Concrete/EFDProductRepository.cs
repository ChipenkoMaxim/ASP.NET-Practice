using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;
using SportStore.Domain.Abstract;


namespace SportStore.Domain.Concrete
{
    public class EFDProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
