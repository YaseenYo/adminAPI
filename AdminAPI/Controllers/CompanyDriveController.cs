using AdminAPI.Application.Queries.GetCompanyDrive;
using AdminAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.API.Controllers
{
    [Route("api/CompanyDrives")]
    [ApiController]
    public class CompanyDriveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyDriveController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDrive>>> Get()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDrive>> Get(string id)
        {
            var res = await _mediator.Send(new Detail.Query() { Id = id });

            if (res == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDrive>> Post([FromBody] CompanyDrive CompanyDrive)
        {
            await _mediator.Send(new Create.Command() { CompanyDrive = CompanyDrive });

            return CreatedAtAction(nameof(Get), new { id = CompanyDrive.Id }, CompanyDrive);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] CompanyDrive CompanyDrive)
        {
            var exisitingCompanyDrive = await _mediator.Send(new Detail.Query() { Id = CompanyDrive.Id });
            if (exisitingCompanyDrive == null)
            {
                return NotFound($"CompanyDrive with Id = {id} not found");
            }
            await _mediator.Send(new Update.Command() { CompanyDrive = CompanyDrive });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var exisitingCompanyDrive = await _mediator.Send(new Detail.Query() { Id = id });
            if (exisitingCompanyDrive == null)
            {
                return NotFound($"CompanyDrive with Id = {id} not found");
            }
            await _mediator.Send(new Delete.Command() { Id = id });
            return Ok($"Student with id = {id} deleted");
        }
    }
}

