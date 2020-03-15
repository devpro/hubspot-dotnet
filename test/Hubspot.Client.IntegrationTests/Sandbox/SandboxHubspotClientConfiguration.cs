using System;

namespace Devpro.Hubspot.Client.IntegrationTests.Sandbox
{
    public class SandboxHubspotClientConfiguration : IHubspotClientConfiguration
    {
        public string BaseUrl => Environment.GetEnvironmentVariable("Hubspot_Sandbox_BaseUrl");

        public string HttpClientName => "Hubspot";

        public bool UseOAuth => bool.Parse(Environment.GetEnvironmentVariable("Hubspot_Sandbox_UseOAuth"));

        public string ApiKey => Environment.GetEnvironmentVariable("Hubspot_Sandbox_ApiKey");

        public string ApplicationId => Environment.GetEnvironmentVariable("Hubspot_Sandbox_ApplicationId");

        public string ClientId => Environment.GetEnvironmentVariable("Hubspot_Sandbox_ClientId");

        public string ClientSecret => Environment.GetEnvironmentVariable("Hubspot_Sandbox_ClientSecret");

        public string OAuthUrl => Environment.GetEnvironmentVariable("Hubspot_Sandbox_OAuthUrl");
    }
}
