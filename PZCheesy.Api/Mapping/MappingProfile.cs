using AutoMapper;
using PZCheesy.Api.Resources;
using PZCheesy.Core.Models;

namespace PZCheesy.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Cheese, CheeseResource>();
            
            // Resource to Domain
            CreateMap<CheeseResource, Cheese>();

        }
    }
}