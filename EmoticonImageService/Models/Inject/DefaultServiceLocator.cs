using Autofac;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;

namespace EmoticonImageService.Models.Inject
{
    public class DefaultServiceLocator : ServiceLocatorImplBase
    {
        IContainer locator;

        public void RegisterFor(IServiceCollection services)
        {
            services.AddTransient<IEmoticonRepository, EmoticonRepository>();
            services.AddTransient<ICacheModel, CacheModel>();
        }

        public DefaultServiceLocator(params Module[] platformModule)
        {
            var b = new ContainerBuilder();

            b.RegisterModule(new DefaultModule());
            foreach (var s in platformModule)
            {
                b.RegisterModule(s);
            }

            locator = b.Build();
        }

        #region implemented abstract members of ServiceLocatorImplBase

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return locator.Resolve(serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Inner classes

        class DefaultModule : Module
        {
            protected override void Load(ContainerBuilder b)
            {
                b.RegisterType<EmoticonRepository>().As<IEmoticonRepository>();
                b.RegisterType<CacheModel>().As<ICacheModel>();
            }
        }

        #endregion
    }
}