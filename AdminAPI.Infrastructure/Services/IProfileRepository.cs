using System;
using AdminAPI.Domain.Entities;

namespace AdminAPI.Infrastructure.Services
{
	public interface IProfileRepository
	{
		Task<Profile> GetProfileByIdAsync(string id);
		Task UpdateProfileAsync(string id, Profile profile);
		Task<Profile> AddAsync(Profile entity);
		Task<IEnumerable<Profile>> GetAll();
		Task DeleteProfile(string id);
	}
}

