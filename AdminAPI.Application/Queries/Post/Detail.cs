using System;
using AdminAPI.Domain.Entities;
using AdminAPI.Infrastructure.Services;
using MediatR;

namespace AdminAPI.Application.Queries.GetPost
{
    public class Detail
    {   
        public class Query : IRequest<Post>
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Query, Post>
        {
            private readonly IPostRepository _repository;

            public Handler(IPostRepository repository)
            {
                _repository = repository;
            }

            public async Task<Post> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetPostByIdAsync(request.Id);
            }
        }
    }
}

