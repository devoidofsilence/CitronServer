using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Elmah.Contrib;
using Elmah.Contrib.WebApi;

namespace CitronWeb.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            // enable elmah
            configuration.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());

            // Web API routes
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            var cors = new EnableCorsAttribute("*", "*", "*");
            configuration.EnableCors(cors);
        }

    }
}