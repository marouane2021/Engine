using Engine.Domain.Abstractions;
using Engine.Domain.Abstractions.Dtos;
using Engine.Infrastructure.MongoRepository.Dtos;
using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Infrastructure.MongoRepository
{
    public class EngineMongoDBRepository : MongoClientFactory, IEngineRepository
    {
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        private readonly IMongoCollection<Domain.Models.BIS.Engine> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineMongoDBRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        public EngineMongoDBRepository(IOptions<Settings> options, ILogger<MongoClientFactory> logger)
            : base(options, logger)
        {
            _collection = _database.GetCollection<Domain.Models.BIS.Engine>(options.Value.Collection);
        }

        public async Task<int> CreateMoteur(Domain.Models.BIS.Engine engine)
        {

            try
            {
                //_collection.FindAsync()
                await _collection.InsertOneAsync(engine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 11;
        }

        public async Task<bool> GetEngineByCode(int code)
        {
            var result = await _collection.FindAsync(x => x.Code == code);
            ;
            return result.Any();
        }
    }
}
