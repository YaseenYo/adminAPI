using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetTimeLine
{
    public class Detail
    {   
        public class Query : IRequest<TimeLine>
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Query, TimeLine>
        {
            private readonly ITimeLineRepository _repository;

            public Handler(ITimeLineRepository repository)
            {
                _repository = repository;
            }

            public async Task<TimeLine> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetTimeLineByIdAsync(request.Id);
            }
        }
    }
}

