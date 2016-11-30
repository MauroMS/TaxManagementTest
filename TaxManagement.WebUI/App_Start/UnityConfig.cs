using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TaxManagement.Core;

namespace TaxManagement.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            UnityLoader.Init(container);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.LoadConfiguration();//RegisterType<IRaisedTicketService, RaisedTicketService>();
            //container.LoadConfiguration("services");//RegisterType<IRaisedTicketService, RaisedTicketService>();
            //container.LoadConfiguration("repos");//RegisterType<IRaisedTicketService, RaisedTicketService>();

            //var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //container.LoadConfiguration(section);

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}