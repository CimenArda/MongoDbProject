﻿using MongoDbProject.Dtos.CategoryDtos;

namespace MongoDbProject.Dtos.ProductDtos
{
	public class ResultProductWithCategoryDto
	{
		public string ProductID { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductImageUrl { get; set; }
		public string CategoryID { get; set; }
		public ResultCategoryDto Category { get; set; }
	}
}
