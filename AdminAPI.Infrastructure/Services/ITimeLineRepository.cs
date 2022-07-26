using System;
using AdminAPI.Domain.Entities;

namespace AdminAPI.Infrastructure.Services
{
	public interface ITimeLineRepository
	{
		Task<TimeLine> GetTimeLineByIdAsync(string id);
		Task UpdateTimeLineAsync(string id, TimeLine TimeLine);
		Task<TimeLine> AddAsync(TimeLine entity);
		Task<IEnumerable<TimeLine>> GetAll();
		Task DeleteTimeLine(string id);
	}
}

