using System;

namespace Devpro.Hubspot.Client.IntegrationTests.Sandbox
{
    public class SandboxHubspotClientConfiguration : IHubspotClientConfiguration
    {
        public string BaseUrl => Environment.GetEnvironmentVariable("Hubspot__Sandbox__BaseUrl");

        public bool UseOAuth { get; set; }

        public string ApiKey => Environment.GetEnvironmentVariable("Hubspot__Sandbox__ApiKey");

        public string ApplicationId => Environment.GetEnvironmentVariable("Hubspot__Sandbox__ApplicationId");

        public string ClientId => Environment.GetEnvironmentVariable("Hubspot__Sandbox__ClientId");

        public string ClientSecret => Environment.GetEnvironmentVariable("Hubspot__Sandbox__ClientSecret");

        public string OAuthUrl => Environment.GetEnvironmentVariable("Hubspot__Sandbox__OAuthUrl");

        public string RedirectUrl => Environment.GetEnvironmentVariable("Hubspot__Sandbox_RedirectUrl");

        public string HttpClientName => "Hubspot";

        public string UserAuthorizationCode => Environment.GetEnvironmentVariable("Hubspot__Sandbox__UserAuthorizationCode");
    }
}
