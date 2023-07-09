using AutoMapper;
using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TeamController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllTeams")]
        public async Task<IEnumerable<TeamDTO>> GetAllTeams()
        {

            return _mediator.Send(new GetListQuery<Team>()).Result.Select(phase => _mapper.Map<TeamDTO>(phase));
        }

        [HttpGet("{id}")]
        public async Task<TeamDTO> GetTeamByID(Guid id)
        {
            var team = await _mediator.Send(new GetQuery<Team>(condition: c => c.Id == id));
            return _mapper.Map<TeamDTO>(team);
        }

        [HttpPost("PostTeam")]
        public async Task<Team> PostTeam(Team team)
        {
            return await _mediator.Send(new PostCommandSpecifique <Team>(team));
        }

        [HttpPut("PutTeam")]
        public async Task<Team> PutTeam(Team team)
        {
            return await _mediator.Send(new PutCommandSpecifique<Team>(team));
        }

        [HttpDelete("DeleteTeam/{id}")]
        public async Task<string> DeleteTeam([FromRoute]Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Team>(id));
        }
    }
}
