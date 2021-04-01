using Engine.Domain.Models;
using Engine.Infrastructure.MongoRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using EngineApi.Infrastructure.Configurations;
using System.Threading;
using System.IO;
//using static Dapper.SqlMapper;

namespace Engine.Infrastructure.Test.MongoRepository
{
    public class EngineMongoDBRepositoryTest
    {
        private readonly IOptions<Settings> _options;
        private readonly Mock<ILogger<MongoClientFactory>> _mockLogger;
        private readonly EngineMongoDBRepository _engineMongoDBRepository;
       // private Mock<IMongoCollection<Engine.Domain.Models.Engine>> _mockCollection;
        private EngineMongoDBRepository GetMongoRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options,
            IMongoCollection<MyEngine> collection)
        {
            return new EngineMongoDBRepository(logger, options, collection);
        }
        public EngineMongoDBRepositoryTest()
        {
            var engine = new MyEngine
            {
                Id = new ObjectId("6048d0b57757e1f98eb48273"),
                Code = 2,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }

            };

            var fakeMongoCollection = new FakeMongoCollection<MyEngine>(new List<MyEngine> { engine }, 1L);
            _options = Options.Create(new ConfigurationBuilder()
                                .AddJsonFile("C:/Users/marouane.kaoukaou/source/repos/Engine/src/EngineApi.Api/appsettings.json", false)
                                .Build()
                                .GetSection("MongoDBConfiguration")
                                .Get<Settings>());

            _mockLogger = new Mock<ILogger<MongoClientFactory>>();
            _engineMongoDBRepository = GetMongoRepository(_mockLogger.Object, _options, fakeMongoCollection);
        }
    
        [Fact]
        public async void CreateEngine_ReturnId()
        {
            var engine = new MyEngine
            {
                Id = new ObjectId("6048c5c8fa42e6ae9581a942"),
                Code = 3,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }

            };

            //_mockCollection = new Mock<IMongoCollection<Engine.Domain.Models.Engine>>();

            //Arrange
            //_mockCollection.Setup(op => op.InsertOneAsync(engine, null, default(CancellationToken))).Returns(Task.FromResult(new ObjectId("6048c5c8fa42e6ae9581a942")));

            //Act
            var result = await _engineMongoDBRepository.CreateEngine(engine);
            //Assert 

            //Verify if InsertOneAsync is called once
            //_mockCollection.Verify(c => c.InsertOneAsync(engine, null, default(CancellationToken)), Times.Once);

            //_mockLogger.Setup(x => x.CreateEngine(engine)).Returns(Task.FromResult(new Result { Id = new ObjectId("6048d0b57757e1f98eb48273") }));

            //var result = await _engineMongoDBRepository.InsertOneAsync(engine);

            Assert.Equal(new ObjectId("6048c5c8fa42e6ae9581a942"), result);
        }
        [Fact]
        public async void GetEngineByCode_TestEngineExistOrNot()
        {            
            var resultTrue = await _engineMongoDBRepository.GetEngineByCode(2);
            var resultFalse = await _engineMongoDBRepository.GetEngineByCode(4);

            Assert.True(resultTrue);
            Assert.False(resultFalse);
        }
        [Fact]
        public async void GetEngineById_withAvailableCode_ShouldReturnEngineInfo()
        {
            var result = await _engineMongoDBRepository.GetEngineById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Code);
            Assert.Equal("Beaute", result.Name);
        }
        [Fact]
        public async void GetEngines_ShouldReturnEngineList()
        {
            // Arrange
            
            // Act
            var result = await _engineMongoDBRepository.GetEngines();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MyEngine>>(result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async void DeleteEngine_WithAvailableEngineId_ShouldBeDeleted()
        {
            // Arrange

           

            // Act
            var result = await _engineMongoDBRepository.DeleteEngine(10);

            // Assert

            Assert.True(result);
        }
        [Fact]
        public async void UpdateEngine_WithCodeAndInfoToUpdate_ShouldBeUpdated()
        {
            // Arrange
            var engine = new MyEngine
            {
                Id = new ObjectId("6048c5c8fa42e6ae9581a942"),
                Code = 10,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }

            };

            
            // Act
            var result = await _engineMongoDBRepository.UpdateEngine(10, engine);

            // Assert
            Assert.True(result);
        }



    }
}
