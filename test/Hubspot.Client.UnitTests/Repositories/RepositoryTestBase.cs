using AutoFixture;
using Devpro.Hubspot.Abstractions.Providers;
using Moq;
using Withywoods.UnitTesting;

namespace Devpro.Hubspot.Client.UnitTests.Repositories
{
    public abstract class RepositoryTestBase : HttpRepositoryTestBase
    {
        protected RepositoryTestBase()
            : base()
        {
            Configuration = new DefaultHubspotClientConfiguration
            {
                BaseUrl = "https://still.dont.exist",
                HttpClientName = "AlsoFake"
            };
            Fixture = new Fixture();
            TokenProviderMock = new Mock<ITokenProvider>();
        }

        protected IHubspotClientConfiguration Configuration { get; }

        protected Fixture Fixture { get; }

        protected Mock<ITokenProvider> TokenProviderMock { get; private set; }
    }
}
