using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetPost
{
    public class List
    {
        public class Query : IRequest<IEnumerable<Post>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<Post>>
        {
            private readonly IPostRepository _repository;

            public Handler(IPostRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Post>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
 }

