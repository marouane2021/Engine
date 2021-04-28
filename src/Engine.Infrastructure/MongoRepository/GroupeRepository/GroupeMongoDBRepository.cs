using Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers;
using Engine.Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EngineApi.Infrastructure.Configurations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Infrastructure.MongoRepository.GroupeRepository
{

    public class GroupeMongoDBRepository : MongoClientFactory, IGroupeRepository
    {
        internal IMongoCollection<Groupe> _collection { get; set; }
        public GroupeMongoDBRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options)
           : base(options, logger)
        {
            _collection = _database.GetCollection<Groupe>(options.Value.groupeCollection);
        }
        public GroupeMongoDBRepository(ILogger<MongoClientFactory> logger, IOptions<Settings> options,
           IMongoCollection<Groupe> collection)
           : base(options, logger)
        {
            _collection = collection;
        }
        public async Task<int> CreateGroupe(Groupe groupe)
        {
            try
            {
                await _collection.InsertOneAsync(groupe);
                return groupe.GroupId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteGroupe(int groupeId)
        {
            if (GetGroupeById(groupeId) == null)
            {
                return false;
            }
            await _collection.DeleteOneAsync(a => a.GroupId == groupeId);
            return true;
        }

        public async Task<bool> GetGroupeByCode(int groupeId)
        {
            var result = await _collection.FindAsync(x => x.GroupId == groupeId);

            return await result.AnyAsync();
        }

        public async  Task<Groupe> GetGroupeById(int groupeId)
        {
            try
            {
                var item = await _collection
                   .Find(Builders<Groupe>.Filter.Eq("GroupId", groupeId))
                   .FirstOrDefaultAsync();

                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Caught exception during the retrieval of Groupes. { ex.Message}");
                throw;
            }
        }

        public async Task<List<Groupe>> GetGroupes()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<bool> UpdateGroupe(int groupeId, Groupe groupe)
        {
            if (GetGroupeById(groupeId) == null)
            {
                return false;
            }
            var update = Builders<Groupe>.Update
                                            .Set(s => s.GroupName, groupe.GroupName)
                                            .Set(s => s.IsEnable, groupe.IsEnable)
                                            .Set(s => s.GroupId, groupe.GroupId)
                ;
            var result = await _collection.UpdateOneAsync(model => model.GroupId== groupeId, update);
            return true;
        }
    }
}
