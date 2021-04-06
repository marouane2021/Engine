using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Consumer;
using Newtonsoft.Json;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Cds.OfferComparatorUpdatesReader.Tests.ConsumerPact
{
    /// <summary>
    /// OfferComparator UpdatesReader Consumer Tests
    /// </summary>
    /// <seealso cref="Cds.Foundation.Test.Pact.Consumer.BaseConsumerTests{Cds.OfferComparatorUpdatesReader.Tests.ConsumerPact.EngineConsumer}" />
    public class EngineConsumerTests : BaseConsumerTests<EngineConsumer>
    {
        // private readonly string getCompetingOfferChangesRoutePath = "/sellers/{0}/competing-offers-changes/";

        public EngineConsumerTests(EngineConsumer consumer) : base(consumer) { }

        [Fact]
        public async Task Consumer_GetEngine_Success_Return200()
        {
            var code = 117;
            string routePath = $"/Moteur/GetEngineByCode/{code}";

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/EngineResponse.json")
                .ConfigureAwait(false));

            MockProviderService
                .Given("Get Engine success")
                .UponReceiving("A request for Engine")
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
                        { "Content-Type","application/vnd.restful+json; charset=utf-8"},
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
        public async Task Consumer_GetEngine_NoContent_Return404()
            
        {
            var code = 369;
            string routePath = $"/Moteur/GetEngineByCode/{code}";

            MockProviderService
                .Given("Get Engine NoContent")
                .UponReceiving("A request Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 404,
                    Headers = null,
                    Body = null
                });

            var httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            var responseContent = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);
            Assert.Null(responseContent);

            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task Consumer_DeleteEngine_Success_Return200()
        {
            var code = 117;
            string routePath = $"/Moteur/DeleteEngine/{code}";

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/EngineResponse.json")
                .ConfigureAwait(false));

            MockProviderService
                .Given("Delete Engine success")
                .UponReceiving("A request for Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Delete,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type","application/vnd.restful+json; charset=utf-8"},
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
        public async Task Consumer_DeleteEngine_NoContent_Return404()

        {
            var code = 369;
            string routePath = $"/Moteur/DeleteEngine/{code}";

            MockProviderService
                .Given("Delete Engine NoContent")
                .UponReceiving("A request Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Delete,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 404,
                    Headers = null,
                    Body = null
                });

            var httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            var responseContent = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);
            Assert.Null(responseContent);

            MockProviderService.VerifyInteractions();
        }

        [Fact]
        public async Task Consumer_UpdateEngine_Success_Return200()
        {
            var code = 117;
            string routePath = $"/Moteur/Moteur/UpdateEngine/{code}";

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/EngineResponse.json")
                .ConfigureAwait(false));

            MockProviderService
                .Given("Update Engine success")
                .UponReceiving("A request for Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Put,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type","application/vnd.restful+json; charset=utf-8"},
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
        public async Task Consumer_UpdateEngine_NoContent_Return404()

        {
            var code = 369;
            string routePath = $"/Moteur/UpdateEngine/{code}";

            MockProviderService
                .Given("Update Engine NoContent")
                .UponReceiving("A request Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Put,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 404,
                    Headers = null,
                    Body = null
                });

            var httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            var responseContent = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);
            Assert.Null(responseContent);

            MockProviderService.VerifyInteractions();
        }
        [Fact]
        public async Task Consumer_GetAllEngines_Success_Return200()
        {
           
            string routePath = $"/Moteur/GetAll/Engines";

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/EngineResponse.json")
                .ConfigureAwait(false));

            MockProviderService
                .Given("Get Engines success")
                .UponReceiving("A request for Engine")
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
                        { "Content-Type","application/vnd.restful+json; charset=utf-8"},
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
        public async Task Consumer_GetAllEngines_NoContent_Return404()

        {
            
            string routePath = $"/Moteur/GetAll/Engines";

            MockProviderService
                .Given("Get Engines NoContent")
                .UponReceiving("A request Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 404,
                    Headers = null,
                    Body = null
                });

            var httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            var responseContent = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);
            Assert.Null(responseContent);

            MockProviderService.VerifyInteractions();
        }
        [Fact]
        public async Task Consumer_CreateEngine_Success_Return200()
        {

            string routePath = $"/Moteur/CreateEngine";

            var responseBody = JsonConvert.DeserializeObject(await File.ReadAllTextAsync(@"Json/EngineResponse.json")
                .ConfigureAwait(false));

            MockProviderService
                .Given("Create Engines success")
                .UponReceiving("A request to Create Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type","application/vnd.restful+json; charset=utf-8"},
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
        public async Task Consumer_CreateEngine_MethodNotAllowed_Return405()

        {

            string routePath = $"/Moteur/CreateEngine";

            MockProviderService
                .Given("Get Engines NoContent")
                .UponReceiving("A request Engine")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = routePath
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 405,
                    Headers = null,
                    Body = null
                });

            var httpResponse = await HttpClientHelper.ExecuteGetHttpActionAsync(new Uri(MockProviderServiceBaseUri, routePath)).ConfigureAwait(false);

            var responseContent = JsonConvert.DeserializeObject(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);
            Assert.Null(responseContent);

            MockProviderService.VerifyInteractions();
        }
    }
}
