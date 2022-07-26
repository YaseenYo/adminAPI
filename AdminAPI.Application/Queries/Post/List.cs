using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetProfile
{
    public class List
    {
        public class Query : IRequest<IEnumerable<Profile>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<Profile>>
        {
            private readonly IProfileRepository _repository;

            public Handler(IProfileRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Profile>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
 }

