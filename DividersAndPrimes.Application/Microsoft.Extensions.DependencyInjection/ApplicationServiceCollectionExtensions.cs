using System;
using System.Diagnostics.CodeAnalysis;
using DividersAndPrimes.Application;
using DividersAndPrimes.Domain.Services;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Register the service described by the IDivisorsService interface
            services.AddScoped<IDivisorsService, DivisorsService>();

            // Register the service described by the IPrimesService interface
            services.AddScoped<IPrimesService, PrimesService>();

            return services;
        }
    }
}

