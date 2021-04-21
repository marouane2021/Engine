using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Consumer;
using Engine.Domain.Models;
using MongoDB.Bson;
using Newtonsoft.Json;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Xunit;
namespace Cds.Engine.Tests.ConsumerPact.EPConsumerTest
{
    public class EngineEPConsumerTest : BaseConsumerTests<EngineEpConsumer>
    {

        public EngineEPConsumerTest(EngineEpConsumer consumer) : base(consumer) { }

        [Fact]
        public async Task Consumer_GetAllEngines_Success_Return200()
        {

            string path = $"/Moteur/GetAll/Engines";

            object responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"EPConsumerTest/Json/EnginesEPResponses.json").ConfigureAwait(false));
            MockProviderService
                .Given("Get  All Engines success")
                .UponReceiving("A request for Engines")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = path,
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = responseBody
                });

            // Act
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, path)).ConfigureAwait(false);
            var responseContent = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.Equal(responseBody, responseContent);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task Consumer_GetAllEngines_NoContent_Return404()

        {

            string path = $"/Moteur/GetAll/Engines";

            MockProviderService
               .Given("Get Engines NotFound")
               .UponReceiving("A request for Engines")
               .With(new ProviderServiceRequest
               {
                   Method = HttpVerb.Get,
                   Path = path
               })
               .WillRespondWith(new ProviderServiceResponse
               {
                   Status = 404
               });

            // Act
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, path)).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);

            MockProviderService.VerifyInteractions();
        }
    }
}
