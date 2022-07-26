using System;
namespace AdminAPI.Infrastructure
{
	public class CollegeDbSettings : ICollegeDbSettings
	{
        public string CompanyDriveCollectionName { get; set; } = String.Empty;

        public string ProfileCollectionName { get; set; } = String.Empty;

        public string PostCollectionName { get; set; } = String.Empty;

        public string TimeLineCollectionName { get; set; } = String.Empty;

        public string ConnectionString { get; set; } = String.Empty;

        public string DatabaseName { get; set; } = String.Empty;
    }
}

