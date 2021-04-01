using Cds.Engine.Tests.Bdd.Core;
using Swashbuckle.Swagger;
using System.Net.Http;
using System.Net;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Threading.Tasks;

namespace Cds.Engine.Tests.Bdd.Feature
{
    [Binding]
    public class GetEngineByIdSteps
    {
        protected HttpResponseMessage Response { get; set; }
        [Given(@"a Engine with the  Code (.*) and request to EngineApi returns :")]
        public void GivenAEngineWithTheCodeAndRequestToEngineApiReturns(int code, Table table)
        {
            new InMemoryEngineApi(table);
        }

        [When(@"the Engine API receives the get request with Code (.*)")]
        public async Task WhenTheEngineAPIReceivesTheGetRequestWithCode(int code)
        {
            Response = await EngineHelper.GetEngineById(code);
        }
        
        [Then(@"the response status is ""(.*)""")]
        public void ThenTheResponseStatusIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;

            Response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"the Engine API sends Engine information:")]
        public void ThenTheEngineAPISendsEngineInformation(Table table)

        {
            var expected = EngineHelper.GetEngineRequestFromTable(table);
            var actual = EngineHelper.GetEngineRequestFromResponse(Response);

            actual.Name.Should().Be(expected.Name);
            actual.Id.Should().Be(expected.Id);
            actual.Code.Should().Be(expected.Code);
           
        }
    }
}
