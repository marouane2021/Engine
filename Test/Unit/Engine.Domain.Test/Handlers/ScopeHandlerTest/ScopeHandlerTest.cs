using Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers;
using Engine.Domain.Handlers;
using Engine.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Engine.Domain.Test.Handlers.ScopeHandlerTest
{
    public class ScopeHandlerTest
    {
        protected readonly Mock<IScopeRepository> _mockRepository;
        protected readonly ScopeHandler _scopeHandler;
        public ScopeHandlerTest()
        {
            _mockRepository = new Mock<IScopeRepository>();
            _scopeHandler = new ScopeHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task VerifyIfScopeExist()
        {
            var scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true

            };

            _mockRepository.Setup(x => x.GetScopeByCode(scope.ScopeId)).Returns(Task.FromResult(true));
            var result = await _scopeHandler.CreateScope(scope);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Errors);
            Assert.Contains("Scope Exist", result.Errors);
        }
        [Fact]
        public async Task GetScopeById_GivenAvailableId_ShouldReturnScopeAsync()
        {
            //Arrange
            var scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true
            };

            _mockRepository.Setup(x => x.GetScopeById(It.IsAny<int>())).ReturnsAsync(scope);

            //Act
            var result = await _scopeHandler.GetScopeById(7);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(7, result.ScopeId);
        }
        [Fact]
        public async void GetScopes_ShouldReturnScopesList()
        {
            // Arrange
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

            _mockRepository.Setup(x => x.GetScopes()).ReturnsAsync(scope);

            // Act
            var result = await _scopeHandler.GetScopes();

            // Assert

            Assert.NotNull(result);
            Assert.IsType<List<Scope>>(result);
            Assert.Equal(2, result.Count);

        }
        [Fact]
        public async Task DeleteScope_GivenScopeeIdToDelete_ShouldReturnTrueForisDeletedAsync()
        {
            //Arrange
            var scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true
            };

            _mockRepository.Setup(x => x.DeleteScope(7)).ReturnsAsync(true);

            //Act
            var result = await _scopeHandler.DeleteScope(7);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task UpdateScope_GivenScopeWithCodeAndNameString_ShouldReturnFalseAsync()
        {
            //Arrange
            var scope = new Scope { Name = "string" };
            //Act
            var reslt = await _scopeHandler.UpdateScope(16, scope);

            //Assert
            Assert.False(reslt);
        }

        [Fact]
        public async Task UpdateScope_GivenScopeToUpdate_ShouldReturnTrueAsync()
        {
            //Arrange
            var scope = new Scope { Name = "beaute" };
            _mockRepository.Setup(x => x.UpdateScope(It.IsAny<int>(), It.IsAny<Scope>())).ReturnsAsync(true);
            //Act
            var reslt = await _scopeHandler.UpdateScope(7, scope);

            //Assert
            Assert.True(reslt);
        }
    }
}
