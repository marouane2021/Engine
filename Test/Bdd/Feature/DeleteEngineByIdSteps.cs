using Cds.Engine.Tests.Bdd.Core;
using Engine.Domain.Models;
using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Engine.Tests.Bdd.Feature
{
    [Binding]
    public class DeleteEngineByIdSteps
    {
        private MyEngine engine;
        protected HttpResponseMessage Response { get; set; }
        [Given(@"a Api the  Code : (.*) and request to EngineApi should returns :")]
        public void GivenAApiTheCodeAndRequestToEngineApiShouldReturns(int code, Table table)
        {
            new InMemoryEngineApi(table);
            engine = EngineHelper.GetEngineRequestFromTable(table);
        }
       
        [When(@"the Engine API receives the delete request with Code : (.*)")]
        public async void WhenTheEngineAPIReceivesTheDeleteRequestWithCode(int code)
        {
            Response = await EngineHelper.DeleteEngine(code);
        }

        [Then(@"the Engine should return : ""(.*)""")]
        public async Task<bool> ThenTheEngineShouldReturn()
        {
            return await Task.FromResult(true);
        }
        [Then(@"the response of delete request status is ""(.*)""")]
        public void ThenTheResponseOfDeleteRequestStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"the response of delete status is ""(.*)""")]
        public void ThenTheResponseOfDeleteStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Response.StatusCode.Should().Be(expectedStatusCode);
        }



    }
}
