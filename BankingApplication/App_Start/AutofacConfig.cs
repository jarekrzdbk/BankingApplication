using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BankingApplication.Api.BLL.BusinessServicesInterfaces;
using BankingApplication.Api.BLL.BusinessServices;
using System.Web.Compilation;
using System.Linq;

namespace BankingApplication.App_Start
{
    public class AutofacConfig
    {
        public static IContainer RegisterAutoFac()
        {
            var builder = new ContainerBuilder();


            AddMvcRegistrations(builder);
            AddRegisterations(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void AddMvcRegistrations(ContainerBuilder builder)
        {
            //mvc
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //var assemblies = BuildManager.GetReferencedAssemblies().Cast().ToArray();

            //builder.RegisterAssemblyModules(assemblies);
            //web api
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           // builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
        }

        private static void AddRegisterations(ContainerBuilder builder)
        {
            builder.RegisterType<BankingAccountBS>().As<IBankingAccount>();
            //builder.RegisterModule(new MyCustomerWebAutoFacModule());
        }
    }
}


