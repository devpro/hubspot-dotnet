using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.Models;
using Devpro.Hubspot.Abstractions.Providers;
using System;

namespace Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly AppConfiguration _configuration;

        private readonly ITokenProvider _tokenProvider;

        /// <summary>
        /// Creates a new instance of <see cref="HomeController"/>.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="tokenProvider"></param>
        public HomeController(AppConfiguration configuration, ITokenProvider tokenProvider)
        {
            _configuration = configuration;
            _tokenProvider = tokenProvider;
        }

        /// <summary>
        /// Index action.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(_tokenProvider.AuthorizationCode))
            {
                Response.Redirect(_configuration.OAuthUrl);
            }

            return View();
        }

        /// <summary>
        /// Privacy action.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Error action.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
