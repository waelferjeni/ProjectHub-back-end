using AutoMapper;
using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamUserController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TeamUserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllTeamUsers")]
        public async Task<IEnumerable<TeamUserDTO>> GetAllTeamUser()
        {

            return _mediator.Send(new GetListQuery<TeamUser>()).Result.Select(phase => _mapper.Map<TeamUserDTO>(phase));
        }

        [HttpGet("GetTeamUsersByTeamID")]
        public async Task<IEnumerable<TeamUserDTO>> GetTeamUsersByTeamID(Guid Teamid)
        {
            return _mediator.Send(new GetListQuery<TeamUser>(condition: c => c.TeamId == Teamid)).Result
                .Select(teamuser => _mapper.Map<TeamUserDTO>(teamuser));
        }
        [HttpGet("GetTeamUsersByUserID")]
        public async Task<IEnumerable<TeamUserDTO>> GetTeamUsersByUserID(Guid userId)
        {
            return _mediator.Send(new GetListQuery<TeamUser>(condition: c => c.UserId == userId)).Result
                .Select(teamuser => _mapper.Map<TeamUserDTO>(teamuser));
        }
        [HttpGet("GetProjectLeader")]
        public async Task<TeamUserDTO> GetProjectLeader(Guid Teamid)
        {
            Role UserRole=Role.ProjectLeader;
            var teamuser = await _mediator.Send(new GetQuery<TeamUser>(condition: c => c.TeamId == Teamid && c.UserRole == UserRole));
            return _mapper.Map<TeamUserDTO>(teamuser);
        }
        [HttpGet("GetEmployees")]
        public async Task<IEnumerable<TeamUserDTO>> GetEmployees(Guid Teamid)
        {
            Role UserRole = Role.Employee;
            return _mediator.Send(new GetListQuery<TeamUser>(condition: c => c.TeamId == Teamid && c.UserRole == UserRole)).Result
             .Select(teamuser=>_mapper.Map<TeamUserDTO>(teamuser));
        }

        [HttpPost("PostTeamUser")]
        public async Task<TeamUser> PostTeamUser(TeamUser teamuser)
        {
            return await _mediator.Send(new PostCommandSpecifique<TeamUser>(teamuser));
        }

        [HttpPut("PutTeamUser")]
        public async Task<TeamUser> PutTeamUser(TeamUser teamuser)
        {
            return await _mediator.Send(new PutCommandSpecifique<TeamUser>(teamuser));
        }

        [HttpDelete("DeleteTeamUser")]
        public async Task<string> DeleteTeamUser(TeamUser teamUser)
        {
            return await _mediator.Send(new DeleteEntitieCommand<TeamUser>(teamUser));
        }
    }
}
