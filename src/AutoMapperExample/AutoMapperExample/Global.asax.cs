using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bootstrap;
using Bootstrap.AutoMapper;
using AutoMapper;
using AutoMapperExample.Dal;
using ViewModels;

namespace AutoMapperExample
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Mapper.CreateMap<Member, WelcomeViewModel>();
            Mapper.CreateMap<Member, ProfileViewModel>().ForMember(dest => dest.ProfilePictureUrl, src => src.Ignore());
            Mapper.CreateMap<Member, MembersViewModel>().ForMember(dest => dest.Name, src => src.ResolveUsing(m => string.Format("{0} {1}", m.FirstName, m.LastName))); // <));

            Mapper.AssertConfigurationIsValid();
        }
    }
}