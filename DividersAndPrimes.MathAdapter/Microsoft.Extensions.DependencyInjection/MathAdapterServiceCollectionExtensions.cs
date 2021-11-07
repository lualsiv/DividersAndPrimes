using System;
using System.Diagnostics.CodeAnalysis;
using DividersAndPrimes.Domain.Adapters;
using DividersAndPrimes.MathAdapter;
using DividersAndPrimes.MathAdapter.Clients;
using Refit;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MathAdapterServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddMathAdapter(
            this IServiceCollection services,
            MathAdapterConfiguration mathAdapterConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (mathAdapterConfiguration == null)
            {
                throw new ArgumentNullException(nameof(mathAdapterConfiguration));
            }

            // Registers the instance of this layer's settings object.
            services.AddSingleton(mathAdapterConfiguration);

            // Set the parameters for the Math API call and register the
            // IMathApi interface.
            services.AddRefitClient<IMathApi>()
                .ConfigureHttpClient(c=> c.BaseAddress = new Uri(
                    mathAdapterConfiguration.MathApiUrlBase));

            // Register the IMathAdapter implementation to be used in the
            // application layer.
            services.AddScoped<IMathAdapter, MathAdapter>();

            return services;
        }
    }
}
