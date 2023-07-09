using AutoMapper;
using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SprintController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllSprints")]
        public async Task<IEnumerable<Sprint>> GetAllSprints()
        {

            return _mediator.Send(new GetListQuery<Sprint>(includes: i => i.Include(p => p.Project))).Result;


        }
        [HttpGet("GetSprintsByProjectId/{id}")]
        public async Task<IEnumerable<Sprint>> GetSprintsByProjectId(Guid id)
        {

            return _mediator.Send(new GetListQuery<Sprint>(condition:c=>c.projectId==id,includes: i => i.Include(p => p.Project))).Result;


        }

        [HttpGet("{id}")]
        public async Task<Sprint> GetSprintByID(Guid id)
        {
            var Sprint = await _mediator.Send(new GetQuery<Sprint>(condition: c => c.Id == id, includes: i => i.Include(p => p.Project)));
            return Sprint;
        }

        [HttpPost("PostSprint")]
        public async Task<Sprint> PostSprint(Sprint Sprint)
        {
            return await _mediator.Send(new PostCommandSpecifique<Sprint>(Sprint));
        }

        [HttpPut("PutSprint")]
        public async Task<Sprint> PutTask(Sprint Sprint)
        {
            return await _mediator.Send(new PutCommandSpecifique<Sprint>(Sprint));
        }

        [HttpDelete("DeleteSprint/{id}")]
        public async Task<string> DeleteSprint([FromRoute] Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Sprint>(id));
        }
    }
}
