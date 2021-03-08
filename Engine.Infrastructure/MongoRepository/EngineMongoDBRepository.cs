using Engine.Infrastructure.MongoRepository.Dtos;
using Engine.Domain.Abstractions.Dtos;
using Engine.Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engine.Domain.Models;

namespace Engine.Infrastructure.MongoRepository
{
    public class EngineMongoDBRepository : MongoClientFactory, IEngineRepository
    {
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        private IMongoCollection<EngineDto> _collection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineMongoDBRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        public EngineMongoDBRepository(ILogger<MongoClientFactory> logger, IConfiguration configuration, IMongoCollection<EngineDto> collection)
            : base(logger, configuration)
        {
            _collection = _database.GetCollection<EngineDto>(Constants.CompetingOffersCollection);
        }
        //public CompetingOfferChangesMongoDBRepository(ILogger<MongoClientFactory> logger, IConfiguration configuration,
        //   IMongoCollection<EngineDto> collection)
        //   : base(logger, configuration)
        //{
        //    _collection = collection;
        //}

        //public IEnumerable<Domain.Models.EngineDto> GetAllMoteurs()
        //{
        //    throw new NotImplementedException();
        //}

        public  Task<int> CreateMoteur(Domain.Models.Engine moteur)
        {
            var engineDto = new EngineDto
            {
                code = moteur.code,
                name = moteur.Name,
                isEnable = moteur.isEnable,
                searchText = moteur.searchText,
                scopes = (IScopesDto)moteur.Scopes,
                Input = (IInputDto)moteur.inputFields,
                Logo = (ILogoDto)moteur.logo,
                Background = (IBackgroundDto)moteur.backgroundImages,
                MarketingText = (IMarketingDto)moteur.marketingText,


            };
            //_collection.FindAsync()
             _collection.InsertOne(engineDto);

            return Task.FromResult(Convert.ToInt32(engineDto.Id));
        }

        //public Task<IList<IEngineDto>> GetEngineChangesAsync(int code)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task SetEngineChangesAsync(int code, IEngineDto updatedProductOffer)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> GetEngineByCode(int code)
        {
            var result = await _collection.FindAsync(x => x.code == code);
            ;
            return result.Any();
        }
    }
}
