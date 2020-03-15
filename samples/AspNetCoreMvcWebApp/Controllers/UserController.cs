using System.Threading.Tasks;
using Devpro.Hubspot.Abstractions.Providers;
using Devpro.Hubspot.Abstractions.Repositories;
using Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController : Controller
    {
        private readonly ILogger _logger;

        private readonly ITokenProvider _tokenProvider;

        private readonly IContactRepository _contactRepository;

        /// <summary>
        /// Creates a new instance of <see cref="UserController"/>.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="tokenProvider"></param>
        /// <param name="contactRepository"></param>
        public UserController(
            ILogger<HomeController> logger,
            ITokenProvider tokenProvider,
            IContactRepository contactRepository)
        {
            _logger = logger;
            _tokenProvider = tokenProvider;
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Receives callback from HubSpot.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string code)
        {
            _logger.LogInformation($"Received code from HubSpot: {code}");

            _tokenProvider.AuthorizationCode = code;
            var token = _tokenProvider.Token;

            _logger.LogInformation($"Generated HubSpot OAuth token: {token}");

            var contacts = await _contactRepository.FindAllAsync();

            _logger.LogInformation($"Number of contacts found: {contacts.Count}");

            return View(new UserViewModel { Contacts = contacts });
        }
    }
}
