using AngularLayout.Model.Common.Loggers;
using AngularLayout.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AngularLayout.Web.Configuration
{
    public static class AppContextInjection
    {
        public static IServiceCollection AddDbContextInjection(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<DefaultContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultContext")));

                return services;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}