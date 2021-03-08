using Engine.Infrastructure.MongoRepository;
using Engine.Infrastructure.MongoRepository.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.Test.MongoRepository
{
    class EngineMongoDBRepositoryTest
    {
        private readonly IConfigurationRoot _configuration;
        private readonly Mock<ILogger<MongoClientFactory>> _mockLogger;
        private readonly EngineMongoDBRepository engineMongoDBRepository;
        private EngineMongoDBRepository GetMongoRepository(ILogger<MongoClientFactory> logger, IConfiguration configuration,
            IMongoCollection<EngineDto> collection)
        {
            return new EngineMongoDBRepository(logger, configuration, collection);
        }
    }

}
