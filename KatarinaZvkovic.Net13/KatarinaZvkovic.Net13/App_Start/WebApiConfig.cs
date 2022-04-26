using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using KatarinaZvkovic.Net13.Intrfaces;
using KatarinaZvkovic.Net13.Models;
using KatarinaZvkovic.Net13.Repository;
using KatarinaZvkovic.Net13.Resolver;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;

namespace KatarinaZvkovic.Net13
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);
            config.EnableSystemDiagnosticsTracing();

            

            var container = new UnityContainer();
              container.RegisterType<IAutobusRepository, AutobusRepository>(new HierarchicalLifetimeManager());
             container.RegisterType<IPutnikRepository, PutnikRepository>(new HierarchicalLifetimeManager());


            config.DependencyResolver = new UnityResolver(container);

            Mapper.Initialize(cfg =>
            {
                 cfg.CreateMap<Putnik, PutnikDTO>();
            });

        }
    }
}
