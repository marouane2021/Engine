using Cds.Engine.Tests.ProviderPact;
using Cds.SearchEngineEditor.Tests.Bdd;
using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using EngineApi.Api.Bootstrap;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Cds.Engine.Tests.Bdd.Steps
{
    [Binding]
    [Scope(Feature = "EngineEpRoutes")]
    public class EngineRoutesSteps
    {
        private HttpResponseMessage _response;
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Startup> _factory;
        /// <summary>
        /// Gets the engine read repository.
        /// </summary>
        /// <value>
        /// The engine read repository.
        /// </value>
        public static Mock<IEngineRepository> _engineReadRepository = new Mock<IEngineRepository>();
        public static InMemoryEngineRepository _inMemoryEngineReadRepository = new InMemoryEngineRepository();

        public EngineRoutesSteps(TestWebApplicationFactory factory)

        {
            var engine = new MyEngine
            {
                //Id = "6048d0b57757e1f98eb48273",
                Id = new ObjectId(timestamp: 1617721631, machine: 7894647, pid: 13311, increment: 5403081),
                /*, creationTime: "2021-04-06T15:07:11Z"*/
                Code = 16,
                Name = "Beuate",
                IsEnable = true,
                SearchText = "string",
                Scopes = new List<Scope> { new Scope { ScopeId = 2, Name = "string", Order = 0, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 1, IsEnable = true, IsMandatory = true, Label = "string", Order = 0, Type = "string", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 1, ExternalCodeId = 0, Order = 0, Label = "string" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "string", IsEnable = true, OpenInNewTab = true, Order = 0, UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string", Alt = "string", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "string" } }
            };
            _engineReadRepository.Setup(r => r.CreateEngine(engine)).Returns(_inMemoryEngineReadRepository.CreateEngine(engine));
            _engineReadRepository.Setup(r => r.GetEngineById(It.IsIn(16))).Returns(_inMemoryEngineReadRepository.GetEngineById(16));
            _engineReadRepository.Setup(r => r.GetEngines()).Returns(_inMemoryEngineReadRepository.GetEngines());
            _engineReadRepository.Setup(r => r.DeleteEngine(It.IsIn(16))).Returns(_inMemoryEngineReadRepository.DeleteEngine(16));
            _engineReadRepository.Setup(r => r.UpdateEngine(It.IsIn(16), engine)).Returns(_inMemoryEngineReadRepository.UpdateEngine(16, engine));

            _factory = factory.WithWebHostBuilder(
                builder => builder.ConfigureTestServices(
                    services =>
                    {

                        services.AddScoped(ser => _engineReadRepository);
                        services.AddScoped(ser => _engineReadRepository.Object);


                    }));


            _client = _factory.CreateClient();
        }

        [Given(@"engines Informations inexistant in database")]
        public void GivenEnginesInformationsInexistantInDatabase()
        {
            _engineReadRepository.Setup(r => r.GetEngines()).Returns(Task.FromResult<List<MyEngine>>(null));
        }

        [When(@"the Api receives a Get request for (.*)")]
        public async Task WhenTheApiRecivesAGetRequestForEngines(string path)
        {
            _response = await _client.GetAsync(new Uri(path, UriKind.Relative)).ConfigureAwait(false);
        }

        [When(@"The Api receives a Post request for (.*) with body (.*)")]
        public async Task WhenTheApiReceivesAPostRequestForEnginesWithBodyAddEngines_Json(string path, string jsonFile)
        {
            jsonFile = "C:/Users/marouane.kaoukaou/source/repos/Engine/Test/Bdd1/Json/CreateEngine.json";
            string content = "";
            if (!jsonFile.Equals("null"))
            {
                content = File.ReadAllText(jsonFile);
            }

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            _response = await _client.PostAsync(new Uri(path, UriKind.Relative), httpContent).ConfigureAwait(false);
        }

        [When(@"the Api receives a Delete request for (.*)")]
        public async Task WhenTheApiReceivesADeleteRequestForEngines(string path)
        {
            _response = await _client.DeleteAsync(new Uri(path, UriKind.Relative)).ConfigureAwait(false);
        }


        [When(@"the Api receives a Put request for (.*) with body (.*)")]
        public async Task WhenTheApiReceivesAPutRequestForEnginesWithBodyUpdateEngines_Json(string path, string jsonFile)
        {

            string content = File.ReadAllText(jsonFile);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            _response = await _client.PutAsync(new Uri(path, UriKind.Relative), httpContent).ConfigureAwait(false);
        }

        [Then(@"the Api returns a list of engine with body")]
        public async Task ThenTheApiReturnsAListOfEngineWithBodyAsync(Table table)
        {
            List<MyEngine> expectedPartialEngine = new List<MyEngine>();
            var actualData = await _response.Content.ReadAsStringAsync().ConfigureAwait(false);
            List<MyEngine> actualPartialEngine = JsonConvert.DeserializeObject<List<MyEngine>>(actualData);

            foreach (var row in table.Rows)
            {

                row.TryGetValue("name", out string name);
                row.TryGetValue("code", out string code);
                row.TryGetValue("isEnable", out string isEnable);
                expectedPartialEngine.Add(new MyEngine
                {

                    Code = Convert.ToInt16(code),
                    IsEnable = Convert.ToBoolean(isEnable),
                    Name = name,

                });
            }

            for (int i = 0; i < actualPartialEngine.Count(); i++)
            {

                Assert.Equal(expectedPartialEngine[i].Name, actualPartialEngine[i].Name);
                Assert.Equal(expectedPartialEngine[i].IsEnable, actualPartialEngine[i].IsEnable);

            }
        }

        [Then(@"the status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int p0)
        {
            Assert.Equal(p0, (int)_response.StatusCode);
        }
        [Then(@"the returned engineId should be (.*)")]
        public async Task ThenTheReturnedEngineIdShouldBe(int p0)
        {
            var content = await _response.Content.ReadAsStringAsync();
            Assert.Equal(p0, Convert.ToInt32(content));
        }


        [Then(@"the returned body should be (.*)")]
        public async Task ThenTheReturnedBodyShouldBeGetEngine_Json(string jsonFile)
        {
            JObject actuelData = JObject.Parse(await _response.Content.ReadAsStringAsync().ConfigureAwait(false));
            MyEngine fullEngineResponse = JsonConvert.DeserializeObject<MyEngine>(actuelData.ToString());
            MyEngine engine = JsonConvert.DeserializeObject<MyEngine>(File.ReadAllText(jsonFile));

            Assert.Equal(engine.Code, fullEngineResponse.Code);
            Assert.Equal(engine.Name, fullEngineResponse.Name);
            Assert.Equal(engine.IsEnable, fullEngineResponse.IsEnable);

        }
    }
}
