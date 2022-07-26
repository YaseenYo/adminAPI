using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetProfile
{
    public class Detail
    {   
        public class Query : IRequest<Profile>
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Query, Profile>
        {
            private readonly IProfileRepository _repository;

            public Handler(IProfileRepository repository)
            {
                _repository = repository;
            }

            public async Task<Profile> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetProfileByIdAsync(request.Id);
            }
        }
    }
}

