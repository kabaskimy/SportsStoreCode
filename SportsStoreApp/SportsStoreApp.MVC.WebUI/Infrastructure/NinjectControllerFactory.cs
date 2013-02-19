using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SportsStoreApp.MVC.Domain.Entities;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Concrete;
using Moq;

namespace SportsStoreApp.MVC.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            List<Product> list = new List<Product>{
                new Product{ Name="Football",Price=25},
                new Product{ Name="Surf board",Price=179},
                new Product{ Name="Running shoes",Price=95}
            };
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(list.AsQueryable());
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();

            EmailSetting emailSetting = new EmailSetting();
            ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("setting", emailSetting);
        }
    }
}