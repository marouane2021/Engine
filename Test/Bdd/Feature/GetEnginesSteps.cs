using Cds.Engine.Tests.Bdd.Core;
using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.Engine.Tests.Bdd.Feature
{
    [Binding]
    public class GetEnginesSteps
    {
        protected HttpResponseMessage Response { get; set; }

        [Given(@"a Request to get All Egines and request to EngineApi returns :")]
        public void GivenARequestToGetAllEginesAndRequestToEngineApiReturns(Table table)
        {
            new InMemoryEngineApi(table);
        }



        [When(@"the Engine API receives the get request")]
        public async Task WhenTheEngineAPIReceivesTheGetRequest()
        {
            Response = await EngineHelper.GetEngines();
        }

        [Then(@"the Engine API sends Engines information:")]
        public void ThenTheEngineAPISendsEnginesInformation(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;

            Response.StatusCode.Should().Be(expectedStatusCode);
        }
        [Given(@"a request and request to EngineApi returns :")]
        public void GivenARequestAndRequestToEngineApiReturns(Table table)
        {
            new InMemoryEngineApi(table);
        }

    }
}
