using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FuealApplication.Models
{
    [BsonIgnoreExtraElements]
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Owner Name")]
        public string OwnerName { get; set; } = string.Empty;

        [BsonElement("User Name")]
        public string UserName { get; set; } = string.Empty;

        [BsonElement("Password")]
        public string Passwod { get; set; } = string.Empty;

        [BsonElement("Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;
    }
}
