using FluentAssertions;
using OpenQA.Selenium;
using Withywoods.Selenium;
using Withywoods.WebTesting.TestHost;
using Xunit;

namespace Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.IntegrationTest.Localhost
{
    [Trait("Environment", "Localhost")]
    public class SmokeTest : SeleniumTestBase, IClassFixture<LocalServerFactory<Startup>>
    {
        private const string ResourceEndpoint = "swagger";

        private readonly LocalServerFactory<Startup> _server;

        public SmokeTest(LocalServerFactory<Startup> server)
            : base(isHeadless: false)
        {
            _server = server;
            _ = _server.CreateClient(); // this call is needed to change state of server
        }

        [Fact]
        public void AspNetCoreMvcWebAppSample_SmokeTest01()
        {
            _server.RootUri.Should().Be("https://localhost:5001");

            try
            {
                // Arrange & Act
                WebDriver.Navigate().GoToUrl($"{_server.RootUri}/{ResourceEndpoint}");

                // Assert
                WebDriver.FindElement(By.ClassName("title"), 60);
                WebDriver.Title.Should().Be("Swagger UI");
                WebDriver.FindElementByClassName("title").Text.Should().Contain("Devpro HubSpot ASP.NET MVC Sample Web App");

                TakeScreenShot(nameof(AspNetCoreMvcWebAppSample_SmokeTest01));
            }
            catch
            {
                TakeScreenShot(nameof(AspNetCoreMvcWebAppSample_SmokeTest01));
                throw;
            }
        }
    }
}
