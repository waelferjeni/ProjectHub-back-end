using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using System.Net.Sockets;
using Task = Domain.Models.Task;

namespace Sprint_Task_Management.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
                CreateMap<Task, TaskDTO>();
                CreateMap<TaskDTO, Task>();
                CreateMap<UserStory, UserStoryDTO>();
                CreateMap<UserStoryDTO, UserStory>();
        }
    }
}
