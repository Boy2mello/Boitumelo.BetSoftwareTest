using Boitumelo.BetSoftwareWeb.Repository;
using Microsoft.Extensions.Logging;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Boitumelo.BetSoftwareWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ILogger, LogConsole>();

  
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}