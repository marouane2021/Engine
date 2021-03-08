using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

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
        /// The logger
        /// </summary>
        protected readonly ILogger<MongoClientFactory> _logger;

        /// <summary>
        /// The database
        /// </summary>
        protected readonly IMongoDatabase _database;

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
    }
}
