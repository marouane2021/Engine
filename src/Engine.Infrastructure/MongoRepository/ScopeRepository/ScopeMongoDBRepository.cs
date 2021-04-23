
using Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers;
using Engine.Domain.Models;
using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Infrastructure.MongoRepository.ScopeRepository
{
    public class ScopeMongoDBRepository : MongoClientFactory, IScopeRepository
    {
        internal IMongoCollection<Scope> _collection { get; set; }
        public ScopeMongoDBRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options)
           : base(options, logger)
        {
            _collection = _database.GetCollection<Scope>(options.Value.scopeCollection);
        }
        public ScopeMongoDBRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options,
           IMongoCollection<Scope> collection)
           : base(options, logger)
        {
            _collection = collection;
        }
        public async Task<int> CreateScope(Scope scope)
        {
            try
            {
                await _collection.InsertOneAsync(scope);
                return scope.ScopeId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> GetScopeByCode(int scopeId)
        {
            var result = await _collection.FindAsync(x => x.ScopeId == scopeId);

            return await result.AnyAsync();
        }

        public async Task<Scope> GetScopeById(int scopeId)
        {
            try
            {
                var item = await _collection
                   .Find(Builders<Scope>.Filter.Eq("ScopeId", scopeId))
                   .FirstOrDefaultAsync();

                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Caught exception during the retrieval of Scopes. { ex.Message}");
                throw;
            }
        }

        public async Task<List<Scope>> GetScopes()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<bool> UpdateScope(int scopeId, Scope scope)
        {
            if (GetScopeById(scopeId) == null)
            {
                return false;
            }
            //var filter = Builders<Domain.Models.Engine>.Filter.Eq(s => s.Code, code);
            var update = Builders<Scope>.Update
                                            .Set(s => s.Name, scope.Name)
                                            .Set(s => s.IsEnable, scope.IsEnable)
                                            .Set(s => s.ScopeId, scope.ScopeId)
                ;
            var result = await _collection.UpdateOneAsync(model => model.ScopeId == scopeId, update);
            return true;
        }

        public async Task<bool> DeleteScope(int scopeId)
        {
            if (GetScopeById(scopeId) == null)
            {
                return false;
            }
            await _collection.DeleteOneAsync(a => a.ScopeId == scopeId);
            return true;
        }
    }
    
}
