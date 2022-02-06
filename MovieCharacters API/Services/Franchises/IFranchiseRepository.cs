using Movie_Characters_API.Models;
using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Franchises
{
    public interface IFranchiseRepository
    {
        public Task<IEnumerable<Franchise>> GetFranchises();
        public Task<Franchise> GetFranchise(int id);
        public Task PutFranchise(int id, Franchise franchise);
        public Task<Franchise> PostFranchise(Franchise franchise);
        public Task DeleteFranchise(int id);
        public bool FranchiseExists(int id);
        public Task<IEnumerable<Movie>> GetMoviesInFranchise(int id);
        public Task<IEnumerable<Character>> GetCharactersInFranchise(int id);
        public Task UpdateMovieInFranchise(int id, int[] Fid);







    }
}
