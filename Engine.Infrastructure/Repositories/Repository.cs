using Engine.Domain.Abstractions;
using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Engine.Domain.Abstractions.Dtos;
using Engine.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using EngineApi.Infrastructure.Configurations;

namespace Engine.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IEngineRepository" />
    public class Repository : IEngineRepository
    {
        private readonly Func<IDbConnection> _connectionFactory;
        private readonly IMongoCollection<Domain.Models.Engine> _engines;
        private readonly EngineContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        /// 
        public Repository(/*Func<IDbConnection> connectionFactory,*/ IOptions<Settings> settings)
        {
            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.DatabaseName);

            //_engines = database.GetCollection<Book>(settings.BooksCollectionName);
            _context = new EngineContext(settings);
            //_connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Gets the scopes.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 

        public async Task<int> CreateMoteur(Domain.Models.BIS.Engine moteur)
        {
            //try
            //{
            //    await _context.Engines.InsertOneAsync(moteur);
            //    return 1;
            //}
            //catch (Exception ex)
            //{
            //    // log or manage the exception
            //    throw ex;
            //    return 0;
            //}
            throw new NotImplementedException();
        }

        //public IEnumerable<Domain.Models.Engine> GetAllMoteurs()
        //{
        //    throw new NotImplementedException();
        //}

        public Task<bool> GetEngineByCode(int code)
        {
            throw new NotImplementedException();
        }

        //public Task<IList<IEngineDto>> GetEngineChangesAsync(int code)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task SetEngineChangesAsync(int code, IEngineDto updatedProductOffer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
