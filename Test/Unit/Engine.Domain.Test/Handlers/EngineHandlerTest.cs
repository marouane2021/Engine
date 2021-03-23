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

        /*public async Task CreateEngine_ShouldReturnErrorList()
        {
            var engine = new Engine.Domain.Models.Engine
            {

                Id = new ObjectId("6048d0b57757e1f98eb48273"),
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
           
            _mockRepository.Setup(x => x.CreateEngine(engine)).Returns(Task.FromResult(new Result { Id = new ObjectId("6048d0b57757e1f98eb48273") , Errors = new List<string> { "Code not accepted, try again " } }));
            var result = await _engineHandler.CreateEngine(engine);

            //Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.NotEmpty(result.Errors);
           
        }
    }
}
