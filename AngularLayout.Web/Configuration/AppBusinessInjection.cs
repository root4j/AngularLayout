using Microsoft.Extensions.DependencyInjection;

namespace AngularLayout.Web.Configuration
{
    public static class AppBusinessInjection
    {
        public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
        {
            #region General Injection
            services.AddScoped<Model.Business.General.IValueListBusiness, Model.Business.General.ValueListBusiness>();
            #endregion
            return services;
        }
    }
}