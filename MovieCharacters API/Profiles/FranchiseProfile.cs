
using AutoMapper;
using Movie_Characters_API.Models.Domain;
using Movie_Characters_API.Models.DTOs.Franchise;
using System.Linq;

namespace Movie_Characters_API.Profiles
{
    public class FranchiseProfile: Profile
    {
        public FranchiseProfile()
        {
            // Franchise<->FranchiseCreateDTO
            CreateMap<Franchise, FranchiseCreateDTO>()
                    .ReverseMap();
            // Franchise <->FranchiseREadDTO
            CreateMap<Franchise, FranchiseReadDTO>()
                    
                    .ForMember(cdto => cdto.Movies, opt => opt
                    .MapFrom(c => c.Movies.Select(m => m.Id).ToArray()))
                    .ReverseMap();


            // Franchise <->FranchiseUpdateDTO
            CreateMap<Franchise, FranchiseUpdateDTo>()
                        .ReverseMap();
        }
       
    }
}
