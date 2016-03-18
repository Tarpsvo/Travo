using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Travo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Travo API",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Formatters
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            formatters.Remove(formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
