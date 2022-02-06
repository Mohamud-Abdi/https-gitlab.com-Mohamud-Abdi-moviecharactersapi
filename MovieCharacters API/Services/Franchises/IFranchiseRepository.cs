using Movie_Characters_API.Models;
using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Franchises
{
    public interface IFranchiseRepository
    {
        public Task<IEnumerable<Franchise>> GetFranchisesAsync();
        public Task<Franchise> GetFranchiseAsync(int id);
        public Task PutFranchiseAsync(int id, Franchise franchise);
        public Task<Franchise> PostFranchiseAsync(Franchise franchise);
        public Task DeleteFranchiseAsync(int id);
        public bool FranchiseExists(int id);
        public Task<IEnumerable<Movie>> GetMoviesInFranchiseAsync(int id);
        public Task<IEnumerable<Character>> GetCharactersInFranchiseAsync(int id);
        public Task UpdateMovieInFranchiseAsync(int id, int[] Fid);







    }
}
