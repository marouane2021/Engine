using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Engine.Domain.Models
{
    /// <summary>
    /// Class Engine
    /// </summary>
    [Serializable]
    public class MyEngine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public ObjectId Id { get; set; }

        /// <summary>
        /// the code of the engine
        /// </summary>
        [BsonElement("Code")]
        [JsonProperty("Code")]
        public int Code { get; set; }

        // <summary>
        /// the name of the engine
        /// </summary>
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// the engine is enable o not
        /// </summary>
        public bool IsEnable { get; set; }


        /// <summary>
        /// The search text for the engine
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// Gets or sets the last integration time.
        /// </summary>
        //DateTime LastUpdateDate { get; set; }
        ///// <summary>
        ///// Gets or sets the last change date.
        ///// </summary>
        //public DateTime LastChangeDate { get; set; }

        /// <summary>
        /// list of the scopes
        /// </summary>
        public IList<Scope> Scopes { get; set; }

        /// <summary>
        /// list of the input fileds
        /// </summary>
        public IList<InputField> InputFields { get; set; }
        /// <summary>
        /// list of the Parameters
        /// </summary>
        //public IList<Parameter> Parameters { get; set; }
        /// <summary>
        /// list of the background images
        /// </summary>
        public IList<BackGroundImage> BackGroundImages { get; set; }

        /// <summary>
        /// the logo of the engine
        /// </summary>
        public IList<Logo> Logo { get; set; }

        /// <summary>
        /// the marketing text for the engine
        /// </summary>
        public IList<MarketingText> MarketingText { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets the modifieAt.
        /// </summary>
        public DateTimeOffset? ModifiedAt { get; set; }
        public static MyEngine Create()
        {
            return new MyEngine();
        }
        
        
    }
}
