using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace TeamManagement.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();
            CreateMap<TeamUser, TeamUserDTO>();
            CreateMap<TeamUserDTO, TeamUser>();
        }
    }
}
