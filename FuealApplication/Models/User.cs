using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FuealApplication.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("User Name")]
        public string UserName { get; set; } = string.Empty;

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("Password")]
        public string Passwod { get; set; } = string.Empty;

        [BsonElement("Vehicle Type")]
        public string VehicleType { get; set; } = string.Empty;
    }
}
