using Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers;
using Engine.Domain.Models;
using EngineApi.Api.Controllers.Scopes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EngineApi.Api.Test.Controllers.ScopeControllerTest
{
    public class ScopeControllerTest
    {
        protected readonly Mock<IScopeHandler> _mockScopeHandler;

        protected readonly ScopesController _scopeController;
        public ScopeControllerTest()
        {
            _mockScopeHandler = new Mock<IScopeHandler>();
            _scopeController = new ScopesController(_mockScopeHandler.Object);
        }
        [Fact]
        public void CreateScope_WithId_ThrowsExceptionAsync()
        {
            Scope scope = GetScope();

            _mockScopeHandler.Setup(x => x.CreateScope(scope)).Throws(new Exception { });

            Assert.ThrowsAsync<Exception>(() => _scopeController.CreateScopeAsync(scope));
        }
        [Fact]
        public async void CreateScope_WithId_ShouldReturnErrors()
        {
            Scope scope = GetScope();
            _mockScopeHandler.Setup(x => x.CreateScope(scope)).Returns(Task.FromResult(new Result { ScopeId = default, Errors = new List<string> { "Id not accepted, try again " } }));

            var result = await _scopeController.CreateScopeAsync(scope);

            Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            Assert.NotEmpty((System.Collections.IEnumerable)((ObjectResult)result).Value);

        }

        private static Scope GetScope()
        {
            return new Scope
            {
                ScopeId = 0,
                Order = 0,
                Name = "beaute",
                IsEnable = true

            };
        }
        [Fact]
        public async void CreateScope_WithId_ShouldReturnId()
        {
            Scope scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true

            };
            _mockScopeHandler.Setup(x => x.CreateScope(scope)).Returns(Task.FromResult(new Result { ScopeId = 7 }));

            var result = await _scopeController.CreateScopeAsync(scope);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);

        }
        [Fact]
        public async void GetScpeById_GivenAvailableId_ShouldReturnOKAsync()
        {
            var scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true

            };
            _mockScopeHandler.Setup(x => x.GetScopeById(7)).ReturnsAsync(scope);
            var result = await _scopeController.GetScopeById(7);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, (result as ObjectResult).StatusCode);
        }
        [Fact]
        public async Task GetScopeById_GivenUnvailableId_ShouldReturnNotFoundAsync()
        {
            //Arrange
            _mockScopeHandler.Setup(x => x.GetScopeById(It.IsAny<int>())).ReturnsAsync((Scope)null);

            //Act
            var result = await _scopeController.GetScopeById(7);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, (result as ObjectResult).StatusCode);
        }
        [Fact]
        public async void GetScopes_Should_Return_Ok()
        {
            List<Scope> scope = new List<Scope>
            {
                new Scope
                {
                 ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true

                },
                new Scope
                {
                 ScopeId = 8,
                Order = 2,
                Name = "gammes",
                IsEnable = true

                }

            };
            _mockScopeHandler.Setup(x => x.GetScopes()).ReturnsAsync(scope);

            // Act
            var result = await _scopeController.GetScopes();

            //// Assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async void GetScops_Should_Return_NotFound()
        {
            // Arrange
            _mockScopeHandler.Setup(x => x.GetScopes());

            // Act
            var result = await _scopeController.GetScopes();

            // Assert

            //Assert.Equal(200, result.GetType());
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task DeleteScopeAsync_GivenAvailableId_ShouldReturnOk()

        {
            var scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true
            };
            //Arrange
            _mockScopeHandler.Setup(x => x.DeleteScope(7)).ReturnsAsync(false);

            //Act
            var reslt = await _scopeController.DeleteScopeAsync(7);

            //Assert
            Assert.NotNull(reslt);
            Assert.IsType<NotFoundObjectResult>(reslt);
        }
        [Fact]
        public async Task DeleteScopeAsync_GivenUnavailableIdShouldReturnNotFoundAsync()
        {
            //Arrange
            _mockScopeHandler.Setup(x => x.DeleteScope(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var reslt = await _scopeController.DeleteScopeAsync(10);

            //Assert
            Assert.NotNull(reslt);
            Assert.IsType<NotFoundObjectResult>(reslt);
        }
        [Fact]
        public async Task UpdateScopeAsync_GivenScopeeWithIdndNameString_ShouldReturnNotFoundAsync()
        {
            //Arrange
            var scope = new Scope { Name = "string" };
            _mockScopeHandler.Setup(x => x.UpdateScope(It.IsAny<int>(), It.IsAny<Scope>())).ReturnsAsync(false);

            //Act
            var reslt = await _scopeController.UpdateScopeAsync(16, scope);

            //Assert
            Assert.NotNull(reslt);
            Assert.IsType<NotFoundObjectResult>(reslt);
        }




    }
}
