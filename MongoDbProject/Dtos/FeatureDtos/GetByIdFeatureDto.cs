﻿namespace MongoDbProject.Dtos.FeatureDtos
{
    public class GetByIdFeatureDto
    {
        public string FeatureID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
