using System.Linq;
using System.Web.Http;

namespace webapi2Tarea.App_Start
{
    public class WebApiConfig
    {
        //midleware de configuraciòn
        public static void Configure(HttpConfiguration config)
        {

            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.EnableSystemDiagnosticsTracing();

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void Register(HttpConfiguration config)
        {
            // New code
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}