using Engine.Domain.Abstractions.Dtos.Handlers;
using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Engine.Infrastructure.MongoRepository
{
    public class EngineMongoDBRepository : MongoClientFactory, IEngineRepository
    {
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        private readonly IMongoCollection<Domain.Models.Engine> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineMongoDBRepository"/> class.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger">The logger.</param>
        public EngineMongoDBRepository(IOptions<Settings> options, ILogger<MongoClientFactory> logger)
            : base(options, logger)
        {
            _collection = _database.GetCollection<Domain.Models.Engine>(options.Value.Collection);
        }

        public async Task<int> CreateEngine(Domain.Models.Engine engine)
        {
            try
            {
                await _collection.InsertOneAsync(engine);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> GetEngineByCode(int code)
        {
            var result = await _collection.FindAsync(x => x.Code == code);
            ;
            return await result.AnyAsync();
        }
    }
}
