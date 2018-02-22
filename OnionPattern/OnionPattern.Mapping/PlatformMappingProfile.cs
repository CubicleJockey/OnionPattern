using AutoMapper;
using OnionPattern.Domain.Platform.Entities;
using OnionPattern.Domain.Platform.Requests;

namespace OnionPattern.Mapping
{
    public class PlatformMappingProfile : Profile
    {
        public PlatformMappingProfile()
        {
            CreateMap<CreatePlatformInput, Platform>(MemberList.Source);
        }
    }
}
