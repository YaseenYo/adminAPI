using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetTimeLine
{
	public class Update
	{
        public class Command : IRequest
        {
            public TimeLine? TimeLine { get; set; }
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
                await _repository.UpdateTimeLineAsync(request.TimeLine.Id, request.TimeLine);

                return Unit.Value;
            }
        }
    }
}

