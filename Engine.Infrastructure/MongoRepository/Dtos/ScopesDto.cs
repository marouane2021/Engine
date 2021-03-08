using Engine.Domain.Abstractions.Dtos;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.MongoRepository.Dtos
{
    public class ScopesDto : IScopesDto
    {
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("name")]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("scopeId")]
        public int scopeId { get; set; }

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
        [BsonElement("order")]
        public bool order { get; set; }

        internal static IScopesDto Create()
        {
            return new ScopesDto();
        }

        public IScopesDto WithScopes(ScopesDto offer)
        {
            if (offer != null)
            {
                name = offer.name;
                isEnable = offer.isEnable;
                order = offer.order;
                scopeId = offer.scopeId;
            }
            return this;
        }
    }
}
