using System;
using AdminAPI.Domain.Entities;
using MongoDB.Driver;

namespace AdminAPI.Infrastructure.Services
{
	public class TimeLineRepository : ITimeLineRepository
	{
        protected readonly IMongoCollection<TimeLine> _collection;

        public TimeLineRepository(ICollegeDbSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TimeLine>(settings.TimeLineCollectionName);
        }


        public async Task<TimeLine> GetTimeLineByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateTimeLineAsync(string id, TimeLine TimeLine)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, TimeLine);
        }

        public async Task<IEnumerable<TimeLine>> GetAll()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<TimeLine> AddAsync(TimeLine entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteTimeLine(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}

