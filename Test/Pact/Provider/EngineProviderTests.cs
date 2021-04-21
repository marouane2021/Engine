using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Cds.Engine.Tests.ProviderPact
{
    /// <summary>
    /// Defines the OfferComparatorUpdatesReader provider tests
    /// </summary>
    public class EngineProviderTests : BaseProviderTests<EngineProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineProviderTests"/> class
        /// </summary>
        /// <param name="output">The Xunit output</param>
        /// <param name="provider">The provider</param>
        public EngineProviderTests(ITestOutputHelper output, EngineProvider provider) : base(output, provider)
        {

            ProviderStates.Add("Get Engine success", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Get Engine NotFound", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Get  All Engines success", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            //ProviderStates.Add("Create Engine success", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            //ProviderStates.Add("Create Engine Method Not Allowed", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Update Engine success", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Update Engine NotFound", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Delete Engine success", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Delete Engine NotFound", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));

        }

        [Fact]
        public Task Provider_EngineReader() => EnsureProviderHonoursPactAsync();
        private async Task MockEngineEpCallReturnSuccessAsync()
        {
            // Get Engine => OK
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5001/Moteur/GetEngineByCode/{16}"),
            };
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false), Encoding.UTF8, "application/json")
            };
            GlobalServiceHandler.AddResponseMap(
                httpRequest,
                httpResponse);

            // Get Engine => NOT FOUND
            var httpRequest6 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5001/Moteur/GetEngineByCode/{369}"),
            };

            var httpResponse6 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
               
            };

            GlobalServiceHandler.AddResponseMap(
                httpRequest6,
                httpResponse6);

            var httpRequest1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("http://localhost:5001/Moteur/GetAll/Engines"),
            };

            var httpResponse1 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseAll.json").ConfigureAwait(false))
            };
         
            GlobalServiceHandler.AddResponseMap(
                httpRequest1,
                httpResponse1);
            var httpRequest2 = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5001/Moteur/CreateEngine"),
            };

            var httpResponse2 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/PostResponse.json").ConfigureAwait(false))
            };

            GlobalServiceHandler.AddResponseMap(
                httpRequest2,
                httpResponse2);
            var httpRequest10 = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5001/Moteur/CreateEngine"),
            };

            var httpResponse10= new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.MethodNotAllowed,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false))
            };

            GlobalServiceHandler.AddResponseMap(
                httpRequest10,
                httpResponse10);
            var httpRequest3 = new HttpRequestMessage
            {
                Method = HttpMethod.Put,

                RequestUri = new Uri("http://localhost:5001/Moteur/UpdateEngine/{16}"),
            };

            var httpResponse3 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false))
            };

            GlobalServiceHandler.AddResponseMap(
                httpRequest3,
                httpResponse3);
            var httpRequest5 = new HttpRequestMessage
            {
                Method = HttpMethod.Put,

                RequestUri = new Uri("http://localhost:5001/Moteur/UpdateEngine/{369}"),
            };

            var httpResponse5 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false))
            };

            GlobalServiceHandler.AddResponseMap(
                httpRequest5,
                httpResponse5);

            var httpRequest4 = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,

                RequestUri = new Uri("http://localhost:5001/Moteur/DeleteEngine/{16}"),
            };

            var httpResponse4 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false))
            };

            GlobalServiceHandler.AddResponseMap(
                httpRequest4,
                httpResponse4);
            // Delete Engine => NOT FOUND
            var httpRequest8 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5001/Moteur/DeleteEngine/{28}"),
            };

            var httpResponse8 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/SuccessResponseById.json").ConfigureAwait(false), Encoding.UTF8, "application/json")
            };


            GlobalServiceHandler.AddResponseMap(
                httpRequest8,
                httpResponse8);
         
        }


    }
}
