using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetProfile
{
	public class Update
	{
        public class Command : IRequest
        {
            public Profile? Profile { get; set; }
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
                await _repository.UpdateProfileAsync(request.Profile.Id, request.Profile);

                return Unit.Value;
            }
        }
    }
}

