using Devpro.Hubspot.Client.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Devpro.Hubspot.Client.IntegrationTests
{
    public class RepositoryIntegrationTestBase<T> where T : class, IHubspotClientConfiguration
    {
        protected RepositoryIntegrationTestBase(T configuration)
        {
            Configuration = configuration;

            var services = new ServiceCollection()
                .AddLogging()
                .AddHubspotClient(Configuration);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected ServiceProvider ServiceProvider { get; private set; }

        protected T Configuration { get; private set; }
    }
}
