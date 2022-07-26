using System;
using AutoMapper;

namespace AdminAPI.Application.mappings
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Domain.Entities.Profile, Domain.Entities.Profile>();
		}
	}
}

