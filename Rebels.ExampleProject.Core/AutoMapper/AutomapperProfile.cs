using AutoMapper;
using Rebels.ExampleProject.Api.Dtos;
using Rebels.ExampleProject.Data.Entities;

namespace Rebels.ExampleProject.Core.AutoMapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Rebel, RebelDto>();
        CreateMap<RebelDto, Rebel>();
    }
}