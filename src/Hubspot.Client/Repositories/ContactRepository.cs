using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Hubspot.Abstractions.Providers;
using Devpro.Hubspot.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace Devpro.Hubspot.Client.Repositories
{
    public class ContactRepository : RepositoryBase, IContactRepository
    {
        public ContactRepository(
            IHubspotClientConfiguration configuration,
            ILogger<ContactRepository> logger,
            IHttpClientFactory httpClientFactory,
            ITokenProvider tokenProvider)
            : base(configuration, logger, httpClientFactory, tokenProvider)
        {
        }

        protected override string ResourceName => "contacts/v1/lists/all/contacts/all";

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns></returns>
        /// <remarks>https://developers.hubspot.com/docs/methods/contacts/get_contacts</remarks>
        public async Task<object> FindAllAsync()
        {
            var url = GenerateUrl();
            var output = await GetAsync<object>(url);
            return output;
        }
    }
}
