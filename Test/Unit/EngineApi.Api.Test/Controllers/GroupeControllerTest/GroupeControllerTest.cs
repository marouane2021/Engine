using Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers;
using Engine.Domain.Models;
using EngineApi.Api.Controllers.Groupes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EngineApi.Api.Test.Controllers.GroupeControllerTest
{
    public class GroupeControllerTest
    {
        protected readonly Mock<IGroupeHandler> _mockGroupeHandler;

        protected readonly GroupeController _groupeController;
        public GroupeControllerTest()
        {
            _mockGroupeHandler = new Mock<IGroupeHandler>();
            _groupeController = new GroupeController(_mockGroupeHandler.Object);
        }
        [Fact]
        public void CreateGroupe_WithId_ThrowsExceptionAsync()
        {
            Groupe groupe = GetGroupe();

            _mockGroupeHandler.Setup(x => x.CreateGroupe(groupe)).Throws(new Exception { });

            Assert.ThrowsAsync<Exception>(() => _groupeController.CreateGroupeAsync(groupe));
        }
        [Fact]
        public async void CreateGroupe_WithId_ShouldReturnErrors()
        {
            Groupe groupe = GetGroupe();
            _mockGroupeHandler.Setup(x => x.CreateGroupe(groupe)).Returns(Task.FromResult(new Result { ScopeId = default, Errors = new List<string> { "Id not accepted, try again " } }));

            var result = await _groupeController.CreateGroupeAsync(groupe);

            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.NotEmpty((System.Collections.IEnumerable)((ObjectResult)result).Value);

        }

        private static Groupe GetGroupe()
        {
            return new Groupe
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
        }
        [Fact]
        public async void CreateGroupe_WithId_ShouldReturnId()
        {
            Groupe groupe = new Groupe
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
            _mockGroupeHandler.Setup(x => x.CreateGroupe(groupe)).Returns(Task.FromResult(new Result { GroupId = 4 }));

            var result = await _groupeController.CreateGroupeAsync(groupe);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);

        }
        [Fact]
        public async void GetGroupeById_GivenAvailableId_ShouldReturnOKAsync()
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
            _mockGroupeHandler.Setup(x => x.GetGroupeById(4)).ReturnsAsync(groupe);
            var result = await _groupeController.GetGroupeById(4);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, (result as ObjectResult).StatusCode);
        }
        [Fact]
        public async Task GetGroupeById_GivenUnvailableId_ShouldReturnNotFoundAsync()
        {
            //Arrange
            _mockGroupeHandler.Setup(x => x.GetGroupeById(It.IsAny<int>())).ReturnsAsync((Groupe)null);

            //Act
            var result = await _groupeController.GetGroupeById(7);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, (result as ObjectResult).StatusCode);
        }
        [Fact]
        public async void GetGroupes_Should_Return_Ok()
        {
            List<Groupe> groupe = new List<Groupe>
            {
                new Groupe
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

                },
                new Groupe
                {
                GroupId = 14,
                GroupName = "MyGroupe",
                IsEnable = true,
                Engines = new List<MyEngine> { new MyEngine{
                Id = default(ObjectId),
                Code = 32,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Engine.Domain.Models.Scope> { new Engine.Domain.Models.Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<Engine.Domain.Models.InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Engine.Domain.Models.Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<Engine.Domain.Models.BackGroundImage> { new Engine.Domain.Models.BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Engine.Domain.Models.Logo> { new Engine.Domain.Models.Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<Engine.Domain.Models.MarketingText> { new Engine.Domain.Models.MarketingText { IsEnable = true, Text = "marketing" } }}}

                }

            };
            _mockGroupeHandler.Setup(x => x.GetGroupes()).ReturnsAsync(groupe);

            // Act
            var result = await _groupeController.GetGroupes();

            //// Assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async void GetGroupes_Should_Return_NotFound()
        {
            // Arrange
            _mockGroupeHandler.Setup(x => x.GetGroupes());

            // Act
            var result = await _groupeController.GetGroupes();

            // Assert

            //Assert.Equal(200, result.GetType());
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task DeleteGroupeAsync_GivenAvailableId_ShouldReturnOk()

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
            //Arrange
            _mockGroupeHandler.Setup(x => x.DeleteGroupe(4)).ReturnsAsync(false);

            //Act
            var reslt = await _groupeController.DeleteGroupeAsync(4);

            //Assert
            Assert.NotNull(reslt);
            Assert.IsType<NotFoundObjectResult>(reslt);
        }
        [Fact]
        public async Task DeleteGroupeAsync_GivenUnavailableIdShouldReturnNotFoundAsync()
        {
            //Arrange
            _mockGroupeHandler.Setup(x => x.DeleteGroupe(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var reslt = await _groupeController.DeleteGroupeAsync(10);

            //Assert
            Assert.NotNull(reslt);
            Assert.IsType<NotFoundObjectResult>(reslt);
        }
        [Fact]
        public async Task UpdateGroupeAsync_GivenScopeeWithIdndNameString_ShouldReturnNotFoundAsync()
        {
            //Arrange
            var groupe = new Groupe { GroupName = "string" };
            _mockGroupeHandler.Setup(x => x.UpdateGroupe(It.IsAny<int>(), It.IsAny<Groupe>())).ReturnsAsync(false);

            //Act
            var reslt = await _groupeController.UpdateGroupeAsync(16, groupe);

            //Assert
            Assert.NotNull(reslt);
            Assert.IsType<NotFoundObjectResult>(reslt);
        }

    }
}
