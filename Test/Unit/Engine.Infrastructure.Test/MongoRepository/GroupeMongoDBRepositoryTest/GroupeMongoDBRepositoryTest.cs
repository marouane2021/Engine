using System;
using System.Collections.Generic;
using EngineApi.Infrastructure.Configurations;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Moq;
using Engine.Infrastructure.MongoRepository.GroupeRepository;
using Engine.Infrastructure.MongoRepository;
using Engine.Domain.Models;
using Microsoft.Extensions.Configuration;
using Xunit;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Engine.Infrastructure.Test.MongoRepository.GroupeMongoDBRepositoryTest
{
    public class GroupeMongoDBRepositoryTest
    {
        private readonly IOptions<Settings> _options;
        private readonly Mock<ILogger<MongoClientFactory>> _mockLogger;
        private readonly GroupeMongoDBRepository _groupeMongoDBRepository;
        private GroupeMongoDBRepository GetMongoRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options,
            IMongoCollection<Groupe> collection)
        {
            return new GroupeMongoDBRepository(logger, options, collection);
        }
        public GroupeMongoDBRepositoryTest()
        {

            var groupe = new Groupe
            {
                GroupId = 4,
                GroupName = "MyGroupe",
                IsEnable = true,
                Engines = new List<MyEngine> { new MyEngine{
                Id = default(ObjectId),
                Code = 12,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }}}



            };
            var fakeMongoCollection = new FakeMongoCollection<Groupe>(new List<Groupe> { groupe }, 1L);
            _options = Options.Create(new ConfigurationBuilder()
                                .AddJsonFile("C:/Users/marouane.kaoukaou/source/repos/Engine/src/EngineApi.Api/appsettings.json", false)
                                .Build()
                                .GetSection("MongoDBConfiguration")
                                .Get<Settings>());

            _mockLogger = new Mock<ILogger<MongoClientFactory>>();
            _groupeMongoDBRepository = GetMongoRepository(_mockLogger.Object, _options, fakeMongoCollection);
        }
        [Fact]
        public async void CreateGroupe_ReturnId()
        {
            var groupe = new Groupe
            {
                GroupId = 4,
                GroupName = "MyGroupe",
                IsEnable = true,
                Engines = new List<MyEngine> { new MyEngine{
                Id = default(ObjectId),
                Code = 12,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }}}

            };

            //Act
            var result = await _groupeMongoDBRepository.CreateGroupe(groupe);
            //Assert 

            Assert.Equal(4, result);
        }
        [Fact]
        public async void GetGroupeByCode_TestGroupeExistOrNot()
        {
            var resultTrue = await _groupeMongoDBRepository.GetGroupeByCode(7);
            var resultFalse = await _groupeMongoDBRepository.GetGroupeByCode(4);

            Assert.True(resultTrue);
        }
        [Fact]
        public async void GetGroupeById_withAvailableCode_ShouldReturnGroupeInfo()
        {
            var result = await _groupeMongoDBRepository.GetGroupeById(7);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.GroupId);
            Assert.Equal("MyGroupe", result.GroupName);
        }
        [Fact]
        public async void GetGroupe_ShouldReturnGroupeList()
        {
            // Arrange

            // Act
            var result = await _groupeMongoDBRepository.GetGroupes();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Groupe>>(result);
            Assert.Equal(1, result.Count);
        }
        [Fact]
        public async void DeleteGroupe_WithAvailableGroupeId_ShouldBeDeleted()
        {
            // Act
            var result = await _groupeMongoDBRepository.DeleteGroupe(4);

            // Assert

            Assert.True(result);
        }
        [Fact]
        public async void UpdateGroupe_WithIdAndInfoToUpdate_ShouldBeUpdated()
        {
            // Arrange
            var groupe = new Groupe
            {
                GroupId = 4,
                GroupName = "MyGroupe",
                IsEnable = true,
                Engines = new List<MyEngine> { new MyEngine{
                Id = default(ObjectId),
                Code = 12,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }}}

            };


            // Act
            var result = await _groupeMongoDBRepository.UpdateGroupe(4, groupe);

            // Assert
            Assert.True(result);
        }
    }
}
