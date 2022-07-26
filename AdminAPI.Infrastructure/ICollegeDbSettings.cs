using System;
namespace AdminAPI.Infrastructure
{
	public interface ICollegeDbSettings
	{
        string CompanyDriveCollectionName { get; set; }
        string ProfileCollectionName { get; set; }
        string PostCollectionName { get; set; }
        string TimeLineCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

