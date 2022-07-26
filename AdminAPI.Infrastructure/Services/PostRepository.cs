using System;
using AdminAPI.Domain.Entities;
using MongoDB.Driver;

namespace AdminAPI.Infrastructure.Services
{
	public class PostRepository : IPostRepository
	{
        protected readonly IMongoCollection<Post> _collection;

        public PostRepository(ICollegeDbSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Post>(settings.PostCollectionName);
        }


        public async Task<Post> GetPostByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdatePostAsync(string id, Post Post)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, Post);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<Post> AddAsync(Post entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeletePost(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}

