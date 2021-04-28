using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Consumer
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
using Xunit;

namespace Cds.Engine.Tests.ConsumerPact
{
    public class ScopeConsumerTest : BaseConsumerTests<ScopeConsumer>
    {
        public ScopeConsumerTest(ScopeConsumer consumer) : base(consumer) { }

        [Fact]
        public async Task Consumer_GetScope_Success_Return200()
        {
            var scopeId = 7;
            string routePath = $"/Scope/GetScopeByCode/{scopeId}";

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/ScopeJson/Engine_response_success.json")
                .ConfigureAwait(false));

            MockProviderService
                .Given("Get Scope success")
                .UponReceiving("A request for Scope")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type","application/json; charset=utf-8"},
                    },
                    Body = Match.Type(responseBody)
                });

            var httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            var responseContent = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.Equal(responseBody, responseContent);

            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task Consumer_GetScope_NotFound_Return404()

        {
            var scopeId = 17;
            string routePath = $"/Scope/GetScopeByCode/{scopeId}";

            MockProviderService
               .Given("Get Scope NotFound")
               .UponReceiving("A request for Scope")
               .With(new ProviderServiceRequest
               {
                   Method = HttpVerb.Get,
                   Path = routePath
               })
               .WillRespondWith(new ProviderServiceResponse
               {
                   Status = 404
               });

            // Act
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);

            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task Consumer_DeleteScope_Success_Return200()
        {

            string path = $"/Scope/DeleteScope/{7}";
            MockProviderService
                .Given("Delete Scope success")
                .UponReceiving("A request for Scope")
                 .With(new ProviderServiceRequest
                 {
                     Method = HttpVerb.Delete,
                     Path = path
                 })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200
                });

            // Act
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteDeleteHttpActionAsync(new Uri(MockProviderServiceBaseUri, path)).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task Consumer_DeleteScope_NoContent_Return404()

        {
            var scopeId = 17;
            string routePath = $"/Scope/GetScopeByCode/{scopeId}";


            MockProviderService
               .Given("Delete Scope NotFound")
               .UponReceiving("A request for Scope")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Delete,
                    Path = routePath,
                })
               .WillRespondWith(new ProviderServiceResponse
               {
                   Status = 404
               });

            // Act
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecuteDeleteHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        [Obsolete]
        public async Task Consumer_UpdateScope_Success_Return200()
        {
            string path = $"/Scope/UpdateScope/{7}";
            object requestBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/ScopeJson/Engine_response_success.json").ConfigureAwait(false));
            MockProviderService
                .Given("Update Scope Success")
                .UponReceiving("A request for Scope")
                 .With(new ProviderServiceRequest
                 {
                     Method = HttpVerb.Put,
                     Path = path,
                     Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                     Body = requestBody
                 })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200
                });

            // Act
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecutePutHttpActionAsync(new Uri(MockProviderServiceBaseUri, path), httpContent).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task Consumer_UpdateScope_NotFound_Return404()

        {
            var scopeId = 369;
            string path = $"/Moteur/UpdateEngine/{scopeId}";

            object requestBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/ScopeJson/Engine_response_success.json").ConfigureAwait(false));
            MockProviderService
                .Given("Update Scope NotFound")
                .UponReceiving("A request for Scope")
                 .With(new ProviderServiceRequest
                 {
                     Method = HttpVerb.Put,
                     Path = path,
                     Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                     Body = requestBody
                 })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 404
                });

            // Act
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecutePutHttpActionAsync(new Uri(MockProviderServiceBaseUri, path), httpContent).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }
        [Fact]
        public async Task Consumer_GetAllEngines_Success_Return200()
        {

            string path = $"/Moteur/GetAll/Engines";

            object responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/EnginesResponses.json").ConfigureAwait(false));
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
        public async Task Consumer_CreateEngine_Success_Return200()
        {

            string path = $"/Moteur/CreateEngine";
            object requestBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/PostResponse.json").ConfigureAwait(false));
            MockProviderService
                .Given("Create Engine success")
                .UponReceiving("A request for Engines")
                 .With(new ProviderServiceRequest
                 {
                     Method = HttpVerb.Post,
                     Path = path,
                     Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                     Body = requestBody
                 })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200
                });

            // Act
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecutePostHttpActionAsync(new Uri(MockProviderServiceBaseUri, path), httpContent).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            MockProviderService.VerifyInteractions();

        }

        [Fact]
        public async Task Consumer_CreateEngine_MethodNotAllowed_Return405()

        {
            string path = $"/Moteur/CreateEngine";
            object requestBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync($"Json/PostResponse.json")
              .ConfigureAwait(false));

            MockProviderService
                .Given("Create Engine Method Not Allowed")
                .UponReceiving("A request for Engines")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = requestBody,
                    Path = path
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 405,
                });

            // Action
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await HttpClientHelper.ExecutePostHttpActionAsync(new Uri(MockProviderServiceBaseUri, path), httpContent).ConfigureAwait(false);

            // Assert
            Assert.Equal(HttpStatusCode.MethodNotAllowed, httpResponse.StatusCode);

            MockProviderService.VerifyInteractions();
        }
    }
}
