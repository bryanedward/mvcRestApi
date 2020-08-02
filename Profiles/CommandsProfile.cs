using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommadReadDto>();
            CreateMap<CommandsCreateDto, Command>();
            CreateMap<CommandsUpdateDto, Command>();
            CreateMap<Command, CommandsUpdateDto>();
        }
    }
}