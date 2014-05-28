using EmoticonImageBackend.App_Start;
using EmoticonImageBackend.Models.Inject;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace EmoticonImageBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //var container = new UnityContainer();
            //new ResolveModule().RegisterAll(container);
            //config.DependencyResolver = new UnityResolver(container);

            config.DependencyResolver = new UnityResolver(UnityConfig.GetConfiguredContainer());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
