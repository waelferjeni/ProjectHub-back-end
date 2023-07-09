using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<Sprint, SprintDTO>();
            CreateMap<SprintDTO, Sprint>();
        }
    }
}
