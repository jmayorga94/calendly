
using Calendly.Application.Contracts.Persistance;
using Calendly.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,  IConfiguration configuration)
        {
            services.AddDbContext<CalendlyDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("CalendlyConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>)); //one instance created per request
            services.AddScoped<IOfficeRepository, OfficeRepository>();

            return services;
        }
    }
}
