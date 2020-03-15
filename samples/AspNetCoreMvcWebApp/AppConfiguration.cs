using System.Reflection;
using Devpro.Hubspot.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Withywoods.AspNetCore;
using Withywoods.Configuration;

namespace Devpro.Hubspot.Samples.AspNetCoreMvcWebApp
{
    /// <summary>
    /// Web application configuration.
    /// This class implements the interface from the libraries that are used in the application.
    /// </summary>
    public class AppConfiguration : IWebAppConfiguration, IHubspotClientConfiguration
    {
        #region Constructor & properties

        /// <summary>
        /// Create a new instance of <see cref="AppConfiguration"/>
        /// </summary>
        /// <param name="configurationRoot"></param>
        public AppConfiguration(IConfiguration configurationRoot)
        {
            ConfigurationRoot = configurationRoot;
        }

        /// <summary>
        /// Configuration root.
        /// </summary>
        public IConfiguration ConfigurationRoot { get; set; }

        #endregion

        #region IWebAppConfiguration properties

        OpenApiInfo IWebAppConfiguration.SwaggerDefinition =>
            new OpenApiInfo
            {
                Title = ConfigurationRoot.TryGetSection("ApiDefinition:Title").Value,
                Version = ConfigurationRoot.TryGetSection("ApiDefinition:Version").Value
            };

        string IWebAppConfiguration.AssemblyName => Assembly.GetExecutingAssembly().GetName().Name;

        #endregion

        #region IHubspotClientConfiguration properties

        string IHubspotClientConfiguration.BaseUrl => ConfigurationRoot.TryGetSection("Hubspot:BaseUrl").Value;

        bool IHubspotClientConfiguration.UseOAuth => true;

        string IHubspotClientConfiguration.ApiKey => null;

        string IHubspotClientConfiguration.ApplicationId => ConfigurationRoot.TryGetSection("Hubspot:ApplicationId").Value;

        string IHubspotClientConfiguration.ClientId => ConfigurationRoot.TryGetSection("Hubspot:ClientId").Value;

        string IHubspotClientConfiguration.ClientSecret => ConfigurationRoot.TryGetSection("Hubspot:ClientSecret").Value;

        string IHubspotClientConfiguration.RedirectUrl => ConfigurationRoot.TryGetSection("Hubspot:RedirectUrl").Value;

        string IHubspotClientConfiguration.HttpClientName => "Hubspot";

        #endregion

        #region Public properties

        /// <summary>
        /// OAuth URL.
        /// </summary>
        public string OAuthUrl => ConfigurationRoot.TryGetSection("Hubspot:OAuthUrl").Value;

        #endregion
    }
}
