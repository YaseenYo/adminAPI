using System;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetTimeLine
{
	public class Delete
	{
        public class Command : IRequest
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ITimeLineRepository _repository;

            public Handler(ITimeLineRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.DeleteTimeLine(request.Id);
                return Unit.Value;
            }
        }
    }
}

