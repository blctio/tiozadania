using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
//using System.Web.Http.OData.Builder;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;


namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
             //Web API configuration and services

             //Web API routes
              config.MapHttpAttributeRoutes();

               config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional });

            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();


            builder.EntitySet<Game>("Games");
            builder.EntitySet<Store>("Stores");
            builder.ComplexType<CardShirt>();

            // config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
            //  builder.Function("Dalajlama").Returns<double>().Parameter<int>("Postal");
            
            // unbound and return the entity
            builder.Function("GetAvailableCardShirts").ReturnsFromEntitySet<CardShirt>("CardShirts");

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                 model: builder.GetEdmModel());
                
        }
    }
}
