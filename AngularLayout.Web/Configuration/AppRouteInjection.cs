using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace AngularLayout.Web.Configuration
{
    public static class AppRouteInjection
    {
        public static IApplicationBuilder UseMvcInjection(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "General_default",
                    areaName: "General",
                    template: "General/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
