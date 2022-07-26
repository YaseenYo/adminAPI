using System;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetPost
{
	public class Delete
	{
        public class Command : IRequest
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IPostRepository _repository;

            public Handler(IPostRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.DeletePost(request.Id);
                return Unit.Value;
            }
        }
    }
}

