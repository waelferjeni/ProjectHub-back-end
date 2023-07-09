using AutoMapper;
using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sprint_Task_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoryController
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserStoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllUserStories")]
        public async Task<IEnumerable<UserStory>> GetAllUserStories()
        {

            return _mediator.Send(new GetListQuery<UserStory>(includes: i => i.Include(lt => lt.Tasks))).Result;
        }
        [HttpGet("GetUserStoriesByProjectId/{id}")]
        public async Task<IEnumerable<UserStory>> GetUserStoriesByProjectId(Guid id)
        {

            return _mediator.Send(new GetListQuery<UserStory>(condition: c => c.ProjectId == id,includes: i => i.Include(lt => lt.Tasks))).Result;


        }
        [HttpGet("{id}")]
        public async Task<UserStory> GetUserStoryByID(Guid id)
        {
            var userStory = await _mediator.Send(new GetQuery<UserStory>(condition: c => c.Id == id, includes: i => i.Include(lt => lt.Tasks)));
            return userStory;
        }

        [HttpPost("PostUserStory")]
        public async Task<string> PostSprint(UserStoryDTO UserStorydto)
        {
            var UserStory = _mapper.Map<UserStory>(UserStorydto);
            return await _mediator.Send(new PostCommand<UserStory>(UserStory));
        }
        [HttpPost("PostSpecUserStory")]
        public async Task<UserStory> PostSpecUserStory(UserStory UserStory)
        {
           // var UserStory = _mapper.Map<UserStory>(UserStorydto);
            return await _mediator.Send(new PostCommandSpecifique<UserStory>(UserStory));
        }
        [HttpPut("PutUserStory")]
        public async Task<UserStory> PutSprint(UserStory UserStory)
        {
            return await _mediator.Send(new PutCommandSpecifique<UserStory>(UserStory));
        }

        [HttpDelete("DeleteUserStory/{id}")]
        public async Task<string> DeleteSprint([FromRoute] Guid id)
        {
            return await _mediator.Send(new DeleteCommand<UserStory>(id));
        }
    }
}
