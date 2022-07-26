using System;
using AdminAPI.Application.Queries.GetPost;
using AdminAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.API.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(string id)
        {
            var res = await _mediator.Send(new Detail.Query() { Id = id });

            if (res == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Post([FromBody] Post Post)
        {
            await _mediator.Send(new Create.Command() { Post = Post });

            return CreatedAtAction(nameof(Get), new { id = Post.Id }, Post);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Post Post)
        {
            var exisitingPost = await _mediator.Send(new Detail.Query() { Id = Post.Id });
            if (exisitingPost == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }
            await _mediator.Send(new Update.Command() { Post = Post });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var exisitingPost = await _mediator.Send(new Detail.Query() { Id = id });
            if (exisitingPost == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }
            await _mediator.Send(new Delete.Command() { Id = id });
            return Ok($"Student with id = {id} deleted");
        }
    }
}

