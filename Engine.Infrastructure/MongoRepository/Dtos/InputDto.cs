using Engine.Domain.Abstractions.Dtos;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.MongoRepository.Dtos
{
    public class InputDto : IInputDto
    {
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        [BsonElement("id")]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("type")]
        public string type { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        ///
        [BsonElement("label")]
        public string label { get; set; }
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
        [BsonElement("isMandatory")]
        public bool isMandatory { get; set; }

        [BsonElement("Parameters")]
        public IParametersDto Parameters { get; set; }
    }
}
