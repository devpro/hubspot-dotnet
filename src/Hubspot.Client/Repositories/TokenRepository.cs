using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Devpro.Hubspot.Abstractions.Models;
using Devpro.Hubspot.Abstractions.Repositories;
using Microsoft.Extensions.Logging;
using Withywoods.Net.Http.Exceptions;
using Withywoods.Serialization.Json;

namespace Devpro.Hubspot.Client.Repositories
{
    /// <summary>
    /// Token repository.
    /// </summary>
    /// <remarks>https://developers.hubspot.com/docs/methods/oauth2/oauth2-quickstart</remarks>
    public class TokenRepository : RepositoryBase, ITokenRepository
    {
        public TokenRepository(
            IHubspotClientConfiguration configuration,
            ILogger<TokenRepository> logger,
            IHttpClientFactory httpClientFactory)
            : base(configuration, logger, httpClientFactory, null)
        {
        }

        protected override string ResourceName => "oauth/v1/token";

        /// <summary>
        /// Create a new Token.
        /// </summary>
        /// <param name="authorizationCode"></param>
        /// <returns></returns>
        /// <remarks>https://developers.hubspot.com/docs/methods/oauth2/get-access-and-refresh-tokens</remarks>
        public async Task<TokenModel> CreateAsync(string authorizationCode)
        {
            var url = GenerateUrl();

            // TODO: create an issue in Withywoods to be able to make PostAsync works in this special case

            var client = HttpClientFactory.CreateClient(HttpClientName);
            client.DefaultRequestHeaders.Clear();

            var body = $"grant_type=authorization_code&client_id={Configuration.ClientId}&client_secret={Configuration.ClientSecret}&redirect_uri={Configuration.RedirectUrl}&code={authorizationCode}";
            var response = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded"));

            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Logger.LogWarning($"Status code doesn't indicate success [HttpRequestUrl={url}] [HttpResponseStatusCode={response.StatusCode}] [HttpResponseContent={stringResult}]");
                throw new ConnectivityException($"The response status \"{response.StatusCode}\" is not a success (reason=\"{response.ReasonPhrase}\")");
            }

            if (string.IsNullOrEmpty(stringResult))
            {
                throw new ConnectivityException($"Empty response received while calling {url}");
            }

            var model = stringResult.FromJson<TokenModel>();
            model.CreatedAt = DateTime.UtcNow;
            model.ExpiredAt = model.CreatedAt.AddSeconds(model.ExpiresIn);
            return model;
        }
    }
}
