using System;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetProfile
{
	public class Delete
	{
        public class Command : IRequest
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IProfileRepository _repository;

            public Handler(IProfileRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.DeleteProfile(request.Id);
                return Unit.Value;
            }
        }
    }
}

