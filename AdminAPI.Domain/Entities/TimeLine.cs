using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdminAPI.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class TimeLine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string CompanyName { get; set; } = String.Empty;

        public double Package { get; set; }

        public string DriveDate { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;
    }
}

