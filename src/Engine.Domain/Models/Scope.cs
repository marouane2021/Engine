using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace Engine.Domain.Models
{
    public class Scope
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public ObjectId Id { get; set; }
        public int ScopeId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public string Url { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets the modifieAt.
        /// </summary>
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
