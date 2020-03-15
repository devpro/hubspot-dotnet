using System.Net.Http;
using System.Net.Http.Headers;
using Devpro.Hubspot.Abstractions.Providers;
using Microsoft.Extensions.Logging;
using Withywoods.Net.Http;

namespace Devpro.Hubspot.Client.Repositories
{
    public abstract class RepositoryBase : HttpRepositoryBase
    {
        private readonly ITokenProvider _tokenProvider;

        protected RepositoryBase(
            IHubspotClientConfiguration configuration,
            ILogger logger,
            IHttpClientFactory httpClientFactory,
            ITokenProvider tokenProvider)
            : base(logger, httpClientFactory)
        {
            Configuration = configuration;
            _tokenProvider = tokenProvider;
        }

        protected IHubspotClientConfiguration Configuration { get; private set; }

        protected abstract string ResourceName { get; }

        protected override string HttpClientName => Configuration.HttpClientName;

        protected string GenerateUrl(string prefix = "", string suffix = "", string arguments = "")
        {
            if (Configuration.UseOAuth)
            {
                arguments = string.IsNullOrEmpty(arguments) ? $"?hapikey={Configuration.ApiKey}" : $"{arguments}&hapikey={Configuration.ApiKey}";
            }
            return $"{Configuration.BaseUrl}{prefix}/{ResourceName}{suffix}{arguments}";
        }

        protected override void EnrichRequestHeaders(HttpClient client)
        {
            if (Configuration.UseOAuth && _tokenProvider != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenProvider.Token);
            }
        }
    }
}
