using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.Configurations
{
    public class DBClient
    {
        private readonly IMongoCollection<Domain.Models.Engine> _engines;

        public DBClient(IOptions<Settings> setting)
        {
            var client = new MongoClient(setting.Value.ConnectionString);
            var database = client.GetDatabase(setting.Value.Database);
            _engines = database.GetCollection<Domain.Models.Engine>(setting.Value.ENGINE_COLLECTION_NAME);
        }

        public IMongoCollection<Domain.Models.Engine> GetEngines() => _engines;
    }
}
