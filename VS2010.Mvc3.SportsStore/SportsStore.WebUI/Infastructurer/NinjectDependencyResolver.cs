using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Infastructurer.Abstract;
using SportsStore.WebUI.Infastructurer.Concrete;
using System.Configuration;

namespace SportsStore.WebUI.Infastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        /// <summary>
        /// 只有程序起动的时候初始化一次
        /// </summary>
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        /// <summary>
        /// 程序的所有对象创建时调用，在这里可以看见VIEW的创建的名称，好长的名字
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }

        public IKernel Kernel
        {
            get { return kernel; }
        }

        private void AddBindings()
        {
            // put additional bindings here
            Bind<IProductRepository>().To<EFProductRepository>();
            Bind<IAuthProvider>().To<FormsAuthProvider>();

            // create the email settings object
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(
                    ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            Bind<IOrderProcessor>()
                .To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
        }
    }
}