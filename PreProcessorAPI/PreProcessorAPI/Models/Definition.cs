using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PreProcessorAPI.Models
{
    public class Definition
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TargetVal")]
        public string Target { get; set; }

        [BsonElement("ReplaceVal")]
        public decimal Replace { get; set; }
    }
}
