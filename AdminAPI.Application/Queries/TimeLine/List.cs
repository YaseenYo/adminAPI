using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetTimeLine
{
    public class List
    {
        public class Query : IRequest<IEnumerable<TimeLine>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<TimeLine>>
        {
            private readonly ITimeLineRepository _repository;

            public Handler(ITimeLineRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<TimeLine>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
 }

