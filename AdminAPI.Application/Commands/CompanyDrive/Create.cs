using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetCompanyDrive
{
	public class Create
	{
        public class Command : IRequest
        {
            public CompanyDrive? CompanyDrive { get; set; } 
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICompanyDriveRepository _repository;

            public Handler(ICompanyDriveRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.AddAsync(request.CompanyDrive);

                return Unit.Value;
            }
        }
    }
}

