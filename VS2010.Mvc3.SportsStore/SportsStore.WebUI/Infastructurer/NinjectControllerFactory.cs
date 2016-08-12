﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
//using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using System.Configuration;
using SportsStore.WebUI.Infastructurer.Abstract;
using SportsStore.WebUI.Infastructurer.Concrete;

namespace SportsStore.WebUI.Infastructurer
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
    //        Mock<IProductRepository> mock = new Mock<IProductRepository>();
    //        mock.Setup(m => m.Products).Returns(new List<Product> {
    //    new Product { Name = "Football", Price = 25 },
    //    new Product { Name = "Surf board", Price = 179 },
    //    new Product { Name = "Running shoes", Price = 95 }
    //}.AsQueryable());
    //        ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile
                    = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            ninjectKernel.Bind<IOrderProcessor>()
                    .To<EmailOrderProcessor>()
                    .WithConstructorArgument("settings", emailSettings);
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}