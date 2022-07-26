using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetPost
{
	public class Update
	{
        public class Command : IRequest
        {
            public Post? Post { get; set; }
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
                await _repository.UpdatePostAsync(request.Post.Id, request.Post);

                return Unit.Value;
            }
        }
    }
}

