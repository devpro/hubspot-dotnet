using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Devpro.Hubspot.Client.DependencyInjection
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the dependency injection configuration.
        /// </summary>
        /// <typeparam name="T">Instance of <see cref="IHubspotClientConfiguration"/></typeparam>
        /// <param name="services">Collection of services that will be completed</param>
        /// <returns></returns>
        public static IServiceCollection AddHubspotClient<T>(this IServiceCollection services, T configuration)
            where T : class, IHubspotClientConfiguration
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.TryAddSingleton<IHubspotClientConfiguration>(configuration);
            services.TryAddScoped<Abstractions.Providers.ITokenProvider, Providers.TokenProvider>();
            services.TryAddTransient<Abstractions.Repositories.IContactRepository, Repositories.ContactRepository>();
            services.TryAddTransient<Abstractions.Repositories.ITokenRepository, Repositories.TokenRepository>();

            services
                .AddHttpClient(configuration.HttpClientName, client =>
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

            return services;
        }
    }
}
