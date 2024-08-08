using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Rentals.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureDDD.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration=> 
            {
                configuration.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly);
            });

            services.AddTransient<PriceService>();

            return services;
        }
    }
}