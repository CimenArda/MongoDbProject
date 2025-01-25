using AutoMapper;
using Microsoft.CodeAnalysis.Scripting;
using MongoDB.Driver;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<ApplicationUser> _userCollection;

        public UserService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _userCollection = database.GetCollection<ApplicationUser>(_databaseSettings.UserCollectionName);
        }
        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _userCollection.Find(user => user.ApplicationUserId == userId).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
        {
            return await _userCollection.Find(user => user.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password)
        {
            // Parola hashleme işlemi
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            await _userCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }

		public async Task<ApplicationUser> UpdateUserAsync(string userId, ApplicationUser updatedUser)
		{
			var filter = Builders<ApplicationUser>.Filter.Eq(user => user.ApplicationUserId, userId);
			var update = Builders<ApplicationUser>.Update
				.Set(user => user.UserName, updatedUser.UserName)
				.Set(user => user.Email, updatedUser.Email)
				.Set(user => user.FullName, updatedUser.FullName)
				.Set(user => user.Title, updatedUser.Title)
				.Set(user => user.Description, updatedUser.Description)
				.Set(user => user.Address, updatedUser.Address)
				.Set(user => user.ProfilePictureUrl, updatedUser.ProfilePictureUrl);

			var result = await _userCollection.UpdateOneAsync(filter, update);

			if (result.MatchedCount == 0)
			{
				return null; // Kullanıcı bulunamadı
			}

			return await GetUserByIdAsync(userId); // Güncellenmiş kullanıcı bilgilerini döndür
		}

	}
}
