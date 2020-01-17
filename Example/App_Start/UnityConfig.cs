using Example.Interfaces;
using Example.Models;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace Example
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IMyDbContext, MyDbContext>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}