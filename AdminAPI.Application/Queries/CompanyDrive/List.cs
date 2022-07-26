using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetCompanyDrive
{
    public class List
    {
        public class Query : IRequest<IEnumerable<CompanyDrive>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<CompanyDrive>>
        {
            private readonly ICompanyDriveRepository _repository;

            public Handler(ICompanyDriveRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<CompanyDrive>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
 }

