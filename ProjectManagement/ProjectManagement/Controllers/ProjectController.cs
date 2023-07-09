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
    public class ProjectController : ControllerBase
    {
            public readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public ProjectController(IMediator mediator, IMapper mapper)
            {
                _mediator = mediator;
                _mapper = mapper;
            }
            //[HttpGet("GetAllProjects")]
            //public async Task<IEnumerable<Project>> GetAllProjects()
            //{

            //    return _mediator.Send(new GetListQuery<Project>(includes: i => i.Include(sp => sp.Sprints))).Result;
            //}

            [HttpGet("GetAllProjects")]

            public async Task<IEnumerable<Project>> GetAllProjects()
            {
                return _mediator.Send(new GetListQuery<Project>(null, includes: i => i.Include(s => s.Service).Include(sp =>sp.Sprints)))
                     .Result;
            }



        [HttpGet("{id}")]
            public async Task<ProjectDTO> GetProjectByID(Guid id)
            {
                var Project = await _mediator.Send(new GetQuery<Project>(condition: c => c.Id == id, includes: i => i.Include(s => s.Sprints)));
                return _mapper.Map<ProjectDTO>(Project);
            }

            //[HttpPost("PostProject")]
            //public async Task<string> PostProject(ProjectDTO Projectdto)
            //{
            //    var Project = _mapper.Map<Project>(Projectdto);
            //    return await _mediator.Send(new PostCommand<Project>(Project));
            //}

            //[HttpPost("PostProject")]
            //public async Task<ProjectDTO> PostProject(Project project)
            //{
            //    var res = await _mediator.Send(new PostCommandSpecifique<Project>(project));

            //    return _mapper.Map<ProjectDTO>(res);
            //}

            [HttpPost("PostProject")]
            public async Task<Project> PostProject(Project project )
            {
                return await _mediator.Send(new PostCommandSpecifique<Project>(project));
            }

            //[HttpPut("PutProject")]
            //public async Task<Project> PutProject(Project Project)
            //{
            //    return await _mediator.Send(new PutCommandSpecifique<Project>(Project));
            //}

            [HttpPut("PutProject")]
            public async Task<string> PutProject(Project project)
            {
                return await _mediator.Send(new PutCommand<Project>(project));
            }

        [HttpDelete("DeleteProject/{id}")]
            public async Task<string> DeleteProject(Guid id)
            {
                return await _mediator.Send(new DeleteCommand<Project>(id));
            }
        }
}
