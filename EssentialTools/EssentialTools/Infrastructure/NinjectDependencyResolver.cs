using System;
using System.Collections.Generic;
using Ninject;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public Object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        
        public IEnumerable<Object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            kernel.Bind<IDiscountHelper>()
                .To<Discount>().WithConstructorArgument("discountParam", 50M);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>()
                .WhenInjectedExactlyInto<LinqValueCalculator>();
        }
    }
}