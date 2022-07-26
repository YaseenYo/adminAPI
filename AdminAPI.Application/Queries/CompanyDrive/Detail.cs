using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetCompanyDrive
{
    public class Detail
    {   
        public class Query : IRequest<CompanyDrive>
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Query, CompanyDrive>
        {
            private readonly ICompanyDriveRepository _repository;

            public Handler(ICompanyDriveRepository repository)
            {
                _repository = repository;
            }

            public async Task<CompanyDrive> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetCompanyDriveByIdAsync(request.Id);
            }
        }
    }
}

