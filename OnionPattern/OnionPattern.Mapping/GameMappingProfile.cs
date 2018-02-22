using AutoMapper;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Game.Requests;

namespace OnionPattern.Mapping
{
    public class GameMappingProfile : Profile
    {

        public GameMappingProfile()
        {
            CreateMap<CreateGameInput, Game>(MemberList.Source);
        }
    }
}
