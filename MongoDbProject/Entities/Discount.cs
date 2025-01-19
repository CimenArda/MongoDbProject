using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string DiscountID { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
