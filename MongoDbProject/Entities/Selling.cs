using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Entities
{
    public class Selling
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string SellingID { get; set; }

        public DateTime CreatedDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductID { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }

        public string ProductImageUrl { get; set; }
        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
