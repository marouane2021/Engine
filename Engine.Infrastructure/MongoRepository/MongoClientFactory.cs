using Engine.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.MongoRepository
{
   /// <summary>
     /// The MongoClientFactory class
     /// </summary>
        public class MongoClientFactory
        {
            /// <summary>
            /// The client
            /// </summary>
            protected readonly MongoClient _mongoClient;

            /// <summary>
            /// The logger
            /// </summary>
            protected readonly ILogger<MongoClientFactory> _logger;

            /// <summary>
            /// The database
            /// </summary>
            protected readonly IMongoDatabase _database;

            /// <summary>
            /// The result limit
            /// </summary>
            protected readonly int _resultLimit;

            /// <summary>
            /// Initializes a new instance of the <see cref="MongoClientFactory"/> class.
            /// </summary>
            /// <param name="logger">The logger.</param>
            /// <param name="configuration">The configuration.</param>
            /// <exception cref="ArgumentNullException">configuration</exception>
            public MongoClientFactory(ILogger<MongoClientFactory> logger, IConfiguration configuration)
            {
                MongoConfiguration _dbConfig = configuration.GetSection(Constants.MongoDbConfigurationSection)?.Get<MongoConfiguration>();

                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _mongoClient = new MongoClient(_dbConfig?.ConnectionString);
                _database = _mongoClient.GetDatabase(_dbConfig?.Database);
                _resultLimit = configuration.GetValue<int>(Constants.CompetingOfferChangesLimitConfigurationSection);
            }
        }
}
