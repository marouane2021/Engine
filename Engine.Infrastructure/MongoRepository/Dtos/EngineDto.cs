using Engine.Domain.Abstractions.Dtos;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Engine.Infrastructure.MongoRepository.Dtos
{
    public class EngineDto : IEngineDto
    {
       [BsonId]
       public int Id { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("Name")]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("code ")]
        public int code { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("isEnable")]
        public bool isEnable { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("searchText")]
        public string searchText { get; set; }
        /// <summary>
        /// Gets the list of all Employees.
        /// </summary>
        /// <returns>The list of Employees.</returns>
        // GET: api/Input
        [BsonElement("Scopes")]
        public IScopesDto scopes { get; set; }
        IScopesDto IEngineDto.Scopes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        [BsonElement("Input")]
        public IInputDto Input { get; set; }
        IInputDto IEngineDto.Input { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        [BsonElement("Logo")]

        public ILogoDto Logo { get; set; }
        ILogoDto IEngineDto.Logo { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        [BsonElement("Background")]
        public IBackgroundDto Background { get; set; }
        IBackgroundDto IEngineDto.Background { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        [BsonElement("MarketingText")]
        public  IMarketingDto MarketingText { get; set; }
        IMarketingDto IEngineDto.MarketingText { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
