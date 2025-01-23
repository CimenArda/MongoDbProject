namespace MongoDbProject.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string FeatureCollectionName { get; set; }
        public string DiscountCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string SellingCollectionName { get; set; }
        public string UserCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
