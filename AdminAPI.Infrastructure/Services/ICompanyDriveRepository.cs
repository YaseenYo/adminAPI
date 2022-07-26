using System;
using AdminAPI.Domain.Entities;

namespace AdminAPI.Infrastructure.Services
{
	public interface ICompanyDriveRepository
	{
		Task<CompanyDrive> GetCompanyDriveByIdAsync(string id);
		Task UpdateCompanyDriveAsync(string id, CompanyDrive drive);
		Task<CompanyDrive> AddAsync(CompanyDrive entity);
		Task<IEnumerable<CompanyDrive>> GetAll();
		Task DeleteCompanyDrive(string id);
	}
}

