using Engine.Domain.Abstractions.Dtos;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.MongoRepository.Dtos
{
   public class LogoDto : ILogoDto
    {
        [BsonElement("order")]
        public int order { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("urlImageDesktop")]
        public string urlImageDesktop { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("urlLinkDesktop")]
        public string urlLinkDesktop { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("urlImageMobile")]
        public string urlImageMobile { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("urlLinkMobile")]
        public string urlLinkMobile { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        [BsonElement("alt")]
        public string alt { get; set; }
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
        [BsonElement("openInNewTab")]
        public bool openInNewTab { get; set; }
    }
}
