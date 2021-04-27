using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Inside here we get the opportunity to create maps from one objet to another object
            CreateMap<Activity , Activity>();
        }
    }
}