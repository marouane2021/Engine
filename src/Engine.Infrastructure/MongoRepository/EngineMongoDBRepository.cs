using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Infrastructure.MongoRepository
{
    public class EngineMongoDBRepository : MongoClientFactory, IEngineRepository
    {
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        internal IMongoCollection<MyEngine> _collection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineMongoDBRepository"/> class.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger">The logger.</param>
        public EngineMongoDBRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options)
            : base(options, logger)
        {
            _collection = _database.GetCollection<MyEngine>(options.Value.Collection);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetingOfferChangesMongoDBRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="options">options.</param>
        /// <param name="collection">The collection.</param>
        public EngineMongoDBRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options,
            IMongoCollection<MyEngine> collection)
            : base(options, logger)
        {
            _collection = collection;
        }

        public async Task<ObjectId> CreateEngine(MyEngine engine)
        {
            try
            {
                await _collection.InsertOneAsync(engine);
                return engine.Id;
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

            return await result.AnyAsync();
        }
        public async Task<MyEngine> GetEngineById(int code)
        {
            try
            {
                var item = await _collection
                   .Find(Builders<MyEngine>.Filter.Eq("Code", code))
                   .FirstOrDefaultAsync();

                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Caught exception during the retrieval of changed offers. { ex.Message}");
                throw;
            }
        }

        public async Task<List<MyEngine>> GetEngines()
        {
            
            return await _collection.Find(_ => true).ToListAsync();




    }
        public async Task<bool> UpdateEngine(int code, MyEngine engine)
        {
            if (GetEngineById(code) == null)
            {
                return false;
            }
            //var filter = Builders<Domain.Models.Engine>.Filter.Eq(s => s.Code, code);
            var update = Builders<MyEngine>.Update
                                            .Set(s => s.Name, engine.Name)
                                            .Set(s => s.IsEnable, engine.IsEnable)
                                            .Set(s => s.Code, engine.Code)
                ;
            var result = await _collection.UpdateOneAsync(model => model.Code == code, update);
            //var filter = Builders<Domain.Models.Engine>.Filter.Eq("Code", engine.Code);
            //var result = await _collection.ReplaceOneAsync(filter, engine);
            return true;

        }
        public async Task<bool> DeleteEngine(int code)

        {
            if (GetEngineById(code) == null)
            {
                return false;
            }
            await _collection.DeleteOneAsync(a => a.Code == code);
            return true;
        }

        }
    }
