using System;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetCompanyDrive
{
	public class Delete
	{
        public class Command : IRequest
        {
            public string Id { get; set; } = string.Empty;
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
                await _repository.DeleteCompanyDrive(request.Id);
                return Unit.Value;
            }
        }
    }
}

