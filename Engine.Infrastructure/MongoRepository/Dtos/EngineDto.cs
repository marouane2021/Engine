using Engine.Domain.Abstractions.Dtos;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace Engine.Infrastructure.MongoRepository.Dtos
{
    public class EngineDto : IEngineDto
    {
        [BsonId]
        public ObjectId Id { get; set; }
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
        [BsonElement("SearchText")]
        public string searchText { get; set; }
        /// <summary>
        /// Gets the list of all Employees.
        /// </summary>
        /// <returns>The list of Employees.</returns>
        // GET: api/Input
        [BsonElement("Scopes")]
        [BsonSerializer(typeof(ImpliedImplementationInterfaceSerializer<IScopesDto, ScopesDto>))]
        public IScopesDto Scopes { get; set; }
        [BsonElement("InputFields")]
        public IInputDto InputFields { get; set; }
        [BsonElement("Logo")]
        public ILogoDto Logo { get; set; }
        [BsonElement("BackgroundImages")]
        public IBackgroundDto BackGroundImages { get; set; }
        [BsonElement("MarketingText")]
        public IMarketingDto MarketingText { get; set; }

        internal static IEngineDto Create()
        {
            return new EngineDto();
        }

        public IEngineDto WithInfoDto(EngineDto offer)
        {
            if (offer != null)
            {
                name = offer.name;
                code = offer.code;
                searchText = offer.searchText;
                isEnable = offer.isEnable;
            }
            return this;
        }

        public IEngineDto WithScopes(ScopesDto scope)
        {
            var scop = ScopesDto.Create();
            
            return this;
        }
    }
}
