using AutoMapper;
using Movie_Characters_API.Models.Domain;
using Movie_Characters_API.Models.DTOs.Movies;
using System.Linq;

namespace Movie_Characters_API.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {

            // Movie<->MovieCreateDtO
            CreateMap<Movie, MovieCreateDTO>()               
                    .ReverseMap();
            // Movie <->MovieReadDtO
            CreateMap<Movie, MovieReadDTO>()
                      .ForMember(cdto => cdto.Characters, opt => opt
                      .MapFrom(c => c.Characters.Select(m => m.Id).ToArray()))
                      .ReverseMap();
            // Movie <->MovieUpdateDtO
            CreateMap<Movie, MovieUpdateDTO>().ReverseMap();

        }
    }
}
