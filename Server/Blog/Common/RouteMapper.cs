using DotNetNuke.Web.Api;

namespace Dnn.Modules.Blog.Common
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("DNN Community/Blog", "BlogMap1", "{controller}/{action}", null, null, new[] { "Dnn.Modules.Blog.Api" });
            mapRouteManager.MapHttpRoute("DNN Community/Blog", "BlogMap2", "{controller}/{action}/{id}", null, new { id = "-?\\d+" }, new[] { "Dnn.Modules.Blog.Api" });
        }
    }
}