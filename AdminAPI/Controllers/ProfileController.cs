using System;
using System.Collections.Generic;
using AdminAPI.Application.Queries.GetProfile;
using AdminAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.API.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> Get()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> Get(string id)
        {
            var res = await _mediator.Send(new Detail.Query() { Id = id });

            if (res == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> Post([FromBody] Profile profile)
        {
            await _mediator.Send(new Create.Command() { Profile = profile });

            return CreatedAtAction(nameof(Get), new { id = profile.Id }, profile);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Profile profile)
        {
            var exisitingProfile = await _mediator.Send(new Detail.Query() { Id = profile.Id});
            if (exisitingProfile == null)
            {
                return NotFound($"Profile with Id = {id} not found");
            }
            await _mediator.Send(new Update.Command() { Profile = profile });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var exisitingProfile = await _mediator.Send(new Detail.Query() { Id = id });
            if (exisitingProfile == null)
            {
                return NotFound($"Profile with Id = {id} not found");
            }
            await _mediator.Send(new Delete.Command() { Id = id });
            return Ok($"Student with id = {id} deleted");
        }
    }

}