using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using EngineApi.Api.Controllers.Engines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EngineApi.Api.Test
{
    public class EngineControllerTest
    {

        protected readonly Mock<IEngineHandler> _mockEngineHandler;

        protected readonly EnginesController _engineController;

        public EngineControllerTest()
        {

            _mockEngineHandler = new Mock<IEngineHandler>();

            _engineController = new EnginesController(_mockEngineHandler.Object);
        }

        [Fact]
        public async void CreateEngine_WithId_ThrowsExceptionAsync()
        {
            Engine.Domain.Models.Engine engine = GetEngine();

            _mockEngineHandler.Setup(x => x.CreateEngine(engine)).Throws(new Exception { });

            Assert.ThrowsAsync<Exception>(() => _engineController.CreateEngineAsync(engine));
        }

        [Fact]
        public async void CreateEngine_WithId_ShouldReturnErrors()
        {
            Engine.Domain.Models.Engine engine = GetEngine();
            _mockEngineHandler.Setup(x => x.CreateEngine(engine)).Returns(Task.FromResult(new Result { Id = default(ObjectId), Errors = new List<string> { "Code not accepted, try again " } }));

            var result = await _engineController.CreateEngineAsync(engine);

            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.NotEmpty((System.Collections.IEnumerable)((ObjectResult)result).Value);

        }

        private static Engine.Domain.Models.Engine GetEngine()
        {
            return new Engine.Domain.Models.Engine
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
            Engine.Domain.Models.Engine engine = new Engine.Domain.Models.Engine
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
    }
}