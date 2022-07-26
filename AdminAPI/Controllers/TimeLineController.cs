using System;
using AdminAPI.Application.Queries.GetTimeLine;
using AdminAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.API.Controllers
{
    [Route("api/TimeLines")]
    [ApiController]
    public class TimeLineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimeLineController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeLine>>> Get()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeLine>> Get(string id)
        {
            var res = await _mediator.Send(new Detail.Query() { Id = id });

            if (res == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<TimeLine>> Post([FromBody] TimeLine TimeLine)
        {
            await _mediator.Send(new Create.Command() { TimeLine = TimeLine });

            return CreatedAtAction(nameof(Get), new { id = TimeLine.Id }, TimeLine);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] TimeLine TimeLine)
        {
            var exisitingTimeLine = await _mediator.Send(new Detail.Query() { Id = TimeLine.Id });
            if (exisitingTimeLine == null)
            {
                return NotFound($"TimeLine with Id = {id} not found");
            }
            await _mediator.Send(new Update.Command() { TimeLine = TimeLine });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var exisitingTimeLine = await _mediator.Send(new Detail.Query() { Id = id });
            if (exisitingTimeLine == null)
            {
                return NotFound($"TimeLine with Id = {id} not found");
            }
            await _mediator.Send(new Delete.Command() { Id = id });
            return Ok($"Student with id = {id} deleted");
        }
    }
}

