
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FuealApplication.Models
{
    public class Station
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Station Name")]
        public string StationName { get; set; } = string.Empty;

        [BsonElement("Location")]
        public string Location { get; set; } = string.Empty;

        [BsonElement("Contact Number")]
        public string ContactNumber { get; set; }   = string.Empty;
    }
}
