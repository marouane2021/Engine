using EngineApi.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.Configurations
{
    public class EngineContext
    {
        private readonly IMongoDatabase _database = null;

        public EngineContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Domain.Models.Engine> Engines
        {
            get
            {
                return _database.GetCollection<Domain.Models.Engine>("base");
            }
        }
    }
}
