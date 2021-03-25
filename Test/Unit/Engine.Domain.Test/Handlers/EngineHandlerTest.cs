using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Handlers;
using Engine.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Engine.Domain.Test.Handlers
{
   public  class EngineHandlerTest
    {
        protected readonly Mock<IEngineRepository> _mockRepository;
        protected readonly EngineHandler _engineHandler;
        public EngineHandlerTest()
        {
            _mockRepository = new Mock<IEngineRepository>();
            _engineHandler = new EngineHandler(_mockRepository.Object);
        }
        [Fact]
        public async Task VerifyIfEngineExist()
        {
            var engine = new Engine.Domain.Models.Engine
            {

                Id = new ObjectId("6048d0b57757e1f98eb48273"),
                Code = 2,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }

            };
            //_mockRepository.Setup(x => x.CreateEngine(engine)).Returns(Task.FromResult(new Result { Id = new ObjectId("6048d0b57757e1f98eb48273"), Errors = new List<string> { "Moteur Exist" } }));
           
           _mockRepository.Setup(x => x.GetEngineByCode(engine.Code)).Returns(Task.FromResult(true));
            var result = await _engineHandler.CreateEngine(engine);

            //Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Moteur Exist", result.Errors);
        }

        //public async Task CreateEngine_ShouldReturnErrorList()
        //{
        //    var engine = new Engine.Domain.Models.Engine
        //    {

        //        Id = new ObjectId("6048d0b57757e1f98eb48273"),
        //        Code = 0,
        //        Name = "beaute",
        //        IsEnable = true,
        //        SearchText = "hello",
        //        Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
        //        InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
        //        BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
        //        Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
        //        MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }

        //    };

        //    _mockRepository.Setup(x => x.CreateEngine(engine)).Returns(Task.FromResult(new Result { Id = new ObjectId("6048d0b57757e1f98eb48273") , Errors = new List<string> { "Code not accepted, try again " } }));
        //    var result = await _engineHandler.CreateEngine(engine);

        //    //Assert.IsType<ObjectResult>(result);
        //    Assert.NotNull(result);
        //    Assert.NotEmpty(result.Errors);

        //}
        [Fact]
        public async Task GetEngineById_GivenAvailablecode_ShouldReturnEngineAsync()
        {
            //Arrange
            var engine = new Engine.Domain.Models.Engine
            {
                Id = new ObjectId("6048d0b57757e1f98eb48273"),
                Code = 10,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }
            };

            _mockRepository.Setup(x => x.GetEngineById(It.IsAny<int>())).ReturnsAsync(engine);

            //Act
            var result = await _engineHandler.GetEngineById(2);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Code);
        }
        [Fact]
        public async void GetEngines_ShouldReturnEngineList()
        {
            // Arrange
            List< Models.Engine> engine = new List<Engine.Domain.Models.Engine>
            {
                new Engine.Domain.Models.Engine{
                Id = new ObjectId("6048d0b57757e1f98eb48273"),
                Code = 1,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }
            },
             new Engine.Domain.Models.Engine
             {
                 Id = new ObjectId("6048d0b57757e1f98eb48253"),
                 Code = 12,
                 Name = "alimentation",
                 IsEnable = true,
                 SearchText = "hello",
                 Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                 InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                 BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                 Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                 MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }
             }
             };

            _mockRepository.Setup(x => x.GetEngines()).ReturnsAsync(engine);

            // Act
            var result = await _engineHandler.GetEngines();

            // Assert

            Assert.NotNull(result);
            Assert.IsType<List<Models.Engine>>(result);
            Assert.Equal(2, result.Count);

        }
        [Fact]
        public async Task DeleteEngine_GivenEngineeIdToDelete_ShouldReturnTrueForisDeletedAsync()
        {
            //Arrange
            var engine = new Engine.Domain.Models.Engine
            {
                Id = new ObjectId("6048d0b57757e1f98eb48273"),
                Code = 10,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }
            };

            _mockRepository.Setup(x => x.DeleteEngine(10)).ReturnsAsync(true);

            //Act
            var result = await _engineHandler.DeleteEngine(10);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task UpdateEngine_GivenEngineWithCodeAndNameString_ShouldReturnFalseAsync()
        {
            //Arrange
            var engine = new Models.Engine { Name = "string" };
            // _mockHandlerTest.Setup(x => x.UpdateScope(It.IsAny<int>(), It.IsAny<ScopeToUpdate>())).ReturnsAsync(false);
            //Act
            var reslt = await _engineHandler.UpdateEngine(5, engine);

            //Assert
            Assert.False(reslt);
        }

        [Fact]
        public async Task UpdateEngine_GivenEngineToUpdate_ShouldReturnTrueAsync()
        {
            //Arrange
            var engine = new Models.Engine { Name = "Beaute" };
            _mockRepository.Setup(x => x.UpdateEngine(It.IsAny<int>(), It.IsAny<Models.Engine>())).ReturnsAsync(true);
            //Act
            var reslt = await _engineHandler.UpdateEngine(10, engine);

            //Assert
            Assert.True(reslt);
        }

    }
}
