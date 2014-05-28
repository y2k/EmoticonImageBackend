using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmoticonImageBackend.Models.Inject
{
    public class ResolveModule
    {
        public void RegisterAll(UnityContainer container)
        {
            container.RegisterType<IEmoticonRepository, EmoticonRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICacheModel, CacheModel>(new HierarchicalLifetimeManager());
        }
    }
}