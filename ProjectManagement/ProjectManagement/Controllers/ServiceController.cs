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
    public class ServiceController
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ServiceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllServices")]
        public async Task<IEnumerable<Service>> GetAllServices()
        {

            //return _mediator.Send(new GetListQuery<Service>(includes: i => i.Include(sp => sp.Sprints))).Result;

            return _mediator.Send(new GetListQuery<Service>(null, null))
                      .Result;
        }

        //[HttpGet("{id}")]
        //public async Task<ServiceDTO> GetProjectByID(Guid id)
        //{
        //    var Project = await _mediator.Send(new GetQuery<Project>(condition: c => c.Id == id, includes: i => i.Include(s => s.Sprints)));
        //    return _mapper.Map<ProjectDTO>(Project);
        //}

        [HttpPost("PostService")]
        public async Task<Service> PostService(Service service)
        {
            return await _mediator.Send(new PostCommandSpecifique<Service>(service));
        }


        //[HttpPut("PutService")]
        //public async Task<Service> PutService(Service service )
        //{
        //    return await _mediator.Send(new PutCommandSpecifique<Service>(service));
        //}

        [HttpGet("{id}")]
        public async Task<Service> GetServiceByID(Guid id)
        {
            var service = await _mediator.Send(new GetQuery<Service>(condition: c => c.Id == id));
            return service;
        }

        [HttpPut("PutService")]
        public async Task<string> PutService(Service service)
        {
            return await _mediator.Send(new PutCommand<Service>(service));
        }

        

        //[HttpPut("PutSprint")]
        //public async Task<Service> PutTask(Service service)
        //{
        //    return await _mediator.Send(new PutCommandSpecifique<Service>(service));
        //}

        //[HttpDelete("DeleteService")]
        //public async Task<string> DeleteService(Guid id)
        //{
        //    return await _mediator.Send(new DeleteCommand<Service>(id));
        //}

        [HttpDelete("DeleteService/{id}")]
        public async Task<string> DeleteService([FromRoute] Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Service>(id));
        }
    }
}
