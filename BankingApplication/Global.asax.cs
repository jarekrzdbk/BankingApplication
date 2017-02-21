using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BankingApplication.Api.BLL.BusinessServices;
using BankingApplication.Api.BLL.BusinessServicesInterfaces;
using BankingApplication.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BankingApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var builder = new ContainerBuilder();
            //builder.RegisterType<BankingAccountBS>().As<IBankingAccount>();



            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //var container = builder.Build();
            //var webApiResolver = new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
            //var mvcResolver = new AutofacDependencyResolver(container);
            //DependencyResolver.SetResolver(mvcResolver);


        }
    }
}
