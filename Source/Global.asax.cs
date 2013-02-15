using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Portfolio.Utils.Log;

namespace Portfolio
{
    // Remarque : pour obtenir des instructions sur l'activation du mode classique IIS6 ou IIS7, 
    // visitez http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Error 404",
                "404",
                new { controller = "Error", action = "Error404" }
            );

            routes.MapRoute(
                "Error 500",
                "500",
                new { controller = "Error", action = "Error500" }
            );

            routes.MapRoute(
                "Sitemap",
                "sitemap.xml",
                new { controller = "Blog", action = "Sitemap" }
            );

            routes.MapRoute(
                "Robots",
                "robots.txt",
                new { controller = "Blog", action = "Robots" }
            );

            routes.MapRoute(
                "Reload",
                "reload",
                new { controller = "Blog", action = "ReloadArticles" }
            );

            routes.MapRoute(
                "Feed",
                "feed",
                new { controller = "Blog", action = "Feed" }
            );

            routes.MapRoute(
                "Search",
                "search/{request}",
                new { controller = "Blog", action = "Search" }
            );

            routes.MapRoute(
               "Home",
               "blog/{page}",
               new { controller = "Blog", action = "Index", page = 1 }
            );

            routes.MapRoute(
                "Article",
                "{title}",
                new { controller = "Blog", action = "Single" }
            );

            routes.MapRoute(
                "Default", // Nom d'itinéraire
                "{controller}/{action}/{id}", // URL avec des paramètres
                new { controller = "Blog", action = "Index", id = UrlParameter.Optional } // Paramètres par défaut
            );
        }


        protected void Application_Start()
        {
            // Initialize log
            Logger.Initialize("Portfolio.Log");
            Logger.Log(LogLevel.Info, "Starting website Portfolio...");

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}