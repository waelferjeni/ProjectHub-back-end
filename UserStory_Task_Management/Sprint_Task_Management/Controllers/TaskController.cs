using AutoMapper;
using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Task = Domain.Models.Task;



namespace Sprint_Task_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TaskController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllTasks")]
        public async Task<IEnumerable<Task>> GetAllTasks()
        {

            return _mediator.Send(new GetListQuery<Task>(includes: i => i.Include(s => s.UserStory))).Result;
        }
        [HttpGet("GetTasksByUserStoryId/{id}")]
        public async Task<IEnumerable<Task>> GetTasksByUserStoryId(Guid id)
        {

            return _mediator.Send(new GetListQuery<Task>(condition: c => c.userStoryId == id)).Result;


        }
        [HttpGet("{id}")]
        public async Task<TaskDTO> GetTaskByID(Guid id)
        {
            var task = await _mediator.Send(new GetQuery<Task>(condition: c => c.Id == id, includes: i => i.Include(s => s.UserStory)));
            return _mapper.Map<TaskDTO>(task);
        }

        [HttpPost("PostTask")]
        public async Task<Task> PostTask(Task task)
        {
            return await _mediator.Send(new PostCommandSpecifique<Task>(task));
        }

        [HttpPut("PutTask")]
        public async Task<Task> PutTask(Task task)
        {
            return await _mediator.Send(new PutCommandSpecifique<Task>(task));
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<string> DeleteSprint([FromRoute] Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Task>(id));
        }
    }
}
