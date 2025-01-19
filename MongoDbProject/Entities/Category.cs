﻿using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
