using System;
using AdminAPI.Domain.Entities;
using MongoDB.Driver;

namespace AdminAPI.Infrastructure.Services
{
	public class CompanyDriveRepository : ICompanyDriveRepository
	{
        protected readonly IMongoCollection<CompanyDrive> _collection;

        public CompanyDriveRepository(ICollegeDbSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<CompanyDrive>(settings.CompanyDriveCollectionName);
        }


        public async Task<CompanyDrive> GetCompanyDriveByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCompanyDriveAsync(string id, CompanyDrive CompanyDrive)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, CompanyDrive);
        }

        public async Task<IEnumerable<CompanyDrive>> GetAll()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<CompanyDrive> AddAsync(CompanyDrive entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteCompanyDrive(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}

