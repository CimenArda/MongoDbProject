﻿namespace MongoDbProject.Dtos.SellingDtos
{
    public class CreateSellingDto
    {
        public DateTime CreatedDate { get; set; }

        public string ProductID { get; set; }
        public int Count { get; set; }

        public decimal Price { get; set; }
        public string ProductImageUrl { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
