using MongoDB.Driver;
using Microsoft.Extensions.Options;
using UserManagementApis.Models;

namespace UserManagementApis.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserDetails> _userCollection;
        public UserService(IOptions<UserDatabaseSettings> userDatabaseSettings)
        {
            var mongoClient = new MongoClient(userDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<UserDetails>(userDatabaseSettings.Value.UserCollectionName);
        }

        public async Task<List<UserDetails>> GetUserDetails() => await _userCollection.Find(_ => true).ToListAsync();
        public async Task<UserDetails?> GetUserDetailsById(int id) => await _userCollection.Find(x => x.id == id).FirstOrDefaultAsync();
        public async Task CreateUser(UserDetails userDetails) => await _userCollection.InsertOneAsync(userDetails);
        public async Task UpdateUser(UserDetails userDetails, int id) => await _userCollection.ReplaceOneAsync(x => x.id == id, userDetails);
        public async Task DeleteUser(int id) => await _userCollection.DeleteOneAsync(x => x.id == id);
    }
}
