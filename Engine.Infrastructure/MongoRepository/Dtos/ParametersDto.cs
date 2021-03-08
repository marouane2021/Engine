using Engine.Domain.Abstractions.Dtos;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.MongoRepository.Dtos
{
    public class ParametersDto :IParametersDto
    {/// <summary>
     /// Gets or sets the scope identifier.
     /// </summary>
     /// <value>
     /// The scope identifier.
     /// </value>
        [BsonElement("scopeParameterId")]
        public int scopeParameterId { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("externalCodeId")]
        public int externalCodeId { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("order")]
        public int order { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("label")]
        public string label { get; set; }
    }
}
