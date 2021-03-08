using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Engine.Domain.Models.BIS
{
    /// <summary>
    /// Class Engine
    /// </summary>
    /// 
    [Serializable]

    public class Engine
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        /// <summary>
        /// the code of the engine
        /// </summary>
        [BsonElement("Code")]
        [JsonProperty("Code")]
        public int Code { get; set; }
        /// <summary>
        /// the engine is enable o not
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// the name of the engine
        /// </summary>
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }
        /// <summary>
        /// The search text for the engine
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// list of the scopes
        /// </summary>
        public IList<Scope> Scopes { get; set; }

        /// <summary>
        /// list of the input fileds
        /// </summary>
        public IList<InputField> InputFields { get; set; }
        /// <summary>
        /// list of the background images
        /// </summary>
        public IList<BackGroundImage> BackGroundImages { get; set; }

        /// <summary>
        /// the logo of the engine
        /// </summary>
        public Logo Logo { get; set; }

        /// <summary>
        /// the marketing text for the engine
        /// </summary>
        public MarketingText MarketingText { get; set; }
    }
}
