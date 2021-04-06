using Cds.Engine.Tests.Bdd.Core;
using Engine.Domain.Models;
using FluentAssertions;
using MongoDB.Bson;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Engine.Tests.Bdd.Feature
{
    [Binding]
    public class CreateEngineSteps
    {
        protected HttpResponseMessage Response { get; set; }
        private MyEngine engine;
       
        [Given(@"EngneApi a Engine with informations  :")]
        public void GivenEngneApiAEngineWithInformations(Table table)
        {
            new InMemoryEngineApi(table);
        }

        [Given(@"a Engine with the an existant Code (.*) a :")]
        public void GivenAEngineWithTheAnExistantCodeA(int code,Table table)
        {
            new InMemoryEngineApi(table);
        }

        [Given(@"a Engine with the Code : (.*) :")]
        public void GivenAEngineWithTheCode(int code, Table table)
        {
            new InMemoryEngineApi(table);
        }

        [When(@"the API receives the post request")]
        public async void WhenTheAPIReceivesThePostRequest()
        {
            Response = await EngineHelper.CreateEngineAsync(engine);
        }

        [When(@"the Engine API receives the post request with  Code (.*)")]
        public async void WhenTheEngineAPIReceivesThePostRequestWithCode(int code)
        {
            Response = await EngineHelper.CreateEngineAsync(engine);
        }

        
        
        [Then(@"should return Id of the Engine")]
        public async Task<ObjectId> ThenShouldReturnIdOfTheEngine(ObjectId Id)
        {
            return await Task.FromResult(Id);
        }

        [Then(@"return the message ""(.*)""")]
        public async Task<string> ThenReturnTheMessage(string message1)
        {
            message1 = "Engine Exist, try again";
            return await Task.FromResult(message1);
        }
        [Then(@"return the error message ""(.*)""")]
        public async Task<string> ThenReturnTheErrorMessage(string message2)
        {
            message2 = "Code not accepted, try again ";
            return await Task.FromResult(message2);
        }
        [Then(@"the response of the request is  status is ""(.*)""")]
        public void ThenTheResponseOfTheRequestIsStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Response.StatusCode.Should().Be(expectedStatusCode);
        }


    }
}
