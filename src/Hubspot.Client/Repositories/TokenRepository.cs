using System;
using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Hubspot.Abstractions.Models;
using Devpro.Hubspot.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace Devpro.Hubspot.Client.Repositories
{
    /// <summary>
    /// Token repository.
    /// </summary>
    /// <remarks>https://developers.hubspot.com/docs/methods/oauth2/oauth2-quickstart</remarks>
    public class TokenRepository : RepositoryBase, ITokenRepository
    {
        public TokenRepository(IHubspotClientConfiguration configuration, ILogger<TokenRepository> logger, IHttpClientFactory httpClientFactory)
            : base(configuration, logger, httpClientFactory, null)
        {
        }

        protected override string ResourceName => "oauth/v1/token";

        public async Task<TokenModel> CreateAsync()
        {
            var url = GenerateUrl();
            var input = new
            {
                grant_type = "authorization_code",
                client_id = Configuration.ClientId,
                client_secret = Configuration.ClientSecret,
                // FIXME
                redirect_uri = Configuration.OAuthUrl,
                RedirectCode = ""
            };
            var model = await PostAsync<TokenModel>(url, input);
            model.ExpiredAt = DateTime.UtcNow.AddSeconds(model.ExpiresIn);
            return model;
        }
    }
}
