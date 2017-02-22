using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BankingApplication.BLL.BusinessServices;
using BankingApplication.BLL.BusinessServicesInterfaces;
using BankingApplication.WebApi;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using BankingApplication.DAL;

[assembly: OwinStartupAttribute(typeof(BankingApplication.Startup))]
namespace BankingApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(BankingAccountsController).Assembly);

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>();
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>();
            builder.RegisterType<BankingAccountBS>().As<IBankingAccount>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            WebApiConfig.Register(config);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
            app.UseAutofacMvc();
        }
    }
}
