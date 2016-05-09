using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication9.Services;
using WebApplication9.Interfaces;
using WebApplication9.Repositories;

namespace WebApplication9
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //builder.RegisterType<ListStorage>().As<IValuesService>().SingleInstance();
            //builder.RegisterType<DatabaseStorage>().As<IValuesService>().InstancePerRequest();
            builder.RegisterType<PaintingRepositoryPSQL>().As<IPaintingRepository>().InstancePerRequest();
            builder.RegisterType<ArtistRepositoryLiteDB>().As<IArtistRepository>().InstancePerRequest();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
