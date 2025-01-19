using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Entities
{
    public class Selling
    {
        public string SellingID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ProductID { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
