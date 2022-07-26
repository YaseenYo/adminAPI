using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdminAPI.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        public string UserName { get; set; } = String.Empty;

        public string UsrImg { get; set; } = String.Empty;

        public string PostTime { get; set; } = String.Empty;

        public string Content { get; set; } = String.Empty;
    }
}

