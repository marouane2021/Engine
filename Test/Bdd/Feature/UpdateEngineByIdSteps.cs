using Cds.Engine.Tests.Bdd.Core;
using Engine.Domain.Models;
using FluentAssertions;
using Swashbuckle.Swagger;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Engine.Tests.Bdd.Feature
{
    [Binding]
    public class UpdateEngineByIdSteps
    {
        protected HttpResponseMessage Response { get; set; }
        private MyEngine engine;

        [Given(@"a Api with the  Code : (.*) and request to EngineApi should returns :")]
        public void GivenAApiWithTheCodeAndRequestToEngineApiShouldReturns( int code,Table table)
        {
            new InMemoryEngineApi(table);
            engine = EngineHelper.GetEngineRequestFromTable(table);
        }

        [When(@"the Engine API receive the put request with Code (.*)")]
        public async void WhenTheEngineAPIReceiveThePutRequestWithCode(int code)
        {
            Response = await EngineHelper.UpdateEngine(code, engine);
        }
        [Then(@"the UpdatedEngine API sends : ""(.*)""")]
        public async Task<bool> ThenTheUpdatedEngineAPISends()
           
        {
            return await Task.FromResult(true);
        }
        [Then(@"the response of Update  status is ""(.*)""")]
        public void ThenTheResponseOfUpdateStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"the response of NoContent status is ""(.*)""")]
        public void ThenTheResponseOfNoContentStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Response.StatusCode.Should().Be(expectedStatusCode);
        }




    }
}
