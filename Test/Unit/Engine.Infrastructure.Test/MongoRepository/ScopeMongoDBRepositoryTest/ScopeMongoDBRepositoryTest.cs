using Engine.Domain.Models;
using Engine.Infrastructure.MongoRepository;
using Engine.Infrastructure.MongoRepository.ScopeRepository;
using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Engine.Infrastructure.Test.MongoRepository.ScopeMongoDBRepositoryTest
{
    public class ScopeMongoDBRepositoryTest
    {
        private readonly IOptions<Settings> _options;
        private readonly Mock<ILogger<MongoClientFactory>> _mockLogger;
        private readonly ScopeMongoDBRepository _scopeMongoDBRepository;
        private ScopeMongoDBRepository GetMongoRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options,
            IMongoCollection<Scope> collection)
        {
            return new ScopeMongoDBRepository(logger, options, collection);
        }
        public ScopeMongoDBRepositoryTest()
        {
           
                var scope = new Scope
                {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true

                

            };
            var fakeMongoCollection = new FakeMongoCollection<Scope>(new List<Scope> { scope }   , 1L);
            _options = Options.Create(new ConfigurationBuilder()
                                .AddJsonFile("C:/Users/marouane.kaoukaou/source/repos/Engine/src/EngineApi.Api/appsettings.json", false)
                                .Build()
                                .GetSection("MongoDBConfiguration")
                                .Get<Settings>());

            _mockLogger = new Mock<ILogger<MongoClientFactory>>();
            _scopeMongoDBRepository = GetMongoRepository(_mockLogger.Object, _options, fakeMongoCollection);
        }
        [Fact]
        public async void CreateScope_ReturnId()
        {
            var scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true

            };

            //Act
            var result = await _scopeMongoDBRepository.CreateScope(scope);
            //Assert 

            Assert.Equal(7, result);
        }
        [Fact]
        public async void GetScopeByCode_TestScopeExistOrNot()
        {
            var resultTrue = await _scopeMongoDBRepository.GetScopeByCode(7);
            var resultFalse = await _scopeMongoDBRepository.GetScopeByCode(4);

            Assert.True(resultTrue);
        }
        [Fact]
        public async void GetScopeById_withAvailableCode_ShouldReturnScopeInfo()
        {
            var result = await _scopeMongoDBRepository.GetScopeById(7);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(7, result.ScopeId);
            Assert.Equal("beaute", result.Name);
        }
        [Fact]
        public async void GetScops_ShouldReturnScopeList()
        {
            // Arrange

            // Act
            var result = await _scopeMongoDBRepository.GetScopes();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Scope>>(result);
            Assert.Equal(1, result.Count);
        }
        [Fact]
        public async void DeleteScope_WithAvailableScopeId_ShouldBeDeleted()
        {
            // Act
            var result = await _scopeMongoDBRepository.DeleteScope(7);

            // Assert

            Assert.True(result);
        }
        [Fact]
        public async void UpdateScope_WithIdAndInfoToUpdate_ShouldBeUpdated()
        {
            // Arrange
            var scope = new Scope
            {
                ScopeId = 7,
                Order = 1,
                Name = "beaute",
                IsEnable = true

            };


            // Act
            var result = await _scopeMongoDBRepository.UpdateScope(7, scope);

            // Assert
            Assert.True(result);
        }
    }
}
