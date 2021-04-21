using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using EngineApi.Api.Controllers.Engines;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EngineApi.Api.Test.Controllers
{
    public class Test
    {

        protected readonly Mock<IEngineHandler> _mockEngineHandler;

        protected readonly EnginesController _engineController;

        public Test()
        {

            _mockEngineHandler = new Mock<IEngineHandler>();

            _engineController = new EnginesController(_mockEngineHandler.Object);
        }

        [Fact]
        public void CreateEngine_WithId_ThrowsExceptionAsync()
        {
            MyEngine engine = GetEngine();

            _mockEngineHandler.Setup(x => x.CreateEngine(engine)).Throws(new Exception { });

            Assert.ThrowsAsync<Exception>(() => _engineController.CreateEngineAsync(engine));
        }

        [Fact]
        public async void CreateEngine_WithId_ShouldReturnErrors()
        {
            MyEngine engine = GetEngine();
            _mockEngineHandler.Setup(x => x.CreateEngine(engine)).Returns(Task.FromResult(new Result { Id = default(ObjectId), Errors = new List<string> { "Code not accepted, try again " } }));

            var result = await _engineController.CreateEngineAsync(engine);

            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.NotEmpty((System.Collections.IEnumerable)((ObjectResult)result).Value);

        }

        private static MyEngine GetEngine()
        {
            return new MyEngine
            {
                Id = default(ObjectId),
                Code = 0,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }

            };
        }

        [Fact]
        public async void CreateEngine_WithId_ShouldReturnId()
        {
            var engine = new MyEngine
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
            _mockEngineHandler.Setup(x => x.CreateEngine(engine)).Returns(Task.FromResult(new Result { Id = new ObjectId("6048d0b57757e1f98eb48273") }));

            var result = await _engineController.CreateEngineAsync(engine);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async void GetEngineById_GivenAvailableCode_ShouldReturnOKAsync()
        {
            //Arrange
            var engine = new MyEngine
            {
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
            };
            _mockEngineHandler.Setup(x => x.GetEngineById(1)).ReturnsAsync(engine);

            //Act
            var result = await _engineController.GetEngineById(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEngineById_GivenUnvailableCode_ShouldReturnNotFoundAsync()
        {
            //Arrange
            _mockEngineHandler.Setup(x => x.GetEngineById(It.IsAny<int>())).ReturnsAsync((MyEngine)null);

            //Act
            var result = await _engineController.GetEngineById(19);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }
}
