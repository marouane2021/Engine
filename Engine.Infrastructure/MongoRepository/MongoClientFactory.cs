using Engine.Infrastructure.Configurations;
using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using Microsoft.Extensions.Options;

namespace Engine.Infrastructure.MongoRepository
{
    /// <summary>
    /// The MongoClientFactory class
    /// </summary>
    public class MongoClientFactory
    {
        /// <summary>
        /// The options
        /// </summary>
        protected readonly IOptions<Settings> _options;

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

        ///// <summary>
        ///// Initializes a new instance of the <see cref="MongoClientFactory"/> class.
        ///// </summary>
        ///// <param name="logger">The logger.</param>
        ///// <param name="configuration">The configuration.</param>
        ///// <exception cref="ArgumentNullException">configuration</exception>
        //public MongoClientFactory(ILogger<MongoClientFactory> logger, IConfiguration configuration)
        //{
        //    MongoConfiguration _dbConfig = configuration.GetSection(Constants.MongoDbConfigurationSection)?.Get<MongoConfiguration>();

        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //    _mongoClient = new MongoClient(_dbConfig?.ConnectionString);
        //    _database = _mongoClient.GetDatabase(_dbConfig?.Database);
        //    _resultLimit = configuration.GetValue<int>(Constants.CompetingOfferChangesLimitConfigurationSection);
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoClientFactory"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">mongoDbConfiguration</exception>
        public MongoClientFactory(IOptions<Settings> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            var client = new MongoClient(MongoClientSettings.FromConnectionString(options.Value.ConnectionString));
            _database = client.GetDatabase(_options.Value.Database);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoClientFactory"/> class.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger">The logger.</param>
        public MongoClientFactory(IOptions<Settings> options, ILogger<MongoClientFactory> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            var _client = new MongoClient(MongoClientSettings.FromConnectionString(_options.Value.ConnectionString));
            _database = _client.GetDatabase(_options.Value.Database);
        }

        /// <summary>
        /// Gets the MONGO collection.
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <returns>
        /// The collection
        /// </returns>
        public IMongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName) where TDocument : class, new()
        {
            return _database.GetCollection<TDocument>(collectionName);
        }
    }
}
