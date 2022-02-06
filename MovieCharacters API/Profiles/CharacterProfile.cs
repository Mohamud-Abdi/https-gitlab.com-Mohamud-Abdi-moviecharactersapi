

using AutoMapper;
using Movie_Characters_API.Models.Domain;
using Movie_Characters_API.Models.DTOs.Character;
using System.Linq;

namespace Movie_Characters_API.Profiles
{

    public class CharacterProfile : Profile

    {
        public CharacterProfile()
        {
            // Character <->CharacterCreateDtO
            CreateMap<Character, CharacterCreateDTO>()
                    .ReverseMap();
            // Character <->CharacterReadDtO
            CreateMap<Character, CharacterReadDTO>()
                      .ForMember(cdto => cdto.Movies, opt => opt
                      .MapFrom(c => c.Movies.Select(m => m.Id).ToArray()))
                      .ReverseMap();

            // Character <->CharacterUpdateDtO
            CreateMap<Character, CharacterUpdateDTO>()
                    .ReverseMap();
        }
    }
}
