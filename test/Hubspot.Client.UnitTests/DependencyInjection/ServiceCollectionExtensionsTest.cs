using System;
using System.Net.Http;
using Devpro.Hubspot.Abstractions.Providers;
using Devpro.Hubspot.Client.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Devpro.Hubspot.Client.UnitTests.DependencyInjection
{
    [Trait("Category", "UnitTests")]
    public class ServiceCollectionExtensionsTest
    {
        private readonly IHubspotClientConfiguration _configuration;

        public ServiceCollectionExtensionsTest()
        {
            _configuration = new DefaultHubspotClientConfiguration
            {
                BaseUrl = "https://sure.dont.exist",
                HttpClientName = "Fake"
            };
        }

        [Fact]
        public void AddHubspotClient_ShouldProvideRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddLogging();

            // Act
            serviceCollection.AddHubspotClient(_configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            services.GetRequiredService<Abstractions.Repositories.IContactRepository>().Should().NotBeNull();
        }

        [Fact]
        public void AddTwohireClient_ShouldProvideProviders()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddHubspotClient(_configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            services.GetRequiredService<ITokenProvider>().Should().NotBeNull();
        }

        [Fact]
        public void AddHubspotClient_ShouldProvideHttpClient()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddLogging();

            // Act
            serviceCollection.AddHubspotClient(_configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
            httpClientFactory.Should().NotBeNull();
            var client = httpClientFactory.CreateClient(_configuration.HttpClientName);
            client.Should().NotBeNull();
        }

        [Fact]
        public void AddHubspotClient_ShouldThrowExceptionIfServiceCollectionIsNull()
        {
            // Arrange
            var serviceCollection = (ServiceCollection)null;

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => serviceCollection.AddHubspotClient(_configuration));

            // Assert
            exc.Should().NotBeNull();
            exc.Message.Should().Be("Value cannot be null. (Parameter 'services')");
        }

        [Fact]
        public void AddHubspotClient_ShouldThrowExceptionIfConfigurationIsNull()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var configuration = (IHubspotClientConfiguration)null;

            // Act
            var exc = Assert.Throws<ArgumentNullException>(() => serviceCollection.AddHubspotClient(configuration));

            // Assert
            exc.Should().NotBeNull();
            exc.Message.Should().Be("Value cannot be null. (Parameter 'configuration')");
        }
    }
}
