using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Cds.Engine.Tests.ProviderPact.EngineEpProvider
{
    public class EngineEpProviderTest : BaseProviderTests<EngineEpProvider>
    {
        public EngineEpProviderTest(ITestOutputHelper output, EngineEpProvider provider) : base(output, provider)
        {
            ProviderStates.Add("Get Engines NotFound", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Get  All Engines success", async () => await MockEngineEpCallReturnSuccessAsync().ConfigureAwait(false));

        }

        [Fact]
        public Task Provider_EngineReader() => EnsureProviderHonoursPactAsync();
        private async Task MockEngineEpCallReturnSuccessAsync()
        {
            var httpRequest1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("http://localhost:5001/Moteur/GetAll/Engines"),
            };

            var httpResponse1 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"SuccessEpResponseAll.json").ConfigureAwait(false))
            };

            GlobalServiceHandler.AddResponseMap(
                httpRequest1,
                httpResponse1);
            var httpRequest9 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri("http://localhost:5001/Moteur/GetAll/Engines"),
            };

            var httpResponse9 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,

            };
            GlobalServiceHandler.AddResponseMap(
               httpRequest9,
               httpResponse9);
        }
    }
}
