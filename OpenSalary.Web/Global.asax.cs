using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client.Document;

namespace OpenSalary.Web {    
    public class MvcApplication : HttpApplication {
        public static DocumentStore Store;
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);           
        }
    }
}