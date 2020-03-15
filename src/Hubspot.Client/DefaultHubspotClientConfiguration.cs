namespace Devpro.Hubspot.Client
{
    public class DefaultHubspotClientConfiguration : IHubspotClientConfiguration
    {
        public string BaseUrl { get; set; }

        public bool UseOAuth { get; set; }

        public string ApiKey { get; set; }

        public string ApplicationId { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string OAuthUrl { get; set; }

        public string HttpClientName { get; set; } = "Hubspot";
    }
}
