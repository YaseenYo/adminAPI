using System;
using AdminAPI.Domain.Entities;
using MongoDB.Driver;

namespace AdminAPI.Infrastructure.Services
{
    public class ProfileRepository : IProfileRepository
    {
        protected readonly IMongoCollection<Profile> _collection;

        public ProfileRepository(ICollegeDbSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Profile>(settings.ProfileCollectionName);
        }


        public async Task<Profile> GetProfileByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateProfileAsync(string id, Profile profile)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, profile);
        }

        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<Profile> AddAsync(Profile entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteProfile(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}

