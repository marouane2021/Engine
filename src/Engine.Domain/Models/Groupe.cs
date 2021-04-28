using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Engine.Domain.Models
{
    public class Groupe
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public ObjectId Id { get; set; }
        /// <summary>
        /// Gets or Sets the code.
        /// </summary>
        public int GroupId{ get; set; }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or Sets the isEnable.
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// Gets or Sets the code.
        /// </summary>
        public IEnumerable<MyEngine> Engines { get; set; }

        /// <summary>
        /// Gets or Sets the createAt.
        /// </summary>
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets the modifieAt.
        /// </summary>
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
