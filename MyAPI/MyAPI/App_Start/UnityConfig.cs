using MyAPI.Repository;
using MyAPI.Service;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace MyAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMemberRepository, MemberRepository>();
            container.RegisterType<IDatabaseHelper, DatabaseHelper>(new InjectionConstructor("456"));
            container.RegisterType<IMemberService, MemberService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}