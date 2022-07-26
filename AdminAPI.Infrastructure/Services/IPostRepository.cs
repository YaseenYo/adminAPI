using System;
using AdminAPI.Domain.Entities;

namespace AdminAPI.Infrastructure.Services
{
	public interface IPostRepository
	{
		Task<Post> GetPostByIdAsync(string id);
		Task UpdatePostAsync(string id, Post post);
		Task<Post> AddAsync(Post entity);
		Task<IEnumerable<Post>> GetAll();
		Task DeletePost(string id);
	}
}

