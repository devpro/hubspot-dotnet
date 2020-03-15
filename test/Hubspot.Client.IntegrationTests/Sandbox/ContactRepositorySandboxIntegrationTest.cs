using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Hubspot.Abstractions.Providers;
using Devpro.Hubspot.Abstractions.Repositories;
using Devpro.Hubspot.Client.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Devpro.Hubspot.Client.IntegrationTests.Sandbox
{
    [Trait("Environment", "Sandbox")]
    public class ContactRepositorySandboxIntegrationTest : RepositoryIntegrationTestBase<SandboxHubspotClientConfiguration>
    {
        public ContactRepositorySandboxIntegrationTest()
            : base(new SandboxHubspotClientConfiguration { UseOAuth = false })
        {
        }

        [Fact]
        public async Task ContactRepositorySandboxFindAllAsync_ReturnToken()
        {
            // Arrange
            var repository = BuildRepository();

            // Act
            var output = await repository.FindAllAsync();

            // Assert
            output.Should().NotBeNull();
        }

        private IContactRepository BuildRepository()
        {
            var logger = ServiceProvider.GetService<ILogger<ContactRepository>>();
            var httpClientFactory = ServiceProvider.GetService<IHttpClientFactory>();
            var tokenProvider = ServiceProvider.GetService<ITokenProvider>();

            return new ContactRepository(Configuration, logger, httpClientFactory, tokenProvider);
        }
    }
}
