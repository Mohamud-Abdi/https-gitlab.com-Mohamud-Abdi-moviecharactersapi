using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Franchises
{
    public class FranchiseRepository : IFranchiseRepository
    {
        private readonly MovieApiDbContext _db;

        public FranchiseRepository(MovieApiDbContext db)
        {
            _db = db;
        }



        public async Task<IEnumerable<Franchise>> GetFranchisesAsync()
        {
            return await _db.Franchises
                    .Include(m => m.Movies)
                    .ToListAsync();

        }
        public async Task DeleteFranchiseAsync(int id)
        {

            var francise = await _db.Franchises.FindAsync(id);
           
            _db.Remove(francise); ;
            await _db.SaveChangesAsync();

        }

        public bool FranchiseExists(int id)
        {
            return _db.Franchises.Any(e => e.Id == id);


        }

        public async Task<Franchise> GetFranchiseAsync(int id)
        {

            var franchise = await _db.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return null;
            }

            return franchise;
        }


        public async Task<Franchise> PostFranchiseAsync(Franchise franchise)
        {
            _db.Franchises.Add(franchise);
            await _db.SaveChangesAsync();
            return franchise;
        }

        public async Task PutFranchiseAsync(int id, Franchise franchise)
        {
             _db.Entry(franchise).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesInFranchiseAsync(int id)
        {
            var franchise = await _db.Franchises
                            .Include(m => m.Movies)
                            .ThenInclude(c => c.Characters)
                            .FirstOrDefaultAsync(f => f.Id == id);
            if (franchise == null)
                return null;

            var movies = _db.Movies.Where(f => f.Id == franchise.Id);

            return  await movies.ToListAsync();


        }
        public async Task<IEnumerable<Character>> GetCharactersInFranchiseAsync(int id)
        {
            var franchise = await _db.Franchises
                            .Include(m => m.Movies)
                            .ThenInclude(c => c.Characters)
                            .FirstOrDefaultAsync(f => f.Id == id);


            if (franchise == null)
                return null;
            var characters = franchise.Movies.SelectMany(c => c.Characters).Distinct();

            return  characters;

        }

        public async Task UpdateMovieInFranchiseAsync(int id, int[] Mids)
        {
            var franchise = await _db.Franchises
                             .Include(m => m.Movies)
                             .FirstOrDefaultAsync(i => i.Id == id);

            if (franchise == null)
            {
                return ;
            }


            var movieIds = Mids.Distinct();
            var movies =  franchise.Movies.Where(movie => movieIds.Any(e => movie.Id == id)).ToList();

            franchise.Movies = movies;


        }
    }
}
