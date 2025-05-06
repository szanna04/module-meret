using DotNetNuke.Web.Api;

namespace Dancers.Dnn.Dnn_DancersChoice_Meret
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                "Dnn_DancersChoice_Meret",
                "default",
                "{controller}/{action}",
                new[] { "Dancers.Dnn.Dnn_DancersChoice_Meret.Controllers" }
            );
        }
    }
}
