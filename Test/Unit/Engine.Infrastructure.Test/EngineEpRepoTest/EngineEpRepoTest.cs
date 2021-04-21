using Engine.Domain.Models;
using Engine.Infrastructure.MongoRepository;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Engine.Infrastructure.Test.EngineEpRepoTest
{
    public  class EngineEpRepoTest
    {
        readonly BestOfferApi config;
        readonly Mock<IHttpClientFactory> mockFactory;
        public EngineEpRepoTest()
        {
            config = new BestOfferApi { BaseAddress = new Uri("https://6076d9e31ed0ae0017d69ecb.mockapi.io") };
            mockFactory = new Mock<IHttpClientFactory>();
        }
        [Fact]
        public async Task GetEngines_ShouldReturnEngineListofEngines()
        {
            HttpClientConfig();
            var ePEngineRepo = new EPEngineRepo(config, mockFactory.Object);
            // Arrange

            // Act
            var result = await ePEngineRepo.GetEngines();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MyEngine>>(result);
            Assert.Equal(2, result.Count);
        }
        private void HttpClientConfig()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = Response()
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        }

        private HttpContent Response()
        {
            return new StringContent(File.ReadAllText(@"MongoRepository/AllEnginesResponse.json"), System.Text.Encoding.UTF8, "application/json");
        }
    }
}
