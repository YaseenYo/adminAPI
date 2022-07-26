using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdminAPI.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Profile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public string Img { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public Int64 Phone { get; set; }
    }
}

