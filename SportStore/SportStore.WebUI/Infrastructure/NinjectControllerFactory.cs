using System;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using SportStore.Domain.Entities;
using SportStore.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using SportStore.Domain.Concrete;

namespace SportStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IProductsRepository>().To<EFDProductRepository>();
        }
    }
}