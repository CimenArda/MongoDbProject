

using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MongoDbProject.Entities
{
    public class ApplicationUser 
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ApplicationUserId { get; set; }  // MongoDB'de genellikle string ID kullanılır
        public string UserName { get; set; }
        public string Title { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        [BsonIgnore]
        public string Password { get; set; }

        /* Not: Password property’sini BsonIgnore attribute ile işaretliyoruz çünkü bu değer sadece formdan alınacak, veri tabanında saklanmayacak.*/ 
    }
}
