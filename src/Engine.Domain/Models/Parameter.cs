using MongoDB.Bson.Serialization.Attributes;

namespace Engine.Domain.Models
{
    public class Parameter
    {
        public int ScopeParameterId { get; set; }
        public int ExternalCodeId { get; set; }
        public int Order { get; set; }
        public string Label { get; set; }
    }
}
