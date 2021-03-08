using Engine.Domain.Abstractions.Dtos;
using MongoDB.Bson.Serialization.Attributes;

namespace Engine.Infrastructure.MongoRepository.Dtos
{
    public class MarketingDto : IMarketingDto
    {
        [BsonElement("isEnable")]
        public string text { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("isEnable")]
        public bool isEnable { get; set; }
    }
}
