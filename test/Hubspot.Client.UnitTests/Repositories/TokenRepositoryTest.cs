using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using Devpro.Hubspot.Abstractions.Models;
using Devpro.Hubspot.Abstractions.Repositories;
using Devpro.Hubspot.Client.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Withywoods.Serialization.Json;
using Xunit;


namespace Devpro.Hubspot.Client.UnitTests.Repositories
{
    [Trait("Category", "UnitTests")]
    public class TokenRepositoryTest : RepositoryTestBase
    {
        [Fact]
        public async Task TokenRepositoryCreateAsync_ReturnToken()
        {
            // Arrange
            var responseDto = Fixture.Create<TokenModel>();
            responseDto.ExpiresIn = 1200;
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseDto.ToJson())
            };
            Configuration.UseOAuth = true;
            var repository = BuildRepository(httpResponseMessage, HttpMethod.Post, $"{Configuration.BaseUrl}/oauth/v1/token");

            // Act
            var output = await repository.CreateAsync("order66");

            // Assert
            output.Should().NotBeNull();
            output.AccessToken.Should().Be(responseDto.AccessToken);
            output.RefreshToken.Should().Be(responseDto.RefreshToken);
            output.ExpiresIn.Should().Be(responseDto.ExpiresIn);
            output.ExpiredAt.Should().Be(output.CreatedAt.AddSeconds(responseDto.ExpiresIn));
        }

        private ITokenRepository BuildRepository(HttpResponseMessage httpResponseMessage, HttpMethod httpMethod, string absoluteUri)
        {
            var logger = ServiceProvider.GetService<ILogger<TokenRepository>>();
            var httpClientFactoryMock = BuildHttpClientFactory(httpResponseMessage, httpMethod, Configuration.HttpClientName, absoluteUri);

            return new TokenRepository(Configuration, logger, httpClientFactoryMock.Object);
        }
    }
}
