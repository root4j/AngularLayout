using Microsoft.Extensions.DependencyInjection;

namespace AngularLayout.Web.Configuration
{
    public static class AppBusinessInjection
    {
        public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
        {
            #region General Injection
            services.AddScoped<Model.Business.General.ICityBusiness, Model.Business.General.Implementations.CityBusiness>();
            services.AddScoped<Model.Business.General.ICountryBusiness, Model.Business.General.Implementations.CountryBusiness>();
            services.AddScoped<Model.Business.General.IStateBusiness, Model.Business.General.Implementations.StateBusiness>();
            services.AddScoped<Model.Business.General.IValueListBusiness, Model.Business.General.Implementations.ValueListBusiness>();
            #endregion
            return services;
        }
    }
}