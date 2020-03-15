﻿using System.Net;
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
    public class ContactRepositoryTest : RepositoryTestBase
    {
        [Fact]
        public async Task ContactRepositoryFindAllAsync_ReturnData()
        {
            // Arrange
            var responseDto = Fixture.Create<ContactResultModel>();
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseDto.ToJson())
            };
            Configuration.UseOAuth = true;
            TokenProviderMock.Setup(x => x.Token).Returns("loveDotNet");
            var repository = BuildRepository(httpResponseMessage, HttpMethod.Get, $"{Configuration.BaseUrl}/contacts/v1/lists/all/contacts/all");

            // Act
            var output = await repository.FindAllAsync();

            // Assert
            output.Should().NotBeNull();
        }

        private IContactRepository BuildRepository(HttpResponseMessage httpResponseMessage, HttpMethod httpMethod, string absoluteUri)
        {
            var logger = ServiceProvider.GetService<ILogger<ContactRepository>>();
            var httpClientFactoryMock = BuildHttpClientFactory(httpResponseMessage, httpMethod, Configuration.HttpClientName, absoluteUri);

            return new ContactRepository(Configuration, logger, httpClientFactoryMock.Object, TokenProviderMock.Object);
        }
    }
}
