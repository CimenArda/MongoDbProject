namespace MongoDbProject.Dtos.SellingDtos
{
    public class ResultSellingDto
    {
        public string SellingID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ProductID { get; set; }
        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
