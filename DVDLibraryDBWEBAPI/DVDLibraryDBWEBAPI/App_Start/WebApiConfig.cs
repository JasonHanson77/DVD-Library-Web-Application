using DVDLibraryDBWEB.Data.ADO;
using DVDLibraryDBWEB.Data.EntityFramework;
using DVDLibraryDBWEB.Data.Interfaces;
using DVDLibraryDBWEB.Data.MockRepository;
using DVDLibraryDBWEBAPI.BLL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibraryDBWEBAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            var Container = new UnityContainer();
            if (mode == "ADO")
            {
                Container.RegisterType<IDVDRepository, DVDRepositoryADO>();
            }
            else if (mode == "EntityFrameWork")
            {
                Container.RegisterType<IDVDRepository, DVDRepositoryEF>();
            }
            else if (mode == "SampleData")
            {
                Container.RegisterType<IDVDRepository, DVDRepositoryMock>();
            }
            else
            {
                throw new Exception("Mode Key in app.config not set properly");
            }

            config.DependencyResolver = new UnityResolver(Container);

            // Web API configuration and services
            var corsSettings = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsSettings);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
