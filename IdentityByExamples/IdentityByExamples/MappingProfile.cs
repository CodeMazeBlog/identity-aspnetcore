using AutoMapper;
using IdentityByExamples.Models;
using System.Security.Claims;

namespace IdentityByExamples
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<ExternalLoginModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(x => x.Principal.FindFirst(ClaimTypes.GivenName).Value))
                .ForMember(u => u.LastName, opt => opt.MapFrom(x => x.Principal.FindFirst(ClaimTypes.Surname).Value));
        }
    }
}
