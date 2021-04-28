using Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers;
using Engine.Domain.Handlers;
using Engine.Domain.Models;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Engine.Domain.Test.Handlers.GroupeHandlerTest
{
    public class GroupeHandlerTest
    {
        protected readonly Mock<IGroupeRepository> _mockRepository;
        protected readonly GroupeHandler _groupeHandler;
        public GroupeHandlerTest()
        {
            _mockRepository = new Mock<IGroupeRepository>();
            _groupeHandler = new GroupeHandler(_mockRepository.Object);
        }
        [Fact]
        public async Task VerifyIfEngineExist()
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

            _mockRepository.Setup(x => x.GetGroupeByCode(groupe.GroupId)).Returns(Task.FromResult(true));
            var result = await _groupeHandler.CreateGroupe(groupe);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Groupe Exist", result.Errors);
        }
        [Fact]
        public async Task GetGroupById_GivenAvailablecode_ShouldReturnEngineAsync()
        {
            //Arrange
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

            _mockRepository.Setup(x => x.GetGroupeById(It.IsAny<int>())).ReturnsAsync(groupe);

            //Act
            var result = await _groupeHandler.GetGroupeById(2);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.GroupId);
        }
        [Fact]
        public async void GetGroupes_ShouldReturnEngineList()
        {
            // Arrange
            List<Groupe> groupe = new List<Groupe>
            {
                new Groupe{
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

            _mockRepository.Setup(x => x.GetGroupes()).ReturnsAsync(groupe);

            // Act
            var result = await _groupeHandler.GetGroupes();

            // Assert

            Assert.NotNull(result);
            Assert.IsType<List<Groupe>>(result);
            Assert.Equal(2, result.Count);

        }
        [Fact]
        public async Task DeleteEngine_GivenGroupeIdToDelete_ShouldReturnTrueForisDeletedAsync()
        {
            //Arrange
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

            _mockRepository.Setup(x => x.DeleteGroupe(4)).ReturnsAsync(true);

            //Act
            var result = await _groupeHandler.DeleteGroupe(4);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task UpdateEngine_GivenGroupeWithCodeAndNameString_ShouldReturnFalseAsync()
        {
            //Arrange
            var groupe = new Groupe { GroupName = "string" };
            // _mockHandlerTest.Setup(x => x.UpdateScope(It.IsAny<int>(), It.IsAny<ScopeToUpdate>())).ReturnsAsync(false);
            //Act
            var reslt = await _groupeHandler.UpdateGroupe(5, groupe);

            //Assert
            Assert.False(reslt);
        }

        [Fact]
        public async Task UpdateEngine_GivenGroupeToUpdate_ShouldReturnTrueAsync()
        {
            //Arrange
            var groupe = new Groupe { GroupName = "MyGroupe" };
            _mockRepository.Setup(x => x.UpdateGroupe(It.IsAny<int>(), It.IsAny<Groupe>())).ReturnsAsync(true);
            //Act
            var reslt = await _groupeHandler.UpdateGroupe(4, groupe);

            //Assert
            Assert.True(reslt);
        }
    }
}
